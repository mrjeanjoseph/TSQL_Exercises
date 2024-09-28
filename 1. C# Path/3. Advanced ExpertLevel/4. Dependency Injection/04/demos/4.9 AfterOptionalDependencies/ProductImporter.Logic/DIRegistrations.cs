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

        services.AddSingleton<IImportStatistics, ImportStatistics>();

        // THIS IS THE CODE FROM THE FIRST EXAMPLE IN THIS CLIP
        // 
        // services.AddTransient<IProductTransformer, ProductTransformer>();

        services.AddTransient<IProductTransformer>((sp) =>
        {
            return null;
        });


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
