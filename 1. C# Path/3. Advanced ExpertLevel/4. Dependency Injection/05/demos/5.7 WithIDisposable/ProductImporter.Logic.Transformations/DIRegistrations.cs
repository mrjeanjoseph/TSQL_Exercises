using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using ProductImporter.Logic.Transformation.Util;
using ProductImporter.Logic.Transformations;
using ProductImporter.Transformations;

namespace ProductImporter.CompositionRoot;

public static class DIRegistrations
{
    public static IServiceCollection RegisterProductTransformations(this IServiceCollection services, Action<ProductTransformationOptions> optionsProvider)
    {
        var options = new ProductTransformationOptions();
        optionsProvider(options);

        services.AddScoped<IProductTransformationContext, ProductTransformationContext>();
        services.AddScoped<IProductTransformation, NameDecapitaliser>();
        services.AddTransient<IProductTransformation, DisposableProductTransformation>();

        if (options.EnableCurrencyNormalizer)
        {
            services.AddScoped<IProductTransformation, CurrencyNormalizer>();
        }
        else
        {
            services.AddScoped<IProductTransformation, NullCurrencyNormalizer>();
        }

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IProductTransformation, ReferenceAdder>();
        services.AddScoped<IReferenceGeneratorFactory, ReferenceGeneratorFactory>();
        services.AddSingleton<IIncrementingCounter, IncrementingCounter>();

        return services;
    }
}
