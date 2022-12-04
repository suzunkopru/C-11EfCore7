using static System.Console;
using static System.Math;
static string DonemBul(Aylar ay) =>
    $$"""
    {{ay}} ayı
    {{Ceiling((decimal)ay / 3)}}. Dönem
    --------
    """;
WriteLine("C# 11 Raw String Literal");
for (int i = 1; i <= 12; i++)
{
    WriteLine(AyDonemi((Aylar)i));
}
ReadKey();
static string AyDonemi(Aylar ay)
{
    string ayDonemi = default;
    switch (ay)
    {
        case Aylar.Ocak:
        case Aylar.Şubat:
        case Aylar.Mart:
            ayDonemi = DonemBul(ay);
            break;
        case Aylar.Nisan:
        case Aylar.Mayıs:
        case Aylar.Haziran:
            ayDonemi = DonemBul(ay);
            break;
        case Aylar.Temmuz:
        case Aylar.Ağustos:
        case Aylar.Eylül:
            ayDonemi = DonemBul(ay);
            break;
        case Aylar.Ekim:
        case Aylar.Kasım:
        case Aylar.Aralık:
            ayDonemi = DonemBul(ay);
            break;
    }
    return ayDonemi;
}
enum Aylar
{
    Null = 0, Ocak = 1, Şubat = 2, Mart = 3, Nisan = 4, Mayıs = 5,
    Haziran = 6, Temmuz = 7, Ağustos = 8, Eylül = 9, Ekim = 10,
    Kasım = 11, Aralık = 12
}