using Entities.DTO;
namespace Entities;

/// <summary>
/// Пройденные тесты
/// </summary>
[Comment("Пройденные тесты")]
public class CompletedTest:IHaveId
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

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

    /// <summary>
    /// Id прошедшего курс
    /// </summary>
    /// <remarks>
	/// Внешний ключ. Связь Один-Ко-Многим
	///</remarks>
    //[Required(ErrorMessage = "Обязательно должн быть выбран владелец курса")]
    //[Range(1, int.MaxValue, ErrorMessage = "Не выбрана владелец курса")]
    [Comment("Id владелеца курса")]
    [DisplayName("Id владелеца курса")]
    public int MyUserId { get; set; }

    /// <summary>
    /// Пользователь, прошедший этот курс
    /// </summary>
	/// <remarks>
	/// Навигационное свойство. Связь один-ко-многим
	///</remarks>
    [Comment("Владелец курса")]
    [DisplayName("Владелец курса")]
    public MyUser? MyUser { get; set; }

    /// <summary>
    /// Дата прохождения курса
    /// </summary>
    [Required(ErrorMessage = "Введите дату создания курса")]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "1/1/2000", "1/1/2035", ErrorMessage = "Дата заключения вне допустимого диапазона")]
    [Comment("Дата создания курса")]
    [DisplayName("Дата создания курса")]
    public DateTime ContractDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Количество вопросов в курсе
    /// </summary>
    [Comment("Количество вопросов в курсе")]
    [DisplayName("Количество вопросов в курсе")]
    public int QestionNumber { get; set; }

    /// <summary>
    /// Количество правильных ответов
    /// </summary>
    [Comment("Количество правильных ответов")]
    [DisplayName("Количество правильных ответов")]
    public int CountCorrectAnswers { get; set; }

    /// <summary>
    /// Результат в процентах
    /// </summary>
    [NotMapped]
    public decimal PercentageResult => Math.Round(100.0m * CountCorrectAnswers / (QestionNumber == 0 ? 1 : QestionNumber), 2);

    /// <summary>
    /// Затраченное время на прохождение курса
    /// </summary>
    public TimeSpan Interval { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public CompletedTest()
    { 
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public CompletedTest(MyUser myUser, TestHelper testHelper)
    {
        MyUserId = myUser.Id;
        TrainingCourseId = testHelper.MainEntity!.Id;
        QestionNumber = testHelper.QestionNumber;
        CountCorrectAnswers = testHelper.CountCorrectAnswers;
        Interval= testHelper.Interval;
    }
}
