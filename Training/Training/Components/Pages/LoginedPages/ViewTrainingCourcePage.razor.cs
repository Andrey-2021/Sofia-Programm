using Radzen.Blazor;

namespace Training.Components.Pages.LoginedPages;

public class ViewTrainingCourcePageModel : BaseModel
{
    #region -------- для карусели карточек
    protected RadzenCarousel carousel = default!;
    protected bool Auto { get; set; } = true;
    protected bool AllowPaging => MainEntity?.CourseQestions?.Count<50;
    protected int interval = 4000;
    protected double? animationDuration = 500;
    protected string toggleText = "Стоп";
    protected bool started = true;

    protected int SelectedNumber
    {
        get => selectedIndex + 1;
        set
        {
            if (value >= 1 && value <= MainEntity?.CourseQestions?.Count)
                selectedIndex = value - 1;
        }
    }
    protected int selectedIndex;


    protected void GoToFirst()
    {
        carousel.Navigate(0);
        //Auto = true;
        //StateHasChanged();
    }

    protected void GoToEnd()
    {
        carousel.Navigate((MainEntity?.CourseQestions?.Count ?? 1) - 1);
    }

    protected void CheckboxChanged(ChangeEventArgs e)
    {
        Auto = !Auto;
        started = !Auto;
        Toggle();
    }

    protected void Toggle()
    {
        if (started)
        {
            carousel.Stop();
            toggleText = "Старт";
        }
        else
        {
            carousel.Start();
            toggleText = "Стоп";
        }

        started = !started;

    }

    protected void OnChange()
    {
        //console.Log($"SelectedIndex changed to {args}
    }
    #endregion ---------------------- 

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
        MainEntity = LoadEntityOperationResponce.Data;
    }

    public void OnCancelClick()
    {
        NavigationManager.NavigateTo(ProjectRouters.allTrainingCoursesPageHref);
    }
}

