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

    



    // -----------------------------------------------------------------
    /// <summary>
    /// Название в параметре запроса (URL) для id редактируемой сущности
    /// </summary>
    public const string queryParametrNameForEditId = "edited-id";

    /*
    /// <summary>
    /// Название в параметре запроса (URL) для выделения объекта c id (строчки в таблице)
    /// </summary>
    public const string queryParametrForSelectedRowId = "selected-id";

    /// <summary>
    /// Название в параметре запроса (URL) для того, чтобы определить находимся ли мы в корзине или просто показываем все сущности
    /// </summary>
    public const string queryParametrIsInBasket = "is-in-basket";



    public const string queryParameterSelectedColorProductId = "color-product-id";

    public const string queryParameterDepartmentId = "parent-id";

    /// <summary>
    /// Название в параметре запроса (URL) для id сущности, копию которой надо сделать
    /// </summary>
    public const string queryParameterNameForCopyId = "copied-id";
    */
}
