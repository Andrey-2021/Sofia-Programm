namespace Training.Components.Pages.LoginedPages.AdminPages;

public class AllUsersPageModel : BaseModel
{
    [Inject]
    protected IServiceProvider ServiceProvider { get; set; } = default!;

    protected OperationResponce<MyUser>? DelOperationResponce { get; set; }
    protected OperationResponce<IEnumerable<MyUser>?>? ReadEntitiesOperationResponce { get; set; }
    protected IEnumerable<MyUser>? Entities { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadData();
    }

    private async Task LoadData()
    {
        IsBusy = true;
        ReadEntitiesOperationResponce = await DbRepository.GetEntities<MyUser>();
        Entities = ReadEntitiesOperationResponce.Data;
        IsBusy = false;
        if (ReadEntitiesOperationResponce.IsSuccessfullOperation)
            NotifyUser("Данные прочитаны");
    }

    /// <summary>
    /// Редактировать пользователч
    /// </summary>
    public async Task OnEditClick(MyUser entity)
    {
        NavigationManager.NavigateTo($"{ProjectRouters.addMyUserHref}?{ProjectRouters.queryParametrNameForEditId}={entity.Id}");
    }

    /// <summary>
    /// Удалить пользователя
    /// </summary>
    public async Task OnDeleteUserClick(MyUser entity)
    {
        //await OnForeveDelWithQuestionCommandAsync(entity, $"Удалить пользователя {entity.Manager.Fio}?");
        //DelSelectedOtherPeopleCourseOperationResponce
        DelOperationResponce = await DbRepository.DelEntityAsync<MyUser>(entity);
        if (DelOperationResponce.IsSuccessfullOperation)
            NotifyUser("Данные удалены");
        await LoadData();
    }

    /// <summary>
    /// Восстановить пароль
    /// </summary>
    public async Task OnRestorePasswordClick(MyUser entity)
    {
    }

    /// <summary>
    /// Заблокировать пользователя
    /// </summary>
    public async Task OnUserBlockClick(MyUser entity)
    {

    }

    /// <summary>
    /// Обновить данные
    /// </summary>
    protected async void OnReloadClick(object? obj, EventArgs eventArgs)
    {
        await LoadData();
        //if (grid != null)
        //  await grid.Reload();
    }

    /// <summary>
    /// Добавить пользователя
    /// </summary>
    public void OnAddUserClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.addMyUserHref);
    }

    /// <summary>
    /// Выйти
    /// </summary>
    //public void OnExitClick()
    //{
    //    NavigationManager.NavigateTo(ProjectRouters.loginedHomePageHref);
    //}
}

