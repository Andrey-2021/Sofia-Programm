namespace Training.Components.Pages.LoginedPages;

public class StartTestPageModel : BaseModel, IDisposable
{
    /// <summary>
    /// Результат выполнения операции чтения
    /// </summary>
    protected OperationResponce<TrainingCourse>? LoadEntityOperationResponce { get; private set; }

    protected TestHelper? TestHelper { get; private set; }

    private bool isInit = false;
    private bool isSavedResult = false;

    /// <summary>
    /// Результат выполнения операции записи
    /// </summary>
    public OperationResponce<CompletedTest>? SaveEntityOperationResponce { get; protected set; }

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

    protected async Task OnAnswerClick(TestAnswer testAnswer)
    {
        TestHelper?.OnTestAnswerClick(testAnswer);

        if (TestHelper?.IsTestFinished == true && !isSavedResult)
        {
            isSavedResult = true;
            await SaveRezult();
        }
    }

    private async Task SaveRezult()
    {
        var result = new CompletedTest(MyUser, TestHelper!);
        SaveEntityOperationResponce = await DbRepository.UpdateEntity(result);
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
