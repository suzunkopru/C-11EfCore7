using static System.Console;
Personel personel = new Personel()
{
    Ad = "Süleyman",
    Soyad = "UZUNKÖPRÜ",
    IseGirisTarihi = new DateTime(1995, 05, 01),
    SGK_No = 3403199606293,
    HomeAddress = new Address()
    {
        Il = "Sakarya",
        Ilce = "Serdivan"
    }
};
WriteLine($"Ad: {personel.Ad}");
WriteLine($"Soyad: {personel.Soyad}");
WriteLine($"İl: {personel.HomeAddress.Il}");
WriteLine($"İlçe: {personel.HomeAddress.Ilce}");
Write("İse Giriş Tarihi: ");
WriteLine(personel.IseGirisTarihi.ToShortDateString());
WriteLine($"SGK No: {personel.SGK_No}");
ReadLine();
public abstract class Kisi
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
}
public class Personel : Kisi
{
    public DateTime IseGirisTarihi { get; set; }
    public long SGK_No { get; set; }
    public Address HomeAddress { get; set; }
}

public class Address
{
    public string Il { get; set; }
    public string Ilce { get; set; }
}

