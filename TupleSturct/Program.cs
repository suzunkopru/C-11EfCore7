using static System.Console;
DateTime tarih = new (1976, 11, 17);
(string ad, string soyad, DateTime dogTar, 
    string dogYer, string dogIlce)
tupleListem = ("Süleyman", "UZUNKÖPRÜ", tarih, "İstanbul", "Fatih");
WriteLine(tupleListem);
WriteLine(tupleListem.ad);
WriteLine(tupleListem.soyad);
//ORNEK
List<(int gun, int ay, string tatilAdi)> resmiTatiller =
     new List<(int gun, int ay, string tatilAdi)>
     {
        (gun:01, ay:01, tatilAdi: "Yılbaşı"),
        (gun:23, ay:04, tatilAdi: "23 Nisan"),
        (gun:01, ay:05, tatilAdi: "1 Mayıs"),
        (gun:19, ay:05, tatilAdi: "19 Mayıs"),
        (gun:15, ay:07, tatilAdi: "15 Temmuz"),
        (gun:30, ay:08, tatilAdi: "30 Ağustos"),
        (gun:29, ay:10, tatilAdi: "29 Ekim")
     };
WriteLine(string.Join(Environment.NewLine, resmiTatiller));
WriteLine();
//ORNEK
List<double> nums = new List<double>
    { 499.75, 1_999.85, 1_501.15, 999.25, 5_250, 4_750, 15_000 };
(double tpl, double ort, double mak, double min, int adt) 
    = Topla(nums);
WriteLine($"Toplam: {tpl:0,0.0000}");
WriteLine($"Ortalama: {ort:0,0.0000}");
WriteLine($"Maksimum: {mak:0,0.0000}");
WriteLine($"Minimum: {min:0,0.0000}");
ReadLine();
static (double tpl, double ort, double mak, double min, 
    int adt) Topla(List<double> nums) =>
    (nums.Sum(), nums.Average(), nums.Max(), 
    nums.Min(), nums.Count());
