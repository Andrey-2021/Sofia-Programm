namespace Training.Components.Pages.LoginedPages;

public class AllTrainingCoursesPageModel : BaseShowAllDataModel<TrainingCourse> 
{
    /// <summary>
    /// Результат выполнения операции чтения чужих курсов, которые я выбрал
    /// </summary>
    protected OperationResponce<IEnumerable<SelectedOtherPeopleCourse>?> OtherPeoplesCoursesThatIChosenResponce { get; set; } = default!;
    
    /// <summary>
    /// Чужие курсы, которые выбраны мною
    /// </summary>
    protected IEnumerable<TrainingCourse>? OtherPeoplesCoursesThatIChosen { get; set; }

    /// <summary>
    /// Результат операции удаления
    /// </summary>
    protected OperationResponce<SelectedOtherPeopleCourse?>? DelSelectedOtherPeopleCourseOperationResponce { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await LoadOtherPeoplesCourses();
    }

    /// <summary>
    /// Загрузка своих курсов
    /// </summary>
    protected override async Task LoadEntetiesAsync()
    {
        IsBusy = true;
        LoadEntitiesOperationResponce = await DbRepository.GetAllMyTrainingCourseAsync(MyUser);
        Entities = LoadEntitiesOperationResponce.Data;
        IsBusy = false;
        if (LoadEntitiesOperationResponce.IsSuccessfullOperation)
            NotifyUser("Данные прочитаны");
    }

    /// <summary>
    /// Загрузка чужих курсов
    /// </summary>
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
