namespace Training.Components.Pages.LoginedPages.AdminPages;

public class AddMyUserComponentModel: BaseAddModel<MyUser>
{
    protected override Task OnParametersSetAsync()
    {
        MainEntity = new();
        return base.OnParametersSetAsync();
    }

    protected override void GoAfterSave()
    {
        NavigationManager.NavigateTo(ProjectRouters.registeredUsersHref);
    }

    protected  void OnCancelClickCommand()
    {
        NavigationManager.NavigateTo(ProjectRouters.registeredUsersHref);
    }
}
