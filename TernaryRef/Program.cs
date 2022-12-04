using static System.Console;
Dictionary<int, string> meyve = new()
{
    {20,"Elma"}, { 25, "Armut"}, { 45,"Muz"}
};
Dictionary<int, string> tatli = new()
{
    {35,"Sütlaç"}, { 55, "Baklava"}, { 25,"Kek"}
};
int meyveFy = meyve.Keys.Sum();
int tatliFy = tatli.Keys.Sum();

string sonuc = $"Meyveler: {meyveFy} Tatlılar: {tatliFy}.";
sonuc += meyveFy > tatliFy
    ? $"Meyve Pahalı+{meyveFy - tatliFy}"
    : $"Tatlı Pahalı+{tatliFy - meyveFy}";
WriteLine(sonuc);
WriteLine("Meyve isterseniz büyük M harfine basınız.");
WriteLine("M dışındaki bir tuşa basarsanız, tatlı verilir.");
ConsoleKeyInfo tus = ReadKey(true);
WriteLine($"{tus.Key} tuşuna bastınız.");
Dictionary<int, string> istenen =
    tus.Key == ConsoleKey.M ? ref meyve : ref tatli;
WriteLine
    ($"{string.Join("\n", istenen)} istemiş oldunuz.");
WriteLine($"Toplam {istenen.Keys.Sum()} ödeyiniz");
ReadKey();