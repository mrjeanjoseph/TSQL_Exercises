using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic;

namespace ProductImporter.CompositionRoot
{
    public static class CompositionRoot
    {
        public static IServiceCollection ComposeApplication(this IServiceCollection services)
        {
            services.RegisterProductImporterLogic();
            services.RegisterProductTransformations((options) => { 
                options.EnableCurrencyNormalizer = false; 
            });

            return services;
        }
    }
}