namespace Training.Components.Pages.LoginedPages.AdminPages;

public class AddMyUserComponentModel: BaseAddModel<MyUser>
{
    //protected override async Task OnParametersSetAsync()
    //{
    //    if (EditedEntityId > 0)
    //    {
    //        LoadEntityOperationResponce = await DbRepository.GetFirstOrDefault<MyUser>(x=>x.Id==EditedEntityId);
    //        MainEntity = LoadEntityOperationResponce.Data;
    //    }
    //    else
    //    {
    //        MainEntity = new();
    //    }
    //    await base.OnParametersSetAsync();
    //}

    protected override void GoAfterSave()
    {
        NavigationManager.NavigateTo(ProjectRouters.registeredUsersHref);
    }

    protected override void OnCancelClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.registeredUsersHref);
    }
}
