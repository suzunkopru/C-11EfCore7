using static System.Console;
IShape kare = new Kare(25);
WriteLine(kare.AlanHesabi(kare));
IShape dortgen = new Dortgen(50, 20);
WriteLine(dortgen.AlanHesabi(dortgen));
ReadKey();

public class Kare : IShape
{
    public Kare(int kenar) => Kenar = kenar;
    public int Kenar { get; }
}
public class Dortgen : IShape
{
    public Dortgen(int uzunluk, int yükseklik) =>
        (Uzunluk, Yükseklik) = (uzunluk, yükseklik);
    public int Uzunluk { get; }
    public int Yükseklik { get; }
}
public interface IShape
{
    string AlanHesabi(dynamic shape) => shape switch
    {
        Kare k => $"{shape.GetType().Name} alanı " +
                  $"{k.Kenar * k.Kenar:0,00}",
        Dortgen d => $"{shape.GetType().Name} alanı " +
                     $"{d.Uzunluk * d.Yükseklik:0,00}",
        _ => throw new Exception($"Alan hesaplanamadı.")
    };
}