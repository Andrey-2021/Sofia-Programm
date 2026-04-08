using Training.Components.Pages.Base;

namespace Training.Components.Pages.LoginedPages;

public class AllTrainingCoursesPageModel: BaseModel
{
    protected IEnumerable<TrainingCourse>? TrainingCourses { get; set; }

    protected OperationResponce<IEnumerable<SelectedOtherPeopleCourse>?> OtherPeoplesCoursesThatIChosenResponce { get; set; } = default!;
    protected IEnumerable<TrainingCourse>? SelectedOtherPeopleCourse { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        var rezult = await DbRepository.GetAllMyTrainingCourse(MyUser);
        TrainingCourses = rezult.data;

        OtherPeoplesCoursesThatIChosenResponce = await DbRepository.GetOtherPeoplesCoursesThatIChosenAsync(MyUser);
        SelectedOtherPeopleCourse = OtherPeoplesCoursesThatIChosenResponce.Data?.Select(x => x.TrainingCourse)?.ToList();
    }

}
