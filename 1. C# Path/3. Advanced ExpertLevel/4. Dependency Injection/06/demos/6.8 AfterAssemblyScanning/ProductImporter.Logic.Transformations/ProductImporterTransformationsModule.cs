using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ProductImporter.CompositionRoot;
using ProductImporter.Logic.Transformation.Util;
using ProductImporter.Logic.Transformations.Util;
using ProductImporter.Transformations;

namespace ProductImporter.Logic.Transformations;

public class ProductImporterTransformationsModule : Module
{
    private readonly Action<ProductTransformationOptions> _optionsProvider;

    public ProductImporterTransformationsModule(Action<ProductTransformationOptions> optionsProvider)
    {
        _optionsProvider = optionsProvider;
    }

    protected override void Load(ContainerBuilder builder)
    {
        var options = new ProductTransformationOptions();
        _optionsProvider(options);

        builder
            .RegisterAssemblyTypes(typeof(ProductImporterTransformationsModule).Assembly)
            .Where(x => x.IsAssignableTo<IProductTransformation>())
            .InstancePerLifetimeScope()
            .PropertiesAutowired()
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(SystemOutLogger));

        builder
            .RegisterType<ProductTransformationContext>()
            .As<IProductTransformationContext>()
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(SystemOutLogger));

        builder
            .RegisterType<DateTimeProvider>()
            .As<IDateTimeProvider>()
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(SystemOutLogger));

        builder
            .RegisterType<ReferenceGeneratorFactory>()
            .As<IReferenceGeneratorFactory>()
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(SystemOutLogger));

        builder
            .RegisterType<IncrementingCounter>()
            .As<IIncrementingCounter>()
            .SingleInstance()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(SystemOutLogger));

        builder.Register(_ => new SystemOutLogger());
    }
}