using static System.Console;
IShape kare = new Kare(25);
WriteLine(kare.AlanHesabi(kare));
Kare kre = new((nint)1_111);
WriteLine($"{kre.GetType().Name} alanı: {kre.Alan}");
IShape dortgen = new Dortgen(50, 20);
WriteLine(dortgen.AlanHesabi(dortgen));
Dortgen drt = new(2_222);
WriteLine($"{drt.GetType().Name} alanı: {drt.Alan}");
ReadKey();
public class Kare : IShape
{
    public Kare(int kenar) => Kenar = kenar;
    public Kare(nint alan) => Alan = alan;
    public int Kenar { get; }
    public nint Alan { get; }
}
public class Dortgen : IShape
{
    public Dortgen(int uzunluk, int yükseklik) =>
        (Uzunluk, Yükseklik) = (uzunluk, yükseklik);
    public Dortgen(int alan) => Alan = alan;
    public int Uzunluk { get; }
    public int Yükseklik { get; }
    public nint Alan { get; }
}
public interface IShape
{
    public nint Alan { get; }
    string AlanHesabi(dynamic shape) => shape switch
    {
        Kare k when k.Alan == 0 =>
            $"{shape.GetType().Name} alanı " +
            $"{k.Kenar * k.Kenar:0,00}",
        Dortgen d when d.Alan == 0 =>
            $"{shape.GetType().Name} alanı " +
            $"{d.Uzunluk * d.Yükseklik:0,00}",
        _ => throw new Exception($"Alan hesaplanamadı.")
    };
}
