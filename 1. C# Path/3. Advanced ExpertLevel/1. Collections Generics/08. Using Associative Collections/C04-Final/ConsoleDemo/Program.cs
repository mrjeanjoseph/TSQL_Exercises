try
{
    MoneyBag[] bags = new MoneyBag[7];
    for (int i = 0; i < bags.Length; i++)
        bags[i] = MoneyBag.Empty;

    int target = 0;
    foreach (Money money in Moneys.TestData.Take(10_000))
    {
        bags[target] = bags[target].Add(money);
        target = (target + 1) % bags.Length;
    }

    foreach (MoneyBag bag in bags)
        Console.WriteLine(bag);
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}