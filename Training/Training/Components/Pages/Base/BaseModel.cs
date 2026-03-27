namespace Training.Components.Pages.Base;

public class BaseModel:ComponentBase
{
    [Inject] 
    protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    protected DbRepository DbRepository { get; set; } = default!;

    [CascadingParameter]
    protected MyUser MyUser { get; set; } = default!;

    /// <summary>
	/// Id объекта для редактирования
	/// </summary>
	[SupplyParameterFromQuery(Name = ProjectRouters.queryParametrNameForEditId)]
    [Parameter]
    public int? EditedEntityId { get; set; }

    /// <summary>
    /// Флаг показывает что выполняется операция
    /// </summary>
    public bool IsBusy { get; set; }
}
