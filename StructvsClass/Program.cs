using static System.Console;
KisiStruct structSample = new KisiStruct();
structSample.Ad = nameof(structSample);
KisiClass classSample = new KisiClass();
classSample.Ad = nameof(classSample);
void Karsilastir(KisiStruct structKisi, KisiClass classKisi)
{
    structKisi.Ad = $"{nameof(structSample)} değer tipli değişken";
    classKisi.Ad = $"{nameof(classSample)} ref tipli değişen";
}

Karsilastir(structSample, classSample);
WriteLine($"{nameof(structSample)} Ad:{structSample.Ad}");
WriteLine($"{nameof(classSample)} Ad:{classSample.Ad}");
ReadLine();
public struct KisiStruct
{
    public string Ad;
    public KisiStruct(string ad, int sira) => Ad = ad;
}
public class KisiClass
{
    public string Ad;
    public KisiClass(string ad, int sira) => Ad = ad;
    public KisiClass() { }
}
