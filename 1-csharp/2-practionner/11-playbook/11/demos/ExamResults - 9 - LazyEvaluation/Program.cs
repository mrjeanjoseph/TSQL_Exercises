using Pluralsight.CShPlaybook.LinqDemos;

Console.WriteLine("Setting up the query...");
var students = ResultsRepository
	.EnumStudents()
	.Take(3)
	.Throttle()
	.Log()
	.OrderBy(student => student.Name);


Console.WriteLine("Displaying the results...");
foreach (Student student in students)
	Console.WriteLine("Outputting student: " + student);

Console.WriteLine("\r\nDisplaying the results (2nd time)...");
foreach (Student student in students)
	Console.WriteLine("Outputting student: " + student);