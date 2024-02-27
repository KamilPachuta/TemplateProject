using System.Security.Claims;

namespace Web_Api.Services;

internal sealed class AccountService : IAccountService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
    
    public Guid GetAccountId()
    {
        var result = Guid.Empty;

        var stringResult = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (stringResult is not null)
        {
            result = new Guid(stringResult);
        }
        
        return result;
    }
}