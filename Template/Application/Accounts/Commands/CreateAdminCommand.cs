using Domain.Shared;
using MediatR;

namespace Application.Accounts.Commands;

public record CreateAdminCommand(string Email, string Password) : IRequest<Result>;