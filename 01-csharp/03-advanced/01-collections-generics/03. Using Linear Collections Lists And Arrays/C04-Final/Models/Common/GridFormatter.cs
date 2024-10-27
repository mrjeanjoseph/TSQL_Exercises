namespace Models.Common;

internal class GridFormatter<T>
{
    public GridFormatter(IEnumerable<T> data)
    {
        this.Data = new List<string>();
        foreach (T item in data)
            this.Data.Add(item?.ToString() ?? string.Empty);
    }

    private IList<string> Data { get; }

    public IEnumerable<string> Format(int width, int gap) =>
        this.FormatRows(this.GetColumnsCount(width, gap), gap);
    
    private IEnumerable<string> FormatRows(int columnsCount, int gap) =>
        this.FormatRows(this.GetColumnWidths(columnsCount), new string(' ', gap));
    
    private IEnumerable<string> FormatRows(int[] columnWidths, string gap)
    {
        int rowsCount = this.GetRowsCount(columnWidths.Length);
        for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
        {
            yield return string.Join(gap, this.GetCells(rowIndex, columnWidths)).Trim();
        }
    }

    private IEnumerable<string> GetCells(int rowIndex, int[] columnWidths)
    {
        int index = rowIndex * columnWidths.Length;
        int count = Math.Min(columnWidths.Length, this.Data.Count - index);
        for (int i = 0; i < count; i++)
        {
            yield return this.Data[index + i].PadRight(columnWidths[i]);
        }
    }

    private int GetRowsCount(int columnsCount) =>
        (this.Data.Count + columnsCount - 1) / columnsCount;
    
    private int[] GetColumnWidths(int columnsCount) =>
        throw new NotImplementedException();
    
    private int GetColumnsCount(int width, int gap) =>
        throw new NotImplementedException();
}