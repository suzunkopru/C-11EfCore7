using static System.Console;
using static System.Linq.Enumerable;

namespace LibFuncitons;
public static class Voids
{
    public static void Ciz(char ne, int kac)
        => WriteLine(string.Concat(Repeat(ne, kac)));
}