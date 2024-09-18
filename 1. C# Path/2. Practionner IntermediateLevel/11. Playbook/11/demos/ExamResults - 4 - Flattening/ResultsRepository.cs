namespace Pluralsight.CShPlaybook.LinqDemos;

public class ResultsRepository
{
	public static IEnumerable<ExamResult> EnumResults()
	{
		yield return new ExamResult(5, "Biology", 55);
		yield return new ExamResult(1, "Physics", 90);
		yield return new ExamResult(1, "Chemistry", 68);
		yield return new ExamResult(1, "Chemistry", 68);
		yield return new ExamResult(4, "Biology", 52);
		yield return new ExamResult(5, "Chemistry", 84);
		yield return new ExamResult(3, "Chemistry", 76);
		yield return new ExamResult(1, "Biology", 55);
		yield return new ExamResult(3, "Biology", 81);
		yield return new ExamResult(4, "Physics", 35);
		yield return new ExamResult(5, "Physics", 63);
		yield return new ExamResult(2, "Biology", 52);
		yield return new ExamResult(2, "Biology", 52);
		yield return new ExamResult(3, "Physics", 55);
		yield return new ExamResult(5, "Physics", 63);
		yield return new ExamResult(1, "Chemistry", 68);
		yield return new ExamResult(5, "Chemistry", 84);
		yield return new ExamResult(2, "Chemistry", 57);
		yield return new ExamResult(2, "Physics", 89);
		yield return new ExamResult(4, "Chemistry", 37);
		yield return new ExamResult(4, "Biology", 52);
		yield return new ExamResult(5, "Chemistry", 84);
		yield return new ExamResult(5, "Biology", 55);
		yield return new ExamResult(1, "Chemistry", 68);
	}
}
