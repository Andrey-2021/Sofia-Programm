namespace Training.Components.Pages.Base;

public class BaseShowAllDataModel<TEntyty>: BaseModel
    where TEntyty:class, IHaveId
{
    /// <summary>
    /// Результат выполнения операции удаления
    /// </summary>
    protected OperationResponce<TEntyty>? DelEntetyOperationResponce { get; set; }
    
    /// <summary>
    /// Результат выполнения операции чтения данных
    /// </summary>
    protected OperationResponce<IEnumerable<TEntyty>?>? LoadEntitiesOperationResponce { get; set; }
    
    /// <summary>
    /// Прочитанные данных
    /// </summary>
    protected IEnumerable<TEntyty>? Entities { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadEntetiesAsync();
    }

    /// <summary>
    /// Загрузка всех данных
    /// </summary>
    /// <returns></returns>
    protected virtual async Task LoadEntetiesAsync()
    {
        IsBusy = true;
        LoadEntitiesOperationResponce = await DbRepository.GetEntities<TEntyty>();
        Entities = LoadEntitiesOperationResponce.Data;
        IsBusy = false;
        if (LoadEntitiesOperationResponce.IsSuccessfullOperation)
            NotifyUser("Данные прочитаны");
    }
    
    /// <summary>
    /// Обновить данные
    /// </summary>
    protected async Task OnReloadClickAsync(object? obj, EventArgs eventArgs)
    {
        await LoadEntetiesAsync();
    }

    /// <summary>
    /// Удалить сущность
    /// </summary>
    public async Task OnDeleteClickAsync(TEntyty entity)
    {
        //await OnForeveDelWithQuestionCommandAsync(entity, $"Удалить пользователя {entity.Manager.Fio}?");
        //DelSelectedOtherPeopleCourseOperationResponce
        DelEntetyOperationResponce = await DbRepository.DelEntityAsync<TEntyty>(entity);
        if (DelEntetyOperationResponce.IsSuccessfullOperation)
            NotifyUser("Данные удалены");
        await LoadEntetiesAsync();
    }


}
