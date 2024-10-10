namespace Pluralsight.CShPlaybook.Generics
{
	public class Course : ProductBase<Course>
	{
		public string Title { get; init; }
		public string Author { get; init; }
		public Course(string author, string title)
		{
			this.Author = author;
			this.Title = title;
		}
	}
}
