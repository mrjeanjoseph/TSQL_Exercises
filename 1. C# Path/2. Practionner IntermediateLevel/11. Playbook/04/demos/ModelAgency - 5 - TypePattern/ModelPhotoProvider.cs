namespace Pluralsight.CShPlaybook.Oop;

public interface IPhotoProvider
{
	Image? GetPhoto();
}

public class ModelPhotoProvider : IPhotoProvider
{
	private Lazy<Image?> _photo;
	private string _filePath;

	private ModelPhotoProvider(string fileName)
	{
		_filePath = DataFileFinder.GetFilePath(fileName);
		_photo = new Lazy<Image?>(() => File.Exists(_filePath) ? Image.FromFile(_filePath) : null);
	}

	public Image? GetPhoto() => _photo.Value;


	public static class PhotoProviderFactory
	{
		public static IPhotoProvider Create(string fileName)
		{
			string filePath = DataFileFinder.GetFilePath(fileName);
			if (File.Exists(filePath))
				return new ModelPhotoProvider(fileName);
			else
				return MissingPhotoProvider.Instance;
		}
	}
}

