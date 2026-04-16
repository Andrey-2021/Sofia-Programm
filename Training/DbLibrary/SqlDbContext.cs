namespace DbLibrary;

/// <summary>
/// Контекст БД
/// </summary>
public class SqlDbContext : DbContext
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public DbSet<MyUser> MyUsers { get; set; }
    
    /// <summary>
    /// Учебные курсы
    /// </summary>
    public DbSet<TrainingCourse> TrainingCourses{ get; set; }
    
    /// <summary>
    /// Вопросы учебного курса
    /// </summary>
    public DbSet<CourseQestion> CourseQestions{ get; set; }
    
    /// <summary>
    /// Неверные ответы для вопроса курса
    /// </summary>
    public DbSet<WrongWordAnswer> WrongWordAnswers { get; set; }
    
    /// <summary>
    /// Завершенные тесты
    /// </summary>
    public DbSet<CompletedTest> CompletedTests{ get; set; }
    
    /// <summary>
    /// Курсы от других посетителей, которые выбраны текущим пользователем
    /// </summary>
    public DbSet<SelectedOtherPeopleCourse> SelectedOtherPeopleCourses { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
    }
}