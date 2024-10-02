using Autofac;
using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic;
using ProductImporter.Logic.Transformations;

namespace ProductImporter.CompositionRoot
{
    public static class CompositionRoot
    {
        public static IServiceCollection ComposeApplication(this IServiceCollection services)
        {
            services.RegisterProductImporterLogic();

            return services;
        }

        public static ContainerBuilder ComposeApplication(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new ProductImporterTransformationsModule((options) =>
            {
                options.EnableCurrencyNormalizer = false;
            }));

            return containerBuilder;
        }
    }
}