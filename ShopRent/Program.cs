using ShopRent;
using static System.Console;
using static System.Environment;

Shopping shopping = new();
WriteLine($"{Shopping.YearBuilt} yılında kuruldu.");
WriteLine($"{Shopping.Anniversary} yıllık bir şirket");
WriteLine($"Şirket Adı: {shopping.Name = "AVM"}");
WriteLine($"Şirket Ürün Grubu: {shopping.ShoppingType(1)}");
WriteLine("AVM Ürün Grupları:");
WriteLine($"{string.Join(NewLine, shopping.DukkanKiralari)}");
Write("AVM Kira Geliri Ortalaması: ");
WriteLine(shopping.DukkanKiralari.Keys
                .Where(x => x > shopping.DukkanKiralari.Keys.Min())
                .Where(x => x < shopping.DukkanKiralari.Keys.Max())
                .Average().ToString("0,00.00"));
int indeks(string value) 
    => shopping.DukkanKiralari.GetKeyAtIndex
    (shopping.DukkanKiralari.IndexOfValue(value));
int gelir;
gelir  = indeks("Giyim") * 16;
gelir += indeks("Elektronik") * 28;
gelir += indeks("Oyuncak") * 5;
gelir += indeks("Kırtasiye") * 15;
gelir += indeks("Bilgisayar") * 7;
WriteLine($"Kira Geliri Toplamı {gelir:0,00}");
WriteLine(nameof(ShopRent));
ReadLine();
