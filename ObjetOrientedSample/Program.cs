namespace ObjetOrientedSample;
using static Console;
using static DateTime;
public interface IKisi
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public DateTime DogTar { get; set; }
    public int Yas(DateTime dogTar);
    public float KitleEndeks(float boy, float kilo);
}
public interface IPersonel
{
    public DateTime IseGirisTarihi { get; set; }
    public long SGK_No { get; set; }
}
public abstract class Kisi : IKisi
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public DateTime DogTar { get; set; }
    public float Boy;
    public float Kilo;
    public Kisi(string ad, string soyad, DateTime dogTar)
                                    => (Ad, Soyad, DogTar)
                                    = (ad, soyad, dogTar);
    public Kisi(float boy, float kilo) 
                                => (Boy, Kilo) = (boy, kilo);
    protected Kisi() { }
    public abstract int Yas(DateTime DogTar);
    public float KitleEndeks(float boy, float kilo)
                                                => kilo / (boy * boy);
    public decimal VucutKitleEndeksi(decimal boy, decimal kilo)
                                                 => kilo / (boy * boy);
    public double VucutKitleEndeksi(double boy, double kilo)
                                                 => kilo / (boy * boy);
}
public class Personel : Kisi, IPersonel
{
    public DateTime IseGirisTarihi { get; set; }
    public long SGK_No { get; set; }
    public override int Yas(DateTime DogTar)
                                    => Today.Year - DogTar.Year;
    public Personel(string ad, string soyad, DateTime dogTar,
                               DateTime iseGiris, long sgkNo)
                               : base(ad, soyad, dogTar)
                               => (IseGirisTarihi, SGK_No)
                               = (iseGiris, sgkNo);
    public Personel(float boy, float kilo)
                                : base(boy, kilo)
                                => (Boy, Kilo) = (boy, kilo);
}
class Program
{
    static void Main(string[] args)
    {
        Personel personel = new Personel
           (ad: "Süleyman",
            soyad: "UZUNKÖPRÜ",
            dogTar: new DateTime(1976, 11, 17),
            iseGiris: new DateTime(1995, 05, 01),
            sgkNo: 3403199606293);
        Personel personel2 = new Personel(1.78f, 92.5f);
        WriteLine($"Ad: {personel.Ad}");
        WriteLine($"Soyad: {personel.Soyad}");
        Write("Doğum Tarihi: ");
        WriteLine(personel.DogTar.ToShortDateString());
        Write("İse Giriş Tarihi: ");
        WriteLine(personel.IseGirisTarihi.ToShortDateString());
        WriteLine($"SGK No: {personel.SGK_No}");
        WriteLine($"Yaşı: {personel.Yas(personel.DogTar)}");
        Write($"{nameof(personel.KitleEndeks)}");
        Write($"{typeof(float)}:");
        WriteLine($"{personel.KitleEndeks(1.78f, 99.5f)}");
        Write($"{nameof(personel.KitleEndeks)}");
        Write($"{typeof(decimal)}:");
        WriteLine($"{personel.VucutKitleEndeksi(1.78m, 99.5m)}");
        Write($"{nameof(personel.KitleEndeks)}");
        Write($"{typeof(double)}:");
        WriteLine($"{personel.VucutKitleEndeksi(1.78d, 99.5d)}");
        ReadLine();
    }
}