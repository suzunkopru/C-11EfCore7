using static System.Console;
using static System.Math;
using static System.DateTime;
int Gelirler(ref int Gelir, params int[] tutarlar)
{
    int tutarlarSum = tutarlar.Sum(Abs);
    Gelir += tutarlarSum;
    return tutarlarSum;
}
int Giderler(ref int Gider, params int[] tutarlar)
{
    int tutarlarSum = -1 * tutarlar.Sum(Abs);
    Gider += tutarlarSum;
    return tutarlarSum;
}
int GelirlerGiderler(ref int karZarar, bool gelirmi,
    params int[] tutarlar)
{
    int carpan = gelirmi? 1 : -1;
    int tutarlarSum = carpan * tutarlar.Sum(Abs);
    karZarar += tutarlarSum;
    return tutarlarSum;
}
int KZ = 0;
int buYil = Today.Year;
int oncYil = buYil - 1;
WriteLine($"{oncYil} yılı durumu");
int gelir = Gelirler(ref KZ, 1_000, 200, 3_000, 400, 10_000);
int gider = Giderler(ref KZ, 1_000, 200, 3_000, 400, 500);
WriteLine($"Geliriniz: {gelir:0,0} Gideriniz: {gider:0,0}");
WriteLine($"{(KZ > 0 ? "Kar Ettiniz:" : "Zarar Ettiniz")}");
Write("K/Z Durumu: ");
WriteLine($"+ {gelir:0,0} {gider:0,0} = {KZ:0,0}");
int oncekiYil = KZ;
WriteLine(string.Concat(Enumerable.Repeat("-", 40)));
WriteLine($"{buYil} yılı durumu");
gelir = GelirlerGiderler(ref KZ, true, 1_000, 200, 3_000, 400, 10_000);
gider = GelirlerGiderler(ref KZ, false, 1_000, 200, 3_000, 400, 500, 5000);
WriteLine($"K/Z Durumu {oncYil} Yılı: {oncekiYil:0,0}");
Write($"K/Z Durumu {buYil} ");
WriteLine($"Yılı: {KZ - oncekiYil:0,0}");
Write("Yıllar İtibarı İle K/Z Durumu: ");
WriteLine($"+ {KZ:0,0}");
ReadKey();