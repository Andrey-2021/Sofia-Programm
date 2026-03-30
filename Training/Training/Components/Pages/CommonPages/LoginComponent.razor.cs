using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
namespace Training.Components.Pages.CommonPages;

public class LoginComponentModel : ComponentBase
{
	[Inject] NavigationManager NavigationManager { get; set; } = default!;
	[Inject] protected MyUserOperationService MyUserOperationService { get; set; } = default!;

	[CascadingParameter]
	private Task<AuthenticationState>? AuthenticationState { get; set; }

	protected UserLoginModel LoginModel { get; set; } = null!;
	protected string? Message { get; set; }
	protected bool IsInit { get; set; } = false;
	protected EditContext editContext = null!;
	protected bool IsBusy{ get; private set; } = false;

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (firstRender)
		{
			await MyUserOperationService.InitUserAsync();
			if (!await CheckAuthenticationAsync())
			{
				OnClearelClick();
				IsInit = true;
				StateHasChanged();
			}
		}
	}

	protected async Task<bool> CheckAuthenticationAsync()
	{
		if (AuthenticationState is not null)
		{
			var authState = await AuthenticationState;
			var user = authState?.User;

			if (user?.Identity is not null && user.Identity.IsAuthenticated)
			{
				NavigationManager.NavigateTo(ProjectRouters.loginedHomePageHref);
				return true;
			}
		}
		//CreateNewLoginModel();
		return false;
	}

	/// <summary>
	/// Очистить поля
	/// </summary>
	protected void OnClearelClick()
	{
		LoginModel = new();
		editContext = new EditContext(LoginModel);
	}

	/// <summary>
	/// Вход
	/// </summary>
	protected async Task OnLoginClick()
	{
		var loginResult = await MyUserOperationService.LoginAsync(LoginModel);

		if (loginResult.ex != null)
		{
			if (string.IsNullOrEmpty(loginResult.messageForUser))
				Message = "Ошибка при проверке данных. Повторите попытку или попробуйте войти позже.";
			else
				Message = loginResult.messageForUser;
#if DEBUG
			Message = Message
				+ Environment.NewLine + "Exception:" + loginResult.ex.Message
				+ (loginResult.ex.InnerException == null ? "" : Environment.NewLine + " InnerException:" + loginResult.ex.InnerException.Message);
#endif
			return;
		}

		if (loginResult.isLogin == false && !string.IsNullOrEmpty(loginResult.messageForUser))
		{
			Message = loginResult.messageForUser;
			return;
		}

		if (loginResult.isLogin == true)
			NavigationManager.NavigateTo(ProjectRouters.loginedHomePageHref);//todo заменил на свою страницу, не проверил
		else
			Message = "Неизвестная ошибка. Пожалуйста обновите страницу и повторите вход.";
	}

	/// <summary>
	/// Отмена
	/// </summary>
	protected void OnCancelClick()
	{
		//throw new Exception();
		//NavigationManager.NavigateTo(ProjectRouters.homeHref);
        NavigationManager.NavigateTo(ProjectRouters.homeHref);
    }
}
