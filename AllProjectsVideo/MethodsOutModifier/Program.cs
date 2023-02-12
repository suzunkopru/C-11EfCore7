using static System.Math;
using static System.Console;
double ort, mak, min, adt;
List<double> sayilarim = new();
double[] sayilar =
{ 499.75, 1_999.85, 1_501.15,
    999.25, 5_250, 4_750, 15_000 };
sayilarim.AddRange(sayilar);
double toplam = Topla(sayilarim, out ort,out mak, out min, out adt);
WriteLine($"Toplam: {toplam:0,0.00}");
WriteLine($"Ortalama: {ort:0,0.00}");
WriteLine($"Maksimum: {mak:0,0.00}");
WriteLine($"Minimum: {min:0,0.00}");
WriteLine($"Adet: {adt}");
ReadKey();
static double Topla
(List<double> sayilar, out double ortalama,
    out double maks, out double min, out double adet)
{
    ortalama = Round(sayilar.Average(), 2);
    maks = Round(sayilar.Max(), 2);
    min = Round(sayilar.Min(), 2);
    adet = sayilar.Count;
    return Round(sayilar.Sum(), 2);
}