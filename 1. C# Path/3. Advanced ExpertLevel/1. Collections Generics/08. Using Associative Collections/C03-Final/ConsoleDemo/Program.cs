try
{
    MoneyBag[] bags = new MoneyBag[7];
    for (int i = 0; i < bags.Length; i++)
        bags[i] = new();

    int target = 0;
    foreach (Money money in Moneys.TestData.Take(10_000))
        bags[target++ % bags.Length].Add(money);

    foreach (MoneyBag bag in bags)
        Console.WriteLine(bag);
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}