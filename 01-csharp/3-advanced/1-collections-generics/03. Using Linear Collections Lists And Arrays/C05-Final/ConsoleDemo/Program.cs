try
{
    Workers.TestData.ToGrid(120, 2).WriteLines();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}
