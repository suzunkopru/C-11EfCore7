using System.Globalization;
using static System.Console;
namespace MethodsParametersVoidReturn;
internal class Program
{
    static void Main(string[] args)
    {
        string ayracNedir = SistemNumerikAyraci();
        AyracOku(ayracNedir);
        ayracNedir = SistemNumerikAyraci(1055);
        bool onlukBinlik = false;
        ayracNedir = SistemNumerikAyraci(onlukBinlik);
        AyracOku(onlukBinlik, ayracNedir);
        ReadLine();
    }
    /// <summary>
    /// Sistemdeki sayıların ondalık kısımları için kullanılan 
    /// ayracı döndürür.
    /// </summary>
    /// <param name="kod">Parametre olarak, ondalık ayraç
    /// istenen ülke kodunu alır.</param>
    /// <returns>Dönüş değeri string tipindedir. 
    /// Nokta veya virgül döner</returns>
    private static string SistemNumerikAyraci(int kod = 1055)
    {
        CultureInfo culture = new(kod);
        return culture.NumberFormat.NumberDecimalSeparator;
    }    /// <summary>
         /// Sistemdeki sayıların ondalık kısımları için kullanılan 
         /// ayracı döndürür.
         /// </summary>
         /// <returns>Dönüş değeri string tipindedir. 
         /// Nokta veya virgül döner</returns>
    private static string SistemNumerikAyraci()
        => CultureInfo.CurrentCulture.NumberFormat
            .NumberDecimalSeparator;
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
    private static string SistemNumerikAyraci(bool On_Bin = true)
    {
        CultureInfo tr = new(1055);
        NumberFormatInfo f = tr.NumberFormat;
        string ayrac = On_Bin
            ? f.NumberDecimalSeparator
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
            .NumberDecimalSeparator== ","
            ? "Virgül (,)" : "Nokta (.)";
        WriteLine(oku);
    }
    /// <summary>
    /// Bu metot ondalık ayracı okur.
    /// </summary>
    /// <param name="OndalikAyrac">
    /// Buraya nokta veya virgül gelecektir.
    /// </param>
    private static void AyracOku(string OndalikAyrac = ".")
    {
        string oku = "Ondalık Ayraç : ";
        oku += OndalikAyrac == ","
            ? "Virgül (,)" : "Nokta (.)";
        WriteLine(oku);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="AyracTipi"></param>
    /// <param name="Ayrac"></param>
    private static void AyracOku(bool AyracTipi, string Ayrac)
    {
        string oku = AyracTipi ? "Ondalık Ayraç : "
                               : "Binlik Ayraç : ";
        oku += Ayrac == "," ? "Virgül (,)" : "Nokta (.)";
        WriteLine(oku);
    }
}