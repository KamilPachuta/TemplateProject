using Domain.Shared;
using Infrastructure.EF.Context;

namespace Infrastructure.EF.UnitOfWork;

internal sealed class UnitOfWork(WriteDbContext dbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
        => await dbContext.SaveChangesAsync(cancellationToken);
}