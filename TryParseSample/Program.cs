﻿using static System.Console;
using static System.Convert;

string sayi = "1.250.785,23";
bool dene = decimal.TryParse(sayi, out decimal tryDecimal);
WriteLine($"Deneme yapılacak sayı {sayi}");
WriteLine($"Sonuç: {(dene ? tryDecimal : "Başarısız"):0,0.00}");
dene = int.TryParse(sayi, out int tryInt);
WriteLine($"Sonuç: {(dene ? tryInt : "Başarısız"):0,0.00}");
WriteLine($"{ToDecimal(sayi):0,0.00}");
sayi = sayi.Split(',').First().Replace(".", "");
WriteLine($"{ToInt32(sayi):0,0}");
ReadKey();

