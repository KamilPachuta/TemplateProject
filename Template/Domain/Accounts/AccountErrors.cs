using Domain.Shared;

namespace Domain.Accounts;

public static class AccountErrors
{
    public static readonly Error InvalidPassword = new(
        "Accounts.InvalidPassword", 
        "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.");
   
    public static readonly Error EmailTaken = new(
        "Accounts.EmailTaken", 
        "The email address provided already exists in the system.");

}