using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InitDb.InitCourses;

internal class TravelingInJapan
{
    public static List<CourseQestion> GetSampleQuestionsForTravelJapan(TrainingCourse trainingCourse)
    {
        var questions = new List<CourseQestion>();

        // 1. Поезд
        questions.Add(new CourseQestion
        {
            KanjiWord = "電車",
            HiraganaWord = "でんしゃ",
            KatakanaWord = "デンシャ",
            RussianWord = "поезд",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Автобус"),
            new("Такси"),
            new("Метро"),
            new("Самолёт")
        }
        });

        // 2. Автобус
        questions.Add(new CourseQestion
        {
            KanjiWord = "バス",
            HiraganaWord = "ばす",
            KatakanaWord = "バス",
            RussianWord = "автобус",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Поезд"),
            new("Такси"),
            new("Трамвай"),
            new("Метро")
        }
        });

        // 3. Билет
        questions.Add(new CourseQestion
        {
            KanjiWord = "切符",
            HiraganaWord = "きっぷ",
            KatakanaWord = "キップ",
            RussianWord = "билет",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Паспорт"),
            new("Багаж"),
            new("Карта"),
            new("Расписание")
        }
        });

        // 4. Отель
        questions.Add(new CourseQestion
        {
            KanjiWord = "ホテル",
            HiraganaWord = "ほてる",
            KatakanaWord = "ホテル",
            RussianWord = "отель",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Рёкан"),
            new("Гостиница"),
            new("Хостел"),
            new("Квартира")
        }
        });

        // 5. Аэропорт
        questions.Add(new CourseQestion
        {
            KanjiWord = "空港",
            HiraganaWord = "くうこう",
            KatakanaWord = "クウコウ",
            RussianWord = "аэропорт",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Вокзал"),
            new("Порт"),
            new("Станция"),
            new("Терминал")
        }
        });

        // 6. Вокзал
        questions.Add(new CourseQestion
        {
            KanjiWord = "駅",
            HiraganaWord = "えき",
            KatakanaWord = "エキ",
            RussianWord = "вокзал",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Аэропорт"),
            new("Остановка"),
            new("Платформа"),
            new("Депо")
        }
        });

        // 7. Экскурсия
        questions.Add(new CourseQestion
        {
            KanjiWord = "見学",
            HiraganaWord = "けんがく",
            KatakanaWord = "ケンガク",
            RussianWord = "экскурсия",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Путешествие"),
            new("Тур"),
            new("Прогулка"),
            new("Отдых")
        }
        });

        // 8. Сувенир
        questions.Add(new CourseQestion
        {
            KanjiWord = "お土産",
            HiraganaWord = "おみやげ",
            KatakanaWord = "オミヤゲ",
            RussianWord = "сувенир",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Подарок"),
            new("Вещь"),
            new("Магазин"),
            new("Фото")
        }
        });

        // 9. Карта
        questions.Add(new CourseQestion
        {
            KanjiWord = "地図",
            HiraganaWord = "ちず",
            KatakanaWord = "チズ",
            RussianWord = "карта",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Схема"),
            new("Атлас"),
            new("Путеводитель"),
            new("Навигатор")
        }
        });

        // 10. Достопримечательность
        questions.Add(new CourseQestion
        {
            KanjiWord = "名所",
            HiraganaWord = "めいしょ",
            KatakanaWord = "メイショ",
            RussianWord = "достопримечательность",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Музей"),
            new("Парк"),
            new("Храм"),
            new("Замок")
        }
        });

        // 11. Гид
        questions.Add(new CourseQestion
        {
            KanjiWord = "案内人",
            HiraganaWord = "あんないにん",
            KatakanaWord = "アンナイニン",
            RussianWord = "гид",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Переводчик"),
            new("Турист"),
            new("Сопровождающий"),
            new("Экскурсовод")
        }
        });

        // 12. Турист
        questions.Add(new CourseQestion
        {
            KanjiWord = "旅行者",
            HiraganaWord = "りょこうしゃ",
            KatakanaWord = "リョコウシャ",
            RussianWord = "турист",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Путешественник"),
            new("Гость"),
            new("Отдыхающий"),
            new("Эмигрант")
        }
        });

        // 13. Багаж
        questions.Add(new CourseQestion
        {
            KanjiWord = "荷物",
            HiraganaWord = "にもつ",
            KatakanaWord = "ニモツ",
            RussianWord = "багаж",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Сумка"),
            new("Чемодан"),
            new("Рюкзак"),
            new("Покупка")
        }
        });

        // 14. Расписание
        questions.Add(new CourseQestion
        {
            KanjiWord = "時刻表",
            HiraganaWord = "じこくひょう",
            KatakanaWord = "ジコクヒョウ",
            RussianWord = "расписание",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Табло"),
            new("График"),
            new("Маршрут"),
            new("Время")
        }
        });

        // 15. Путешествие
        questions.Add(new CourseQestion
        {
            KanjiWord = "旅行",
            HiraganaWord = "りょこう",
            KatakanaWord = "リョコウ",
            RussianWord = "путешествие",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1,
            WrongRussianWordAnswers = new List<WrongRussianWordAnswer>
        {
            new("Отдых"),
            new("Экскурсия"),
            new("Тур"),
            new("Прогулка")
        }
        });

        return questions;
    }
}
