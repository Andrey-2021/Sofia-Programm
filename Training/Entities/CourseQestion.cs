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
    /// Кандзи (иероглифы)
    /// </summary>
    [Required(ErrorMessage = "Введите Кандзи")]
    [StringLength(LengthConstants.qestionMaxLength, MinimumLength = LengthConstants.qestionMinLength, ErrorMessage = "Длина кандзи должна быть не менее {2} и не более {1} символов")]
    [Comment("Вопрос курса")]
    [DisplayName("Вопрос курса")]
    public string KanjiWord { get; set; } = default!;

    /// <summary>
    /// Хирагана (слоговая азбука, 46 знаков)
    /// </summary>
    public string? HiraganaWord { get; set; }

    /// <summary>
    /// Катакана (слоговая азбука, 46 знаков)
    /// </summary>
    public string? KatakanaWord { get; set; }

    /// <summary>
    /// Русское слово
    /// </summary>
    public string RussianWord { get; set; } = string.Empty;

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
    public int TrainingCourseId { get; set; }

    /// <summary>
    /// Учебный курс
    /// </summary>
	/// <remarks>
	/// Навигационное свойство. Связь один-ко-многим
	///</remarks>
    [Comment("Учебный курс")]
    [DisplayName("Учебный курс")]
    public TrainingCourse? TrainingCourse { get; set; }

    /// <summary>
    /// Уровень сложности вопроса
    /// </summary>
    [Range(0, LengthConstants.qestionDifficultyLevelLength, ErrorMessage = "Не выбрана уровень сложности")]
    [Comment("Уровень сложности вопроса")]
    [DisplayName("Уровень сложности вопроса")]
    public int DifficultyLevel { get; set; }

    public ICollection<WrongRussianWordAnswer>? WrongRussianWordAnswers{ get; set; }
}
