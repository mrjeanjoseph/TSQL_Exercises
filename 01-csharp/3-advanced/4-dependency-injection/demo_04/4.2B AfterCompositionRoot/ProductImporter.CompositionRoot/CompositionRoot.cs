using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Source;
using ProductImporter.Logic.Target;
using ProductImporter.Logic.Transformation;
using ProductImporter.Logic.Transformation.Util;
using ProductImporter.Logic.Transformations;
using ProductImporter.Transformations;

namespace ProductImporter.CompositionRoot
{
    public static class CompositionRoot
    {
        public static IServiceCollection AddProductImporter(this IServiceCollection services)
        {
            services.AddSingleton<Configuration>();

            services.AddTransient<IPriceParser, PriceParser>();
            services.AddTransient<IProductSource, ProductSource>();

            services.AddTransient<IProductFormatter, ProductFormatter>();
            services.AddTransient<IProductTarget, CsvProductTarget>();

            services.AddTransient<Logic.ProductImporter>();

            services.AddSingleton<IImportStatistics, ImportStatistics>();

            services.AddTransient<IProductTransformer, ProductTransformer>();

            services.AddScoped<IProductTransformationContext, ProductTransformationContext>();
            services.AddScoped<INameDecapitaliser, NameDecapitaliser>();
            services.AddScoped<ICurrencyNormalizer, CurrencyNormalizer>();

            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IReferenceAdder, ReferenceAdder>();
            services.AddScoped<IReferenceGenerator, ReferenceGenerator>();
            services.AddSingleton<IIncrementingCounter, IncrementingCounter>();

            return services;
        }
    }
}