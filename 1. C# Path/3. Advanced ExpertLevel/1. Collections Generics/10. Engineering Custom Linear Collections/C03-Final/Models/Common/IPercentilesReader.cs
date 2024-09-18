using Models.Common.Analytics;

namespace Models.Common;

public interface IPercentilesReader<T>
{
    Percentile<T> GetPercentile(float position);
}