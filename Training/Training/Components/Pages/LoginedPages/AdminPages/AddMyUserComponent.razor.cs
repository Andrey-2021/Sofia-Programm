namespace Training.Components.Pages.LoginedPages.AdminPages;

public class AddMyUserComponentModel: BaseAddModel<MyUser>
{
    protected override async Task OnParametersSetAsync()
    {
        //MainEntity = new();
        //return base.OnParametersSetAsync();

        if (EditedEntityId > 0)
        {
            LoadEntityOperationResponce = await DbRepository.GetFirstOrDefault<MyUser>(x=>x.Id==EditedEntityId);
            MainEntity = LoadEntityOperationResponce.Data;
        }
        else
        {
            MainEntity = new();
        }
        await base.OnParametersSetAsync();
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
