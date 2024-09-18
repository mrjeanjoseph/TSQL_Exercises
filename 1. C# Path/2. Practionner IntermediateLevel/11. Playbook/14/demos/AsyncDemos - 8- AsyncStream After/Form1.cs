namespace Pluralsight.CShPlaybook.AsyncDemo;

public partial class Form1 : Form
{
	public Form1()
	{
		InitializeComponent();
	}

	private async void btnSearchForLinq_Click(object sender, EventArgs e)
	{
		try
		{
			// disable this button etc. while we are working
			this.btnSearchForLinq.Enabled = false;
			this.lbxCoursesWithLinq.Items.Clear();
			this.lbxCoursesNoLinq.Items.Clear();
			this.lblSearchStatus.Text = "Searching for courses...";

			List<PsCourseInfo> courseList = PsCourseInfoParser.LoadCourseInfoDataFromFileName("courses.txt");
			CourseSearcher searcher = new CourseSearcher();

			Progress<SearchResult> progress = new( (result)=>DisplaySearchResult(result) );
            List<Task<SearchResult>> tasks = new();
            foreach (var course in courseList)
            {
                Task<SearchResult> task = searcher.LoadAndSearchPageAsync(course, progress);
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
        }
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			this.lblSearchStatus.Text = null;
			this.btnSearchForLinq.Enabled = true;
		}
	}

	public void DisplaySearchResult(SearchResult result)
	{
		if (!result.IsSuccess)
			return;
		if (result.ContainsLinq)
			this.lbxCoursesWithLinq.Items.Add(result.Course.Name);
		else
			this.lbxCoursesNoLinq.Items.Add(result.Course.Name);
	}


	private void btnLoadCourseNames_Click(object sender, EventArgs e)
	{
		try
		{
			// disable this button etc. while we are working
			this.btnLoadCourseNames.Enabled = false;
			this.lbxCourses.Items.Clear();
			this.lblLoadStatus.Text = "Loading courses...";

			string filePath = DataFileFinder.GetFilePath("courses.txt");

			foreach (string file in SlowFileReader.ReadFileSlow(filePath))
			{
				this.lbxCourses.Items.Add(file);
				this.lbxCourses.Refresh();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			this.lblLoadStatus.Text = null;
			this.btnLoadCourseNames.Enabled = true;
		}

	}
}
