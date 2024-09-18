try
{
    IEnumerable<Worker> workers =
        Workers.TestData.Take(5).Replicate(2, .1F).BeginShuffle().Iterate().ToList();
    
    IEnumerable<Employee> employees = workers.Concat(
        workers.Take(5).Select(worker => new Employee(worker.Name)))
        .BeginShuffle().Iterate().ToList();

    List<Worker> items = new(workers);
    items.Sort(Worker.DefaultEmployeeComparer);
    items.ToGrid(120, 2).WriteLines();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}