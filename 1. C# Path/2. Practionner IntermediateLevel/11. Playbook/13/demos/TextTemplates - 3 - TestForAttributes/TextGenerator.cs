namespace Pluralsight.CShPlaybook.AttribsReflection;

public class TextGenerator
{
	private readonly string _template;

	public TextGenerator(string template)
	{
		_template = template;
	}

    public string GenerateTextV2(Product product)
    {
        if (!TextGenHelper.CanDisplayProduct(product))
            throw new ArgumentException($"{product.GetType().Name} cannot be used in the text template");

        return _template
            .Replace("[[Name]]", product.Name)
            .Replace("[[Status]]", product.Status.ToString())
            .Replace("[[Price]]", $"${product.Price:#.00}")
            .Replace("[[FeatureList]]", "Please enquire for details");
    }

    [Obsolete(@"Please use GenerateTextV2, which uses ""[[...]]"" instead of ""(...)"" to delimit text substitutions")]
    public string GenerateText(Product product)
	{
		
		return _template
			.Replace("(Name)", product.Name)
			.Replace("(Status)", product.Status.ToString())
			.Replace("(Price)", $"${product.Price:#.00}")
			.Replace("(FeatureList)", "Please enquire for details");			
	}
}
