using Entities;
namespace InitDb;

public static class CommonCourseQuestionSeeder
{
    public static List<CourseQestion> GetQuestions(List<TrainingCourse> trainingCourses)
    {
        List<CourseQestion> courseQestions = new();

        var qestions1 = CourseQuestionSeeder.GetSampleQuestions(trainingCourses[0]);
        courseQestions.AddRange(qestions1);

        return courseQestions;
    }
}
