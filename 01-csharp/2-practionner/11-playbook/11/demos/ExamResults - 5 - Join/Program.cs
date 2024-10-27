using Pluralsight.CShPlaybook.LinqDemos;

var students = ResultsRepository.EnumStudents();
var results = ResultsRepository.EnumResults().Distinct(ExamResultEqualityComparer.Instance);

IEnumerable<(Student student, ExamResult result)> studentResults =
	from Student student in students
	join ExamResult result in results on student.AnonymousId equals result.StudentId
	orderby student.Name, result.Subject
	select (student, result);

foreach ((Student student, ExamResult result) in studentResults)
	Console.WriteLine($"{student.Name.PadRight(10)}: {result.Mark:##}% in {result.Subject}");


Console.ReadLine(); // prevent VS Code external console terminating
