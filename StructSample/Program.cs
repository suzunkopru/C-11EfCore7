using static System.Console;
using static System.DateTime;

AracBilgi arac1 = new("Ankara", 2015);
AracBilgi arac2 = arac1 with { modelYili = 2021 };
// C# 10.0 ile gelen with desteği.
WriteLine(arac1.ToString());
WriteLine(arac2.ToString());
ReadKey();

public struct AracBilgi
{
    public sbyte Plaka;
    public string ilAdi;
    public int modelYili;
    public AracBilgi(string IlinAdi, int kacModel)
        => (ilAdi, modelYili) = (IlinAdi, kacModel);
    //Plaka yok. C#11 öncesi auto default field hatası verir
    public readonly override string ToString()
        => ($"İl Adı : {ilAdi} Yaşı: {yas(modelYili)}");
    public readonly int yas(int modelYili)
        => Today.Year - modelYili;
}
