using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductImporter.Shared;
using ProductImporter.Source;
using ProductImporter.Target;
using ProductImporter.Target.EntityFramework;
using ProductImporter.Transformation;
using ProductImporter.Transformation.Transformations;
using ProductImporter.Util;
using Microsoft.EntityFrameworkCore;

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
        services.AddTransient<IProductTarget, SqlProductTarget>();

        services.AddTransient<ProductImporter.ProductImporter>();

        services.AddSingleton<IImportStatistics, ImportStatistics>();

        services.AddTransient<IProductTransformer, ProductTransformer>();

        services.AddScoped<IProductTransformationContext, ProductTransformationContext>();
        services.AddScoped<INameDecapitaliser, NameDecapitaliser>();
        services.AddScoped<ICurrencyNormalizer, CurrencyNormalizer>();

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IReferenceAdder, ReferenceAdder>();
        services.AddScoped<IReferenceGenerator, ReferenceGenerator>();
        services.AddSingleton<IIncrementingCounter, IncrementingCounter>();

        services.AddDbContext<TargetContext>(options =>
                options.UseSqlServer(context.Configuration["TargetContextConnectionString"]));
    })
    .Build();

var productImporter = host.Services.GetRequiredService<ProductImporter.ProductImporter>();

productImporter.Run();