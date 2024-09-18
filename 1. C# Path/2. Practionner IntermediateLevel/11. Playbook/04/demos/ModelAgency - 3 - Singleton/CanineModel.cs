namespace Pluralsight.CShPlaybook.Oop;

public class CanineModel : ModelBase
{
	public string CompanionHuman { get; }

	public CanineModel (int id, string name, string companionHuman)
		: base (id, name, MakePhotoFileName(id, name))
	{		
		CompanionHuman = companionHuman;
	}

	private static string MakePhotoFileName(int id, string name) => $"Dog_{id}_{name}.jpg";
}

