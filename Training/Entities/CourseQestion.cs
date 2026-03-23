namespace Entities;

/// <summary>
/// Вопрос курса
/// </summary>
public class CourseQestion
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Вопрос курса
    /// </summary>
    [Required(ErrorMessage = "Введите вопрос")]
    [StringLength(LengthConstants.qestionMaxLength, MinimumLength = LengthConstants.qestionMinLength, ErrorMessage = "Длина вопроса должна быть не менее {2} и не более {1} символов")]
    [Comment("Вопрос курса")]
    [DisplayName("Вопрос курса")]
    public string Qestion { get; set; } = default!;

    /// <summary>
    /// Id учебного курса
    /// </summary>
    /// <remarks>
	/// Внешний ключ. Связь Один-Ко-Многим
	///</remarks>
    [Required(ErrorMessage = "Обязательно должн быть выбран учебный курс")]
    [Range(1, int.MaxValue, ErrorMessage = "Не выбрана учебный курс")]
    [Comment("Id учебного курса")]
    [DisplayName("Id учебного курса")]
    public int MedicalServiceTypeId { get; set; }

    /// <summary>
    /// Учебный курс
    /// </summary>
	/// <remarks>
	/// Навигационное свойство. Связь один-ко-многим
	///</remarks>
    [Comment("Учебный курс")]
    [DisplayName("Учебный курс")]
    public TrainingCourse? TrainingCourse { get; set; }

    // уровень сложности
}
