using System.Collections.Generic;
using static System.Console;
using static System.Linq.Enumerable;

namespace LibFuncitons;
public static class Voids
{
    public static void Ciz(char ne, int kac)
        => WriteLine(string.Concat(Repeat(ne, kac)));
    public static void JoinList(int[] ints) 
        => WriteLine(string.Join("\n", ints));
    public static void JoinList<T>(List<T> ints) where T : struct
        => WriteLine(string.Join("\n", ints));
   public static bool IsLetter(char karakter) 
        => karakter is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');
    public static bool IsNumber(int sayi) => sayi is (>= 0 and <= 9);

}