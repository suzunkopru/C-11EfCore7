using static System.Console;
List<int> num = Enumerable.Range(1, 10).ToList();
foreach (var carpan in num)
{
    foreach (var carpim in num)
    {
        Write($"{carpan}x{carpim}={carpan * carpim}\t");
    }
    WriteLine();
}
num.ForEach(x => num.ForEach(y => WriteLine($"{x}x{y}={x * y}")));
ReadLine();
