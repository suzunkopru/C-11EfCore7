using static System.Console;
using static System.DateTime;

AracBilgi aracBilgi = new(06, "Ankara", 2015, AracTipi.Binek);
WriteLine($"İl: {aracBilgi.ilAdi} Plaka: {aracBilgi.Plaka} ");
WriteLine(aracBilgi.ToString());
// C# 10.0 ile gelen with desteği.
AracBilgi kopyalaAracBilgi 
            = aracBilgi with { AracinTipi = AracTipi.Kamyon };
ReadKey();
public struct AracBilgi
{
    public AracTipi AracinTipi { get; init; }
    public AracBilgi() { }
    public AracBilgi(sbyte plaka, string IlinAdi,
                int kacModel, AracTipi tip)
                => (Plaka, ilAdi, modelYili, AracinTipi)
                = (plaka, IlinAdi, kacModel, tip);
    public sbyte Plaka { get; init; }
    public string ilAdi { get; set; }
    public int modelYili { get; set; }
    public override string ToString()
        => $"Plaka : {Plaka} -> İl Adı : {ilAdi} " +
           $"-> Araç Yaşı: {Yas(modelYili)}" +
           $"-> Araç Tipi: {AracinTipi}";
    public int Yas(int modelYili) => Today.Year - modelYili;
}
public enum AracTipi
{
    Binek, Kamyon, Kamyonet
}