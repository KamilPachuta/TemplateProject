using Application.Accounts.Services;
using Domain.Accounts;
using Domain.Accounts.Factory;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Accounts.Commands.Handlers;

public class CreateAdminHandler : IRequestHandler<CreateAdminCommand, Result>
{
    private readonly IAccountRepository _repository;
    private readonly IAccountFactory _factory;
    private readonly IAccountReadService _readService;
    private readonly IPasswordHasher<Account> _passwordHasher;

    public CreateAdminHandler(IAccountRepository repository, IAccountFactory factory, IAccountReadService readService, IPasswordHasher<Account> passwordHasher)
    {
        _repository = repository;
        _factory = factory;
        _readService = readService;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Result> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        if (await _readService.CheckUnique(request.Email))
        {
            return Result.Failure(AccountErrors.EmailTaken);
        }

        var admin = _factory.CreateAdmin(request.Email, request.Password, _passwordHasher);

        await _repository.AddAsync(admin);

        return Result.Success();
    }
}