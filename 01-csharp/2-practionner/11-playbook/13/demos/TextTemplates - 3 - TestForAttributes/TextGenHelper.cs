using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Pluralsight.CShPlaybook.AttribsReflection;

internal static class TextGenHelper
{
	internal static bool CanDisplayProduct(Product product)
	{
		Type type = product.GetType();
		object[] attribs = type.GetCustomAttributes(typeof(ActualProductAttribute), false);
		if (attribs.Length == 0)
			return false;
		Debug.Assert(attribs.Length == 1);
		var attrib = (ActualProductAttribute)attribs[0];
		return attrib.CanUseInTemplate;
	}
}

