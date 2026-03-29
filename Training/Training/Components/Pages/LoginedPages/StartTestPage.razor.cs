namespace Training.Components.Pages.LoginedPages;

public class StartTestPageModel : BaseModel
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
    /// Индекс вопроса
    /// </summary>
    protected int CurrentQestionIndex { get; set; } = -1;

    /// <summary>
    /// Ответы на текущий вопрос в случайном порядке
    /// </summary>
    protected AllAnswers? RandomAnswers { get; set; }

    /// <summary>
    /// Текущий вопрос
    /// </summary>
    protected CourseQestion? CurrentCourseQestion { get; set; }

    /// <summary>
    /// Количество правильных ответов
    /// </summary>
    protected int CountCorrectAnswers { get; set; } = 0;

    /// <summary>
    /// Тестирование завершено
    /// </summary>
    protected bool IsTestFinished { get; set; } = false;

    /// <summary>
    /// Затраченное время на прохождение курса
    /// </summary>
    public int Duration { get; set; }

    private bool isInit = false;

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
        MainEntity = LoadEntityOperationResponce.Data;
        CreateNextQuestion();
    }

    private async Task CreateNextQuestion()
    {
        if (QestionNumber == 0)
            return;

        //IsAnswerSelected = false;

        CurrentQestionIndex++;
        if (CurrentQestionIndex >= QestionNumber)
        {
            IsTestFinished = true;
            //CurrentQestionIndex = 0;
            //CurrentCourseQestion = MainEntity?.CourseQestions?.FirstOrDefault();
            await SaveRezult();
            return;
        }
        else
            CurrentCourseQestion = MainEntity?.CourseQestions[CurrentQestionIndex];

        RandomAnswers = new(CurrentCourseQestion);
    }

    private async Task SaveRezult()
    {
        var result = new CompletedTest()
        {
            TrainingCourseId = MainEntity.Id,
            MyUserId = MyUser.Id,
            QestionNumber = QestionNumber,
            CountCorrectAnswers = CountCorrectAnswers,
            Duration = 0
        };

        SaveEntityOperationResponce = await DbRepository.UpdateEntity(result);
    }


    protected void OnAnswerClick(TestAnswer testAnswer)
    {
        //IsAnswerSelected = true;
        //SelectedAnswer = testAnswer;
        if (testAnswer.IsCorrectAnswer)
            CountCorrectAnswers++;

        CreateNextQuestion();
    }

    //public void OnCancelClick()
    //{
    //    NavigationManager.NavigateTo(ProjectRouters.allTrainingCoursesPageHref);
    //}

    public void OnGoToCourceListClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.allTrainingCoursesPageHref);
    }
}
