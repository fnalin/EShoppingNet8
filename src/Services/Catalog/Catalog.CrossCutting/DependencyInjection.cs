using System.Reflection;
using Catalog.Core.Contracts.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddApplication();
        
        return services;
    }
    
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddScoped<ICatalogContext, CatalogContext>();
        services.AddScoped<IBrandRepository, ProductRepository>();
        services.AddScoped<ITypeRepository, ProductRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        
        
        // var connString = configuration.GetConnectionString("DefaultConnection");
        //
        // services.AddDbContext<StoreDbContext>(options =>
        //     options.UseMySql(connString, ServerVersion.AutoDetect(connString))
        // );
        
    }
    
    private static void AddApplication(this IServiceCollection services)
    {
        var assemblyString = "Catalog.Application";
        var myHandlers = AppDomain.CurrentDomain.Load(assemblyString);
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(myHandlers);
            //config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        //services.AddValidatorsFromAssembly(Assembly.Load(assemblyString));
    }
}