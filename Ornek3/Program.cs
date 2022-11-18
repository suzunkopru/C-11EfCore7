using static System.Console;

namespace Ornek3;
internal class Program
{
    static int Topla(int v1, int v2) => v1 + v2;
    static decimal Topla(decimal v1, decimal v2) => v1 + v2;
    static float Topla(float v1, float v2) => v1 + v2;
    static double Topla(double v1, double v2) => v1 + v2;
    static void Main(string[] args)
    {
        WriteLine($"{Topla(1.78f, 99.2f)}");
        WriteLine($"{Topla(1.75m, 125.25m)}");
        WriteLine($"{Topla(178, 99)}");
        WriteLine($"{Topla(225d, 79d)}");
        ReadLine();
        WriteLine("Hello, World!");
    }
}
