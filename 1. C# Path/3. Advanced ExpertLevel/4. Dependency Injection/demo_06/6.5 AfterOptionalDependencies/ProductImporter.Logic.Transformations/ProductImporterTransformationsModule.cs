using Autofac;
using ProductImporter.CompositionRoot;
using ProductImporter.Logic.Transformation.Util;
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

        builder.RegisterType<ProductTransformationContext>().As<IProductTransformationContext>().InstancePerLifetimeScope();
        builder.RegisterType<NameDecapitaliser>().As<IProductTransformation>().InstancePerLifetimeScope();
        builder.RegisterType<DisposableProductTransformation>().As<IProductTransformation>().InstancePerDependency();

        if (options.EnableCurrencyNormalizer)
        {
            builder.RegisterType<CurrencyNormalizer>().As<IProductTransformation>().InstancePerLifetimeScope();
        }
        else
        {
            builder.RegisterType<NullCurrencyNormalizer>().As<IProductTransformation>().InstancePerLifetimeScope();
        }

        builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>().InstancePerLifetimeScope();
        builder.RegisterType<ReferenceAdder>().As<IProductTransformation>().InstancePerLifetimeScope().PropertiesAutowired();
        builder.RegisterType<ReferenceGeneratorFactory>().As<IReferenceGeneratorFactory>().InstancePerLifetimeScope();
        builder.RegisterType<IncrementingCounter>().As<IIncrementingCounter>().SingleInstance();
    }
}
