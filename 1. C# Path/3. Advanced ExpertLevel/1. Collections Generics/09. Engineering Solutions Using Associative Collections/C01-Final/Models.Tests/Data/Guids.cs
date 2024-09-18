namespace Models.Tests.Data;

public static class Guids
{
    public static IEnumerable<Guid> TestData =>
        ReplicatingOperators.GetRandomByteArrays(16).Select(array => new Guid(array));
}