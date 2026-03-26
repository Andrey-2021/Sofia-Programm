using Training.Components.Pages.Base;

namespace Training.Components.Pages.LoginedPages;

public class AllTrainingCoursesPageModel: BaseModel
{
    protected IEnumerable<TrainingCourse>? TrainingCourses { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        var rezult = await DbRepository.GetAllMyTrainingCourse(MyUser);
        TrainingCourses = rezult.data;
    }
    
public async Task OnStartTestClick(TrainingCourse entity)
    {
        NavigationManager.NavigateTo(ProjectRouters.startTestPageHref);
    }

    public async Task OnEditClick(TrainingCourse entity)
    {

    }
}
