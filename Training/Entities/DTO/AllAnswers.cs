namespace Entities.DTO;

public class AllAnswers
{
    public TestAnswer[] RandomAnswers { private set; get; }

    public AllAnswers(CourseQestion? courseQestion)
    {
        if(courseQestion==null)
        {
            RandomAnswers = new TestAnswer[0];
            return;
        }

        int numberAnswers = (courseQestion?.WrongRussianWordAnswers?.Count ?? 0) + 1;
        RandomAnswers = new TestAnswer[numberAnswers];

        Random rng = new Random();

        //Размещаем неправильные ответы случайным образом
        if (courseQestion?.WrongRussianWordAnswers != null)
        {
            foreach (var item in courseQestion.WrongRussianWordAnswers)
            {
                var index= rng.Next(0, numberAnswers);
                if (RandomAnswers[index] ==null)
                    RandomAnswers[index]= new TestAnswer(item.Answer, false);
                else
                    WriteToCleanPlase(item.Answer, false);

            }
        }

        WriteToCleanPlase(courseQestion.RussianWord, true);

        //// Находим свободное место и туда помещаем правильный ответ
        //for (int i = 0; i < RandomAnswers.Count(); i++)
        //{
        //    if (RandomAnswers[i] == null)
        //    {
        //        RandomAnswers[i] = new TestAnswer(courseQestion.RussianWord, true);
        //        break;
        //    }
        //}

    }

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
    public string RussianWord { get; set; }
    
    /// <summary>
    /// Правильный ответ
    /// </summary>
    public bool IsCorrectAnswer { get; set; }

    public TestAnswer(string russianWord, bool isWrongAnswer)
    {
        RussianWord = russianWord;
        IsCorrectAnswer = isWrongAnswer;
    }
}
