namespace Entities;

/// <summary>
/// Ответ на вопрос курса
/// </summary>
public class WrongRussianWordAnswer
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Неправильный ответ на вопрос
    /// </summary>
    [Required(ErrorMessage = "Введите слово")]
    [StringLength(LengthConstants.answerMaxLength, MinimumLength = LengthConstants.answerMinLength, ErrorMessage = "Длина должна быть не менее {2} и не более {1} символов")]
    [Comment("Слово (перевод)")]
    [DisplayName("Слово (перевод)")]
    public string Answer { get; set; } = string.Empty;

    /// <summary>
    /// Id вопроса
    /// </summary>
    /// <remarks>
	/// Внешний ключ. Связь Один-Ко-Многим
	///</remarks>
    [Required(ErrorMessage = "Обязательно должн быть выбран вопрос")]
    //[Range(1, int.MaxValue, ErrorMessage = "Не выбрана вопрос")]
    [Comment("Id вопроса")]
    [DisplayName("Id вопроса")]
    public int CourseQestionId { get; set; }

    /// <summary>
    /// Вопрос курса
    /// </summary>
	/// <remarks>
	/// Навигационное свойство. Связь один-ко-многим
	///</remarks>
    [Comment("Вопрос курса")]
    [DisplayName("Вопрос курса")]
    public CourseQestion? CourseQestion { get; set; }

    public WrongRussianWordAnswer()
    { }

    public WrongRussianWordAnswer(string answer)
    {
        Answer = answer;
    }

}
