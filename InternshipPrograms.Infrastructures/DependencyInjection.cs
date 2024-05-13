 
namespace InternshipPrograms.Infrastructures;
public static class DependencyInjection
{
    public static IServiceCollection AddDataDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var accountEndpoint = configuration.GetSection("CosmosDb:Account").Value;
        var databaseName = configuration.GetSection("CosmosDb:DatabaseName").Value;
        var key = configuration.GetSection("CosmosDb:Key").Value;
        //services.AddDbContext<DataContext>(options =>
        //      options.UseCosmos(accountEndpoint, key, databaseName
        // ));
        services.AddDbContextPool<DataContext>(options =>
        options.UseCosmos(accountEndpoint, key, databaseName));
        services.AddSingleton(configuration); 
        return services;
    }
}
