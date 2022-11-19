using static System.Console;
WriteLine($"Bir sayı yazınız.");
int rakam1 = Convert.ToInt32(ReadLine());
WriteLine($"Bir sayı daha yazınız.");
int rakam2 = Convert.ToInt32(ReadLine());
WriteLine($"Toplamı: {HesapMakinesi(rakam1, rakam2, DortIslem.Topla)}");
WriteLine($"Farkı: {HesapMakinesi(rakam1, rakam2, DortIslem.Cikar)}");
WriteLine($"Çarpımı: {HesapMakinesi(rakam1, rakam2, DortIslem.Carp)}");
WriteLine($"Bölümü: {HesapMakinesi(rakam1, rakam2, DortIslem.Bol)}");
ReadKey();

int HesapMakinesi(int sayi1, int sayi2, DortIslem islem) => islem switch
{
    DortIslem.Topla => sayi1 + sayi2,
    DortIslem.Cikar => sayi1 - sayi2,
    DortIslem.Carp => sayi1 * sayi2,
    DortIslem.Bol => sayi1 / sayi2,
    _ => 0
};
enum DortIslem
{
    Topla, Cikar, Carp, Bol
}


