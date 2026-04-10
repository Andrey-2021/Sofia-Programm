namespace Training.Components.Pages.CommonPages;

public class NewUserRegistretionPageModel : BaseAddModel<MyUser>
{
    protected override Task OnParametersSetAsync()
    {
        MainEntity = new() { Role = RoleEnum.manager };
        return base.OnParametersSetAsync();
    }

    protected override void GoAfterSave()
    {
        NavigationManager.NavigateTo(ProjectRouters.registeredUsersHref);
    }

    protected void OnCancelClickCommand()
    {
        NavigationManager.NavigateTo(ProjectRouters.registeredUsersHref);
    }
}
