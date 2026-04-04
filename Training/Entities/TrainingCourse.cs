namespace Entities;

/// <summary>
/// Учебный курс
/// </summary>
[Comment("Учебный курс")]
public class TrainingCourse
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Название курса
    /// </summary>
    [Required(ErrorMessage = "Введите название курса")]
    [StringLength(LengthConstants.trainingCourseNameMaxLength, MinimumLength = LengthConstants.trainingCourseNameMinLength, ErrorMessage = "Длина наименования должна быть не менее {2} и не более {1} символов")]
    [Comment("Название курса")]
    [DisplayName("Название курса")]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Описание курса
    /// </summary>
    [MaxLength(LengthConstants.trainingCourseDescriptionMaxLength, ErrorMessage = "Длина описания должна быть не более {1} символов")]
    [Comment("Описание курса")]
    [DisplayName("Описание курса")]
    public string? Description { get; set; }

    /// <summary>
    /// Продолжительность курса (минут)
    /// </summary>
     [Range(0, (double)LengthConstants.maxDurationHours, ErrorMessage = "Недопустимое значение. Должно быть от {1} до {2}")]
    [Comment("Продолжительность курса (минут)")]
    [DisplayName("Продолжительность курса (минут)")]
    public int DurationHours { get; set; }

    /// <summary>
    /// Дата создания курса
    /// </summary>
    [Required(ErrorMessage = "Введите дату создания курса")]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "1/1/2000", "1/1/2035", ErrorMessage = "Дата заключения вне допустимого диапазона")]
    [Comment("Дата создания курса")]
    [DisplayName("Дата создания курса")]
    public DateTime ContractDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Уровень сложности курса
    /// </summary>
    [Range(0, LengthConstants.courceDifficultyLevelLength, ErrorMessage = "Не введён уровень сложности")]
    [Comment("Уровень сложности курса")]
    [DisplayName("Уровень сложности курса")]
    public int DifficultyLevel { get; set; }

    /// <summary>
    /// Курс виден всем
    /// </summary>
    public bool IsVisableForAll { get; set; } = false;

    /// <summary>
    /// Id владельца курса
    /// </summary>
    /// <remarks>
	/// Внешний ключ. Связь Один-Ко-Многим
	///</remarks>
    [Required(ErrorMessage = "Обязательно должн быть выбран владелец курса")]
    [Range(1, int.MaxValue, ErrorMessage = "Не выбрана владелец курса")]
    [Comment("Id владелеца курса")]
    [DisplayName("Id владелеца курса")]
    public int MyUserId { get; set; }

    /// <summary>
    /// Владелец курса
    /// </summary>
	/// <remarks>
	/// Навигационное свойство. Связь один-ко-многим
	///</remarks>
    [Comment("Владелец курса")]
    [DisplayName("Владелец курса")]
    public MyUser? MyUser { get; set; }

    /// <summary>
    /// Вопросы курса
    /// </summary>
    [ValidateComplexType]
    public IList<CourseQestion>? CourseQestions { get; set; }
    
    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public TrainingCourse()
    { 
    }

    /// <summary>
    /// Конструктор с пареметром
    /// </summary>
    public TrainingCourse(MyUser myUser)
    {
        //MyUser = myUser;
        MyUserId = myUser.Id;
    }
}
