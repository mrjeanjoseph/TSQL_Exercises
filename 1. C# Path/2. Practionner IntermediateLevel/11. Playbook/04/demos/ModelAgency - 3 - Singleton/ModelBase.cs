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
		if (File.Exists(DataFileFinder.GetFilePath(photoFileName)))
			PhotoProvider = new ModelPhotoProvider(photoFileName);
		else
			PhotoProvider = MissingPhotoProvider.Instance;
	}

	public override string ToString() => Name;
}
