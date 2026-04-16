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
            Word = "суши",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Сашими"),
            new("Роллы"),
            new("Темпура"),
          //  new("Рис")
        }
        });

        // 2. Сашими
        questions.Add(new CourseQestion
        {
            KanjiWord = "刺身",
            HiraganaWord = "さしみ",
            KatakanaWord = "サシミ",
            Word = "сашими",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Суши"),
            new("Роллы"),
            new("Удон"),
        //    new("Гёдза")
        }
        });

        // 3. Роллы (макидзуси)
        questions.Add(new CourseQestion
        {
            KanjiWord = "巻き寿司",
            HiraganaWord = "まきずし",
            KatakanaWord = "マキズシ",
            Word = "роллы",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Суши"),
            new("Сашими"),
            new("Темпура"),
         //   new("Гёдза")
        }
        });

        // 4. Удон
        questions.Add(new CourseQestion
        {
            KanjiWord = "饂飩",
            HiraganaWord = "うどん",
            KatakanaWord = "ウドン",
            Word = "удон",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Соба"),
            new("Рамен"),
            new("Якитори"),
         //   new("Рис")
        }
        });

        // 5. Соба
        questions.Add(new CourseQestion
        {
            KanjiWord = "蕎麦",
            HiraganaWord = "そば",
            KatakanaWord = "ソバ",
            Word = "соба",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Удон"),
            new("Рамен"),
            new("Темпура"),
         //   new("Мисо-суп")
        }
        });

        // 6. Рамен
        questions.Add(new CourseQestion
        {
            KanjiWord = "拉麺",
            HiraganaWord = "らーめん",
            KatakanaWord = "ラーメン",
            Word = "рамен",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Удон"),
            new("Соба"),
            new("Якитори"),
         //   new("Гёдза")
        }
        });

        // 7. Темпура
        questions.Add(new CourseQestion
        {
            KanjiWord = "天ぷら",
            HiraganaWord = "てんぷら",
            KatakanaWord = "テンプラ",
            Word = "темпура",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Суши"),
            new("Сашими"),
            new("Якитори"),
          //  new("Мисо-суп")
        }
        });

        // 8. Гёдза
        questions.Add(new CourseQestion
        {
            KanjiWord = "餃子",
            HiraganaWord = "ぎょうざ",
            KatakanaWord = "ギョウザ",
            Word = "гёдза",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Якитори"),
            new("Темпура"),
            new("Суши"),
         //   new("Рамен")
        }
        });

        // 9. Мисо-суп
        questions.Add(new CourseQestion
        {
            KanjiWord = "味噌汁",
            HiraganaWord = "みそしる",
            KatakanaWord = "ミソシル",
            Word = "мисо-суп",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Сукияки"),
            new("Темпура"),
            new("Якитори"),
         //   new("Рис")
        }
        });

        // 10. Якитори
        questions.Add(new CourseQestion
        {
            KanjiWord = "焼き鳥",
            HiraganaWord = "やきとり",
            KatakanaWord = "ヤキトリ",
            Word = "якитори",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Гёдза"),
            new("Темпура"),
            new("Суши"),
          //  new("Удон")
        }
        });

        // 11. Рис
        questions.Add(new CourseQestion
        {
            KanjiWord = "ご飯",
            HiraganaWord = "ごはん",
            KatakanaWord = "ゴハン",
            Word = "рис",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Лапша"),
            new("Хлеб"),
            new("Суп"),
         //   new("Салат")
        }
        });

        // 12. Чай
        questions.Add(new CourseQestion
        {
            KanjiWord = "お茶",
            HiraganaWord = "おちゃ",
            KatakanaWord = "オチャ",
            Word = "чай",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Кофе"),
            new("Сок"),
            new("Вода"),
        //    new("Молоко")
        }
        });

        // 13. Заказ
        questions.Add(new CourseQestion
        {
            KanjiWord = "注文",
            HiraganaWord = "ちゅうもん",
            KatakanaWord = "チュウモン",
            Word = "заказ",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Меню"),
            new("Счёт"),
            new("Ресторан"),
         //   new("Официант")
        }
        });

        // 14. Меню
        questions.Add(new CourseQestion
        {
            KanjiWord = "",
            HiraganaWord = "",
            KatakanaWord = "メニュー",
            Word = "меню",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Заказ"),
            new("Счёт"),
            new("Ресторан"),
         //   new("Кухня")
        }
        });

        // 15. Счёт
        questions.Add(new CourseQestion
        {
            KanjiWord = "お勘定",
            HiraganaWord = "おかんじょう",
            KatakanaWord = "オカンジョウ",
            Word = "счёт",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Меню"),
            new("Заказ"),
            new("Чаевые"),
          //  new("Оплата")
        }
        });

        return questions;
    }
}
