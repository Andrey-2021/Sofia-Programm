namespace Training.Components.Pages.Components;

public class ShowAllTrainingCoursesComponentMode:ComponentBase
{
    [Parameter]
    public IEnumerable<TrainingCourse>? TrainingCourses { get; set; }

    [Parameter]
    public MyUser? MyUser { get; set; } = default!;

    /// <summary>
    /// true- это мои личные курсы, false - кырсы других пользователей, которые я выбрал
    /// </summary>
    [Parameter]
    public bool IsMyTrainingCourses { get; set; } 


    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

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
        NavigationManager.NavigateTo($"{ProjectRouters.addTrainingCoursePageHref}?{ProjectRouters.queryParametrNameForEditId}={entity.Id}");
    }

    public async Task OnDeleteClick(TrainingCourse entity)
    {

    }
}
