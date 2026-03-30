using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Training.Components;
var builder = WebApplication.CreateBuilder(args);

//Включаем подробное описание ошибок в браузере
// статья "Параметры обработчика канала на стороне сервера" -  https://learn.microsoft.com/ru-ru/aspnet/core/blazor/fundamentals/signalr?view=aspnetcore-8.0#server-side-circuit-handler-options
builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents(options =>
            {
                options.DetailedErrors = builder.Environment.IsDevelopment();//true; https://learn.microsoft.com/ru-ru/aspnet/core/blazor/fundamentals/handle-errors?view=aspnetcore-8.0
                                                                             //options.DisconnectedCircuitMaxRetained = 100;
                                                                             //options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
                                                                             //options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
                                                                             //options.MaxBufferedUnacknowledgedRenderBatches = 10;
builder.Services.AddTransient<DbRepository>(); // регистрируем репозиторий

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<MyUserOperationService>();

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState(); //новая аутентификация

//Строка подкючения к БД
string connectionString = "Data Source = WIN10PC; Initial Catalog =2026TrainingCRM ; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

builder.Services.AddDbContextFactory<SqlDbContext>
        (
            options => options.UseSqlServer(connectionString
                                            // описание  EnableRetryOnFailure -  https://makolyte.com/how-to-do-retries-in-ef-core/
                                            , options => { options.EnableRetryOnFailure(); }
                                            )
            );
builder.Services.AddRadzenComponents(); // Для Radzen компонентов


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
