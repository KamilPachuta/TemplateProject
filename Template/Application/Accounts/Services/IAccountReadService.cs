using Domain.Accounts.ValueObjects;

namespace Application.Accounts.Services;

public interface IAccountReadService
{
    Task<bool> CheckUnique(AccountEmail email);
}