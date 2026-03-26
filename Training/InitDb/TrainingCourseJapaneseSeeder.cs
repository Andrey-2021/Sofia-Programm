using Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
            DurationHours = 20,
            ContractDate = new DateTime(2024, 1, 10),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[1]
        });

        // 1. Азбука Хирагана
        courses.Add(new TrainingCourse
        {
            Name = "Хирагана: основы",
            Description = "Изучение базовой слоговой азбуки хирагана",
            DurationHours = 20,
            ContractDate = new DateTime(2024, 1, 10),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[1]
        });

        // 2. Азбука Катакана
        courses.Add(new TrainingCourse
        {
            Name = "Катакана: для иностранных слов",
            Description = "Освоение азбуки для записи заимствований",
            DurationHours = 15,
            ContractDate = new DateTime(2024, 1, 15),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[1]
        });

        // 3. Кандзи начального уровня (JLPT N5)
        courses.Add(new TrainingCourse
        {
            Name = "Кандзи N5: первые 100 иероглифов",
            Description = "Изучение базовых иероглифов, необходимых для уровня N5",
            DurationHours = 40,
            ContractDate = new DateTime(2024, 2, 1),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[1]
        });

        // 4. Кандзи уровня N4
        courses.Add(new TrainingCourse
        {
            Name = "Кандзи N4: расширяем словарный запас",
            Description = "Следующие 150 иероглифов и устойчивые сочетания",
            DurationHours = 50,
            ContractDate = new DateTime(2024, 2, 20),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[2]
        });

        // 5. Кандзи N3
        courses.Add(new TrainingCourse
        {
            Name = "Кандзи N3: средний уровень",
            Description = "Иероглифы для повседневного общения",
            DurationHours = 60,
            ContractDate = new DateTime(2024, 3, 10),
            DifficultyLevel = 3,
            IsVisableForAll = false,
            MyUser = myUsers[2]
        });

        // 6. Кандзи N2 и N1
        courses.Add(new TrainingCourse
        {
            Name = "Кандзи продвинутого уровня (N2/N1)",
            Description = "Сложные иероглифы для профессионального использования",
            DurationHours = 80,
            ContractDate = new DateTime(2024, 3, 25),
            DifficultyLevel = 4,
            IsVisableForAll = false,
            MyUser = myUsers[3]
        });

        // 7. Словарь: семья и дом
        courses.Add(new TrainingCourse
        {
            Name = "Японские слова: семья и быт",
            Description = "Лексика по теме семьи, дома, повседневных дел",
            DurationHours = 25,
            ContractDate = new DateTime(2024, 4, 5),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[3]
        });

        // 8. Словарь: еда и рестораны
        courses.Add(new TrainingCourse
        {
            Name = "Японская кухня: названия блюд и заказ",
            Description = "Слова и фразы для похода в ресторан, названия продуктов",
            DurationHours = 20,
            ContractDate = new DateTime(2024, 4, 12),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[4]
        });

        // 9. Словарь: путешествия и транспорт
        courses.Add(new TrainingCourse
        {
            Name = "Путешествия по Японии: словарь",
            Description = "Лексика для поездок, ориентирования в городе, покупки билетов",
            DurationHours = 30,
            ContractDate = new DateTime(2024, 5, 1),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[4]
        });

        // 10. Словарь: работа и бизнес
        courses.Add(new TrainingCourse
        {
            Name = "Бизнес-японский: словарь и выражения",
            Description = "Профессиональная лексика, вежливые формы (кэйго)",
            DurationHours = 45,
            ContractDate = new DateTime(2024, 5, 20),
            DifficultyLevel = 4,
            IsVisableForAll = false,
            MyUser = myUsers[4]
        });

        // 11. Ономатопея (звукоподражания)
        courses.Add(new TrainingCourse
        {
            Name = "Ономатопея: гионго и гитайго",
            Description = "Звукоподражательные слова, описывающие звуки и состояния",
            DurationHours = 20,
            ContractDate = new DateTime(2024, 6, 5),
            DifficultyLevel = 3,
            IsVisableForAll = false,
            MyUser = myUsers[5]
        });

        // 12. Счётные суффиксы
        courses.Add(new TrainingCourse
        {
            Name = "Счётные суффиксы в японском",
            Description = "Правила подсчёта предметов, людей, животных и т.д.",
            DurationHours = 25,
            ContractDate = new DateTime(2024, 6, 18),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[6]
        });

        // 13. Грамматика: частицы и порядок слов
        courses.Add(new TrainingCourse
        {
            Name = "Грамматика: частицы ва, га, о, ни, дэ",
            Description = "Использование основных частиц и построение предложений",
            DurationHours = 35,
            ContractDate = new DateTime(2024, 7, 1),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[6]
        });

        // 14. Грамматика: формы вежливости
        courses.Add(new TrainingCourse
        {
            Name = "Вежливые формы (кэйго)",
            Description = "Сонкэйго, кэндзёго, тэйнейго",
            DurationHours = 40,
            ContractDate = new DateTime(2024, 7, 15),
            DifficultyLevel = 4,
            IsVisableForAll = false,
            MyUser = myUsers[7]
        });

        // 15. Разговорные фразы для повседневного общения
        courses.Add(new TrainingCourse
        {
            Name = "Разговорный японский: фразы для общения",
            Description = "Типичные диалоги, выражения приветствия, благодарности",
            DurationHours = 25,
            ContractDate = new DateTime(2024, 8, 1),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[7]
        });

        // 16. Японские пословицы и идиомы
        courses.Add(new TrainingCourse
        {
            Name = "Пословицы и идиомы (ёдзидзюкуго)",
            Description = "Четырёхсимвольные фразеологизмы и устойчивые выражения",
            DurationHours = 30,
            ContractDate = new DateTime(2024, 8, 20),
            DifficultyLevel = 3,
            IsVisableForAll = false,
            MyUser = myUsers[8]
        });

        // 17. Произношение и интонация
        courses.Add(new TrainingCourse
        {
            Name = "Японское произношение: акценты и долгота",
            Description = "Правильное ударение, долгие гласные, двойные согласные",
            DurationHours = 15,
            ContractDate = new DateTime(2024, 9, 5),
            DifficultyLevel = 1,
            IsVisableForAll = true,
            MyUser = myUsers[8]
        });

        // 18. Чтение: тексты для начинающих
        courses.Add(new TrainingCourse
        {
            Name = "Чтение простых текстов",
            Description = "Адаптированные рассказы и диалоги с хираганой и базовыми кандзи",
            DurationHours = 35,
            ContractDate = new DateTime(2024, 9, 18),
            DifficultyLevel = 2,
            IsVisableForAll = true,
            MyUser = myUsers[9]
        });

        // 19. Чтение: новости и статьи
        courses.Add(new TrainingCourse
        {
            Name = "Чтение японских новостей",
            Description = "Работа с газетными статьями, официальными текстами",
            DurationHours = 50,
            ContractDate = new DateTime(2024, 10, 5),
            DifficultyLevel = 4,
            IsVisableForAll = false,
            MyUser = myUsers[9]
        });

        // 20. Подготовка к JLPT N5/N4
        courses.Add(new TrainingCourse
        {
            Name = "Комплексная подготовка к JLPT N5/N4",
            Description = "Все аспекты: лексика, грамматика, аудирование, чтение",
            DurationHours = 70,
            ContractDate = new DateTime(2024, 10, 20),
            DifficultyLevel = 3,
            IsVisableForAll = true,
            MyUser = myUsers[9]
        });

        return courses;
    }
}