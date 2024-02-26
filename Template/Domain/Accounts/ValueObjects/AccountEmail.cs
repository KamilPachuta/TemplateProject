using Domain.Accounts.Exceptions;

namespace Domain.Accounts.ValueObjects;

public record AccountEmail
{
    public string Value { get; set; }

    public AccountEmail(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyEmailException();
        }

        if (value.Length > 50)
        {
            throw new EmailLengthExceededException(value);
        }

        Value = value;
    }
    
    public static implicit operator string(AccountEmail value)
        => value.Value;
    
    public static implicit operator AccountEmail(string value)
        => new(value);
}