using static System.Console;
int sayi1 = int.MaxValue;
byte ekle = 200;
WriteLine($"int.MaxValue + 200: {sayi1 + ekle}");
int sayi2 = 1;
WriteLine($"sayi1 + sayi2 (1 ise): {sayi1 + sayi2}");
sayi2 = 2;
WriteLine($"sayi1 + sayi2 (2 ise): {sayi1 + sayi2}");
byte byt = 255;
WriteLine($"byt (255 idi) + 255: {byt + 255} eder.");
Write("(byte)(byt * 1_000_000_001) ise yine:");
WriteLine($"{(byte)(byt * 1_000_000_001)} eder.");
unchecked
{
    WriteLine($"unchecked int.MaxValue + 200: {sayi1 + ekle}");
}
checked
{
    WriteLine($"checked int.MaxValue + 200: {sayi1 + ekle}");
    WriteLine((byte)(byt + ((byt + 1) * 100)));
}
ReadKey();

