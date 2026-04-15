namespace Training.Components.Pages.LoginedPages.AdminPages;

public class AllUsersPageModel : BaseShowAllDataModel<MyUser>
{
    //[Inject]
    //protected IServiceProvider ServiceProvider { get; set; } = default!;

    //protected OperationResponce<MyUser>? DelOperationResponce { get; set; }
    //protected OperationResponce<IEnumerable<MyUser>?>? ReadEntitiesOperationResponce { get; set; }
    //protected IEnumerable<MyUser>? Entities { get; set; }

    /// <summary>
    /// Добавить пользователя
    /// </summary>
    public void OnAddUserClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.addMyUserHref);
    }

    /// <summary>
    /// Редактировать пользователч
    /// </summary>
    public async Task OnEditClick(MyUser entity)
    {
        NavigationManager.NavigateTo($"{ProjectRouters.addMyUserHref}?{ProjectRouters.queryParametrNameForEditId}={entity.Id}");
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
}

