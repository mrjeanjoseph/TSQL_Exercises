namespace Models.Tests.Data;

public static class Timers
{
    public static IEnumerable<TimeSpan> GetRandomTimeSpans(TimeSpan from, TimeSpan to) =>
        ReplicatingOperators.GetRandomDoubleValues(from.TotalMilliseconds, to.TotalMilliseconds)
            .Select(TimeSpan.FromMilliseconds);

    public static IEnumerable<DateTime> GetRandomDateTimes(
        DateTime begin, TimeSpan averageStep, TimeSpan wavePeriod)
    {
        TimeSpan current = TimeSpan.Zero;
        foreach (double rnd in ReplicatingOperators.GetRandomDoubleValues(.3, 1.7))
        {
            double position = current.TotalSeconds / wavePeriod.TotalSeconds;
            position -= (int) position;

            double angle = 2 * Math.PI * position;
            double relativeStep = (Math.Cos(angle) + 1) / 2 + .5;
            double stepSeconds = relativeStep * averageStep.TotalSeconds;
            
            double condensingFactor = position <= .9 ? (3 + 10 * position) / 6 : 15.5 - 15 * position;
            
            TimeSpan step = TimeSpan.FromSeconds(rnd * stepSeconds * condensingFactor);
            current += step;
            yield return begin + current;
        }
    }

    public static IEnumerable<DateTime> GetUniformTimestamps(DateTime start, TimeSpan step)
    {
        DateTime current = start;
        while (true)
        {
            yield return current;
            current += step;
        }
    }
}