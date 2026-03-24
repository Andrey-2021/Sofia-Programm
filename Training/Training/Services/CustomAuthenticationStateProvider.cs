using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
namespace Training.Services;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider, IDisposable
{
	private readonly MyUserOperationService _myUserOperationService;
	private readonly ILogger<CustomAuthenticationStateProvider> _logger;

	public CustomAuthenticationStateProvider(MyUserOperationService myUserOperationService, ILogger<CustomAuthenticationStateProvider> logger)
	{
		_myUserOperationService = myUserOperationService;
		_logger = logger;
		_myUserOperationService.StateChanged += OnMyUserChanged;
	}

	private void OnMyUserChanged(MyUser? basket)
	{
		NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
	}

	public void Dispose()
	{
		_myUserOperationService.StateChanged -= OnMyUserChanged;
	}

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
			if (_myUserOperationService.IsRegisteredUser && _myUserOperationService.MyUser!.ExpiredAt > DateTime.Now)
			{
				var identity = CreateClaimsIdentityFromUser(_myUserOperationService.MyUser);
				var principal = new ClaimsPrincipal(identity);
				return new AuthenticationState(principal);
			}
		}
        catch (Exception ex)
        {
			_logger.LogError(ex, $"Ошибка при проверке прав пользователя, метод {nameof(GetAuthenticationStateAsync)}, класс {nameof(CustomAuthenticationStateProvider)}");
			throw new UnauthorizedAccessException("Ошибка при проверке прав пользователя",ex);
        }
		await Task.Delay(0);
		return CreateAnonymous();
	}

    private AuthenticationState CreateAnonymous()
    {
		var anonymousIdentity = new ClaimsIdentity();
		var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);
		return new AuthenticationState(anonymousPrincipal);
	}

    private static ClaimsIdentity CreateClaimsIdentityFromUser(MyUser user)
    {
        return new ClaimsIdentity(new Claim[]
        {
            new (ClaimTypes.Name, user.Login!),
            new (ClaimTypes.Hash, user.UserGuid!),
            new (ClaimTypes.Role, user.Role.ToString()!)
        }, "Calendar");
    }
}
