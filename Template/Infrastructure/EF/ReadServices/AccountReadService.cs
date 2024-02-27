using Application.Accounts.Services;
using Domain.Accounts.ValueObjects;

namespace Infrastructure.EF.ReadServices;

public class AccountReadService : IAccountReadService
{

  
    
    public async Task<bool> CheckUnique(AccountEmail email)
    {
     

        throw new NotImplementedException();
    }
}