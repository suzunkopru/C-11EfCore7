using System.Text.Json;

#region  .net 6 DateOnly
Console.WriteLine(new CustomType().Serialize());
public class CustomType
{
    public DateOnly Date { get; set; } = new(2022, 11, 21);
    public TimeOnly Time { get; set; } = new(23, 30);
    public string Serialize() => JsonSerializer.Serialize(this);
}
#endregion .net 6 DateOnly

