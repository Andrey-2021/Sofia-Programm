namespace Training.Components.Pages.LoginedPages.AdminPages;

public class CreateDbPageModel: BaseModel
{
    /// <summary>
    /// Сообщение после создания новой БД
    /// </summary>
    protected string? CreteDbMassage { get; set; }
    
    /// <summary>
    /// Сообщение после записи начальных данных в БД
    /// </summary>
    protected string? SaveDbMassage { get; set; }

    /// <summary>
    /// Результат выполнения операции создания БД
    /// </summary>
    protected  OperationResponce<bool>? CreateNewDbResponce{ get; set; }

    /// <summary>
    /// Результат выполнения операции записи начальных данных в БД
    /// </summary>
    protected OperationResponce<bool>? SaveDataToDbResponce { get; set; }

    /// <summary>
	/// Создать новую БД
	/// </summary>
    protected async Task CretaeNewDb()
    {
        CreateNewDbResponce = null;
        SaveDataToDbResponce = null;
        CreteDbMassage = null;
        SaveDbMassage = null;

        
        CreateNewDbResponce = await DbRepository.CreateNewDbAsync();
        
        if (!CreateNewDbResponce.IsSuccessfullOperation) //если ошибка
            CreteDbMassage="Ошибка при создании новой БД. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + CreateNewDbResponce.Exception?.Message
                + Environment.NewLine + "InnerException:" + CreateNewDbResponce.Exception?.InnerException?.Message;
        else
            CreteDbMassage = "БД создана";
    }

    /// <summary>
	/// Записать данные в БД
	/// </summary>
    protected async Task SaveDataInDb()
    {
        SaveDataToDbResponce = await DbRepository.SaveInitDataInDbAsync();
        
        if (!SaveDataToDbResponce.IsSuccessfullOperation) //если ошибка
            SaveDbMassage = "Ошибка при записи данных а БД. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + SaveDataToDbResponce.Exception?.Message
                + Environment.NewLine + "InnerException:" + SaveDataToDbResponce.Exception?.InnerException?.Message;
        else
            SaveDbMassage = "Данные записаны в БД";
    }
}
