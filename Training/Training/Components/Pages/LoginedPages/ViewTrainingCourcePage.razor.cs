using DbLibrary.Helpers;
using Microsoft.EntityFrameworkCore;
using Training.Components.Pages.Base;
namespace Training.Components.Pages.LoginedPages;

public class ViewTrainingCourcePageModel: BaseModel
{
    /// <summary>
    /// Объект
    /// </summary>
    public TrainingCourse? MainEntity { get; set; }

    /// <summary>
    /// Результат выполнения операции чтения
    /// </summary>
    public OperationResponce<TrainingCourse>? LoadEntityOperationResponce { get; protected set; }

    protected override async Task OnParametersSetAsync()
    {
        await LoadEntityFromDb();
        await base.OnParametersSetAsync();
    }

    protected async Task LoadEntityFromDb()
    {
        LoadEntityOperationResponce = await DbRepository.GetFirstOrDefault<TrainingCourse>
            (predicate: x=>x.Id== EditedEntityId,
            include: x=>x.Include(tc=>tc.CourseQestions)
                            .ThenInclude(cq=>cq.WrongRussianWordAnswers));

        if (LoadEntityOperationResponce.IsSuccessfullOperation)
            MainEntity = LoadEntityOperationResponce.Data;

        StateHasChanged();
    }

    public virtual void OnCancelClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.loginedHomePageHref);
    }
}
