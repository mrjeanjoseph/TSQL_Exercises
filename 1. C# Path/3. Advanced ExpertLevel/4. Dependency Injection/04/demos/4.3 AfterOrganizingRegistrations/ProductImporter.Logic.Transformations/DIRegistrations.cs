using Microsoft.Extensions.DependencyInjection;
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
        services.AddScoped<INameDecapitaliser, NameDecapitaliser>();

        if (options.EnableCurrencyNormalizer)
        {
            services.AddScoped<ICurrencyNormalizer, CurrencyNormalizer>();
        }
        else
        {
            services.AddScoped<ICurrencyNormalizer, NullCurrencyNormalizer>();
        }

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IReferenceAdder, ReferenceAdder>();
        services.AddScoped<IReferenceGenerator, ReferenceGenerator>();
        services.AddSingleton<IIncrementingCounter, IncrementingCounter>();

        return services;
    }
}
