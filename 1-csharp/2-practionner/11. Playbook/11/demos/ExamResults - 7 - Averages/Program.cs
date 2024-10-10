using Pluralsight.CShPlaybook.LinqDemos;

var results = ResultsRepository.EnumResults().Distinct(ExamResultEqualityComparer.Instance);
var students = ResultsRepository.EnumStudents();

IEnumerable<(Student, double)> studentAverages =
	from student in students
	join result in results on student.AnonymousId equals result.StudentId
	into resultsByStudent
	let avg = resultsByStudent.Average(x => x.Mark)
	orderby avg descending
	select (student, avg);


foreach ((Student student, double avg) in studentAverages)
	Console.WriteLine($"{student.Name.PadRight(10)}: {avg:##.#}%");