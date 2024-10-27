using Pluralsight.CShPlaybook.LinqDemos;

IEnumerable<IEnumerable<ExamResult>> resultsByStudent = GroupByStudent();

IEnumerable<ExamResult> flatResults = from grouping in resultsByStudent
									  from result in grouping
									  orderby result.StudentId, result.Subject
									  select result;


foreach (ExamResult result in flatResults)
	Console.WriteLine(result);


static IEnumerable<IEnumerable<ExamResult>> GroupByStudent()
{
	var resultsDistinct = ResultsRepository.EnumResults().Distinct(ExamResultEqualityComparer.Instance);

	IEnumerable<IGrouping<int, ExamResult>> resultsByStudent =
		from result in resultsDistinct
		group result by result.StudentId;
	return resultsByStudent;
}