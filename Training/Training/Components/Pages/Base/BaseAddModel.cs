namespace Training.Components.Pages.Base;

public class BaseAddModel<TEntity> : BaseModel
    where TEntity : class, IHaveId, new()
{
    /// <summary>
    /// Результат выполнения операции чтения
    /// </summary>
    protected OperationResponce<TEntity?>? LoadEntityOperationResponce { get; set; }

    /// <summary>
    /// Результат выполнения операции записи
    /// </summary>
    protected OperationResponce<TEntity>? SaveEntityOperationResponce { get;  set; }

    /// <summary>
    /// EditContext для EditForm с MainEntity
    /// </summary>
    protected EditContext? EditContext { get;  set; }

    /// <summary>
    /// Объект
    /// </summary>
    protected TEntity? MainEntity { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (EditedEntityId > 0)
        {
            LoadEntityOperationResponce = await DbRepository.GetFirstOrDefault<TEntity>(x => x.Id == EditedEntityId);
            MainEntity = LoadEntityOperationResponce.Data;
        }
        else
        {
            MainEntity = new();
        }

        EditContext = ConfigEditContext(MainEntity, EditContext);
        await base.OnParametersSetAsync();
    }
    

    /// <summary>
	/// Создание EditContext для основного объекта (MainEntity)
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="editContext"></param>
	protected EditContext? ConfigEditContext(TEntity? entity, EditContext? editContext)
    {
        if (editContext is not null)
        {
            editContext.OnFieldChanged -= FieldChanged;
            editContext.OnValidationRequested -= HandleValidationRequested;
        }

        if (entity == null)
        {
            editContext = null;
            return null; ;
        }

        editContext = new EditContext(entity);
        editContext.OnFieldChanged += FieldChanged;
        editContext.OnValidationRequested += HandleValidationRequested;
        return editContext;
    }

    private void HandleValidationRequested(object? sender, ValidationRequestedEventArgs args)
    {
        //EditContext?.NotifyValidationStateChanged();
        //OnPropertyChanged();
    }

    /// <summary>
	/// Обработка изменений (в input-элементе формы)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	protected void FieldChanged(object? sender, FieldChangedEventArgs args)
    {
    }

    /// <summary>
    /// Сохранить валидные данные в БД
    /// </summary>
    /// <returns></returns>
    protected virtual async Task OnSaveValidEntityClick()
    {
        if (MainEntity is IDelSpaces delInfo)
            delInfo.DelSpaces();

        IsBusy = true;
        SaveEntityOperationResponce = await DbRepository.UpdateEntity(MainEntity!);
        IsBusy = false;
        if (SaveEntityOperationResponce.IsSuccessfullOperation)
            GoAfterSave();
    }

    /// <summary>
    /// Переход после операции сохранения
    /// </summary>
    protected virtual void GoAfterSave()
    {
        NavigationManager.NavigateTo(ProjectRouters.loginedHomePageHref);
    }

    /// <summary>
    /// Нажата кнопка "отмена"
    /// </summary>
    protected virtual void OnCancelClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.loginedHomePageHref);
    }
}

