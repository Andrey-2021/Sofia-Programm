namespace Entities;

/// <summary>
/// Данные для входа пользователя
/// </summary>
public class UserLoginModel
{
	[Required(ErrorMessage = "Не ввели логин")] //при null
	public string? Login { get; set; } = null!;

	[Required(ErrorMessage = "Не ввели пароль")] //при null
	public string? Password { get; set; } = null!;
}
