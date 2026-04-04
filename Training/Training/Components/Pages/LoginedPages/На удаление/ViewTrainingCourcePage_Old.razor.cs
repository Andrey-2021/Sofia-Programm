namespace Training.Components.Pages.LoginedPages;

public class ViewTrainingCourcePageModel_Old: BaseModel
{
    /// <summary>
    /// Объект
    /// </summary>
    protected TrainingCourse? MainEntity { get; set; }

    /// <summary>
    /// Результат выполнения операции чтения
    /// </summary>
    protected OperationResponce<TrainingCourse>? LoadEntityOperationResponce { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await LoadEntityFromDb();
        await base.OnParametersSetAsync();
    }

    
    protected async Task LoadEntityFromDb()
    {
        LoadEntityOperationResponce = await DbRepository.GetCourse(EditedEntityId);

            //.GetFirstOrDefault<TrainingCourse>
            //(predicate: x=>x.Id== EditedEntityId,
            //include: x=>x.Include(tc=>tc.CourseQestions)
            //                .ThenInclude(cq=>cq.WrongRussianWordAnswers));

        //if (LoadEntityOperationResponce.IsSuccessfullOperation)
            MainEntity = LoadEntityOperationResponce.Data;

        //StateHasChanged();
    }
    

    public void OnCancelClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.allTrainingCoursesPageHref);
    }
}
