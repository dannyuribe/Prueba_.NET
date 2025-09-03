using MarcasAutos.Application.Interfaces.Infrastructure.Mappings;
using MarcasAutos.Application.Interfaces.Infrastructure.Repositories;
using MarcasAutos.Infrastructure.Mappings;
using MarcasAutos.Infrastructure.Persistence;
using MarcasAutos.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutos.Infrastructure.Extensions;

internal static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var defaultSchema = configuration.GetSection("Database")["Schema"] ?? "public";

        services.AddDbContext<AutosMarcasDbContext>(options =>
        {
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.MigrationsAssembly(typeof(AutosMarcasDbContext).Assembly.FullName);
                npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", defaultSchema);
            });
        });

        return services;
    }
    public static IServiceCollection AddInfrastructureMappers(this IServiceCollection services)
    {
        services.AddScoped<IAutoMarcasMapper, AutoMarcasMapper>();
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IAutosMarcasRepository, AutoMarcasAdapter>();

        return services;
    }
}
