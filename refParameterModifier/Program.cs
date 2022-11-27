using static System.Console;
int Gelirler(ref int Gelir, params int[] tutar)
{
    int tutarSum = tutar.Sum(x => Math.Abs(x));
    Gelir += tutarSum;
    return tutarSum;
}
int Giderler(ref int Gider, params int[] tutar)
{
    int tutarSum = -1 * tutar.Sum(x => Math.Abs(x));
    Gider += tutarSum;
    return tutarSum;
}
int Tutarlar(ref int karZarar, bool gelirmi,
                                params int[] tutar)
{
    int carpan = gelirmi ? 1 : -1;
    int tutarSum = carpan * tutar.Sum(x => Math.Abs(x));
    karZarar += tutarSum;
    return tutarSum;
}
int KZ = 0;
int buYil = DateTime.Today.Year;
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
gelir = Tutarlar(ref KZ, true, 1_000, 200, 3_000, 400, 10_000);
gider = Tutarlar(ref KZ, false, 1_000, 200, 3_000, 400, 500, 5000);
WriteLine($"Geliriniz: {gelir:0,0} Gideriniz: {gider:0,0}");
WriteLine($"{(KZ > 0 ? "Kar Ettiniz:" : "Zarar Ettiniz")}");
Write("K/Z Durumu: ");
WriteLine($"+ {gelir:0,0} {gider:0,0} = {gelir + gider:0,0}");
WriteLine(string.Concat(Enumerable.Repeat("-", 40)));
WriteLine($"K/Z Durumu {oncYil} Yılı: {oncekiYil:0,0}");
Write($"K/Z Durumu {buYil} ");
WriteLine($"Yılı: {KZ - oncekiYil:0,0}");
Write("Yıllar İtibarı İle K/Z Durumu: ");
WriteLine($"+ {KZ:0,0}");
ReadKey();