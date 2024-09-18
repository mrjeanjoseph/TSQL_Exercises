namespace Pluralsight.CShPlaybook.Oop;

public class ModelBase
{
	public string Name { get; }
	public int Id { get; }
	public IPhotoProvider PhotoProvider { get; }

	public ModelBase(int id, string name, string photoFileName)
	{
		Id = id;
		Name = name;
		PhotoProvider = new ModelPhotoProvider(photoFileName);
	}

	public override string ToString() => Name;
}
