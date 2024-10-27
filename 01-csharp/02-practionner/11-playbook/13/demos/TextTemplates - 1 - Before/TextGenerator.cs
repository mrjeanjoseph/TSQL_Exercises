namespace Pluralsight.CShPlaybook.AttribsReflection;

public class TextGenerator
{
	private readonly string _template;

	public TextGenerator(string template)
	{
		_template = template;
	}
	
	public string GenerateText(Product product)
	{
		return _template
			.Replace("(Name)", product.Name)
			.Replace("(Status)", product.Status.ToString())
			.Replace("(Price)", $"${product.Price:#.00}")
			.Replace("(FeatureList)", "Please enquire for details");			
	}
}
