namespace Training.Components.Pages.Components;

public class ShowAllTrainingCoursesComponentMode:ComponentBase
{
    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;
    
    [Parameter]
    public IEnumerable<TrainingCourse>? TrainingCourses { get; set; }

    [Parameter]
    public MyUser? MyUser { get; set; } = default!;

    /// <summary>
    /// true- это мои личные курсы, false - кырсы других пользователей, которые я выбрал
    /// </summary>
    [Parameter]
    public bool IsShowDelButton { get; set; }

    /// <summary>
    /// true- это страница моих курсов, 
    /// false - это страница чужих курсов
    /// </summary>
    [Parameter]
    public bool IsMyTrainingCoursesPage { get; set; } = true;

    /// <summary>
    /// Удалить чужой курс из списка выбранных
    /// </summary>
    [Parameter]
    public EventCallback<TrainingCourse> OnDeleteTrainingCourseCallback { get; set; }

    /// <summary>
    /// Добавить чудой курс
    /// </summary>
    [Parameter]
    public EventCallback<TrainingCourse> OnAddTrainingCourseCallback { get; set; }

    protected TrainingCourse? SelectedTrainingCourse { get; set; }

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

    /// <summary>
    /// Удалить курс из списка чужих выбранных курсов
    /// </summary>
    public async Task OnDeleteClick(TrainingCourse entity)
    {
        await OnDeleteTrainingCourseCallback.InvokeAsync(entity);
    }

    /// <summary>
    /// Добавить чужой курс к себе
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task OnAddTrainingCourseClick(TrainingCourse entity)
    {
        await OnAddTrainingCourseCallback.InvokeAsync(entity);
    }

    /// <summary>
    /// Показать подробную информацию о курсе
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task OnShowInfoTrainingCourseClick(TrainingCourse entity)
    {
        SelectedTrainingCourse = entity;
    }
}
