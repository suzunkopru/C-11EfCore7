using static System.Console;
int[] yillar = { 2002, 2005, 1997, 2022, 2013 };
var sirali1 = yillar.OrderBy(x => x);
var sirali2 = yillar.Order();
WriteLine("Sıralama Yok");
foreach (var str in yillar) WriteLine(str);
WriteLine("Sıralama Simplified Ordering With .Net 7");
foreach (var str in sirali1) WriteLine(str);
foreach (var str in sirali2) WriteLine(str);
ReadLine();

