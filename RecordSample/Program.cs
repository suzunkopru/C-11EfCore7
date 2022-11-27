//C# 10
//Eski Adı: RecordKayıt
//C# 10.0 Record Types Can Seal ToString
using static System.Console;
using static System.DateTime;

AracBilgi aracBilgi = new(06, "Ankara", 2015, AracTipi.Binek);
WriteLine($"İl: {aracBilgi.ilAdi} Plaka: {aracBilgi.Plaka} ");
//aracBilgi.Plaka = 54;
/* Eğer Record propertyleri {get; init} şeklinde tanımlarsanız
 * değerlerini sonradan değiştirmeniz mümkün değildir. 
 */
WriteLine(aracBilgi.ToString());
AracBilgi kopyalaAracBilgi = aracBilgi with { AracinTipi = AracTipi.Kamyon };
/* With kullanarak aracBilgi record'unu kopyaldım ve Sadece
 * AracinTipi'ni Kamyon olarak ayarladım. Çünkü; araç binek
 * otomobil idi ve init olrak tanımlamıştım, yani artık tipini
 * değiştiremiyordum. Bende with kullanıp kopyaladım ve araç
 * tipini kamyon olarak değiştirdim.
 */

ReadKey();

public record AracTip
//Bu kaydı (record) sadece miras vermek ve almak üzere bir örnek olarak yazdım.
{
    public AracTipi AracinTipi { get; init; }
}
public enum AracTipi
{
    Binek, Kamyon, Kamyonet
}
public sealed record AracBilgi : AracTip
/* AracBilgi sınıfı bir record (record: C# 9.0 ile geldi). Miras verme işlemini
 * bu record ile sonlandırmak istiyorum, o yüzden mühürledim (sealed). Bir 
 * record (kayıt) başka bir kayıttan (record) miras alabiliyor, tabii ki mühürlü
 * (sealed) bir record (kayıt) değilse.
 */
{
    public AracBilgi() { }
    //Boş bir kurucu metot (constructor) tanımladım.
    public AracBilgi(sbyte plaka, string IlinAdi, int kacModel, AracTipi tip)
        => (Plaka, ilAdi, modelYili, AracinTipi) = (plaka, IlinAdi, kacModel, tip);
    /* Bir de parametre alabilen bir kurucu metot (constructor) tanımladım.
     * Kurucu metotta tüm özellik veya alanlarına (property, field) atama 
     * yapmak zorunda değilsiniz.
     */
    public sbyte Plaka { get; init; }
    //Bir özellik tanımı
    public string ilAdi { get; set; }
    public int modelYili { get; set; }
    /* C# 10.0 RecordTypesCanSealToString: Artık ToString metodu da
     * mühürlenebiliyor. Ancak record zaten mühürlü olduğu için etkisi
     * olmayacak.
     */
    public sealed override string ToString()
        => $"Plaka : {Plaka} -> İl Adı : {ilAdi} " +
           $"-> Araç Yaşı: {Yas(modelYili)}" +
           $"-> Araç Tipi: {AracinTipi}";
    //ToString metodunu override (ezerek değiştirdim) ettim.
    public int Yas(int modelYili) => Today.Year - modelYili;
    //Bu metot yıla göre yaş hesaplıyor.

}