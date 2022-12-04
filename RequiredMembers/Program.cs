using static System.Console;
using static System.DateTime;

int Yil = Today.Year;
var kisi = new Kisi { Ad = "Süleyman", Soyad = "UZUNKÖPRÜ", DogumTarihi = 1976 };
WriteLine($"Adı: {kisi.Ad}, Soyadı: {kisi.Soyad}, Yaşı: {Yil - kisi.DogumTarihi}");
ReadLine();
public class Kisi
{
    public required string Ad { get; init; }
    public required string Soyad { get; init; }
    public required int DogumTarihi { get; set; }
}