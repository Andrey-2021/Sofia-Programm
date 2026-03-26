namespace Training.Components.Pages.Base;

public class BaseModel:ComponentBase
{
    [Inject] 
    protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    protected DbRepository DbRepository { get; set; } = default!;

    [CascadingParameter]
    protected MyUser MyUser { get; set; } = default!;
}
