namespace WhileEngAlfabe;
public struct Karakter
{
    public static string CharList
                (char basla = 'A', char bitir = 'Z')
    {
        string[] keys = new string[bitir - basla + 1];
        char i = basla;

        while (i <= bitir)
        {
            keys[i - basla] = i.ToString();
            i++;
        }
        return string.Join(string.Empty, keys);
    }
    public static string CharList
                (char[] dizi, char[] diziDil = default)
    {
        string[] keys = new string[dizi.Length];
        for (int i = 0; i < dizi.Length; i++)
        {
            keys[i] = dizi[i].ToString();
        }
        if (diziDil != default)
        {
            Array.Resize
                (ref keys, diziDil.Length + dizi.Length);
            for (int j = 0; j < diziDil.Length; j++)
            {
                keys[j + dizi.Length] = diziDil[j].ToString();
            }
        }
        Array.Sort(keys);
        return string.Join(string.Empty, keys);
    }
}