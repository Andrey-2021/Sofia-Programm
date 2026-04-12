namespace Entities;

/// <summary>
/// Базовый класс для возврата результата операции с БД
/// </summary>
public abstract class BaseOperationResponce
{
	/// <summary>
	/// Флаг показывает результат выполнения операции. true- операция выполнена успешно. false - ошибка при выполнении операции.
	/// </summary>
	public bool IsSuccessfullOperation { get; protected set; } = false;

	/// <summary>
	/// Исключение возникшее при выполнении операции
	/// </summary>
	public Exception? Exception { get; protected set; }

	/// <summary>
	/// Сообщение отображаемое пользователю
	/// </summary>
	public string? MessageForUser { get; protected set; }

	/// <summary>
	/// Сообщение для отладки (из Exception)
	/// </summary>
	public string? ExceptionsMessage => (Exception == null ? null : "Exception: " + Exception?.Message)
										+ (Exception?.InnerException == null ? null : Environment.NewLine + "InnerException: " + Exception?.InnerException?.Message);
}
