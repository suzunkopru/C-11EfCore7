using static System.Console;
Vehicle Ornek = new Vehicle
{
    Brand = "Traktör",
    Name = "Ankara"
};
WriteLine(Ornek);
ReadLine();
class Vehicle
{
    public string Brand { get; init; } = "Kamyonet"; //public readonly string Brand = "Kamyonet";
    public string Name { get; init; } = "Pejo"; //public readonly string Name = "Pejo";
    public Vehicle()
    {
        Brand = "Araba";
        Name = "Mereles";
    }
    public override string ToString() => $"{Brand} {Name}";
}
