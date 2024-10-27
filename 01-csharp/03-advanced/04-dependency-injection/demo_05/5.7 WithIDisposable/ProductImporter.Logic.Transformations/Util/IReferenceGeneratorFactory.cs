namespace ProductImporter.Logic.Transformation.Util;

public interface IReferenceGeneratorFactory
{
    IReferenceGenerator CreateReferenceGenerator(string prefix);
}
