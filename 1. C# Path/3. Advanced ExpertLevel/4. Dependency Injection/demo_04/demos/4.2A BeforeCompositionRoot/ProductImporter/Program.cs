using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Source;
using ProductImporter.Logic.Target;
using ProductImporter.Logic.Transformation;
using ProductImporter.Logic.Transformations;
using ProductImporter.Logic.Transformation.Util;

using ProductImporter.Transformations;

using var host = Host.CreateDefaultBuilder(args)
    .UseDefaultServiceProvider((context, options) => {
        options.ValidateScopes = true;
    })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<Configuration>();

        services.AddTransient<IPriceParser, PriceParser>();
        services.AddTransient<IProductSource, ProductSource>();

        services.AddTransient<IProductFormatter, ProductFormatter>();
        services.AddTransient<IProductTarget, CsvProductTarget>();

        services.AddTransient<ProductImporter.Logic.ProductImporter>();

        services.AddSingleton<IImportStatistics, ImportStatistics>();

        services.AddTransient<IProductTransformer, ProductTransformer>();

        services.AddScoped<IProductTransformationContext, ProductTransformationContext>();
        services.AddScoped<INameDecapitaliser, NameDecapitaliser>();
        services.AddScoped<ICurrencyNormalizer, CurrencyNormalizer>();

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IReferenceAdder, ReferenceAdder>();
        services.AddScoped<IReferenceGenerator, ReferenceGenerator>();
        services.AddSingleton<IIncrementingCounter, IncrementingCounter>();
    })
    .Build();

var productImporter = host.Services.GetRequiredService<ProductImporter.Logic.ProductImporter>();

productImporter.Run();