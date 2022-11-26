static int Gelirler(ref int Gelir, params int[] tutar)
{
    int tutarSum = tutar.Sum(x => Math.Abs(x));
    Gelir += tutarSum;
    return tutarSum;
}
static int Giderler(ref int Gider, params int[] tutar)
{
    int tutarSum = -1 * tutar.Sum(x => Math.Abs(x));
    Gider += tutarSum;
    return tutarSum;
}

static int Tutarlar(ref int karZarar, bool gelirmi,
                                params int[] tutar)
{
    int carpan = gelirmi ? 1 : -1;
    int tutarSum = carpan * tutar.Sum(x => Math.Abs(x));
    karZarar += tutarSum;
    return tutarSum;
}

int KZDurumu = 0;
int buYil = DateTime.Today.Year;
int oncYil = buYil - 1;
Console.WriteLine($"{oncYil} yılı durumu");
int gelir = Gelirler(ref KZDurumu, 1_000, 200, 3_000, 400, 10_000);
int gider = Giderler(ref KZDurumu, 1_000, 200, 3_000, 400, 500);
Console.WriteLine($"Geliriniz: {gelir:0,0} Gideriniz: {gider:0,0}");
Console.WriteLine
    ($"{(KZDurumu > 0 ? "Gelir Ettiniz:" : "Zarar Ettiniz")}");
Console.Write("K/Z Durumu: ");
Console.WriteLine($"+ {gelir:0,0} {gider:0,0} = {KZDurumu:0,0}");
int oncekiYil = KZDurumu;
Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));
Console.WriteLine($"{buYil} yılı durumu");
gelir = Tutarlar
    (ref KZDurumu, true, 1_000, 200, 3_000, 400, 10_000);
gider = Tutarlar
    (ref KZDurumu, false, 1_000, 200, 3_000, 400, 500, 5000);
Console.WriteLine($"Geliriniz: {gelir:0,0} Gideriniz: {gider:0,0}");
Console.WriteLine
    ($"{(KZDurumu > 0 ? "Gelir Ettiniz:" : "Zarar Ettiniz")}");
Console.Write("K/Z Durumu: ");
Console.WriteLine
    ($"+ {gelir:0,0} {gider:0,0} = {gelir + gider:0,0}");
Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));
Console.WriteLine($"K/Z Durumu {oncYil} Yılı: {oncekiYil:0,0}");
Console.Write($"K/Z Durumu {buYil} ");
Console.WriteLine($"Yılı: {KZDurumu - oncekiYil:0,0}");
Console.Write("Yıllar İtibarı İle K/Z Durumu: ");
Console.WriteLine($"+ {KZDurumu:0,0}");
Console.ReadKey();



