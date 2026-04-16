using Microsoft.AspNetCore.Http.HttpResults;
using Radzen;
using Training.Components.Pages.Base;

namespace Training.Components.Pages.LoginedPages;

public class AllTrainingCoursesPageModel : BaseShowAllDataModel<TrainingCourse> 
{
    //protected IEnumerable<TrainingCourse>? Entities { get; set; }

    protected OperationResponce<IEnumerable<SelectedOtherPeopleCourse>?> OtherPeoplesCoursesThatIChosenResponce { get; set; } = default!;
    protected IEnumerable<TrainingCourse>? OtherPeoplesCoursesThatIChosen { get; set; }

    /// <summary>
    /// Результат операции удаления
    /// </summary>
    protected OperationResponce<SelectedOtherPeopleCourse?>? DelSelectedOtherPeopleCourseOperationResponce { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        //await LoadMyCourses();
        await LoadOtherPeoplesCourses();
    }

    protected override async Task LoadEntetiesAsync()
    {
        //var rezult = await DbRepository.GetAllMyTrainingCourse(MyUser);
        IsBusy = true;
        LoadEntitiesOperationResponce = await DbRepository.GetAllMyTrainingCourseAsync(MyUser);
        Entities = LoadEntitiesOperationResponce.Data;
        IsBusy = false;
        if (LoadEntitiesOperationResponce.IsSuccessfullOperation)
            NotifyUser("Данные прочитаны");
    }



    private async Task LoadOtherPeoplesCourses()
    {
        OtherPeoplesCoursesThatIChosenResponce = await DbRepository.GetOtherPeoplesCoursesThatIChosenAsync(MyUser);
        OtherPeoplesCoursesThatIChosen = OtherPeoplesCoursesThatIChosenResponce.Data?.Select(x => x.TrainingCourse!)?.ToList();
    }

    /// <summary>
    /// Удалить курс из списка чужих выбранных курсов
    /// </summary>
    protected async Task DeleteSelectedTrainingCourse(TrainingCourse entity)
    {
        DelSelectedOtherPeopleCourseOperationResponce = await DbRepository.DelSelectedTrainingCourceAsync(MyUser, entity);
        if (DelSelectedOtherPeopleCourseOperationResponce.IsSuccessfullOperation)
            NotifyUser("Курс удалён из списка выбранных", "Успешно", Radzen.NotificationSeverity.Success);
        else
            NotifyUser("Не удалось удалить курс из списка выбранных", "Ошибка", Radzen.NotificationSeverity.Error);
        await LoadOtherPeoplesCourses();
    }
}
