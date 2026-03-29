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

    public async Task OnViewTrainingCourseClick(TrainingCourse entity)
    {
        NavigationManager.NavigateTo($"{ProjectRouters.viewTrainingCourcePageHref}?{ProjectRouters.queryParametrNameForEditId}={entity.Id}");
    }

    public async Task OnMemorizationTrainingCourseClick(TrainingCourse entity)
    {
        NavigationManager.NavigateTo($"{ProjectRouters.memorizationTrainingCourcePageHref}?{ProjectRouters.queryParametrNameForEditId}={entity.Id}");
    }


    public async Task OnStartTestClick(TrainingCourse entity)
    {
        NavigationManager.NavigateTo($"{ProjectRouters.startTestPageHref}?{ProjectRouters.queryParametrNameForEditId}={entity.Id}");
    }

    public async Task OnEditClick(TrainingCourse entity)
    {

    }
}
