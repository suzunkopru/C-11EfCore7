using static System.Console;
using static WhileEngAlfabe.Karakter;
char[] uCaseTr = { 'Ç', 'Ğ', 'Ö', 'Ü', 'İ', 'Ş' };
char[] lCaseTr = { 'ç', 'ğ', 'ö', 'ü', 'ş' };
int kacAdet = 'Z' - 'A' + 1;
char[] AZ = Enumerable.Range
    ('A', kacAdet).Select(x => (char)x).ToArray();
kacAdet = 'z' - 'a' + 1;
char[] az = Enumerable.Range
    ('a', kacAdet).Select(x => (char)x).ToArray();
WriteLine($"{CharList('A', 'Z')}");
WriteLine($"{CharList()}");
WriteLine(CharList('a', 'z'));
WriteLine(CharList(AZ));
WriteLine($"{CharList(az)}");
WriteLine(CharList(uCaseTr));
WriteLine(CharList(lCaseTr));
WriteLine(CharList(uCaseTr, AZ));
WriteLine(CharList(lCaseTr, az));
Array.Resize(ref AZ, AZ.Length + uCaseTr.Length);
AZ[^6] = 'Ç';
AZ[^5] = 'Ğ';
AZ[^4] = 'Ö';
AZ[^3] = 'Ü';
AZ[^2] = 'İ';
AZ[^1] = 'Ş';
Array.Resize(ref az, az.Length + lCaseTr.Length);
az[^5] = 'ç';
az[^4] = 'ğ';
az[^3] = 'ö';
az[^2] = 'ü';
az[^1] = 'ş';
WriteLine($"{CharList(AZ)}");
WriteLine($"{CharList(az)}");
char j = 'a';
char k = '0';
for (char i = 'A'; i <= 'Z'; i++)
{
    WriteLine($"{(int)i}.Karakter Büyük Harf: {i}");
    WriteLine($"{(int)j}.Karakter Küçük Harf: {j}");
    j++;
    if (k <= '9')
    {
        WriteLine($"{(int)k}.Karakter Rakam: {k}");
        k++;
    }
}
ReadKey();
