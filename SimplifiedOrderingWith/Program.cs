using static System.Console;
int[] yillar = { 2002, 2005, 1997, 2022, 2013 };
//var sirali = yillar.OrderBy(x => x); //Net 6
var sirali = yillar.Order(); //Net 7
WriteLine("Sıralama Yok");
foreach (var str in yillar) WriteLine(str);
WriteLine("Sıralama Simplified Ordering With .Net 7");
foreach (var str in sirali) WriteLine(str);
ReadLine();
