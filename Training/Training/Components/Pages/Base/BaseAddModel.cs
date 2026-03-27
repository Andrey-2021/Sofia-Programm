using DbLibrary.Helpers;
using Entities.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
namespace Training.Components.Pages.Base;

public class BaseAddModel<TEntity> : BaseModel
    where TEntity : class, new()
{
    /// <summary>
    /// EditContext для EditForm с MainEntity
    /// </summary>
    public EditContext? EditContext { get; protected set; }

    /// <summary>
    /// Объект
    /// </summary>
    public TEntity? MainEntity { get; set; }

    /// <summary>
    /// Результат выполнения операции записи
    /// </summary>
    public OperationResponce<TEntity>? SaveEntityOperationResponce { get; protected set; }

    /// <summary>
    /// Сохранить валидные данные в БД
    /// </summary>
    /// <returns></returns>
    public virtual async Task OnSaveValidEntityClick()
    {
        if (MainEntity is IDelSpaces delInfo)
            delInfo.DelSpaces();

        IsBusy = true;
        SaveEntityOperationResponce = await DbRepository.UpdateEntity(MainEntity!);
        IsBusy = false;
        if(SaveEntityOperationResponce.IsSuccessfullOperation)
            NavigationManager.NavigateTo(ProjectRouters.loginedHomePageHref);
    }

    public virtual void OnCancelClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.loginedHomePageHref);
    }

    protected override Task OnParametersSetAsync()
    {
        EditContext = ConfigEditContext(MainEntity, EditContext);
        return base.OnParametersSetAsync();
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
}

