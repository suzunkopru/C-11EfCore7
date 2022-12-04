using static System.DateTime;
namespace ShopRent;
public class Shopping
{
    public string Name;
    public static int YearBuilt => 1976;
    public static int Anniversary => Today.Year - YearBuilt;
    public SortedList<int, string> DukkanKiralari = new()
    {
        {65_000, "Giyim"},
        {85_000, "Elektronik"},
        {26_000, "Oyuncak"},
        {24_000, "Kırtasiye"},
        {75_000, "Bilgisayar"},
     };
    public string ShoppingType(int i)
                        => DukkanKiralari.Values[i];
}
