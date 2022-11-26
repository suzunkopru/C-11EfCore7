using static System.Console;
using System.Drawing;
static int AracYasTip(dynamic arac, out Type type, int model)
{
    type = arac.GetType();
    arac.Model = model;
    return arac.Yas;
}
Type tipiNE;
Araba araba = new();
WriteLine($"{AracYasTip(araba, out tipiNE, 2016)} yaşında {tipiNE}");
Motor motor = new();
WriteLine($"{AracYasTip(motor, out tipiNE, 2014)} yaşında {tipiNE}");
ReadLine();
public enum Vites
{
    Manuel, Otomatik
}
public class Araba
{
    public Color Renk { get; set; }
    public Vites Vites { get; set; }
    public int Model { get; set; }
    public int Yas => DateTime.Today.Year - Model;
}
class Motor : Araba
{
    public bool TopCase { get; set; }
}