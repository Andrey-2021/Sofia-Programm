using Entities.Enums;
namespace Entities;

/// <summary>
/// Данные вводимые при регистрации пользователя
/// </summary>
public class MyUser :  IHaveId
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    [ValidateComplexType]
    [Required]
    public Manager Manager { get; set; }

    /// <summary>
	/// Токен входа
	/// </summary>
	[MaxLength(600)]
    public string? UserGuid { get; set; }

    /// <summary>
    /// Дата последнего входа на сайт
    /// </summary>
    public DateTime LastOperationDate { get; set; }

    /// <summary>
    /// Login
    /// </summary>
    [Required(ErrorMessage = "Обязательно должна быть введен логин")]
    [StringLength(LengthConstants.loginMaxLength, MinimumLength = LengthConstants.loginMinLength, ErrorMessage = "Длина логина должна быть не менее {2} и не более {1} символов")]
    [Comment("Логин")]
    [DisplayName("Логин")]
    public string Login { get; set; }

	/// <summary>
	/// Пароль
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть введен пароль")]
    [StringLength(LengthConstants.passwordMaxLength, MinimumLength = LengthConstants.passwordMinLength, ErrorMessage = "Длина пароля должна быть не менее {2} и не более {1} символов")]
    [Comment("Пароль")]
    [DisplayName("Пароль")]
    public string Password { get; set; }

	/// <summary>
	/// Повторный пароль
	/// </summary>
	[NotMapped]
	[Compare("Password", ErrorMessage ="Пароли не совпадают ")]
    [Comment("Повторный пароль")]
    [DisplayName("Повторный пароль")]
    public string? ConfirmedPassword { get; set; }

	/// <summary>
	/// Роль
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть указана роль")]
	[Comment("Роль")]
    [DisplayName("Роль")]
    public RoleEnum? Role { get; set; }

    /// <summary>
	/// Время прекращения действия токена
	/// </summary>
	public DateTime ExpiredAt { get; set; }

    /// <summary>
    /// Счётчик попыток входа
    /// </summary>
    public int PasswordInputCount { get; set; } = 0;

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public MyUser() 
    {
        Manager = new();
    }

    public MyUser(string? guid, int hours)
    {
        UserGuid = guid;
        ExpiredAt = DateTime.Now.AddHours(hours);
        LastOperationDate = DateTime.Now;
    }

    /// <summary>
    /// Конструктор с инициализацией.
    /// </summary>
    public MyUser(string login, string password, RoleEnum role, Manager manager)
    {
        Login = login;
		Password = password;
		Role = role;
        Manager = manager;
    }

    public void ClearForLogout()
    {
        UserGuid = null;
        LastOperationDate = DateTime.Now;
        ExpiredAt = DateTime.Now;
        PasswordInputCount = 0;
    }
}
