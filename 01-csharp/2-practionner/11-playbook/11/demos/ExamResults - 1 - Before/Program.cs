using Pluralsight.CShPlaybook.LinqDemos;

IEnumerable<ExamResult> results = 
	from result in ResultsRepository.EnumResults()
    orderby result.StudentId, result.Subject
    select result;

foreach (ExamResult result in results)
	Console.WriteLine(result);
	
Console.ReadLine(); // prevent VS Code external console terminating

