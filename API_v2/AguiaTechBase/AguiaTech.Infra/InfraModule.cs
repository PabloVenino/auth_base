using AguiaTech.Application.Abstractions;
using AguiaTech.Infra.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace AguiaTech.Infra;

public static class InfraModule
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
        
        return services;
    }
}   