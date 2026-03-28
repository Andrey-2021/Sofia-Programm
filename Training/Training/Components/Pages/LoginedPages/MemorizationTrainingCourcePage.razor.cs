namespace Training.Components.Pages.LoginedPages;

public class MemorizationTrainingCourcePageModel : BaseModel
{
    /// <summary>
    /// Результат выполнения операции чтения
    /// </summary>
    protected OperationResponce<TrainingCourse>? LoadEntityOperationResponce { get; set; }

    /// <summary>
    /// Объект
    /// </summary>
    protected TrainingCourse? MainEntity { get; set; }

    /// <summary>
    /// Количество вопросов в курсе
    /// </summary>
    protected int QestionNumber => MainEntity?.CourseQestions?.Count ?? 0;

    /// <summary>
    /// Текущий вопрос
    /// </summary>
    protected CourseQestion? CurrentCourseQestion { get; set; }

    /// <summary>
    /// Ответы на текущий вопрос в случайном порядке
    /// </summary>
    protected AllAnswers? RandomAnswers { get; set; }

    /// <summary>
    /// Индекс вопроса
    /// </summary>
    protected int CurrentQestionIndex { get; set; } = -1;

    /// <summary>
    /// Количество правильных ответов
    /// </summary>
    protected int CountCorrectAnswers { get; set; } = -1;

    /// <summary>
    /// Пользователь выбрал ответ
    /// </summary>
    protected bool IsAnswerSelected { get; set; }

    protected TestAnswer? SelectedAnswer { get; set; }

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
        MainEntity = LoadEntityOperationResponce.Data;
        CreateNextQuestion();

    }

    public void OnNextClick()
    {
        CreateNextQuestion();
    }

    private void CreateNextQuestion()
    {
        IsAnswerSelected = false;

        CurrentQestionIndex++;
        if (CurrentQestionIndex == QestionNumber)
        {
            CurrentQestionIndex = 0;
            CurrentCourseQestion = MainEntity?.CourseQestions?.FirstOrDefault();
        }
        else
            CurrentCourseQestion = MainEntity?.CourseQestions[CurrentQestionIndex];

        RandomAnswers = new(CurrentCourseQestion);
    }

    protected void OnAnswerClick(TestAnswer testAnswer)
    {
        IsAnswerSelected = true;
        SelectedAnswer = testAnswer;
        if (testAnswer.IsCorrectAnswer)
            CountCorrectAnswers++;
    }

    public void OnCancelClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.allTrainingCoursesPageHref);
    }
}
