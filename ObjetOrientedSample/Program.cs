namespace ObjetOrientedSample;
using static Console;
using static DateTime;
public partial interface IKisi
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public DateTime DogTar { get; set; }
    public int Yas(DateTime _dogTar);
    public float KitleEndeks(float _boy, float _kilo);
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
    protected Kisi(string _ad, string _soyad, DateTime _dogTar)
                    => (Ad, Soyad, DogTar) = (_ad, _soyad, _dogTar);
    public abstract int Yas(DateTime _dogTar);
    public float KitleEndeks(float _boy, float _kilo)
                                                => _kilo / (_boy * _boy);
    public decimal KitleEndeks(decimal _boy, decimal _kilo)
                                                 => _kilo / (_boy * _boy);
    public double KitleEndeks(double _boy, double _kilo)
                                                 => _kilo / (_boy * _boy);
}
public class Personel : Kisi, IPersonel
{
    public DateTime IseGirisTarihi { get; set; }
    public long SGK_No { get; set; }
    public override int Yas(DateTime _dogTar)
                                    => Today.Year - _dogTar.Year;
    public Personel(string _ad, string _soyad, DateTime _dogTar,
                                DateTime _iseGiris, long _sgkNo)
                                : base(_ad, _soyad, _dogTar)
                                => (IseGirisTarihi, SGK_No)
                                = (_iseGiris, _sgkNo);
}
public class Program
{
    static void Main(string[] args)
    {
        Personel personel = new
           (_ad: "Süleyman",
            _soyad: "UZUNKÖPRÜ",
            _dogTar: new DateTime(1976, 11, 17),
           _iseGiris: new DateTime(1995, 05, 01),
           _sgkNo: 3403199606293);
        WriteLine($"Ad: {personel.Ad}");
        WriteLine($"Soyad: {personel.Soyad}");
        Write("Doğum Tarihi: ");
        WriteLine(personel.DogTar.ToShortDateString());
        Write("İse Giriş Tarihi: ");
        WriteLine(personel.IseGirisTarihi.ToShortDateString());
        WriteLine($"SGK No: {personel.SGK_No}");
        WriteLine($"Yaşı: {personel.Yas(personel.DogTar)}");
        WriteLine("Vücut Kitle Endeks durumu");
        WriteLine($"{personel.KitleEndeks(1.78f, 99.5f)}");
        WriteLine($"{personel.KitleEndeks(1.78m, 99.5m)}");
        WriteLine($"{personel.KitleEndeks(1.78d, 99.5d)}");
        ReadLine();
    }
}
public partial interface IKisi
{
    public decimal KitleEndeks(decimal _boy, decimal _kilo);
    public double KitleEndeks(double _boy, double _kilo);
}