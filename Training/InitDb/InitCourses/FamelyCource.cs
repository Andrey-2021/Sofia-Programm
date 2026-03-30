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
            RussianWord = "отец",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Мать"),
            new("Дедушка"),
            new("Сын"),
            new("Брат")
        }
        });

        // 2. Мать
        questions.Add(new CourseQestion
        {
            KanjiWord = "母",
            HiraganaWord = "はは",
            KatakanaWord = "ハハ",
            RussianWord = "мать",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Отец"),
            new("Бабушка"),
            new("Дочь"),
            new("Сестра")
        }
        });

        // 3. Старший брат
        questions.Add(new CourseQestion
        {
            KanjiWord = "兄",
            HiraganaWord = "あに",
            KatakanaWord = "アニ",
            RussianWord = "старший брат",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Младший брат"),
            new("Старшая сестра"),
            new("Отец"),
            new("Дядя")
        }
        });

        // 4. Старшая сестра
        questions.Add(new CourseQestion
        {
            KanjiWord = "姉",
            HiraganaWord = "あね",
            KatakanaWord = "アネ",
            RussianWord = "старшая сестра",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Младшая сестра"),
            new("Старший брат"),
            new("Мать"),
            new("Тётя")
        }
        });

        // 5. Младший брат
        questions.Add(new CourseQestion
        {
            KanjiWord = "弟",
            HiraganaWord = "おとうと",
            KatakanaWord = "オトウト",
            RussianWord = "младший брат",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Старший брат"),
            new("Младшая сестра"),
            new("Сын"),
            new("Внук")
        }
        });

        // 6. Младшая сестра
        questions.Add(new CourseQestion
        {
            KanjiWord = "妹",
            HiraganaWord = "いもうと",
            KatakanaWord = "イモウト",
            RussianWord = "младшая сестра",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Старшая сестра"),
            new("Младший брат"),
            new("Дочь"),
            new("Внучка")
        }
        });

        // 7. Семья
        questions.Add(new CourseQestion
        {
            KanjiWord = "家族",
            HiraganaWord = "かぞく",
            KatakanaWord = "カゾク",
            RussianWord = "семья",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Дом"),
            new("Родственники"),
            new("Друзья"),
            new("Коллеги")
        }
        });

        // 8. Дом
        questions.Add(new CourseQestion
        {
            KanjiWord = "家",
            HiraganaWord = "いえ",
            KatakanaWord = "イエ",
            RussianWord = "дом",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Квартира"),
            new("Здание"),
            new("Комната"),
            new("Двор")
        }
        });

        // 9. Комната
        questions.Add(new CourseQestion
        {
            KanjiWord = "部屋",
            HiraganaWord = "へや",
            KatakanaWord = "ヘヤ",
            RussianWord = "комната",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Кухня"),
            new("Ванная"),
            new("Коридор"),
            new("Балкон")
        }
        });

        // 10. Кухня
        questions.Add(new CourseQestion
        {
            KanjiWord = "台所",
            HiraganaWord = "だいどころ",
            KatakanaWord = "ダイドコロ",
            RussianWord = "кухня",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Столовая"),
            new("Гостиная"),
            new("Спальня"),
            new("Кладовая")
        }
        });

        // 11. Ванна
        questions.Add(new CourseQestion
        {
            KanjiWord = "風呂",
            HiraganaWord = "ふろ",
            KatakanaWord = "フロ",
            RussianWord = "ванна",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Душ"),
            new("Бассейн"),
            new("Сауна"),
            new("Раковина")
        }
        });

        // 12. Туалет
        questions.Add(new CourseQestion
        {
            KanjiWord = "トイレ",
            HiraganaWord = "といれ",
            KatakanaWord = "トイレ",
            RussianWord = "туалет",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Ванная"),
            new("Прихожая"),
            new("Коридор"),
            new("Балкон")
        }
        });

        // 13. Постель (футон)
        questions.Add(new CourseQestion
        {
            KanjiWord = "布団",
            HiraganaWord = "ふとん",
            KatakanaWord = "フトン",
            RussianWord = "постель",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Подушка"),
            new("Одеяло"),
            new("Матрас"),
            new("Кровать")
        }
        });

        // 14. Еда
        questions.Add(new CourseQestion
        {
            KanjiWord = "食べ物",
            HiraganaWord = "たべもの",
            KatakanaWord = "タベモノ",
            RussianWord = "еда",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Напиток"),
            new("Блюдо"),
            new("Продукт"),
            new("Угощение")
        }
        });

        // 15. Вода
        questions.Add(new CourseQestion
        {
            KanjiWord = "水",
            HiraganaWord = "みず",
            KatakanaWord = "ミズ",
            RussianWord = "вода",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>()
        {
            new("Сок"),
            new("Чай"),
            new("Молоко"),
            new("Напиток")
        }
        });

        return questions;
    }
}
