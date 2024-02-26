using Domain.Accounts.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IAccountFactory, AccountFactory>();

        return services;
    }
}