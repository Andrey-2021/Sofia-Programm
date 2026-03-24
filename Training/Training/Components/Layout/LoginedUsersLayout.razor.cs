using Microsoft.AspNetCore.Components.Authorization;

namespace Training.Components.Layout;

public class LoginedUsersLayoutModel : LayoutComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
    [Inject] public MyUserOperationService MyUserOperationService { get; protected set; } = default!;

    protected bool sidebarExpanded = false;
    //private bool isFirst = true;
    protected bool IsInit { get; set; } = false;

    [CascadingParameter] private Task<AuthenticationState>? AuthenticationState { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (MyUserOperationService.MyUser == null) //При переходе на новую вкладку браузера надо по новому прочитать Пользователя/MyUser
            {
                await MyUserOperationService.InitUserAsync();
            }

            IsInit = await CheckAuthenticationAsync();
            //IsInit = true;
            StateHasChanged();
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
                //NavigationManager.NavigateTo(ProjectRouters.loginedHref);
                return true;
            }
            else //неизвестный пользователь
            {
                NavigationManager.NavigateTo(ProjectRouters.homeHref);
            }
        }
        return false;
    }

    /// <summary>
    /// Выход
    /// </summary>
    protected async Task Logout()
    {
        await MyUserOperationService.LogoutAsync();
        NavigationManager.NavigateTo(ProjectRouters.homeHref);
    }

    protected void OnRadzenSidebarToggleClick()
    {
        //throw new Exception();
        sidebarExpanded = !sidebarExpanded;
    }
}
