using Entities;
namespace InitDb.InitCourses;

internal class FamelyCource
{
    public static List<CourseQestion> GetSampleQuestionsForFamilyAndLife(TrainingCourse trainingCourse)
    {
        var questions = new List<CourseQestion>();

        // 1. Отец
        questions.Add(new CourseQestion
        {
            KanjiWord = "父",
            HiraganaWord = "ちち",
            KatakanaWord = "チチ",
            Word = "отец",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Мать"),
            new("Дедушка"),
            new("Сын"),
          //  new("Брат")
        }
        });

        // 2. Мать
        questions.Add(new CourseQestion
        {
            KanjiWord = "母",
            HiraganaWord = "はは",
            KatakanaWord = "ハハ",
            Word = "мать",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Отец"),
            new("Бабушка"),
            new("Дочь"),
          //  new("Сестра")
        }
        });

        // 3. Старший брат
        questions.Add(new CourseQestion
        {
            KanjiWord = "兄",
            HiraganaWord = "あに",
            KatakanaWord = "アニ",
            Word = "старший брат",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Младший брат"),
            new("Старшая сестра"),
            new("Отец"),
           // new("Дядя")
        }
        });

        // 4. Старшая сестра
        questions.Add(new CourseQestion
        {
            KanjiWord = "姉",
            HiraganaWord = "あね",
            KatakanaWord = "アネ",
            Word = "старшая сестра",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Младшая сестра"),
            new("Старший брат"),
            new("Мать"),
           // new("Тётя")
        }
        });

        // 5. Младший брат
        questions.Add(new CourseQestion
        {
            KanjiWord = "弟",
            HiraganaWord = "おとうと",
            KatakanaWord = "オトウト",
            Word = "младший брат",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Старший брат"),
            new("Младшая сестра"),
            new("Сын"),
           // new("Внук")
        }
        });

        // 6. Младшая сестра
        questions.Add(new CourseQestion
        {
            KanjiWord = "妹",
            HiraganaWord = "いもうと",
            KatakanaWord = "イモウト",
            Word = "младшая сестра",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Старшая сестра"),
            new("Младший брат"),
            new("Дочь"),
          //  new("Внучка")
        }
        });

        // 7. Семья
        questions.Add(new CourseQestion
        {
            KanjiWord = "家族",
            HiraganaWord = "かぞく",
            KatakanaWord = "カゾク",
            Word = "семья",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Дом"),
            new("Родственники"),
            new("Друзья"),
          //  new("Коллеги")
        }
        });

        // 8. Дом
        questions.Add(new CourseQestion
        {
            KanjiWord = "家",
            HiraganaWord = "いえ",
            KatakanaWord = "イエ",
            Word = "дом",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Квартира"),
            new("Здание"),
            new("Комната"),
         //   new("Двор")
        }
        });

        // 9. Комната
        questions.Add(new CourseQestion
        {
            KanjiWord = "部屋",
            HiraganaWord = "へや",
            KatakanaWord = "ヘヤ",
            Word = "комната",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Кухня"),
            new("Ванная"),
            new("Коридор"),
         //   new("Балкон")
        }
        });

        // 10. Кухня
        questions.Add(new CourseQestion
        {
            KanjiWord = "台所",
            HiraganaWord = "だいどころ",
            KatakanaWord = "ダイドコロ",
            Word = "кухня",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Столовая"),
            new("Гостиная"),
            new("Спальня"),
         //   new("Кладовая")
        }
        });

        // 11. Ванна
        questions.Add(new CourseQestion
        {
            KanjiWord = "風呂",
            HiraganaWord = "ふろ",
            KatakanaWord = "フロ",
            Word = "ванна",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Душ"),
            new("Бассейн"),
            new("Сауна"),
         //   new("Раковина")
        }
        });

        // 12. Туалет
        questions.Add(new CourseQestion
        {
            KanjiWord = "トイレ",
            HiraganaWord = "といれ",
            KatakanaWord = "トイレ",
            Word = "туалет",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Ванная"),
            new("Прихожая"),
            new("Коридор"),
        //    new("Балкон")
        }
        });

        // 13. Постель (футон)
        questions.Add(new CourseQestion
        {
            KanjiWord = "布団",
            HiraganaWord = "ふとん",
            KatakanaWord = "フトン",
            Word = "постель",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Подушка"),
            new("Одеяло"),
            new("Матрас"),
          //  new("Кровать")
        }
        });

        // 14. Еда
        questions.Add(new CourseQestion
        {
            KanjiWord = "食べ物",
            HiraganaWord = "たべもの",
            KatakanaWord = "タベモノ",
            Word = "еда",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Напиток"),
            new("Блюдо"),
            new("Продукт"),
          //  new("Угощение")
        }
        });

        // 15. Вода
        questions.Add(new CourseQestion
        {
            KanjiWord = "水",
            HiraganaWord = "みず",
            KatakanaWord = "ミズ",
            Word = "вода",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Сок"),
            new("Чай"),
            new("Молоко"),
          //  new("Напиток")
        }
        });

        return questions;
    }
}
