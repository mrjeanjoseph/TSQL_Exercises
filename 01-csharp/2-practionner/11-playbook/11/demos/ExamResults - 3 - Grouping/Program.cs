using Pluralsight.CShPlaybook.LinqDemos;

var resultsDistinct = ResultsRepository.EnumResults().Distinct(ExamResultEqualityComparer.Instance);

var resultsByStudent =
	from result in resultsDistinct
	orderby result.StudentId, result.Subject
	group result by result.StudentId;

foreach (IGrouping<int, ExamResult> resultGroup in resultsByStudent)
{
	Console.WriteLine($"Student {resultGroup.Key}:");
	foreach (var result in resultGroup)
		Console.WriteLine($@"  {result.Mark:##}% in {result.Subject}");
}

Console.ReadLine(); // prevent VS Code external console terminating
