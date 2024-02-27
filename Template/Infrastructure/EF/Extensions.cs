using Domain.Accounts;
using Domain.Shared;
using Infrastructure.EF.Configurations;
using Infrastructure.EF.Context;
using Infrastructure.Postgres;
using Infrastructure.EF.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EF;

public static class Extensions
{
    public static ModelBuilder AddEFConfig(this ModelBuilder modelBuilder)
    {
        var accountConfiguration = new AccountConfiguration();
        modelBuilder.ApplyConfiguration<Account>(accountConfiguration);
        
        return modelBuilder;
    }

    public static IServiceCollection AddEF(this IServiceCollection services, IConfiguration configuration)
    {
        var postgresOptions = new PostgresOptions();
        configuration.GetSection("Postgres").Bind(postgresOptions);
        
        services.AddDbContext<WriteDbContext>(ctx =>
            ctx.UseNpgsql(postgresOptions.ConnectionString));
        
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        
        // services.AddScoped<IAccountRepository, AccountRepository>();
        //
        // services.AddScoped<IAccountReadService, AccountReadService>();

        return services;
    }
}