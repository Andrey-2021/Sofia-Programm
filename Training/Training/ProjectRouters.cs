namespace Training;

public static class ProjectRouters
{
	public const string homeHref = "";
	public const string home = "/" + homeHref;

    // Политика конфиденциальности
    public const string privacyPolicyHref = "privacy-policy";
    public const string privacyPolicy= "/" + privacyPolicyHref;

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

    public const string addMyUserHref = "add-user";
    public const string addMyUser = "/" + addMyUserHref;

    /// <summary>
    /// Все курсы
    /// </summary>
    public const string allTrainingCoursesPageHref = "all-training-courses";
    public const string allTrainingCoursesPage= "/" + allTrainingCoursesPageHref;

    /// <summary>
    /// Чужие курсы
    /// </summary>
    public const string otherPeoplesCoursesPageHref = "other-peoples-courses";
    public const string otherPeoplesCoursesPage = "/" + otherPeoplesCoursesPageHref;

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
    
    /// <summary>
    /// Все курсы
    /// </summary>
    public const string viewTrainingCourcePageHref = "view-course";
    public const string viewTrainingCourcePage = "/" + viewTrainingCourcePageHref;

    /// <summary>
    /// Заучивание
    /// </summary>
    public const string memorizationTrainingCourcePageHref = "memorization";
    public const string memorizationTrainingCourcePage = "/" + memorizationTrainingCourcePageHref;


    public const string adminInfoHref = "admin-info";
    public const string adminInfo = "/" + adminInfoHref;
   
    /// <summary>
    /// Название в параметре запроса (URL) для id редактируемой сущности
    /// </summary>
    public const string queryParametrNameForEditId = "edited-id";
}
