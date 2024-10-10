using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Pluralsight.CShPlaybook.AttribsReflection;

internal static class TextGenHelper
{
    internal static string GetPropertyValueList(object instanceToCheck)
    {
        Type type = instanceToCheck.GetType();
        PropertyInfo[] props = type.GetProperties(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

        StringBuilder sb = new StringBuilder();
        foreach (PropertyInfo prop in props)
            sb.AppendLine($"{prop.Name}: {prop.GetValue(instanceToCheck)?.ToString()}");
        return sb.ToString();
    }

    internal static string GetFriendlyText<T>(T value) where T : Enum
    {
        Type type = value.GetType();
        FieldInfo? memberInfo = type.GetField(value.ToString());
        object[]? attribs = memberInfo?.GetCustomAttributes(typeof(FriendlyTextAttribute), false);
        if (attribs == null || attribs.Length == 0)
            return value.ToString();
        var attrib = (FriendlyTextAttribute)attribs[0];
        return attrib.FriendlyText;
    }
	
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

