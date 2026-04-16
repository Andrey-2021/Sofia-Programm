namespace Entities.DTO;

/// <summary>
/// Статистическая информация о курсе
/// </summary>
public class TrainingCourseInfoDto
{
    public TrainingCourse? TrainingCourse { get; private set; }

    /// <summary>
    /// Количество подписчиков
    /// </summary>
    public int SubscribersNumber { get; private set; }

    /// <summary>
    /// Количество карточек
    /// </summary>
    public int CardsNumber => TrainingCourse?.CourseQestions?.Count??0;

    /// <summary>
    /// Владелец курса
    /// </summary>
    public MyUser? MyUser => TrainingCourse?.MyUser;

    /// <summary>
    /// Средний результат в процентах
    /// </summary>
    [NotMapped]
    public decimal PercentageResult { get; private set; }


    public TrainingCourseInfoDto(TrainingCourse? trainingCourse, int subscribersNumber, decimal percentageResult)
    {
        TrainingCourse = trainingCourse;
        SubscribersNumber = subscribersNumber;
        PercentageResult = percentageResult;
    }
}
