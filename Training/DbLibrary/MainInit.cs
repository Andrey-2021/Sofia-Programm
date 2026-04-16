namespace DbLibrary;

/// <summary>
/// Инициализация БД начальными значениями
/// </summary>
public static class MainInit
{
    /// <summary>
    /// Инициализировать БД начальными данными
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static async Task InitDb(SqlDbContext db)
    {
        var users = UserSeeder.GetSampleUsers();
        await db.MyUsers.AddRangeAsync(users);

        var trainingCourse = TrainingCourseJapaneseSeeder.GetSampleCourses(users);
        await db.TrainingCourses.AddRangeAsync(trainingCourse);

        var questions = CommonCourseQuestionSeeder.GetQuestions(trainingCourse);
        await db.CourseQestions.AddRangeAsync(questions);

        await AddCompetedTests(trainingCourse, users, db);
    }

    /// <summary>
    /// Добавить завершенные тесты
    /// </summary>
    private static async Task AddCompetedTests(List<TrainingCourse> trainingCourse, List<MyUser> users, SqlDbContext db)
    {
        var completedTest1 = new CompletedTest()
        {
            TrainingCourse = trainingCourse[0],
            MyUser = trainingCourse[0].MyUser, //users[0],
            QestionNumber = trainingCourse[0].CourseQestions?.Count ?? 0,
            CountCorrectAnswers = (trainingCourse[0].CourseQestions?.Count ?? 0) / 2
        };

        var completedTest2 = new CompletedTest()
        {
            TrainingCourse = trainingCourse[1],
            MyUser = trainingCourse[1].MyUser, //users[0],
            QestionNumber = trainingCourse[1].CourseQestions?.Count ?? 0,
            CountCorrectAnswers = (trainingCourse[1].CourseQestions?.Count ?? 0) / 2
        };

        var completedTest3 = new CompletedTest()
        {
            TrainingCourse = trainingCourse[2],
            MyUser = trainingCourse[2].MyUser, //users[0],
            QestionNumber = trainingCourse[2].CourseQestions?.Count ?? 0,
            CountCorrectAnswers = (trainingCourse[2].CourseQestions?.Count ?? 0) / 2
        };

        var completedTest4 = new CompletedTest()
        {
            TrainingCourse = trainingCourse[3],
            MyUser = trainingCourse[3].MyUser, //users[0],
            QestionNumber = trainingCourse[3].CourseQestions?.Count ?? 0,
            CountCorrectAnswers = (trainingCourse[3].CourseQestions?.Count ?? 0) / 2
        };

        var completedTest5 = new CompletedTest()
        {
            TrainingCourse = trainingCourse[4],
            MyUser = trainingCourse[4].MyUser, //users[0],
            QestionNumber = trainingCourse[4].CourseQestions?.Count ?? 0,
            CountCorrectAnswers = (trainingCourse[4].CourseQestions?.Count ?? 0) / 2
        };

        await db.CompletedTests.AddRangeAsync(completedTest1, completedTest2,completedTest3,completedTest4, completedTest5);
    }
}


