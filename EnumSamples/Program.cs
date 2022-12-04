using static LibFuncitons.Voids;
using static System.Console;
WriteLine($"AracTipleri.Binek: {AracTipleri.Binek}");
WriteLine($"AracTipleri.Motor: {AracTipleri.Motor}");
WriteLine($"AracTipleri.Ticari: {AracTipleri.Ticari}");
Ciz('-', 45);
WriteLine($"(AracTipleri)1: {(AracTipleri)1}");
WriteLine($"(AracTipleri)2: {(AracTipleri)2}");
WriteLine($"(AracTipleri)3: {(AracTipleri)3}");
Ciz('-', 45);
int kac = Enum.GetValues(typeof(AracTipleri)).Length;
for (int i = 0; i < kac; i++)
{
    WriteLine($"AracTipleri Döngüsü {i} :{(AracTipleri)i}");
}
Ciz('-', 45);
WriteLine("Araç Seçimi: Binek için:1, Ticari:2, Motor:3");
ConsoleKeyInfo tus = ReadKey(true);
int aracSecimi = tus.KeyChar - 48;
WriteLine($"Aracınız : {(AracTipleri)aracSecimi}");
if (tus.Key == ConsoleKey.NumPad1 || tus.Key == ConsoleKey.NumPad2)
{
    WriteLine("Otomatik vites için O harfi, ");
    WriteLine("Manuel için M tuşuna basınız");
    tus = ReadKey(true);
    string vites = tus.Key == ConsoleKey.O
                        ? "Otomatik Vites"
                        : "Manuel vites";
    WriteLine($"Seçilen Vites: {vites}");
    foreach (var item in Enum.GetValues(typeof(AracTipleri)))
    {
        WriteLine($"AracTipleri Döngüsü {item}");
    }
    ReadKey();
}
enum AracTipleri
{
    Null = 0, Binek = 1, Ticari = 2, Motor = 3
}