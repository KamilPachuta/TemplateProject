namespace Domain.Shared;

public sealed record Error(string Code, string? Description = null) // move to SharedKernel
{
    public static readonly Error None = new(string.Empty);
}