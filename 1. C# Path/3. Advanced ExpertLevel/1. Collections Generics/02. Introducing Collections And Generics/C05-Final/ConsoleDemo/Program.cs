try
{
    IEnumerable<Worker> data = Workers.TestData;

    int[] colWidths = GetColumnWidths(data, 4);
    foreach (string row in FormatGridRows(data, colWidths))
        Console.WriteLine(row);
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}

int[] GetColumnWidths(IEnumerable<Worker> data, int columnsCount)
{
    int[] colWidths = new int[columnsCount];
    int colIndex = 0;
    foreach (Worker item in data)
    {
        colWidths[colIndex] = Math.Max(item.ToString().Length, colWidths[colIndex]);
        colIndex = (colIndex + 1) % columnsCount;
    }
    return colWidths;
}

IEnumerable<string> FormatGridRows(IEnumerable<Worker> data, int[] colWidths)
{
    StringBuilder row = new();
    int colIndex = 0;
    foreach (Worker item in data)
    {
        row.Append(item.ToString().PadRight(colWidths[colIndex] + 2));
        colIndex = (colIndex + 1) % colWidths.Length;
        if (colIndex == 0)
        {
            yield return row.ToString().TrimEnd();
            row.Clear();
        }
    }
    if (row.Length > 0) yield return row.ToString().TrimEnd();
}