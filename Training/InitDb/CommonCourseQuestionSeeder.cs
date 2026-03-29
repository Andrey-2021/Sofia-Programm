using Entities;
using InitDb.InitCourses;
namespace InitDb;

public static class CommonCourseQuestionSeeder
{
    public static List<CourseQestion> GetQuestions(List<TrainingCourse> trainingCourses)
    {
        List<CourseQestion> courseQestions = new();

        var qestions1 = CourseQuestionSeeder.GetSampleQuestions(trainingCourses[0]);
        courseQestions.AddRange(qestions1);

        var qestions2 = FamelyCource.GetSampleQuestionsForFamilyAndLife(trainingCourses[1]);
        courseQestions.AddRange(qestions2);

        var qestions3 = JapaneseKitchen.GetSampleQuestionsForJapaneseCuisine(trainingCourses[2]);
        courseQestions.AddRange(qestions3);

        var qestions4 = TravelingInJapan.GetSampleQuestionsForTravelJapan(trainingCourses[3]);
        courseQestions.AddRange(qestions4);

        var qestions5 = BusinessInJapan.GetSampleQuestionsForBusinessJapan(trainingCourses[4]);
        courseQestions.AddRange(qestions5);

        return courseQestions;
    }
}
