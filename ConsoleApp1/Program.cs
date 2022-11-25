namespace ConsoleApp1
{
    internal class Program
    {
        decimal Borc;
        decimal Alacak;
        static decimal a =
            decimal Borc-Alacak;
        static decimal BorcBakiye => a=100 - 50 > 0 ? a : 0;
        static void Main(string[] args)
        {
            Console.WriteLine(BorcBakiye);
        }
    }
}