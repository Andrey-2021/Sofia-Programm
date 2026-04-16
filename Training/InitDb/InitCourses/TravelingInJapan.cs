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
            Word = "поезд",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Автобус"),
            new("Такси"),
            new("Метро"),
          //  new("Самолёт")
        }
        });

        // 2. Автобус
        questions.Add(new CourseQestion
        {
            KanjiWord = "バス",
            HiraganaWord = "ばす",
            KatakanaWord = "バス",
            Word = "автобус",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Поезд"),
            new("Такси"),
            new("Трамвай"),
          //  new("Метро")
        }
        });

        // 3. Билет
        questions.Add(new CourseQestion
        {
            KanjiWord = "切符",
            HiraganaWord = "きっぷ",
            KatakanaWord = "キップ",
            Word = "билет",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Паспорт"),
            new("Багаж"),
            new("Карта"),
          //  new("Расписание")
        }
        });

        // 4. Отель
        questions.Add(new CourseQestion
        {
            KanjiWord = "ホテル",
            HiraganaWord = "ほてる",
            KatakanaWord = "ホテル",
            Word = "отель",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Рёкан"),
            new("Гостиница"),
            new("Хостел"),
        //    new("Квартира")
        }
        });

        // 5. Аэропорт
        questions.Add(new CourseQestion
        {
            KanjiWord = "空港",
            HiraganaWord = "くうこう",
            KatakanaWord = "クウコウ",
            Word = "аэропорт",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Вокзал"),
            new("Порт"),
            new("Станция"),
          //  new("Терминал")
        }
        });

        // 6. Вокзал
        questions.Add(new CourseQestion
        {
            KanjiWord = "駅",
            HiraganaWord = "えき",
            KatakanaWord = "エキ",
            Word = "вокзал",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Аэропорт"),
            new("Остановка"),
            new("Платформа"),
           // new("Депо")
        }
        });

        // 7. Экскурсия
        questions.Add(new CourseQestion
        {
            KanjiWord = "見学",
            HiraganaWord = "けんがく",
            KatakanaWord = "ケンガク",
            Word = "экскурсия",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Путешествие"),
            new("Тур"),
            new("Прогулка"),
          //  new("Отдых")
        }
        });

        // 8. Сувенир
        questions.Add(new CourseQestion
        {
            KanjiWord = "お土産",
            HiraganaWord = "おみやげ",
            KatakanaWord = "オミヤゲ",
            Word = "сувенир",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Подарок"),
            new("Вещь"),
            new("Магазин"),
          //  new("Фото")
        }
        });

        // 9. Карта
        questions.Add(new CourseQestion
        {
            KanjiWord = "地図",
            HiraganaWord = "ちず",
            KatakanaWord = "チズ",
            Word = "карта",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Схема"),
            new("Атлас"),
            new("Путеводитель"),
           // new("Навигатор")
        }
        });

        // 10. Достопримечательность
        questions.Add(new CourseQestion
        {
            KanjiWord = "名所",
            HiraganaWord = "めいしょ",
            KatakanaWord = "メイショ",
            Word = "достопримечательность",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Музей"),
            new("Парк"),
            new("Храм"),
          //  new("Замок")
        }
        });

        // 11. Гид
        questions.Add(new CourseQestion
        {
            KanjiWord = "案内人",
            HiraganaWord = "あんないにん",
            KatakanaWord = "アンナイニン",
            Word = "гид",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Переводчик"),
            new("Турист"),
            new("Сопровождающий"),
          //  new("Экскурсовод")
        }
        });

        // 12. Турист
        questions.Add(new CourseQestion
        {
            KanjiWord = "旅行者",
            HiraganaWord = "りょこうしゃ",
            KatakanaWord = "リョコウシャ",
            Word = "турист",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Путешественник"),
            new("Гость"),
            new("Отдыхающий"),
          //  new("Эмигрант")
        }
        });

        // 13. Багаж
        questions.Add(new CourseQestion
        {
            KanjiWord = "荷物",
            HiraganaWord = "にもつ",
            KatakanaWord = "ニモツ",
            Word = "багаж",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Сумка"),
            new("Чемодан"),
            new("Рюкзак"),
          //  new("Покупка")
        }
        });

        // 14. Расписание
        questions.Add(new CourseQestion
        {
            KanjiWord = "時刻表",
            HiraganaWord = "じこくひょう",
            KatakanaWord = "ジコクヒョウ",
            Word = "расписание",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Табло"),
            new("График"),
            new("Маршрут"),
           // new("Время")
        }
        });

        // 15. Путешествие
        questions.Add(new CourseQestion
        {
            KanjiWord = "旅行",
            HiraganaWord = "りょこう",
            KatakanaWord = "リョコウ",
            Word = "путешествие",
            TrainingCourse = trainingCourse,
               
            WrongWordAnswers = new List<WrongWordAnswer>
        {
            new("Отдых"),
            new("Экскурсия"),
            new("Тур"),
          //  new("Прогулка")
        }
        });

        return questions;
    }
}
