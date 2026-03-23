namespace Training.Components.Pages.AdminPages;

public class CreateDbPageModel: ComponentBase
{
    /// <summary>
	/// Контейнер
	/// </summary>
	[Inject]
    protected IServiceProvider ServiceProvider { get; set; } = default!;

    /// <summary>
    /// Сообщение после создания новой БД
    /// </summary>
    protected string? CreteDbMassage { get; set; }
    
    /// <summary>
    /// Сообщение после записи начальных данных в БД
    /// </summary>
    protected string? SaveDbMassage { get; set; }

    /// <summary>
	/// Создать новую БД
	/// </summary>
    protected async Task CretaeNewDb()
    {
        SaveDbMassage = null;

        var repository = ServiceProvider.GetRequiredService<DbRepository>();
        var result = await repository.CreateNewDbAsync();
        
        if (result.operationResult == false) //если ошибка
            CreteDbMassage="Ошибка при создании новой БД. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + result.ex?.Message
                + Environment.NewLine + "InnerException:" + result.ex?.InnerException?.Message;
        else
            CreteDbMassage = "БД создана";
    }

    /// <summary>
	/// Записать данные в БД
	/// </summary>
    protected async Task SaveDataInDb()
    {
        var repository = ServiceProvider.GetRequiredService<DbRepository>();
        var result = await repository.SaveInitDataInDbAsync();
        
        if (result.operationResult == false) //если ошибка
            SaveDbMassage = "Ошибка при записи данных а БД. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + result.ex?.Message
                + Environment.NewLine + "InnerException:" + result.ex?.InnerException?.Message;
        else
            SaveDbMassage = "Данные записаны в БД";
    }
}
