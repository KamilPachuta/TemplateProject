using Domain.Shared;

namespace Domain.Accounts;

internal static class AccountErrors
{
    public static readonly Error InvalidPassword = new(
        "Accounts.InvalidPassword", 
        "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.");
    
}