namespace Training.Components.Pages.LoginedPages;

public class LoginedHomePageModel:ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
    [Inject] protected MyUserOperationService MyUserOperationService { get; set; } = default!;

    /// <summary>
    /// Выход
    /// </summary>
    protected async Task OnLogoutClick()
    {
        await MyUserOperationService.LogoutAsync();
        NavigationManager.NavigateTo(ProjectRouters.homeHref);
    }
}
