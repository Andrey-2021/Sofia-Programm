using Microsoft.AspNetCore.Components;
using Radzen;
using System.Collections.ObjectModel;
namespace Training.Components.Pages.LoginedPages.AdminPages;

public class RegisteredUsersPageModel : ComponentBase
{
    /// <summary>
    /// Флаг занятости
    /// </summary>
    public bool IsBusy { get; set; }

    [Inject]
    protected IServiceProvider ServiceProvider { get; set; } = default!;

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    protected string? ErrorMassage { get; set; }

    public IEnumerable<MyUser>? Entities { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        IsBusy = true;
        var repository = ServiceProvider.GetRequiredService<DbRepository>();
        var result = await repository.GetEntitiesAsync<MyUser>();
        Entities = result.data;

        if (result.ex is null)
        {
            ErrorMassage = null;
        }
        else
        {
            ErrorMassage = "Ошибка при чтении данных. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + result.ex?.Message
                + Environment.NewLine + "InnerException:" + result.ex?.InnerException?.Message;
        }
        IsBusy = false;
    }
}
