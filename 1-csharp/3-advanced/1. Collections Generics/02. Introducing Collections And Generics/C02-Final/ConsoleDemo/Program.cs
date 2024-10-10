try
{
    foreach (Worker worker in Workers.TestData)
        Console.WriteLine($"{worker} --");
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}