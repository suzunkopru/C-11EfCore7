using static System.Console;
//Func<int, bool> isCift = (int x) => x % 2 == 0;
var isCift = (int x) => x % 2 == 0;
int sayi = 225;
Write($"Sayınız: {sayi}  {(isCift(sayi) ? "Çift" : "Tek")}");
WriteLine(" Sayıdır.");
//Func<List<int>> Liste = List<int> () => new List<int> { 1, 2, 3 };
var Liste = List<int> () => new List<int> { 1, 2, 3 };
Liste().ForEach(x => WriteLine(x));
foreach (var item in Liste()) ;
Func<int, int> square = x => x * x;
WriteLine(square(10));
ReadLine();

