using System.Text;
using Application;
using Application.Behaviors;
using Domain;
using Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Web_Api;

public static class Extensions
{
    public static IServiceCollection AddAuthenticationSettings(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var authenticationSettings = new AuthenticationSettings();
        configuration.GetSection("Authentication").Bind(authenticationSettings);

        //Authentication
        services.AddSingleton(authenticationSettings);
        
        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = "Bearer";
            option.DefaultScheme = "Bearer";
            option.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authenticationSettings.JwtIssuer,
                ValidAudience = authenticationSettings.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))

            };
        });
        
        return services;
    }


    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddCarter();
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            cfg.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });
        
        
        services.AddAuthenticationSettings(configuration);

        services.AddAuthorization();
        
        services.AddHttpContextAccessor();

        // services.AddScoped<IUserService, UserService>();
        
        // services.AddValidatorsFromAssembly(typeof(Extensions).Assembly);
        
        return services;
    }
    
    public static ConfigureHostBuilder AddSerilog(this ConfigureHostBuilder host)
    {
        host.UseSerilog((context, loggerConfig) => 
            loggerConfig.ReadFrom.Configuration(context.Configuration));
        
        return host;
    }
    
    public static IServiceCollection AddProject(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDomain();
        services.AddApplication();
        services.AddInfrastructure(configuration);
        services.AddApi(configuration);
        
        return services;
    }
}