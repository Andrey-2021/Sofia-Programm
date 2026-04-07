namespace Training.Components.Pages.LoginedPages;

public class MemorizationTrainingCourcePageModel : BaseModel, IDisposable
{
    /// <summary>
    /// Результат выполнения операции чтения
    /// </summary>
    protected OperationResponce<TrainingCourse>? LoadEntityOperationResponce { get; set; }

    protected TestHelper? TestHelper { get; set; }
   

    private bool isInit = false;
    protected override async Task OnParametersSetAsync()
    {
        if (!isInit)
        {
            isInit = true;
            await LoadEntityFromDb();
        }
        await base.OnParametersSetAsync();
    }

    protected async Task LoadEntityFromDb()
    {
        LoadEntityOperationResponce = await DbRepository.GetCourse(EditedEntityId);
        TestHelper = new(LoadEntityOperationResponce.Data);
        TestHelper.Timer.Elapsed += OnTimedEvent;
    }

    public void OnCancelClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.allTrainingCoursesPageHref);
    }

    private async void OnTimedEvent(object? source, System.Timers.ElapsedEventArgs e)
    {
        await InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        TestHelper?.Timer?.Elapsed -= OnTimedEvent;
    }
}
