namespace Entities.DTO;

/// <summary>
/// Создаём ответы для тестирования знаний по курсу
/// </summary>
public class AllAnswers
{
    /// <summary>
    /// Ответы в случайном порядка
    /// </summary>
    public TestAnswer[] RandomAnswers { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="currentCourseQestion">Текущий вопрос</param>
    /// <param name="courseQestions">Все вопросы уч. курса</param>
    public AllAnswers(CourseQestion? currentCourseQestion, IList<CourseQestion>? courseQestions)
    {
        if (currentCourseQestion == null || courseQestions == null || courseQestions.Count == 0)
        {
            RandomAnswers = new TestAnswer[0];
            return;
        }

        List<String> wrongUnswers = default!; // Список неправильных ответов/слов
        if (currentCourseQestion?.WrongWordAnswers?.Count > 0) // Если есть неправильные ответы/слова для текущего вопроса
            wrongUnswers = CreteFrowWrongAnswers(currentCourseQestion); // тогда берём их
        else
            wrongUnswers = CreteFrowQustions(currentCourseQestion!, courseQestions); // иначе, получаем их другим способом

        int numberAnswers = (currentCourseQestion?.WrongWordAnswers?.Count ?? 0) + 1;
        RandomAnswers = new TestAnswer[numberAnswers];
        Random rng = new Random();

        //Размещаем неправильные ответы случайным образом
        if (currentCourseQestion?.WrongWordAnswers != null)
        {
            foreach (var item in currentCourseQestion.WrongWordAnswers)
            {
                var index = rng.Next(0, numberAnswers);
                if (RandomAnswers[index] == null)
                    RandomAnswers[index] = new TestAnswer(item.Answer, false);
                else
                    WriteToCleanPlase(item.Answer, false);
            }
        }
        // На свободное место в массивы размещаем правильный ответ
        WriteToCleanPlase(currentCourseQestion!.Word, true);
    }

    /// <summary>
    /// Создаём слова из неправильных ответов
    /// </summary>
    /// <param name="courseQestion">Текущий вопрос</param>
    /// <returns></returns>
    private List<String> CreteFrowWrongAnswers(CourseQestion courseQestion)
    {
        return courseQestion!.WrongWordAnswers!.Select(x => x.Answer).ToList();
    }

    /// <summary>
    /// Создаём слова из вопросов
    /// </summary>
    /// <param name="courseQestion">Текущий вопрос</param>
    /// <param name="courseQestions">Все вопросы</param>
    private List<String> CreteFrowQustions(CourseQestion courseQestion, IList<CourseQestion>? courseQestions)
    {
        //создаём слова ответы из массива случайных слов
        List<String> wordsList = new();

        // Создаём слова ответы из других вопросов уч.курса
        if (courseQestions?.Count > 0)
        {
            wordsList = courseQestions.Where(x => x.Id != courseQestion.Id)
                .Where(x => x.KatakanaWord != courseQestion.KatakanaWord
                && x.HiraganaWord != courseQestion.HiraganaWord
                && x.KanjiWord != courseQestion.KanjiWord
                && x.Word.ToUpper() != courseQestion.Word.ToUpper())
                .Select(x => x.Word).ToList();
            wordsList= wordsList.Distinct().ToList(); //Удаляем повторяющиеся слова
        }

        if (wordsList.Count < LengthConstants.minNumberOfWrongWords) // если уникальных слов, полученных из ответа мало, т.е. не получиться создать многовариантные случайные неправильные ответы 
            wordsList = Words.ToList(); // тогда берём слова из массива

        Random random = new Random();
        List<String> randomWords = new();

        int i = 0;
        while (i < LengthConstants.numberOfWrongAnswersWords)
        {
            int index = random.Next(wordsList.Count);
            var addedWord = wordsList[index];
            if (randomWords.Any(x => x == addedWord) // если такое слово уже есть
                && addedWord.ToUpper() == courseQestion.Word.ToUpper()) // или оно совпадвет с правильным ответом из вопроса
                continue;
            randomWords.Add(addedWord);
            i++;
        }
        return randomWords;
    }

    /// <summary>
    /// Случайные слова
    /// </summary>
    private static readonly List<string> Words = new List<string>
    {
        "apple", "banana", "cherry", "date", "elderberry",
        "fig", "grape", "honeydew", "kiwi", "lemon",
        "mango", "nectarine", "orange", "peach", "pear",
        "quince", "raspberry", "strawberry", "tangerine", "ugli",
        "vanilla", "watermelon", "xylophone", "yellow", "zucchini",
        "мыло", "арбуз","помидор","школа","ученик","автобус","самолёт","тетрадь","книга","Карандаш","Урок","пенал"
    };

    private void WriteToCleanPlase(string word, bool isCorrectAnswer)
    {
        // Находим свободное место и туда помещаем ответ
        for (int i = 0; i < RandomAnswers.Count(); i++)
        {
            if (RandomAnswers[i] == null)
            {
                RandomAnswers[i] = new TestAnswer(word, isCorrectAnswer);
                break;
            }
        }
    }

}



public class TestAnswer
{
    /// <summary>
    /// Текущее слово
    /// </summary>
    /// <remarks>
    /// Руссоке, английское
    /// </remarks>
    public string CurrentAnswerWord { get; set; }

    /// <summary>
    /// Это правильный ответ
    /// </summary>
    public bool IsCorrectAnswer { get; set; }

    public TestAnswer(string russianWord, bool isWrongAnswer)
    {
        CurrentAnswerWord = russianWord;
        IsCorrectAnswer = isWrongAnswer;
    }
}
