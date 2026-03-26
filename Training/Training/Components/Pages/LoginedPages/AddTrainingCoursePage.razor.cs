using Training.Components.Pages.Base;
namespace Training.Components.Pages.LoginedPages;

public class AddTrainingCoursePageModel: BaseAddModel<TrainingCourse>
{
    protected override Task OnParametersSetAsync()
    {
        MainEntity = new(MyUser);
        return base.OnParametersSetAsync();
    }
}
