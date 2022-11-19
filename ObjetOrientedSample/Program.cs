namespace ObjetOrientedSample;
using static Console;
using static DateTime;

public interface IKisi
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public DateTime DogumTarihi { get; set; }
    public int Yas(DateTime DogTar);
    public float VucutKitleEndeksi(float boy, float kilo);
}
public abstract class Kisi: IKisi
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public DateTime DogumTarihi { get; set; }
    private float Boy;
    private float Kilo;
    private DateTime DogTar;
    protected Kisi(string ad, string soyad, DateTime dogTar) 
                        => (Ad, Soyad, DogTar) = (ad, soyad, dogTar);
    protected Kisi() { }
    public abstract int Yas(DateTime DogTar);
    public float VucutKitleEndeksi(float boy, float kilo) 
                                                    => kilo / (boy * boy);
    public decimal VucutKitleEndeksi(decimal boy, decimal kilo) 
                                                    => kilo / (boy * boy);
    public double VucutKitleEndeksi(double boy, double kilo) 
                                                    => kilo / (boy * boy);
}
public interface IPersonel: IKisi
{
    public DateTime IseGirisTarihi { get; set; }
    public long SGK_No { get; set; }
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
                            => (IseGirisTarihi, SGK_No) = (iseGiris, sgkNo);
    public Personel() { }
}
class Program
{
    static void Main(string[] args)
    {
        Personel personel = new Personel()
        {
            Ad = "Süleyman",
            Soyad = "UZUNKÖPRÜ",
            DogumTarihi = new DateTime(1976, 11, 17),
            IseGirisTarihi = new DateTime(1995, 05, 01),
            SGK_No = 3403199606293,
        };

        WriteLine($"Ad: {personel.Ad}");
        WriteLine($"Soyad: {personel.Soyad}");
        Write("Doğum Tarihi: ");
        WriteLine(personel.DogumTarihi.ToShortDateString());
        Write("İse Giriş Tarihi: ");
        WriteLine(personel.IseGirisTarihi.ToShortDateString());
        WriteLine($"SGK No: {personel.SGK_No}");
        WriteLine($"Yaşı: {personel.Yas(personel.DogumTarihi)}");
        Write($"{nameof(personel.VucutKitleEndeksi)}");
        Write($"{typeof(float)}:");
        WriteLine($"{personel.VucutKitleEndeksi(1.78f, 99.5f)}");
        Write($"{nameof(personel.VucutKitleEndeksi)}");
        Write($"{typeof(decimal)}:");
        WriteLine($"{personel.VucutKitleEndeksi(1.78m, 99.5m)}");
        Write($"{nameof(personel.VucutKitleEndeksi)}");
        Write($"{typeof(double)}:");
        WriteLine($"{personel.VucutKitleEndeksi(1.78d, 99.5d)}");
        ReadLine();
    }
}