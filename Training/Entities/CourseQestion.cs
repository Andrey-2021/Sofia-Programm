using Entities.Validations;
namespace Entities;

/// <summary>
/// Вопрос курса
/// </summary>
[Comment("Вопрос курса")]
public class CourseQestion
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Кандзи (иероглиф)
    /// </summary>
    [CheckJapanWords()]
    [MaxLength(LengthConstants.jupanWordMaxLength, ErrorMessage = "Длина должна быть не более {1} символов")]
    [Comment("Кандзи (иероглиф)")]
    [DisplayName("Кандзи (иероглиф)")]
    public string? KanjiWord { get; set; }

    /// <summary>
    /// Хирагана (слоговая азбука, 46 знаков)
    /// </summary>
    [CheckJapanWords()]
    [MaxLength(LengthConstants.jupanWordMaxLength, ErrorMessage = "Длина должна быть не более {1} символов")]
    [Comment("Хирагана)")]
    [DisplayName("Хирагана")]
    public string? HiraganaWord { get; set; }

    /// <summary>
    /// Катакана (слоговая азбука, 46 знаков)
    /// </summary>
    [CheckJapanWords()]
    [MaxLength(LengthConstants.jupanWordMaxLength, ErrorMessage = "Длина должна быть не более {1} символов")]
    [Comment("Катакана")]
    [DisplayName("Катакана")]
    public string? KatakanaWord { get; set; }

    /// <summary>
    /// Русское слово
    /// </summary>
    [Required(ErrorMessage = "Введите слово")]
    [StringLength(LengthConstants.russianWordMaxLength, MinimumLength = LengthConstants.russianWordMinLength, ErrorMessage = "Длина слова должна быть не менее {2} и не более {1} символов")]
    [Comment("Слово")]
    [DisplayName("Слово")]
    public string Word { get; set; } = string.Empty;

    /// <summary>
    /// Id учебного курса
    /// </summary>
    /// <remarks>
	/// Внешний ключ. Связь Один-Ко-Многим
	///</remarks>
    [Required(ErrorMessage = "Обязательно должн быть выбран учебный курс")]
    //[Range(1, int.MaxValue, ErrorMessage = "Не выбрана учебный курс")]
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
    /// Список ошибочных ответов
    /// </summary>
    /// <remarks>
	/// Навигационное свойство. Связь один-ко-многим
	///</remarks>
    [ValidateComplexType]
    public ICollection<WrongWordAnswer>? WrongWordAnswers{ get; set; }

    /// <summary>
    /// Скопировать свойства
    /// </summary>
    /// <param name="courseQestion"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void CopyTo(CourseQestion courseQestion)
    {
        if (courseQestion == null)
            throw new ArgumentNullException(nameof(courseQestion));

        // Копирование простых свойств
        courseQestion.Id = this.Id;
        courseQestion.KanjiWord = this.KanjiWord;
        courseQestion.HiraganaWord = this.HiraganaWord;
        courseQestion.KatakanaWord = this.KatakanaWord;
        courseQestion.Word = this.Word;
        courseQestion.TrainingCourseId = this.TrainingCourseId;
        courseQestion.TrainingCourse = this.TrainingCourse;
        courseQestion.WrongWordAnswers = this.WrongWordAnswers;
    }
}
