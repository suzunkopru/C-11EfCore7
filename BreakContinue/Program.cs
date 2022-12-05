using static System.Console;
gotoDongusu:
Write("4 Dönem mevcuttur. Buna göre bir dönem değeri yazınız.");
WriteLine("Ekranda Kaç Dönem Yazdırılacak? Bir Sayı giriniz.");
bool veriGir = int.TryParse(ReadLine(), out int dnm);
if (veriGir == false)
{
    WriteLine("Bir sayı girmeniz gerekmez mi?");
    goto gotoDongusu;
}
dnm = dnm > 4 ? 4 : dnm <= 0 ? 1 : dnm;
int donemSayaci = 0;
int yil = DateTime.Today.Year;
for (int i = 1; i <= 12; i++)
{
    int mod = i % 3;
    if (mod != 0) continue;
    if (donemSayaci == dnm) break;
    donemSayaci++;
    string ayAdi = new DateOnly(yil, i, 1).ToString("MMMM");
    Write($"{yil} Yılı {i}. Ay ({ayAdi}) ayının son günü: ");
    WriteLine($"{DateTime.DaysInMonth(yil, i)}");
}
ReadKey();
