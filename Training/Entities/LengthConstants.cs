namespace Entities;

public class LengthConstants
{

    /// <summary>
    /// Минимальная длина Login
    /// </summary>
    public const byte loginMinLength = 4;
    /// <summary>
    /// Максимальная длина Login
    /// </summary>
    public const int loginMaxLength = 50;

    /// <summary>
    /// Минимальная длина Пароля
    /// </summary>
    public const byte passwordMinLength = 4;
    /// <summary>
    /// Максимальная длина Пароля
    /// </summary>
    public const int passwordMaxLength = 50;

    public const int trainingCourseNameMaxLength = 255;
    public const int trainingCourseNameMinLength = 4;

    /// <summary>
    /// максимальная длина описания курса
    /// </summary>
    public const int trainingCourseDescriptionMaxLength = 255;

    /// <summary>
	/// Максимальное значение для "Продолжительность курса (минут)"
	/// </summary>
	public const decimal maxDurationHours = 180;


    public const int qestionMaxLength = 255;
    public const int qestionMinLength = 4;

    public const int answerMaxLength = 255;
    public const int answerMinLength = 1;

    /// <summary>
    /// Максимальный уровень сложности курса
    /// </summary>
    public const int courceDifficultyLevelLength = 5;

    /// <summary>
    /// Максимальный уровень сложности вопроса
    /// </summary>
    public const int qestionDifficultyLevelLength = 5;

    /// <summary>
	/// Максимальная количество попыток ввода пароля
	/// </summary>
	public const byte maxPasswordInputCount = 5;

    /// <summary>
    /// Русское слово
    /// </summary>
    public const int russianWordMaxLength = 100;
    public const int russianWordMinLength = 1;


    /// <summary>
    /// максимальная длина японского слова
    /// </summary>
    public const int jupanWordMaxLength = 50;



    /// <summary>
    /// Минимальное количество неправильных слов из которых составляем неправильные варианты ответов
    /// </summary>
    public const int minNumberOfWrongWords = 5;

    // Количество неправильных слов-ответов по умолчанию
    public const int numberOfWrongAnswersWords = 3;













    /// <summary>
	/// Минимальная длина фамилии
	/// </summary>
	public const byte lastNameMinLength = 4;
    /// <summary>
    /// Максимальная длина фамилии
    /// </summary>
    public const int lastNameMaxLength = 255;

    /// <summary>
	/// Минимальная длина имени
	/// </summary>
	public const byte firstNameMinLength = 4;
    /// <summary>
    /// Максимальная длина имени
    /// </summary>
    public const int firstNameMaxLength = 255;

    /// <summary>
	/// Минимальная длина отчества
	/// </summary>
	public const byte middleNameMinLength = 4;
    /// <summary>
    /// Максимальная длина отчества
    /// </summary>
    public const int middleNameMaxLength = 255;
        
    /// <summary>
    /// Минимальная длина телефона
    /// </summary>
    public const byte phonetMinLength = 5;
    /// <summary>
    /// Максимальная длина телефона
    /// </summary>
    public const byte phonetMaxLength = 25;
    
    
    /// <summary>
    /// Максимальная длина e-mail
    /// </summary>
    public const byte emailMaxLength = 254;
    /// <summary>
    /// Минимальная длина e-mail
    /// </summary>
    public const byte emailMinLength = 5;
    }
