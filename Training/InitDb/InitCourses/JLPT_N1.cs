using Entities;
namespace InitDb.InitCourses;

public class JLPT_N1
{
    public static List<CourseQestion> GetJapan(TrainingCourse trainingCourse)
    {
        var questions = new List<CourseQestion>();
        
        questions.Add(new CourseQestion
        {
            KanjiWord = "氏",
            HiraganaWord = string.Empty,
            KatakanaWord = string.Empty,
            Word = "family name, surname, clan",
            TrainingCourse = trainingCourse,
            WrongWordAnswers = new List<WrongWordAnswer>
            {
                new("well"),
                new("fresh"),
                new("ring")}});

        questions.Add(new CourseQestion
        {
            KanjiWord = "統",
            HiraganaWord = string.Empty,
            KatakanaWord = string.Empty,
            Word = "overall, relationship, ruling",
            TrainingCourse = trainingCourse,
            WrongWordAnswers = new List<WrongWordAnswer>
            {
                new("tree"),
                new("oversee"),
                new("ring")}
        });

        questions.Add(new CourseQestion
        {
            KanjiWord = "保",
            HiraganaWord = string.Empty,
            KatakanaWord = string.Empty,
            Word = "protect, guarantee, keep",
            TrainingCourse = trainingCourse,
            WrongWordAnswers = new List<WrongWordAnswer>
            {
                new("evaluate"),
                new("shadow"),
                new("ballot")}
        });
        return questions;
    }
}
