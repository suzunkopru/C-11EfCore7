namespace BlazorApp1.Data;
public class Kisi
{
    public Kisi() { }
    public Kisi
    (string adi, string soyadi, string cinsiyeti,
       string dYeri, int dYili)
       => (Adi, Soyadi, Cinsiyeti, DogumYeri, DogumYili) =
       (adi, soyadi, cinsiyeti, dYeri, dYili);

    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public string Cinsiyeti { get; set; }
    public string DogumYeri { get; set; }
    public int DogumYili { get; set; }

    public List<Kisi> KisilerListesi()
    {
        List<Kisi> kisiler = new()
        {
         new("Süleyman", "UZUNKÖPRÜ", "Erkek", "Tekirdağ",1976),
         new ("Ahmet", "UZUNKÖPRÜ", "Erkek", "İstanbul", 2012),
         new ("Ayşe", "UZUNKÖPRÜ", "Kız", "Sakarya", 2014)
        };
        return kisiler;
    }
}