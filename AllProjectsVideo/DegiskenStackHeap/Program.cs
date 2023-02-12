Person Suleyman = new();
Suleyman.Old = 47;
Suleyman.Name = "Süleyman UZUNKÖPRÜ";
Person Fatih = new();
Fatih.Old = 17;
Fatih.Name = "Muhammed Fatih";
Fatih = Suleyman;
Console.WriteLine("1.Adım");
Console.WriteLine("Suleyman.Old:" + Suleyman.Old);
Console.WriteLine("Suleyman.Name:" + Suleyman.Name);
Console.WriteLine("Fatih.Old:" + Fatih.Old);
Console.WriteLine("Fatih.Name:" + Fatih.Name);
Suleyman.Name = "Ahmet Yasin";
Suleyman.Old = 10;
Console.WriteLine("Suleyman.Old:" + Suleyman.Old);
Console.WriteLine("Suleyman.Name:" + Suleyman.Name);
Console.WriteLine("Fatih.Old:" + Fatih.Old);
Console.WriteLine("Fatih.Name:" + Fatih.Name);
Console.ReadKey();
class Person
{
    public byte Old { get; set; }
    public string Name { get; set; }
}
