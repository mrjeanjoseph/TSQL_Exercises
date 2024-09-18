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
    
    private int GetColumnsCount(int width, int gap)
    {
        int columnsCount = this.GetColumnsCountUpperBound(width, gap);
        while (columnsCount > 1 && this.GetTotalWidth(columnsCount, width, gap) > width)
        {
            columnsCount--;
        }
        return columnsCount;
    }

    private int GetTotalWidth(int columnsCount, int width, int gap) =>
        this.GetColumns(columnsCount, width, gap, true).totalWidth;
    
    private int GetColumnsCountUpperBound(int width, int gap)
    {
        int currentWidth = this.Data.Count > 0 ? this.Data[0].Length : 0;
        int columnsCount = 1;
        foreach (string item in this.Data.Skip(1))
        {
            int nextWidth = currentWidth + gap + item.Length;
            if (nextWidth > width) break;
            currentWidth = nextWidth;
            columnsCount++;
        }
        return columnsCount;
    }
    
    private int[] GetColumnWidths(int columnsCount) =>
        this.GetColumns(columnsCount, 0, 0, false).columnWidths;
    
    private (int[] columnWidths, int totalWidth) GetColumns(
        int columnsCount, int width, int gap, bool preempt)
    {
        int[] columnWidths = new int[columnsCount];
        int totalWidth = (Math.Min(columnsCount, this.Data.Count) - 1) * gap;
        int columnIndex = 0;
        foreach (string item in this.Data)
        {
            int increase = Math.Max(item.Length - columnWidths[columnIndex], 0);
            columnWidths[columnIndex] += increase;
            totalWidth += increase;
            if (preempt && totalWidth > width) return (columnWidths, totalWidth);
            columnIndex = (columnIndex + 1) % columnsCount;
        }
        return (columnWidths, totalWidth);
    }
}