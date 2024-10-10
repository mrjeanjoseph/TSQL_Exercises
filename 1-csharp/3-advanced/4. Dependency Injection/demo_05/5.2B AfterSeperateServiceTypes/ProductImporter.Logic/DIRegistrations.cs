using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Source;
using ProductImporter.Logic.Target;
using ProductImporter.Logic.Transformation;

namespace ProductImporter.Logic;

public static class DIRegistrations
{
    public static IServiceCollection RegisterProductImporterLogic(this IServiceCollection services)
    {
        services.AddTransient<IPriceParser, PriceParser>();
        services.AddHttpClient<IProductSource, HttpProductSource>()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("https://raw.githubusercontent.com/henrybeen/");
            });

        services.AddTransient<IProductFormatter, ProductFormatter>();
        services.AddTransient<IProductTarget, CsvProductTarget>();

        services.AddTransient<Logic.ProductImporter>();

        services.AddSingleton<ImportStatistics>();
        
        services.AddSingleton<IGetImportStatistics>((serviceProvider) =>
        {
            return serviceProvider.GetRequiredService<ImportStatistics>();
        });

        services.AddSingleton<IWriteImportStatistics>((serviceProvider) =>
        {
            return serviceProvider.GetRequiredService<ImportStatistics>();
        });

        services.AddTransient<IProductTransformer, ProductTransformer>();

        services.AddOptions<CsvProductSourceOptions>()
            .Configure<IConfiguration>((options, configuration) =>
            {
                configuration.GetSection(CsvProductSourceOptions.SectionName).Bind(options);
            });

        services.AddOptions<CsvProductTargetOptions>()
            .Configure<IConfiguration>((options, configuration) =>
            {
                configuration.GetSection(CsvProductTargetOptions.SectionName).Bind(options);
            });

        return services;
    }
}
