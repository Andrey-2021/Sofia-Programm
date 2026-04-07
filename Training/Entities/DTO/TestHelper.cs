namespace Entities.DTO;

public class TestHelper:IDisposable
{
    /// <summary>
    /// Учебный курс
    /// </summary>
    public TrainingCourse? MainEntity { get; private set; }

    /// <summary>
    /// Количество вопросов в курсе
    /// </summary>
    public int QestionNumber => MainEntity?.CourseQestions?.Count ?? 0;

    /// <summary>
    /// Результат в процентах
    /// </summary>
    public decimal PercentageResult => Math.Round(100.0m * CountCorrectAnswers/(QestionNumber==0?1: QestionNumber),2);

    /// <summary>
    /// Текущий вопрос
    /// </summary>
    public CourseQestion? CurrentCourseQestion { get; set; }

    /// <summary>
    /// Ответы на текущий вопрос в случайном порядке
    /// </summary>
    public AllAnswers? RandomAnswers { get; set; }

    /// <summary>
    /// Индекс вопроса
    /// </summary>
    public int CurrentQestionIndex { get; set; } = -1;

    /// <summary>
    /// Количество правильных ответов
    /// </summary>
    public int CountCorrectAnswers { get; set; } = 0;

    /// <summary>
    /// Количество НЕправильных ответов
    /// </summary>
    public int CountWrongAnswers { get; set; } = 0;

    /// <summary>
    /// Пользователь выбрал ответ
    /// </summary>
    public bool IsAnswerSelected { get; set; }

    /// <summary>
    /// Выбранный пользователем ответ
    /// </summary>
    public TestAnswer? SelectedAnswer { get; set; }

    /// <summary>
    /// Тест завершён
    /// </summary>
    public bool IsTestFinished { get; private set; } = false;

    /// <summary>
    /// Затраченное время на прохождение курса,сек
    /// </summary>
    public TimeSpan Interval { get; private set; } = new(0, 0, 0);
    //public int Duration { get; private set; }

    /// <summary>
    /// Время от начала прохождения теста
    /// </summary>
    public string Time => Interval.ToString();

    /// <summary>
    /// Таймер на 1-у секунду
    /// </summary>
    public System.Timers.Timer Timer { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="trainingCourse"></param>
    public TestHelper(TrainingCourse? trainingCourse)
    {
        if(trainingCourse==null)
            throw new ArgumentNullException(nameof(trainingCourse));

        MainEntity = trainingCourse;
        CreateNextQuestion();

        Timer = new System.Timers.Timer(1000); // Интервал 1 сек. (1000 миллисекунд)
        Timer.Elapsed += OnTimedEvent;
        Timer.AutoReset = true;
        Timer.Enabled = true;
        Timer.Start();
    }

    private void OnTimedEvent(object? source, System.Timers.ElapsedEventArgs e)
    {
        Interval=Interval.Add(new TimeSpan(0,0,1));
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
            CurrentCourseQestion = MainEntity?.CourseQestions![CurrentQestionIndex];

        RandomAnswers = new(CurrentCourseQestion, MainEntity?.CourseQestions);
    }

    public void OnNextClick()
    {
        CreateNextQuestion();
    }

    public void OnAnswerClick(TestAnswer testAnswer)
    {
        IsAnswerSelected = true;
        SelectedAnswer = testAnswer;
        if (testAnswer.IsCorrectAnswer)
            CountCorrectAnswers++;
        else
            CountWrongAnswers++;
        CheckStopTest();
    }

    public void OnTestAnswerClick(TestAnswer testAnswer)
    {
        OnAnswerClick(testAnswer);
        if (CurrentQestionIndex < QestionNumber - 1)
            OnNextClick();
        //else
        //{
        //    IsTestFinished = true;
        //    Timer.Stop();
        //}
        CheckStopTest();
    }

    private void CheckStopTest()
    {
        if (CurrentQestionIndex == QestionNumber - 1)
        {
            IsTestFinished = true;
            Timer.Stop();
        }
    }

    public void Dispose()
    {
        Timer?.Elapsed -= OnTimedEvent;
    }
}

