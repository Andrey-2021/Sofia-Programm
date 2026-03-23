using System;
using System.Collections.Generic;
using System.Text;

namespace Entities;

/// <summary>
/// Ответ на вопрос курса
/// </summary>
public class Answer
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Ответ на вопрос
    /// </summary>
    [Required(ErrorMessage = "Введите ответ")]
    [StringLength(LengthConstants.answerMaxLength, MinimumLength = LengthConstants.answerMinLength, ErrorMessage = "Длина вопроса должна быть не менее {2} и не более {1} символов")]
    [Comment("Ответ на вопрос")]
    [DisplayName("Ответ на вопрос")]
    public string Qestion { get; set; } = default!;

    /// <summary>
    /// Id вопроса
    /// </summary>
    /// <remarks>
	/// Внешний ключ. Связь Один-Ко-Многим
	///</remarks>
    [Required(ErrorMessage = "Обязательно должн быть выбран вопрос")]
    [Range(1, int.MaxValue, ErrorMessage = "Не выбрана вопрос")]
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

}
