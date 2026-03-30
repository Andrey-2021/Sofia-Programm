using Entities;
namespace InitDb.InitCourses;

internal class JapaneseKitchen
{
    public static List<CourseQestion> GetSampleQuestionsForJapaneseCuisine(TrainingCourse trainingCourse)
    {
        var questions = new List<CourseQestion>();

        // 1. Суши
        questions.Add(new CourseQestion
        {
            KanjiWord = "寿司",
            HiraganaWord = "すし",
            KatakanaWord = "スシ",
            RussianWord = "суши",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Сашими"),
            new("Роллы"),
            new("Темпура"),
            new("Рис")
        }
        });

        // 2. Сашими
        questions.Add(new CourseQestion
        {
            KanjiWord = "刺身",
            HiraganaWord = "さしみ",
            KatakanaWord = "サシミ",
            RussianWord = "сашими",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Суши"),
            new("Роллы"),
            new("Удон"),
            new("Гёдза")
        }
        });

        // 3. Роллы (макидзуси)
        questions.Add(new CourseQestion
        {
            KanjiWord = "巻き寿司",
            HiraganaWord = "まきずし",
            KatakanaWord = "マキズシ",
            RussianWord = "роллы",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Суши"),
            new("Сашими"),
            new("Темпура"),
            new("Гёдза")
        }
        });

        // 4. Удон
        questions.Add(new CourseQestion
        {
            KanjiWord = "饂飩",
            HiraganaWord = "うどん",
            KatakanaWord = "ウドン",
            RussianWord = "удон",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Соба"),
            new("Рамен"),
            new("Якитори"),
            new("Рис")
        }
        });

        // 5. Соба
        questions.Add(new CourseQestion
        {
            KanjiWord = "蕎麦",
            HiraganaWord = "そば",
            KatakanaWord = "ソバ",
            RussianWord = "соба",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Удон"),
            new("Рамен"),
            new("Темпура"),
            new("Мисо-суп")
        }
        });

        // 6. Рамен
        questions.Add(new CourseQestion
        {
            KanjiWord = "拉麺",
            HiraganaWord = "らーめん",
            KatakanaWord = "ラーメン",
            RussianWord = "рамен",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Удон"),
            new("Соба"),
            new("Якитори"),
            new("Гёдза")
        }
        });

        // 7. Темпура
        questions.Add(new CourseQestion
        {
            KanjiWord = "天ぷら",
            HiraganaWord = "てんぷら",
            KatakanaWord = "テンプラ",
            RussianWord = "темпура",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Суши"),
            new("Сашими"),
            new("Якитори"),
            new("Мисо-суп")
        }
        });

        // 8. Гёдза
        questions.Add(new CourseQestion
        {
            KanjiWord = "餃子",
            HiraganaWord = "ぎょうざ",
            KatakanaWord = "ギョウザ",
            RussianWord = "гёдза",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Якитори"),
            new("Темпура"),
            new("Суши"),
            new("Рамен")
        }
        });

        // 9. Мисо-суп
        questions.Add(new CourseQestion
        {
            KanjiWord = "味噌汁",
            HiraganaWord = "みそしる",
            KatakanaWord = "ミソシル",
            RussianWord = "мисо-суп",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Сукияки"),
            new("Темпура"),
            new("Якитори"),
            new("Рис")
        }
        });

        // 10. Якитори
        questions.Add(new CourseQestion
        {
            KanjiWord = "焼き鳥",
            HiraganaWord = "やきとり",
            KatakanaWord = "ヤキトリ",
            RussianWord = "якитори",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Гёдза"),
            new("Темпура"),
            new("Суши"),
            new("Удон")
        }
        });

        // 11. Рис
        questions.Add(new CourseQestion
        {
            KanjiWord = "ご飯",
            HiraganaWord = "ごはん",
            KatakanaWord = "ゴハン",
            RussianWord = "рис",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Лапша"),
            new("Хлеб"),
            new("Суп"),
            new("Салат")
        }
        });

        // 12. Чай
        questions.Add(new CourseQestion
        {
            KanjiWord = "お茶",
            HiraganaWord = "おちゃ",
            KatakanaWord = "オチャ",
            RussianWord = "чай",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Кофе"),
            new("Сок"),
            new("Вода"),
            new("Молоко")
        }
        });

        // 13. Заказ
        questions.Add(new CourseQestion
        {
            KanjiWord = "注文",
            HiraganaWord = "ちゅうもん",
            KatakanaWord = "チュウモン",
            RussianWord = "заказ",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Меню"),
            new("Счёт"),
            new("Ресторан"),
            new("Официант")
        }
        });

        // 14. Меню
        questions.Add(new CourseQestion
        {
            KanjiWord = "",
            HiraganaWord = "",
            KatakanaWord = "メニュー",
            RussianWord = "меню",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Заказ"),
            new("Счёт"),
            new("Ресторан"),
            new("Кухня")
        }
        });

        // 15. Счёт
        questions.Add(new CourseQestion
        {
            KanjiWord = "お勘定",
            HiraganaWord = "おかんじょう",
            KatakanaWord = "オカンジョウ",
            RussianWord = "счёт",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Меню"),
            new("Заказ"),
            new("Чаевые"),
            new("Оплата")
        }
        });

        return questions;
    }
}
