using static System.Console;
var isim = "Süleyman UZUNKÖPRÜ";
WriteLine($"isim değişkeni string midir? {isim is string}");
WriteLine($"isim.GetType(): {isim.GetType()}");
char[] harf = (isim as string).ToCharArray();
WriteLine($"harf.GetType(): {harf.GetType()}");
WriteLine($"harf değişkeninin 0. Karakteri: {harf[0]}");
WriteLine
    ($"harf değişkeninin 8 adet karakterinin sonuncusu: {harf[..8][^1]}");
WriteLine($"harf değişkeninin sondan 2. Karakteri: {harf[^2]}");
WriteLine($"Cast ile int to byte: {(byte)harf.Length}");
MiniClass miniClass = new();
WriteLine($"miniClass.GetType() {miniClass.GetType()}");
WriteLine($"typeof(MiniClass): {typeof(MiniClass)}");
WriteLine($"typeof(int): {typeof(int)}");
miniClass.Tip<int>();
miniClass.Tip<byte>();
miniClass.Tip<MiniClass>();
miniClass.Tip<SortedList<int, string>>();
ReadKey();
public class MiniClass
{
    public void Tip<T>() => WriteLine($"typeof(T):{typeof(T).Name}");
}

