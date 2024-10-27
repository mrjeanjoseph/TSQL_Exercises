namespace Pluralsight.CShPlaybook.Oop;

public interface IPhotoProvider
{
	Image? GetPhoto();
}

public class ModelPhotoProvider : IPhotoProvider
{
	private Lazy<Image?> _photo;
	private string _filePath;

	public ModelPhotoProvider(string fileName)
	{
		_filePath = DataFileFinder.GetFilePath(fileName);
		_photo = new Lazy<Image?>(() => File.Exists(_filePath) ? Image.FromFile(_filePath) : null);
	}

	public Image? GetPhoto() => _photo.Value;

}

