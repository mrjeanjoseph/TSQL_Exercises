namespace Models.Common;

public interface IOutliersRemover<out T>
{
    IEnumerable<T> RemoveOutliers(float relativeCount);
}