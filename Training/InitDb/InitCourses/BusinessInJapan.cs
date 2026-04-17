using Entities;

namespace InitDb.InitCourses;

internal class BusinessInJapan
{
    public static List<CourseQestion> GetSampleQuestionsForBusinessJapan(TrainingCourse trainingCourse)
    {
        var questions = new List<CourseQestion>();

        // 1. Компания / Фирма
        questions.Add(new CourseQestion
        {
            KanjiWord = "会社",
            HiraganaWord = "かいしゃ",
            KatakanaWord = "カイシャ",
            Word = "компания",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Офис"),
        new("Предприятие"),
        new("Организация"),
        //new("Корпорация")
    }
        });

        // 2. Работа
        questions.Add(new CourseQestion
        {
            KanjiWord = "仕事",
            HiraganaWord = "しごと",
            KatakanaWord = "シゴト",
            Word = "работа",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Должность"),
        new("Занятие"),
        new("Труд"),
       // new("Карьера")
    }
        });

        // 3. Начальник
        questions.Add(new CourseQestion
        {
            KanjiWord = "上司",
            HiraganaWord = "じょうし",
            KatakanaWord = "ジョウシ",
            Word = "начальник",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Подчинённый"),
        new("Директор"),
        new("Менеджер"),
       // new("Руководитель")
    }
        });

        // 4. Коллега
        questions.Add(new CourseQestion
        {
            KanjiWord = "同僚",
            HiraganaWord = "どうりょう",
            KatakanaWord = "ドウリョウ",
            Word = "коллега",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Друг"),
        new("Партнёр"),
        new("Сотрудник"),
       // new("Знакомый")
    }
        });

        // 5. Сотрудник
        questions.Add(new CourseQestion
        {
            KanjiWord = "社員",
            HiraganaWord = "しゃいん",
            KatakanaWord = "シャイン",
            Word = "сотрудник",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Работник"),
        new("Персонал"),
        new("Штат"),
       // new("Стажёр")
    }
        });

        // 6. Совещание
        questions.Add(new CourseQestion
        {
            KanjiWord = "会議",
            HiraganaWord = "かいぎ",
            KatakanaWord = "カイギ",
            Word = "совещание",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Конференция"),
        new("Переговоры"),
        new("Презентация"),
       // new("Семинар")
    }
        });

        // 7. Отчёт
        questions.Add(new CourseQestion
        {
            KanjiWord = "報告",
            HiraganaWord = "ほうこく",
            KatakanaWord = "ホウコク",
            Word = "отчёт",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Доклад"),
        new("Презентация"),
        new("Справка"),
       // new("Анализ")
    }
        });

        // 8. Проект
        questions.Add(new CourseQestion
        {
            KanjiWord = "プロジェクト",
            HiraganaWord = "ぷろじぇくと",
            KatakanaWord = "プロジェクト",
            Word = "проект",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Задача"),
        new("План"),
        new("Инициатива"),
        //new("Программа")
    }
        });

        // 9. Клиент
        questions.Add(new CourseQestion
        {
            KanjiWord = "顧客",
            HiraganaWord = "こきゃく",
            KatakanaWord = "コキャク",
            Word = "клиент",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Покупатель"),
        new("Заказчик"),
        new("Партнёр"),
        //new("Посетитель")
    }
        });

        // 10. Контракт
        questions.Add(new CourseQestion
        {
            KanjiWord = "契約",
            HiraganaWord = "けいやく",
            KatakanaWord = "ケイヤク",
            Word = "контракт",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Соглашение"),
        new("Договор"),
        new("Сделка"),
       // new("Оферта")
    }
        });

        // 11. Прибыль
        questions.Add(new CourseQestion
        {
            KanjiWord = "利益",
            HiraganaWord = "りえき",
            KatakanaWord = "リエキ",
            Word = "прибыль",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Доход"),
        new("Выручка"),
        new("Оборот"),
        //new("Капитал")
    }
        });

        // 12. Убыток
        questions.Add(new CourseQestion
        {
            KanjiWord = "損失",
            HiraganaWord = "そんしつ",
            KatakanaWord = "ソンシツ",
            Word = "убыток",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Расход"),
        new("Затраты"),
        new("Дефицит"),
        //new("Долг")
    }
        });

        // 13. Бизнес-карточка (визитка)
        questions.Add(new CourseQestion
        {
            KanjiWord = "名刺",
            HiraganaWord = "めいし",
            KatakanaWord = "メイシ",
            Word = "визитка",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Бланк"),
        new("Карточка"),
        new("Документ"),
       // new("Письмо")
    }
        });

        // 14. Извинение
        questions.Add(new CourseQestion
        {
            KanjiWord = "謝罪",
            HiraganaWord = "しゃざい",
            KatakanaWord = "シャザイ",
            Word = "извинение",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("Просьба"),
        new("Благодарность"),
        new("Отказ"),
       // new("Объяснение")
    }
        });

        // 15. Спасибо за работу (фраза)
        questions.Add(new CourseQestion
        {
            KanjiWord = "お疲れ様です",
            HiraganaWord = "おつかれさまです",
            KatakanaWord = "オツカレサマデス",
            Word = "спасибо за работу",
            TrainingCourse = trainingCourse,

            WrongWordAnswers = new List<WrongWordAnswer>
    {
        new("До свидания"),
        new("Извините"),
        new("Пожалуйста"),
        //new("Здравствуйте")
    }
        });

        return questions;
    }
}
