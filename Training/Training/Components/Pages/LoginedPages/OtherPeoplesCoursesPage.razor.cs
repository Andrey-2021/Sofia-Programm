using Microsoft.AspNetCore.Http.HttpResults;

namespace Training.Components.Pages.LoginedPages;

public class OtherPeoplesCoursesPageModel : BaseModel
{
    protected IEnumerable<TrainingCourse>? SelectedOtherPeopleCourse { get; set; }
    protected IEnumerable<TrainingCourse>? NotSelectedOtherPeopleCourse { get; set; }

    /// <summary>
    /// Результат операции удаления
    /// </summary>
    protected OperationResponce<SelectedOtherPeopleCourse?>? DelSelectedOtherPeopleCourseOperationResponce { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
        var rezult = await DbRepository.GetOtherPeoplesCoursesAsync(MyUser);
        SelectedOtherPeopleCourse = rezult.Data.allOtherPeopleCourse?.Where(x => rezult.Data.mySelectedOtherPeopleCourse.Any(s=>s.TrainingCourseId==x.Id)).ToList();
        rezult.Data.allOtherPeopleCourse?.RemoveAll(x => SelectedOtherPeopleCourse.Any(z => z.Id == x.Id));
        NotSelectedOtherPeopleCourse = rezult.Data.allOtherPeopleCourse;
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
