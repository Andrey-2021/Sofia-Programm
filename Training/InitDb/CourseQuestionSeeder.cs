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
            RussianWord = "я",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
        });

        // 2. Ты
        questions.Add(new CourseQestion
        {
            KanjiWord = "貴方",
            HiraganaWord = "あなた",
            KatakanaWord = "アナタ",
            RussianWord = "ты",
            TrainingCourse = trainingCourse,
            DifficultyLevel = 1
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
}