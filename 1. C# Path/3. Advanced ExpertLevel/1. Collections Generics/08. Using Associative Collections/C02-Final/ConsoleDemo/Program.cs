try
{
    MoneyBag bag = new(Moneys.TestData.Take(10_000));
    Console.WriteLine(bag);
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}