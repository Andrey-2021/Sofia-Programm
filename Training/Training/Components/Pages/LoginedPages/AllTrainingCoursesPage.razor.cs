using Radzen;
using Training.Components.Pages.Base;

namespace Training.Components.Pages.LoginedPages;

public class AllTrainingCoursesPageModel: BaseModel
{
    protected IEnumerable<TrainingCourse>? TrainingCourses { get; set; }
    
    protected OperationResponce<IEnumerable<SelectedOtherPeopleCourse>?> OtherPeoplesCoursesThatIChosenResponce { get; set; } = default!;
    protected IEnumerable<TrainingCourse>? OtherPeoplesCoursesThatIChosen { get; set; }

    /// <summary>
    /// Результат операции удаления
    /// </summary>
    protected OperationResponce<SelectedOtherPeopleCourse?>? DelSelectedOtherPeopleCourseOperationResponce { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        var rezult = await DbRepository.GetAllMyTrainingCourse(MyUser);
        TrainingCourses = rezult.data;
        await Load();
    }

    private async Task Load()
    {
        OtherPeoplesCoursesThatIChosenResponce = await DbRepository.GetOtherPeoplesCoursesThatIChosenAsync(MyUser);
        OtherPeoplesCoursesThatIChosen = OtherPeoplesCoursesThatIChosenResponce.Data?.Select(x => x.TrainingCourse!)?.ToList();
    }

    /// <summary>
    /// Удалить курс из списка чужих выбранных курсов
    /// </summary>
    protected async Task DeleteSelectedTrainingCourse(TrainingCourse entity)
    {
        DelSelectedOtherPeopleCourseOperationResponce = await DbRepository.DelSelectedTrainingCourceAsync(MyUser, entity);
        await Load();
    }
}
