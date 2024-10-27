namespace Pluralsight.CShPlaybook.AsyncDemo;

public class CourseSearcher
{
    private static readonly HttpClient _client = new HttpClient();
    private static Random rnd = new Random();

    DownloadedPages _downloadedPages = new();

    public async Task<SearchResult> LoadAndSearchPageAsync(
        PsCourseInfo course, IProgress<SearchResult> progress)
    {
        try
        {
            // Download the page from Pluralsight. This is an IO-bound task
            string pageBody = await _client.GetStringAsync(course.Url);

            // figure out if the downloaded text contains LINQ. This is a cpu-bound task
            bool containsLinq = await Task.Run(()=>SearchForLinq(course.Name, pageBody));

            var result = new SearchResult(course, containsLinq, true);
            progress.Report(result);
            return result;
        }
        catch (Exception)
        {
            return new SearchResult(course, false, false);
        }
    }

    public bool SearchForLinq(string courseName, string pageBody)
	{
        _downloadedPages.Add(courseName, pageBody);
        // simulate it taking lots of CPU time to process each result
        // (random time up to 10 seconds)
        Thread.Sleep(rnd.Next(10000));
        return pageBody.Contains("LINQ");
    }
}
