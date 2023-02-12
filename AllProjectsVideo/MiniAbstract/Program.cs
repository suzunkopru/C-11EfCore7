using static System.Console;
Kus minikKus = new Kus();
WriteLine(nameof(Kus));
minikKus.SolunumYap();
Kus.Uyu();
Balik minikBalik = new Balik();
WriteLine(nameof(Balik));
minikBalik.SolunumYap();
Balik.Uyu();
ReadKey();
abstract class Canli
{
    public abstract void SolunumYap();
    public static void Uyu() => WriteLine("Uyudum");
}
class Kus : Canli
{
    public override void SolunumYap()
        => WriteLine("Oksijenli Solunum Yapıyorum.");
    private string Gaga { get; set; }
}
class Balik : Canli
{
    public override void SolunumYap()
        => WriteLine("Solungaçlı Solunum Yapıyorum.");
}
