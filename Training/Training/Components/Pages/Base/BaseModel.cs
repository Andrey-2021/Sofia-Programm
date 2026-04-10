using Radzen;
namespace Training.Components.Pages.Base;

public class BaseModel:ComponentBase
{
    [Inject]
    protected NotificationService NotificationService { get; set; } = default!;

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

    /// <summary>
    /// Вывести сообщение
    /// </summary>
    /// <param name="text">Текст</param>
    /// <param name="title">Заголовок</param>
    /// <param name="severity">Тип</param>
    /// <param name="duration">Продолжительность видимости сообщения</param>
    public void NotifyUser(string text, string title="Внимание", NotificationSeverity severity=NotificationSeverity.Info, double? duration = 6000)
    {
        var notyfy = new NotificationMessage
        {
            Severity = severity,
            Summary = title,
            Detail = text,
            Duration = duration
        };
        NotificationService.Notify(notyfy);
    }
}
