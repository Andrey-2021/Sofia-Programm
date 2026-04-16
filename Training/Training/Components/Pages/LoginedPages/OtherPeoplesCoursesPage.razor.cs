namespace Training.Components.Pages.LoginedPages;

public class OtherPeoplesCoursesPageModel : BaseModel
{
    /// <summary>
    /// Курсы открытые для всех. Разработанные другими пользователями, не считая моих
    /// </summary>
    protected IEnumerable<TrainingCourse>? NotSelectedOtherPeopleCourse { get; set; }

    /// <summary>
    /// Уже мною выбранные чужие курсы (разработанные другими пользователями)
    /// </summary>
    protected IEnumerable<TrainingCourse>? SelectedOtherPeopleCourse { get; set; }

    /// <summary>
    /// Результат операции удаления
    /// </summary>
    protected OperationResponce<SelectedOtherPeopleCourse?>? DelSelectedOtherPeopleCourseOperationResponce { get; set; }

    /// <summary>
    /// Результат операции чтения чужих открытых курсов
    /// </summary>
    protected OperationResponce<(IEnumerable<TrainingCourse>? mySelectedOtherPeopleCourse, IEnumerable<TrainingCourse>? notSelectedAllOtherPeopleCourse)>? LoadOtherPeoplesCoursesResponce { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
        IsBusy = true;
        LoadOtherPeoplesCoursesResponce = await DbRepository.GetOtherPeoplesCoursesAsync(MyUser);
        SelectedOtherPeopleCourse = LoadOtherPeoplesCoursesResponce.Data.mySelectedOtherPeopleCourse;
        NotSelectedOtherPeopleCourse = LoadOtherPeoplesCoursesResponce.Data.notSelectedAllOtherPeopleCourse;
        IsBusy = false;
        if (LoadOtherPeoplesCoursesResponce.IsSuccessfullOperation)
            NotifyUser("Данные прочитаны");
    }

    /// <summary>
    /// Добавить чужой курс к себе
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task OnAddTrainingCourseClick(TrainingCourse entity)
    {
        var selectedCource = new SelectedOtherPeopleCourse()
        {
            MyUserId = MyUser.Id,
            TrainingCourseId=entity.Id
        };

        var rezult= await DbRepository.UpdateEntity(selectedCource);
        if(rezult.IsSuccessfullOperation)
            NotifyUser("Курс добавлен", "Успешно", Radzen.NotificationSeverity.Success);
        else
            NotifyUser("Курс не удалось добавить", "Ошибка", Radzen.NotificationSeverity.Error);
        await LoadData();
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
        await LoadData();
    }
}
