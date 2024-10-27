namespace Pluralsight.CShPlaybook.LinqDemos;

public class ExamResult
{
	public int StudentId { get; }
	public int Mark { get; }
	public string Subject { get; }

	public ExamResult(int studentId, string subject, int mark)
	{
		StudentId = studentId;
		Mark = mark;
		Subject = subject;
	}

	public override string ToString() => $@"Student {StudentId}: {Mark:##}% in {Subject}";
}
