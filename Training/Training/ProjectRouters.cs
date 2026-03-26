namespace Training;

public static class ProjectRouters
{
	public const string homeHref = "";
	public const string home = "/" + homeHref;

    /// <summary>
	/// Страница входа (ввод логина и пароля)
	/// </summary>
	public const string inputLoginandPasswordHref = "login";
    public const string inputLoginandPassword = "/" + inputLoginandPasswordHref;

    /// <summary>
	/// Страница входа (ввод логина и пароля)
	/// </summary>
	public const string newUserRegistrationHref = "new-user-registretion";
    public const string newUserRegistration = "/" + newUserRegistrationHref;



    /// <summary>
	/// Вход выполнен
	/// </summary>
	public const string loginedHomePageHref = "logined-home-page";
    public const string loginedHomePage = "/" + loginedHomePageHref;


    public const string aboutUsHref = "about-us";
	public const string aboutUs = "/" + aboutUsHref;

    public const string createDbHref = "create-db";
    public const string createDb = "/" + createDbHref;

    public const string registeredUsersHref = "registered-users";
    public const string registeredUsers = "/" + registeredUsersHref;




    /// <summary>
    /// Все курсы
    /// </summary>
    public const string allTrainingCoursesPageHref = "all-training-courses";
    public const string allTrainingCoursesPage= "/" + allTrainingCoursesPageHref;

    /// <summary>
    /// Добавить курс
    /// </summary>
    public const string addTrainingCoursePageHref = "add-training-course";
    public const string addTrainingCoursePage = "/" + addTrainingCoursePageHref;

    /// <summary>
    /// Пройденные тесты
    /// </summary>
    public const string completedTestsHref = "completed-tests";
    public const string completedTests = "/" + completedTestsHref;

    /// <summary>
    /// Начать тест
    /// </summary>
    public const string startTestPageHref = "start-test";
    public const string startTestPage = "/" + startTestPageHref;

}
