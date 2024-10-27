namespace Pluralsight.CShPlaybook.Oop;

public interface IPhotoProvider
{
	Image? GetPhoto();
}

public class ModelPhotoProvider : IPhotoProvider
{
	private Image? _photo;

	public ModelPhotoProvider(string fileName)
	{
		string filePath = DataFileFinder.GetFilePath(fileName);
		if (File.Exists(filePath))
			_photo = Image.FromFile(filePath);
	}

	public Image? GetPhoto() => _photo;
}

