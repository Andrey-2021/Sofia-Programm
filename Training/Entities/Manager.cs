namespace Entities;

/// <summary>
/// Создатель курса
/// </summary>
[Owned]
public class Manager
{
    /// <summary>
	/// Фамилия И.О.
	/// </summary>
	[NotMapped]
    public string? FIO => LastName + " " + FirstName?[0] + "." + MiddleName?[0] + ".";

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required(ErrorMessage = "Введите фамилию")]
    [StringLength(LengthConstants.lastNameMaxLength, MinimumLength = LengthConstants.lastNameMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Фамилия")]
    [DisplayName("Фамилия")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Имя
    /// </summary>
    [Required(ErrorMessage = "Введите имя")]
    [StringLength(LengthConstants.firstNameMaxLength, MinimumLength = LengthConstants.firstNameMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Имя")]
    [DisplayName("Имя")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Отчество
    /// </summary>
    [Required(ErrorMessage = "Введите отчество")]
    [StringLength(LengthConstants.middleNameMaxLength, MinimumLength = LengthConstants.middleNameMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Отчество")]
    [DisplayName("Отчество")]
    public string MiddleName { get; set; } = string.Empty;

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Phone(ErrorMessage = "Неверный формат телефона")]
    [Required(ErrorMessage = "Введите телефон")]
    [StringLength(LengthConstants.phonetMaxLength, MinimumLength = LengthConstants.phonetMinLength, ErrorMessage = "Длина номера телефона должна быть не менее {2} и не более {1} символов")]
    [Comment("Телефон")]
    [DisplayName("Телефон")]
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Электронная почта
    /// </summary>
    [EmailAddress(ErrorMessage = "Неверный формат e-mail")]
    [Required(ErrorMessage = "Введите e-mail")]
    //[MaxLength(LengthConstants.emailMaxLength, ErrorMessage = "Длина e-mail должна быть не более {1} символов")]
    [StringLength(LengthConstants.emailMaxLength, MinimumLength = LengthConstants.emailMinLength, ErrorMessage = "Длина номера e-mail должна быть не менее {2} и не более {1} символов")]
    [Comment("e-mail")]
    [DisplayName("e-mail")]
    public string Email { get; set; } = string.Empty;

    public Manager()
    {
    }

    /// <summary>
    /// Конструктор для инициализации
    /// </summary>
    public Manager(string lastName, string firstName, string middleName,  string phoneNumber, string email)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}
