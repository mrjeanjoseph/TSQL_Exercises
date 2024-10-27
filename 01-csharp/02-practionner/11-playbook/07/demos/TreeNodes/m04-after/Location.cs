namespace Pluralsight.CShPlaybook.Generics;
public enum LocationType { Town, Country, World }
public record class Location (string Name, LocationType Type)
{
	public static Location Earth => new Location("Earth", LocationType.World);
	public static Location MakeTown(string name) => new Location(name, LocationType.Town);
	public static Location MakeCountry(string name) => new Location(name, LocationType.Country);

}