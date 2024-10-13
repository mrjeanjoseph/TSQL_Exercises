namespace Models.Common;

public interface IPercentilesReader<out T>
{
    T GetPercentile(float position);
}