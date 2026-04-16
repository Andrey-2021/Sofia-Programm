namespace Training.Components.Pages.Components;

public class ShowTrainingCourseInfoModel:ComponentBase
{
    [Inject]
    public Radzen.DialogService DialogService { get; set; } = default!;

    [Parameter]
    [EditorRequired]
    public TrainingCourseInfoDto TrainingCourseInfo { get; set; }
}
