using Entities;
namespace InitDb;

/// <summary>
/// Предоставляет начальные данные для вопросов курса «Базовое слова японского языка».
/// </summary>
public static class CourseQuestionSeeder
{
    /// <summary>
    /// Возвращает список из 20 вопросов для указанного учебного курса.
    /// </summary>
    /// <param name="trainingCourse">Id курса, к которому относятся вопросы.</param>
    public static List<CourseQestion> GetSampleQuestions(TrainingCourse trainingCourse)
    {
        var questions = new List<CourseQestion>();

        // 1. Я
        questions.Add(new CourseQestion
        {
            KanjiWord = "私",
            HiraganaWord = "わたし",
            KatakanaWord = "ワタシ",
            Word = "я",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Ты"),
            new("Мы"),
            new("Город"),
            //new("Село")
        }
        });

        // 2. Ты
        questions.Add(new CourseQestion
        {
            KanjiWord = "貴方",
            HiraganaWord = "あなた",
            KatakanaWord = "アナタ",
            Word = "ты",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Я"),
            new("Вы"),
            new("Он"),
           // new("Она")
        }
        });

        // 3. Студент
        questions.Add(new CourseQestion
        {
            KanjiWord = "学生",
            HiraganaWord = "がくせい",
            KatakanaWord = "ガクセイ",
            Word = "студент",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Учитель"),
            new("Школьник"),
            new("Ученик"),
           // new("Преподаватель")
        }
        });

        // 4. Учитель
        questions.Add(new CourseQestion
        {
            KanjiWord = "先生",
            HiraganaWord = "せんせい",
            KatakanaWord = "センセイ",
            Word = "учитель",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Студент"),
            new("Директор"),
            new("Врач"),
            //new("Инженер")
        }
        });

        // 5. Японский язык
        questions.Add(new CourseQestion
        {
            KanjiWord = "日本語",
            HiraganaWord = "にほんご",
            KatakanaWord = "ニホンゴ",
            Word = "японский язык",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Китайский язык"),
            new("Английский язык"),
            new("Корейский язык"),
            //new("Русский язык")
        }
        });

        // 6. Книга
        questions.Add(new CourseQestion
        {
            KanjiWord = "本",
            HiraganaWord = "ほん",
            KatakanaWord = "ホン",
            Word = "книга",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Тетрадь"),
            new("Журнал"),
            new("Газета"),
           // new("Словарь")
        }
        });

        // 7. Вода
        questions.Add(new CourseQestion
        {
            KanjiWord = "水",
            HiraganaWord = "みず",
            KatakanaWord = "ミズ",
            Word = "вода",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Молоко"),
            new("Сок"),
            new("Чай"),
           // new("Кофе")
        }
        });

        // 8. Есть (кушать)
        questions.Add(new CourseQestion
        {
            KanjiWord = "食べる",
            HiraganaWord = "たべる",
            KatakanaWord = "タベル",
            Word = "есть (кушать)",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Пить"),
            new("Готовить"),
            new("Жевать"),
           // new("Глотать")
        }
        });

        // 9. Пить
        questions.Add(new CourseQestion
        {
            KanjiWord = "飲む",
            HiraganaWord = "のむ",
            KatakanaWord = "ノム",
            Word = "пить",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Есть"),
            new("Наливать"),
            new("Пробовать"),
           // new("Глотать")
        }
        });

        // 10. Идти
        questions.Add(new CourseQestion
        {
            KanjiWord = "行く",
            HiraganaWord = "いく",
            KatakanaWord = "イク",
            Word = "идти",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Бежать"),
            new("Ехать"),
            new("Стоять"),
           // new("Лететь")
        }
        });

        // 11. Смотреть
        questions.Add(new CourseQestion
        {
            KanjiWord = "見る",
            HiraganaWord = "みる",
            KatakanaWord = "ミル",
            Word = "смотреть",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Видеть"),
            new("Глядеть"),
            new("Наблюдать"),
           // new("Разглядывать")
        }
        });

        // 12. Собака
        questions.Add(new CourseQestion
        {
            KanjiWord = "犬",
            HiraganaWord = "いぬ",
            KatakanaWord = "イヌ",
            Word = "собака",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Кошка"),
            new("Волк"),
            new("Лиса"),
           // new("Медведь")
        }
        });

        // 13. Кошка
        questions.Add(new CourseQestion
        {
            KanjiWord = "猫",
            HiraganaWord = "ねこ",
            KatakanaWord = "ネコ",
            Word = "кошка",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Собака"),
            new("Тигр"),
            new("Лев"),
           // new("Рысь")
        }
        });

        // 14. Гора
        questions.Add(new CourseQestion
        {
            KanjiWord = "山",
            HiraganaWord = "やま",
            KatakanaWord = "ヤマ",
            Word = "гора",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Холм"),
            new("Скала"),
            new("Вулкан"),
           // new("Пик")
        }
        });

        // 15. Река
        questions.Add(new CourseQestion
        {
            KanjiWord = "川",
            HiraganaWord = "かわ",
            KatakanaWord = "カワ",
            Word = "река",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Озеро"),
            new("Ручей"),
            new("Море"),
          //  new("Водопад")
        }
        });

        // 16. Цветок
        questions.Add(new CourseQestion
        {
            KanjiWord = "花",
            HiraganaWord = "はな",
            KatakanaWord = "ハナ",
            Word = "цветок",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Дерево"),
            new("Трава"),
            new("Лист"),
         //   new("Куст")
        }
        });

        // 17. Небо
        questions.Add(new CourseQestion
        {
            KanjiWord = "空",
            HiraganaWord = "そら",
            KatakanaWord = "ソラ",
            Word = "небо",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Земля"),
            new("Облако"),
            new("Космос"),
          //  new("Горизонт")
        }
        });

        // 18. Дождь
        questions.Add(new CourseQestion
        {
            KanjiWord = "雨",
            HiraganaWord = "あめ",
            KatakanaWord = "アメ",
            Word = "дождь",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Снег"),
            new("Град"),
            new("Туман"),
          //  new("Ветер")
        }
        });

        // 19. Машина
        questions.Add(new CourseQestion
        {
            KanjiWord = "車",
            HiraganaWord = "くるま",
            KatakanaWord = "クルマ",
            Word = "машина",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Автобус"),
            new("Мотоцикл"),
            new("Велосипед"),
          //  new("Грузовик")
        }
        });

        // 20. Поезд
        questions.Add(new CourseQestion
        {
            KanjiWord = "電車",
            HiraganaWord = "でんしゃ",
            KatakanaWord = "デンシャ",
            Word = "поезд",
            TrainingCourse = trainingCourse,
             
            WrongWordAnswers = new List<WrongWordAnswer>()
        {
            new("Метро"),
            new("Трамвай"),
            new("Самолет"),
         //   new("Корабль")
        }
        });

        return questions;
    }
}



/*
 
public static List<CourseQestion> GetSampleQuestions(TrainingCourse trainingCourse)
    {
        var questions = new List<CourseQestion>();

        // 1. Я
        questions.Add(new CourseQestion
        {
            KanjiWord = "私",
            HiraganaWord = "わたし",
            KatakanaWord = "ワタシ",
            RussianWord = "я",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>() {new("Ты"), new("Мы"),new("Город"), new("Село") }
        });

        // 2. Ты
        questions.Add(new CourseQestion
        {
            KanjiWord = "貴方",
            HiraganaWord = "あなた",
            KatakanaWord = "アナタ",
            RussianWord = "ты",
            TrainingCourse = trainingCourse,
             
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>() { new("Я"), new("Они"), new("Корова"), new("Телёнок") }
        });

        // 3. Студент
        questions.Add(new CourseQestion
        {
            KanjiWord = "学生",
            HiraganaWord = "がくせい",
            KatakanaWord = "ガクセイ",
            RussianWord = "студент",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 4. Учитель
        questions.Add(new CourseQestion
        {
            KanjiWord = "先生",
            HiraganaWord = "せんせい",
            KatakanaWord = "センセイ",
            RussianWord = "учитель",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 5. Японский язык
        questions.Add(new CourseQestion
        {
            KanjiWord = "日本語",
            HiraganaWord = "にほんご",
            KatakanaWord = "ニホンゴ",
            RussianWord = "японский язык",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 6. Книга
        questions.Add(new CourseQestion
        {
            KanjiWord = "本",
            HiraganaWord = "ほん",
            KatakanaWord = "ホン",
            RussianWord = "книга",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 7. Вода
        questions.Add(new CourseQestion
        {
            KanjiWord = "水",
            HiraganaWord = "みず",
            KatakanaWord = "ミズ",
            RussianWord = "вода",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 8. Есть (кушать)
        questions.Add(new CourseQestion
        {
            KanjiWord = "食べる",
            HiraganaWord = "たべる",
            KatakanaWord = "タベル",
            RussianWord = "есть (кушать)",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 9. Пить
        questions.Add(new CourseQestion
        {
            KanjiWord = "飲む",
            HiraganaWord = "のむ",
            KatakanaWord = "ノム",
            RussianWord = "пить",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 10. Идти
        questions.Add(new CourseQestion
        {
            KanjiWord = "行く",
            HiraganaWord = "いく",
            KatakanaWord = "イク",
            RussianWord = "идти",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 11. Смотреть
        questions.Add(new CourseQestion
        {
            KanjiWord = "見る",
            HiraganaWord = "みる",
            KatakanaWord = "ミル",
            RussianWord = "смотреть",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 12. Собака
        questions.Add(new CourseQestion
        {
            KanjiWord = "犬",
            HiraganaWord = "いぬ",
            KatakanaWord = "イヌ",
            RussianWord = "собака",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 13. Кошка
        questions.Add(new CourseQestion
        {
            KanjiWord = "猫",
            HiraganaWord = "ねこ",
            KatakanaWord = "ネコ",
            RussianWord = "кошка",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 14. Гора
        questions.Add(new CourseQestion
        {
            KanjiWord = "山",
            HiraganaWord = "やま",
            KatakanaWord = "ヤマ",
            RussianWord = "гора",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 15. Река
        questions.Add(new CourseQestion
        {
            KanjiWord = "川",
            HiraganaWord = "かわ",
            KatakanaWord = "カワ",
            RussianWord = "река",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 16. Цветок
        questions.Add(new CourseQestion
        {
            KanjiWord = "花",
            HiraganaWord = "はな",
            KatakanaWord = "ハナ",
            RussianWord = "цветок",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 17. Небо
        questions.Add(new CourseQestion
        {
            KanjiWord = "空",
            HiraganaWord = "そら",
            KatakanaWord = "ソラ",
            RussianWord = "небо",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 18. Дождь
        questions.Add(new CourseQestion
        {
            KanjiWord = "雨",
            HiraganaWord = "あめ",
            KatakanaWord = "アメ",
            RussianWord = "дождь",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 19. Машина
        questions.Add(new CourseQestion
        {
            KanjiWord = "車",
            HiraganaWord = "くるま",
            KatakanaWord = "クルマ",
            RussianWord = "машина",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 20. Поезд
        questions.Add(new CourseQestion
        {
            KanjiWord = "電車",
            HiraganaWord = "でんしゃ",
            KatakanaWord = "デンシャ",
            RussianWord = "поезд",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        return questions;
    }
  
 */