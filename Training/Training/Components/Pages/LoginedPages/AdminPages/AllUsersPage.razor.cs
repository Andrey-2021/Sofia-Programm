namespace Training.Components.Pages.LoginedPages.AdminPages;

public class AllUsersPageModel : BaseModel
{
    [Inject]
    protected IServiceProvider ServiceProvider { get; set; } = default!;

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    protected string? ErrorMassage { get; set; }

    public IEnumerable<MyUser>? Entities { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        IsBusy = true;
        var repository = ServiceProvider.GetRequiredService<DbRepository>();
        var result = await repository.GetEntitiesAsync<MyUser>();
        Entities = result.data;

        if (result.ex is null)
        {
            ErrorMassage = null;
        }
        else
        {
            ErrorMassage = "Ошибка при чтении данных. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + result.ex?.Message
                + Environment.NewLine + "InnerException:" + result.ex?.InnerException?.Message;
        }
        IsBusy = false;
    }


    /// <summary>
    /// Редактировать пользователч
    /// </summary>
    public async Task OnEditClick(MyUser entity)
    {
        //_goToUrlService.GoToUrl($"{ProjectRouters.addMyUserHref}?{ParametersNames.queryParametrNameForEditId}={entity.Id}");
    }

    /// <summary>
    /// Удалить пользователя
    /// </summary>
    public async Task OnDeleteUserClick(MyUser entity)
    {
        //await OnForeveDelWithQuestionCommandAsync(entity, $"Удалить пользователя {entity.Manager.Fio}?");
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
    public void OnExitClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.loginedHomePageHref);
    }
}

