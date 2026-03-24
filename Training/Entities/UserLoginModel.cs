namespace Entities;

public class UserLoginModel
{
	[Required(ErrorMessage = "Не ввели логин")] //при null
	//[StringLength(LengthConstants.loginMaxLength, MinimumLength = LengthConstants.loginMinLength, ErrorMessage = "Длина логина должна быть от {2} до {1} символов")]
	//[EmailAddress(ErrorMessage = "Некорректно ввели e-mail")]
	public string? Login { get; set; } = null!;

	[Required(ErrorMessage = "Не ввели пароль")] //при null
	//[StringLength(LengthConstants.passwordMaxLength, MinimumLength = LengthConstants.passwordMinLength, ErrorMessage = "Длина пароля должна быть от {2} до {1} символов")]
	public string? Password { get; set; } = null!;
}
