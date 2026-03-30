using Training.Components.Pages.Base;
namespace Training.Components.Pages.LoginedPages;

public class AddTrainingCoursePageModel: BaseAddModel<TrainingCourse>
{
    protected override Task OnParametersSetAsync()
    {
        MainEntity = new(MyUser);
        return base.OnParametersSetAsync();
    }

    /// <summary>
    /// Добавляемая карточка
    /// </summary>
    protected CourseQestion? AddedCourseQestion { get; set; }

    /// <summary>
    /// Добавляем новую карточку
    /// </summary>
    protected bool IsAddingNewCard { get; set; } = false;

    protected void OnAddNewCardClick()
    {
        IsAddingNewCard = true;
        AddedCourseQestion = new();
    }

    protected void OnSaveCardClick()
    {
        IsAddingNewCard = false;
        if(MainEntity!.CourseQestions==null)
        {
            MainEntity.CourseQestions = new List<CourseQestion>();
        }
        MainEntity.CourseQestions.Add(AddedCourseQestion!);
    }
}
