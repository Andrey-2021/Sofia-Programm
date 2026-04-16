namespace Entities;

/// <summary>
/// Выбранный мною чужой курс
/// </summary>
[Comment("Выбранный мною чужой курс")]
public class SelectedOtherPeopleCourse
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Мой Id
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
    /// Я
    /// </summary>
	/// <remarks>
	/// Навигационное свойство. Связь один-ко-многим
	///</remarks>
    [Comment("Владелец курса")]
    [DisplayName("Владелец курса")]
    public MyUser? MyUser { get; set; }

    /// <summary>
    /// Id учебного курса
    /// </summary>
    /// <remarks>
	/// Внешний ключ. Связь Один-Ко-Многим
	///</remarks>
    //[Required(ErrorMessage = "Обязательно должн быть выбран учебный курс")]
    //[Range(1, int.MaxValue, ErrorMessage = "Не выбрана учебный курс")]
    [Comment("Id учебного курса")]
    [DisplayName("Id учебного курса")]
    public int? TrainingCourseId { get; set; }

    /// <summary>
    /// Учебный курс
    /// </summary>
	/// <remarks>
	/// Навигационное свойство. Связь один-ко-многим
	///</remarks>
    [Comment("Учебный курс")]
    [DisplayName("Учебный курс")]
    public TrainingCourse? TrainingCourse { get; set; }

}
