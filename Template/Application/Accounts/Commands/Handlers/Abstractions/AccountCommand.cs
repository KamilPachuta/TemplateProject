using Domain.Shared;
using MediatR;

namespace Application.Accounts.Commands.Handlers.Abstractions;

public record AccountCommand(Guid Id) : IRequest<Result>;