using Pluralsight.CShPlaybook.LinqDemos;

var students = ResultsRepository
	.EnumStudents()
	.Take(3)
	.Throttle()
	.Log()
	.OrderBy(x => x.Name)
	.ToList();

Console.WriteLine("\r\nDisplaying results:");
foreach (Student student in students)
	Console.WriteLine(student);

Console.ReadLine(); // prevent VS Code external console terminating
