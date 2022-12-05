using static System.Console;
static nint Kuvvet(int sayi, int kuvvet)
{
    nint hesapla = 1;
    for (int i = 0; i < kuvvet; i++)
    {
        hesapla *= sayi;
    }
    return hesapla;
}
WriteLine($"Kuvvet(2, 32): {Kuvvet(2, 32):0,0}");
WriteLine($"Math.Pow(2, 32): {Math.Pow(2, 32):0,0}");
Console.ReadKey();
