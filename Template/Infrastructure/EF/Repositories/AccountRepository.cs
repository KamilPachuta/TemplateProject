using Domain.Accounts;
using Domain.Accounts.ValueObjects;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Repositories;

internal sealed class AccountRepository : IAccountRepository
{
    private readonly DbSet<Account> _accounts;

    public AccountRepository(WriteDbContext dbContext)
    {
        _accounts = dbContext.Accounts;
    }
    
    public async Task<Account> GetAsync(Guid id)
        => await _accounts
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Account> GetAsync(AccountEmail email)
        => await _accounts
            .FirstOrDefaultAsync(a => a.Email == email);
    
    public async Task AddAsync(Account account)
    {
        await _accounts.AddAsync(account);
    }

    public Task UpdateAsync(Account account)
    {
        _accounts.Update(account);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Account account)
    {
        _accounts.Remove(account);
        return Task.CompletedTask;
    }
}