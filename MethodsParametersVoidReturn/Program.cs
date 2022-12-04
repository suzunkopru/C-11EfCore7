using System.Globalization;

namespace MethodsParametersVoidReturn;
class Program
{
    static void Main(string[] args)
    {
        string ayracNedir = SistemNumerikAyraci();
        AyracOku(ayracNedir);
        ayracNedir = SistemNumerikAyraci(1055);
        AyracOku(ayracNedir);
        bool onlukBinlik = false;
        ayracNedir = SistemNumerikAyraci(onlukBinlik);
        AyracOku(onlukBinlik, ayracNedir);
        Console.ReadKey();
    }
    /// <summary>
    /// Sistemdeki sayıların ondalık kısımları için kullanılan 
    /// ayracı döndürür.
    /// </summary>
    /// <returns>Dönüş değeri string tipindedir. 
    /// Nokta veya virgül döner</returns>
    static string SistemNumerikAyraci()
    {
        return CultureInfo.CurrentCulture.NumberFormat
                                .NumberDecimalSeparator;
    }
    /// <summary>
    /// Sistemdeki sayıların ondalık kısımları için kullanılan 
    /// ayracı döndürür.
    /// </summary>
    /// <param name="Kod">Parametre olarak, ondalık ayraç
    /// istenen ülke kodunu alır.</param>
    /// <returns>Dönüş değeri string tipindedir. 
    /// Nokta veya virgül döner</returns>
    static string SistemNumerikAyraci(int Kod = 1055)
    {
        CultureInfo cultureInfo = new(Kod);
        return cultureInfo.NumberFormat.NumberDecimalSeparator;
    }

    /// <summary>
    /// Sistemdeki sayıların ondalık veya binlik 
    /// kısımları için kullanılan
    /// ayracı döndürür.
    /// </summary>
    /// <param name="On_Bin">Ondalık mı, binlik ayraç istediğinizi 
    /// sorar. 
    /// Eğer <code>true</code> gönderirseniz Ondalık Ayraç döner. 
    /// Eğer <code>false</code> gönderirseniz Binlik Ayraç döner. 
    /// </param>
    /// <remarks>
    /// Ayraçların doğru olarak bulunması sayesinde, sayıların
    /// okunması sırasında bir hata ile karşılaşmayacaksınız.
    /// </remarks>
    /// <returns>Dönüş değeri string tipindedir. 
    /// Nokta veya virgül döner</returns>
    static string SistemNumerikAyraci(bool On_Bin = true)
    {
        CultureInfo tr = new(1055);
        NumberFormatInfo f = tr.NumberFormat;
        string ayrac = On_Bin ? f.NumberDecimalSeparator
                              : f.NumberGroupSeparator;
        return ayrac;
    }
    /// <summary>
    /// Bu metot ondalık ayracı okur.
    /// </summary>
    static void AyracOku()
    {
        string oku = "Ondalık Ayraç : ";
        oku += CultureInfo.CurrentCulture.NumberFormat
            .NumberDecimalSeparator == ","
                    ? "Virgül (,)" : "Nokta (.)";
        Console.WriteLine(oku);
    }
    static void AyracOku(string OndalikAyrac)
    {
        string oku = "Ondalık Ayraç : ";
        oku += OndalikAyrac == ","
                    ? "Virgül (,)" : "Nokta (.)";
        Console.WriteLine(oku);
    }
    static void AyracOku(bool AyracTipi, string Ayrac)
    {
        string oku = AyracTipi ? "Ondalık Ayraç : "
                               : "Binlik Ayraç : ";
        oku += Ayrac == "," ? "Virgül (,)" : "Nokta (.)";
        Console.WriteLine(oku);
    }
}
