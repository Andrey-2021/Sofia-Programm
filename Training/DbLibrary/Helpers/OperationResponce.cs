namespace DbLibrary.Helpers;

/// <summary>
/// Результат выполнения операции
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class OperationResponce<TEntity>: BaseOperationResponce
{
    /// <summary>
    /// Данные
    /// </summary>
    public TEntity? Data { get; protected set; } = default;
    
	/// <summary>
	/// Операция с ошибкой
	/// </summary>
	/// <param name="messageForUser"></param>
	/// <param name="ex"></param>
	/// <returns></returns>
	public static OperationResponce<TEntity> SetExceptionOperation(string? messageForUser, Exception? ex = null)
    {
        return new OperationResponce<TEntity>()
        {
            IsSuccessfullOperation = false,
            MessageForUser = messageForUser,
            Exception = ex
        };
    }

    /// <summary>
    /// Успешная операция
    /// </summary>
    /// <param name="data"></param>
    /// <param name="messageForUser"></param>
    /// <returns></returns>
    public static OperationResponce<TEntity> SetSuccessfullOperation(TEntity data, string? messageForUser = null)
    {
        return new OperationResponce<TEntity>()
        {
            IsSuccessfullOperation = true,
            MessageForUser = messageForUser,
            Data = data
        };
    }
}
