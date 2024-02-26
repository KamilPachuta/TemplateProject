using Domain.Accounts;
using Domain.Shared;
using MediatR;

namespace Application.Accounts.Commands.Handlers.Abstractions;

internal abstract class AccountCommandHandler<TRequest> : IRequestHandler<TRequest, Result>
    where TRequest : AccountCommand
{
    private readonly IAccountRepository _repository;

    public AccountCommandHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public abstract Task<Result> Handle(TRequest request, CancellationToken cancellationToken);

    // protected async Task<Account?> GetAccount(Guid id)
    // {
    //     var account = await _repository.GetAsync(id);
    //
    //     if (account is null)
    //     {
    //         
    //     }
    //
    //     return account;
    // }
}