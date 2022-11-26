double ort, mak, min, adt;
List<double> sayilarim = new();
double[] sayilar =
    { 499.75, 1_999.85, 1_501.15,
            999.25, 5_250, 4_750, 15_000 };
sayilarim.AddRange(sayilar);
double toplam = Topla(sayilarim,
    out ort, out mak, out min, out adt);
Console.WriteLine($"Toplam: {toplam:0,0.00}");
Console.WriteLine($"Ortalama: {ort:0,0.00}");
Console.WriteLine($"Maksimum: {mak:0,0.00}");
Console.WriteLine($"Minimum: {min:0,0.00}");
Console.WriteLine($"Adet: {adt}");
Console.ReadKey();
static double Topla
    (List<double> sayilar, out double ortalama,
        out double maks, out double min, out double adet)
{
    ortalama = Math.Round(sayilar.Average(), 2);
    maks = Math.Round(sayilar.Max(), 2);
    min = Math.Round(sayilar.Min(), 2);
    adet = sayilar.Count;
    return Math.Round(sayilar.Sum(), 2);
}



