using Microsoft.Extensions.DependencyInjection;

namespace ProductImporter.Logic.Transformation.Util;

public class ReferenceGeneratorFactory : IReferenceGeneratorFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ReferenceGeneratorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IReferenceGenerator CreateReferenceGenerator(string prefix)
    {
        return new ReferenceGenerator(
            _serviceProvider.GetRequiredService<IDateTimeProvider>(),
            _serviceProvider.GetRequiredService<IIncrementingCounter>(),
            prefix);
    }
}