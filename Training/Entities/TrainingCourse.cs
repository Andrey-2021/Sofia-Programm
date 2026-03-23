namespace Entities;

/// <summary>
/// Учебный курс
/// </summary>
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
    /// Дата создания курса
    /// </summary>
    [Required(ErrorMessage = "Введите дату создания курса")]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "1/1/2000", "1/1/2035", ErrorMessage = "Дата заключения вне допустимого диапазона")]
    [Comment("Дата создания курса")]
    [DisplayName("Дата создания курса")]

    public DateTime ContractDate { get; set; } = DateTime.Now;
}
