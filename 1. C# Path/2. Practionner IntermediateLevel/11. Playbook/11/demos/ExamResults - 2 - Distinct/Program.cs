using Pluralsight.CShPlaybook.LinqDemos;

var rawResults = ResultsRepository.EnumResults();

IEnumerable<ExamResult> results = from result in rawResults.Distinct(ExamResultEqualityComparer.Instance)
								  orderby result.StudentId, result.Subject
								  select result;

foreach (ExamResult result in results)
	Console.WriteLine(result);

