using System.Text.Json;

#region .net 7 simplified ordering with
List<int> yillar= new List<int> { 2002, 2005, 1997 , 2022, 2013 };
var sirali = yillar.Order();
foreach (var str in yillar)
{
    Console.WriteLine(str);
}
foreach (var str in sirali)
{
    Console.WriteLine(str);
} 
#endregion .net 7 simplified ordering with


#region  .net 6 DateOnly
Console.WriteLine(new CustomType().Serialize());
public class CustomType
{
    public DateOnly Date { get; set; } = new(2022, 11, 21);
    public TimeOnly Time { get; set; } = new(23, 30);
    public string Serialize() => JsonSerializer.Serialize(this);
}
#endregion .net 6 DateOnly

