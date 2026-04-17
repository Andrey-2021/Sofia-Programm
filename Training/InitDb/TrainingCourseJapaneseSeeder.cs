using Entities;
namespace InitDb;

/// <summary>
/// Предоставляет начальные данные для учебных курсов по изучению японских слов.
/// </summary>
public static class TrainingCourseJapaneseSeeder
{
    /// <summary>
    /// Возвращает список из 20 курсов, связанных с изучением японского языка.
    /// </summary>
    public static List<TrainingCourse> GetSampleCourses(List<MyUser> myUsers)
    {
        var courses = new List<TrainingCourse>();

        // 1. Азбука Хирагана
        courses.Add(new TrainingCourse
        {
            Name = "Базовое слова японского языка",
            Description = "Японские слова, которые имеют написание во всех трёх системах (кандзи, хирагана, катакана)",
            Duration = 20,
            CreateDate = new DateTime(2024, 1, 10),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[1]
        });

        // 2. Словарь: семья и дом
        courses.Add(new TrainingCourse
        {
            Name = "Японские слова: семья и быт",
            Description = "Лексика по теме семьи, дома, повседневных дел",
            Duration = 25,
            CreateDate = new DateTime(2024, 4, 5),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[3]
        });

        // 3. Словарь: еда и рестораны
        courses.Add(new TrainingCourse
        {
            Name = "Японская кухня: названия блюд и заказ",
            Description = "Слова и фразы для похода в ресторан, названия продуктов",
            Duration = 20,
            CreateDate = new DateTime(2024, 4, 12),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[4]
        });

        // 4. Словарь: путешествия и транспорт
        courses.Add(new TrainingCourse
        {
            Name = "Путешествия по Японии: словарь",
            Description = "Лексика для поездок, ориентирования в городе, покупки билетов",
            Duration = 30,
            CreateDate = new DateTime(2024, 5, 1),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[4]
        });

        // 5. Словарь: работа и бизнес
        courses.Add(new TrainingCourse
        {
            Name = "Бизнес в Японии: словарь и выражения",
            Description = "Профессиональная лексика, вежливые формы (кэйго)",
            Duration = 45,
            CreateDate = new DateTime(2024, 5, 20),
            DifficultyLevel = 4,
            IsVisableForAll = true,
            MyUser = myUsers[4]
        });

        // 6. Азбука Хирагана
        courses.Add(new TrainingCourse
        {
            Name = "JLPT N1",
            Description = "Base words",
            Duration = 1,
            CreateDate = new DateTime(2026, 2, 10),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[2]
        });










        // 7. Азбука Катакана
        courses.Add(new TrainingCourse
        {
            Name = "Катакана: для иностранных слов",
            Description = "Освоение азбуки для записи заимствований",
            Duration = 15,
            CreateDate = new DateTime(2024, 1, 15),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[1]
        });

        // 8. Кандзи начального уровня (JLPT N5)
        courses.Add(new TrainingCourse
        {
            Name = "Кандзи N5: первые 100 иероглифов",
            Description = "Изучение базовых иероглифов, необходимых для уровня N5",
            Duration = 40,
            CreateDate = new DateTime(2024, 2, 1),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[1]
        });

        // 9. Кандзи уровня N4
        courses.Add(new TrainingCourse
        {
            Name = "Кандзи N4: расширяем словарный запас",
            Description = "Следующие 150 иероглифов и устойчивые сочетания",
            Duration = 50,
            CreateDate = new DateTime(2024, 2, 20),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[2]
        });

        // 10. Кандзи N3
        courses.Add(new TrainingCourse
        {
            Name = "Кандзи N3: средний уровень",
            Description = "Иероглифы для повседневного общения",
            Duration = 60,
            CreateDate = new DateTime(2024, 3, 10),
            DifficultyLevel = 3,
            IsVisableForAll = false,
            MyUser = myUsers[2]
        });

        // 11. Кандзи N2 и N1
        courses.Add(new TrainingCourse
        {
            Name = "Кандзи продвинутого уровня (N2/N1)",
            Description = "Сложные иероглифы для профессионального использования",
            Duration = 80,
            CreateDate = new DateTime(2024, 3, 25),
            DifficultyLevel = 4,
            IsVisableForAll = false,
            MyUser = myUsers[3]
        });

        

        

        

        // 12. Ономатопея (звукоподражания)
        courses.Add(new TrainingCourse
        {
            Name = "Ономатопея: гионго и гитайго",
            Description = "Звукоподражательные слова, описывающие звуки и состояния",
            Duration = 20,
            CreateDate = new DateTime(2024, 6, 5),
            DifficultyLevel = 3,
            IsVisableForAll = false,
            MyUser = myUsers[5]
        });

        // 13. Счётные суффиксы
        courses.Add(new TrainingCourse
        {
            Name = "Счётные суффиксы в японском",
            Description = "Правила подсчёта предметов, людей, животных и т.д.",
            Duration = 25,
            CreateDate = new DateTime(2024, 6, 18),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[6]
        });

        // 14. Грамматика: частицы и порядок слов
        courses.Add(new TrainingCourse
        {
            Name = "Грамматика: частицы ва, га, о, ни, дэ",
            Description = "Использование основных частиц и построение предложений",
            Duration = 35,
            CreateDate = new DateTime(2024, 7, 1),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[6]
        });

        // 15. Грамматика: формы вежливости
        courses.Add(new TrainingCourse
        {
            Name = "Вежливые формы (кэйго)",
            Description = "Сонкэйго, кэндзёго, тэйнейго",
            Duration = 40,
            CreateDate = new DateTime(2024, 7, 15),
            DifficultyLevel = 4,
            IsVisableForAll = false,
            MyUser = myUsers[7]
        });

        // 16. Разговорные фразы для повседневного общения
        courses.Add(new TrainingCourse
        {
            Name = "Разговорный японский: фразы для общения",
            Description = "Типичные диалоги, выражения приветствия, благодарности",
            Duration = 25,
            CreateDate = new DateTime(2024, 8, 1),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[7]
        });

        // 17. Японские пословицы и идиомы
        courses.Add(new TrainingCourse
        {
            Name = "Пословицы и идиомы (ёдзидзюкуго)",
            Description = "Четырёхсимвольные фразеологизмы и устойчивые выражения",
            Duration = 30,
            CreateDate = new DateTime(2024, 8, 20),
            DifficultyLevel = 3,
            IsVisableForAll = false,
            MyUser = myUsers[8]
        });

        // 18. Произношение и интонация
        courses.Add(new TrainingCourse
        {
            Name = "Японское произношение: акценты и долгота",
            Description = "Правильное ударение, долгие гласные, двойные согласные",
            Duration = 15,
            CreateDate = new DateTime(2024, 9, 5),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[8]
        });

        // 19. Чтение: тексты для начинающих
        courses.Add(new TrainingCourse
        {
            Name = "Чтение простых текстов",
            Description = "Адаптированные рассказы и диалоги с хираганой и базовыми кандзи",
            Duration = 35,
            CreateDate = new DateTime(2024, 9, 18),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[9]
        });

        // 20. Чтение: новости и статьи
        courses.Add(new TrainingCourse
        {
            Name = "Чтение японских новостей",
            Description = "Работа с газетными статьями, официальными текстами",
            Duration = 50,
            CreateDate = new DateTime(2024, 10, 5),
            DifficultyLevel = 4,
            IsVisableForAll = false,
            MyUser = myUsers[9]
        });

        // 21. Подготовка к JLPT N5/N4
        courses.Add(new TrainingCourse
        {
            Name = "Комплексная подготовка к JLPT N5/N4",
            Description = "Все аспекты: лексика, грамматика, аудирование, чтение",
            Duration = 70,
            CreateDate = new DateTime(2024, 10, 20),
            DifficultyLevel = 3,
            IsVisableForAll = true,
            MyUser = myUsers[9]
        });

        return courses;
    }
}