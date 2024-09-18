namespace Pluralsight.CShPlaybook.AsyncDemo;

public class CourseSearcher
{
    private static readonly HttpClient _client = new HttpClient();
    private static Random rnd = new Random();

    public async Task<SearchResult> LoadAndSearchPageAsync(PsCourseInfo course)
    {
        try
        {
            // Download the page from Pluralsight. This is an IO-bound task
            string pageBody = await _client.GetStringAsync(course.Url);

            // figure out if the downloaded text contains LINQ. This is a cpu-bound task
            bool containsLinq = await Task.Run(()=>SearchForLinq(pageBody));

            return new SearchResult(course, containsLinq, true);
        }
        catch (Exception)
        {
            return new SearchResult(course, false, false);
        }
    }

    public bool SearchForLinq(string pageBody)
	{
        // simulate it taking lots of CPU time to process each result
        // (random time up to 10 seconds)
        Thread.Sleep(rnd.Next(10000));
        return pageBody.Contains("LINQ");
    }
}
