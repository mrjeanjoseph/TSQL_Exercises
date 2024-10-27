using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Module2.DIApplied;
using Module2.DIApplied.Shared;
using Module2.DIApplied.Source;
using Module2.DIApplied.Target;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddTransient<Configuration>();

        services.AddTransient<IPriceParser, PriceParser>();
        services.AddTransient<IProductSource, ProductSource>();

        services.AddTransient<IProductFormatter, ProductFormatter>();
        services.AddTransient<IProductTarget, ProductTarget>();

        services.AddTransient<ProductImporter>();
    })
    .Build();

var productImporter = host.Services.GetRequiredService<ProductImporter>();

productImporter.Run();