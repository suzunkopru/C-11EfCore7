using static System.Console;
List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int sayi = 5;
var anySample = numbers.AsQueryable().Any(x => x == sayi);
WriteLine(anySample ? $"{sayi} var" : $"{sayi} yok");
var AvgSample = numbers.AsQueryable().Average();
WriteLine(AvgSample);
List<string> strings = new() { "Ali", "Veli", "Can", "Cem" };
string ad = "Cem";
var ContainsSmp = strings.AsQueryable().Contains(ad);
WriteLine(ContainsSmp ? $"{ad} var" : $"{ad} Yok");
var countSmp = numbers.AsQueryable().Count();
WriteLine($"{countSmp} adet eleman var");
numbers.AddRange(new List<int>() { 1, 2, 3, 4, 5 });
WriteLine(string.Join("-", numbers.Distinct()));
SortedList<string, string>
    kisi = new()
    {
        {"Süleyman", "İstanbul"},
        {"Faruk", "Sakarya"},
        {"Salih",  "İstanbul"}
    };
WriteLine(string.Join("-", kisi.DistinctBy(x => x.Value)));
WriteLine(kisi.FirstOrDefault());
WriteLine(kisi.LastOrDefault());
SortedDictionary<double, string> alisveris = new()
{
    {25.25, "Meyve"},
    {125.76,"Meyve"},
    {55.99, "Meyve"},
    {65.25, "Sebze"},
    {90.20, "Sebze"},
    {30.60, "Baklagil"},
    {40.60, "Baklagil"},
    {50.80, "Baklagil"},
    {90.50, "Baklagil"}
};
var grupla = alisveris.AsQueryable().GroupBy(urun => urun.Value)
    .Select(grp => new
    {
        urun = grp.Select(gida => gida.Value).ToList()[0],
        adet = grp.Count(),
        toplam = grp.Sum(tutar => tutar.Key)
    });
WriteLine(string.Join("\n", grupla));
WriteLine(numbers.Max());
WriteLine(numbers.Min());
strings.Order();
WriteLine(string.Join("\n", strings));
WriteLine(string.Join("\n", alisveris
    .OrderBy(x => x.Value)
    .ThenBy(y => y.Key)));
WriteLine(string.Join(", ", numbers.Append(17)));
WriteLine(string.Join(", ", numbers.Prepend(53)));
List<int> num = Enumerable.Range(1, 100).ToList();
WriteLine(string.Join(", ", num.Skip(40).Take(15)));
SortedDictionary<double, string> masraflar = new()
{
    {35.25, "Peynir"},
    {15.75, "Peynir"},
    {25.99, "Peynir"},
    {65.25, "Zeytin"},
    {40.20, "Zeytin"},
    {30.60, "Zeytin"},
    {60.60, "Süt"},
    {40.80, "Süt"},
    {50.50, "Süt"}
};
var unionSort = alisveris.Union(masraflar);
unionSort = unionSort.OrderBy(x => x.Value);
WriteLine(string.Join("\n", unionSort));
WriteLine(string.Concat(Enumerable.Repeat("-", 15)));
WriteLine(string.Join("\n", alisveris.Where(x => x.Key > 60)));
List<string> isim = new() { "Ali", "Veli", "Can", "Cem", "Eda" };
List<int> borcu = new() { 49, 50, 60, 70, 80 };
WriteLine(string.Join("\n", borcu.Zip(isim)));
Kisi kisi1 = new() { Ad = "Ali", Soyad = "Tat" };
Kisi kisi2 = new() { Ad = "Can", Soyad = "Cino" };
Kisi kisi3 = new() { Ad = "Cem", Soyad = "Pes" };
Arac arac1 = new() { Ad = "Handa", Sahibi = kisi1 };
Arac arac2 = new() { Ad = "Reno", Sahibi = kisi2 };
Arac arac3 = new() { Ad = "Mereles", Sahibi = kisi3 };
Arac arac4 = new() { Ad = "Fiyat", Sahibi = kisi1 };
List<Kisi> kisiler = new() { kisi1, kisi2, kisi3 };
List<Arac> araclar = new() { arac1, arac2, arac3, arac4 };
WriteLine(string.Concat(Enumerable.Repeat("-", 15)));
var queryJoin =
    kisiler.AsQueryable().Join(araclar,
        ks => ks,
        ar => ar.Sahibi, //kisi1,2,3,4
        (ks, ar) =>
            new
            {
                shbAdi = ks.Ad,
                shbSoyd = ks.Soyad,
                shbYas = ks.Yas,
                aracAdi = ar.Ad,
                aracYasi = Math.Abs(ks.Yas - ar.Yas + 3)
            });
foreach (var obj in queryJoin)
{
    Write($"({obj.shbYas}) {obj.shbAdi} {obj.shbSoyd} ");
    WriteLine($" {obj.aracAdi} ({obj.aracYasi}))");
}
WriteLine(string.Concat(Enumerable.Repeat("-", 15)));
var queryGroupJoin =
    kisiler.AsQueryable().GroupJoin(araclar,
        ks => ks,
        ar => ar.Sahibi, //kisi1,2,3,4
        (ks, ar) =>
            new
            {
                shbAdi = ks.Ad,
                shbSoyd = ks.Soyad,
                shbYas = ks.Yas,
                aracAdi = ar.Select(ar => ar.Ad),
                aracYasi = ar.Select(ar => ar.Yas)
            });
foreach (var obj in queryGroupJoin)
{
    Write($"({obj.shbYas}) {obj.shbAdi} {obj.shbSoyd} :");
    foreach (string item in obj.aracAdi)
        Write($"{item}->");
    foreach (int each in obj.aracYasi)
        Write($"({each})->");
    WriteLine();
}
WriteLine(string.Concat(Enumerable.Repeat("-", 15)));
List<int> nums1 = new() { 27, 24, 9, 12, 15, 18, 21, 6, 3 };
List<int> nums2 = new() { 48, 40, 18, 24, 32, 12, 6 };
var kesisim = nums1.Intersect(nums2);
WriteLine(string.Join("-", kesisim));
WriteLine(string.Join("-", nums1.Order()));
WriteLine(string.Join("-", nums2.Order()));
WriteLine(string.Join("-", kesisim.Order()));
ReadLine();
abstract class Ortak
{
    public string Ad { get; set; }
    public int Yas
    {
        get;
        set;
    } = new Random().Next(18, 40) - new DateOnly().Year;
}
class Kisi : Ortak
{
    public string Soyad { get; set; }
}
class Arac : Ortak
{
    public Kisi Sahibi { get; set; }
}