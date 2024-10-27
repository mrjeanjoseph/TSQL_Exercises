namespace Pluralsight.CShPlaybook.Oop
{
	public class MissingPhotoProvider : IPhotoProvider
	{
		private Lazy<Image> _missingPhotoImage;

		public static MissingPhotoProvider Instance { get; } = new ();

		private MissingPhotoProvider()
		{
			string filePath = DataFileFinder.GetFilePath("Missing.jpg");
			_missingPhotoImage = new Lazy<Image>(() => Image.FromFile(filePath));
		}

		public Image GetPhoto() => _missingPhotoImage.Value;
	}

}
