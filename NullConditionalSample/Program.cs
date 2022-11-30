using static System.Console;
using static LibFuncitons.Voids;

int? integer = null;
WriteLine(integer ?? int.MaxValue);
List<int[]>? integrals = new List<int[]>
     {
        new [] { 200, 320, 300, 100, 800 },     //0. int listesi
        new [] { 600, 250, 325, 115, 875 },     //1. int listesi
        null                                                     //2. int listesi
    };
WriteLine($"integrals 0. Satır 0. Sütun: {integrals[0][0]}");
WriteLine($"integrals 0. Satır 1. Sütun: {integrals[0][1]}");
WriteLine($"integrals 1. Satır 2. Sütun: {integrals[1][2]}");
WriteLine($"integrals 1. Satır 3. Sütun: {integrals[1][3]}");
Ciz('-', 32);
JoinList(integrals[0]);
Ciz('-', 32);
WriteLine($"Toplama metodu: {Toplama(integrals, 0)}");
WriteLine($"Toplama metodu: {Toplama(integrals, 2)}");
int[] intsnewInts = { 55, 15, 11, 30 };
JoinList(intsnewInts);
Ciz('+', 5);
WriteLine($"{Topla(intsnewInts)}");
WriteLine(intsnewInts.Where(x => x > 20).Sum());
Ciz('-', 32);
ReadKey();
static int? Topla(int[]? sayilar) => sayilar?.Sum();
static int? Toplama(List<int[]>? ints, int start)
                        => ints?[start].Sum() ?? 9999;