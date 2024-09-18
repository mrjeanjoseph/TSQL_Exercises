try
{
    Workers.TestData.ToGrid(120, 2).WriteLines();
    Console.WriteLine();

    using IEnumerator<Worker> shuffler = Workers.TestData.BeginShuffle();

    for (int i = 0; i < 5; i++)
    {
        shuffler.Iterate().Take(3).ToGrid(120, 3).WriteLines();
        shuffler.Reset();
    }
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}