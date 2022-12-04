using System.Drawing;
using static System.Console;

Lcd lcd = new();
lcd.CCFLUnit = 4;
lcd.Resolution = new(1680, 1050);
WriteLine($"Floresan Adedi: {lcd.CCFLUnit}");
WriteLine($"Çözünürlük: {lcd.Resolution}");
WriteLine($"Piksel: {lcd.Pixel(lcd.Resolution):0,0}");
Led led = new();
led.LedUnit = 40;
led.Resolution = new(1920, 1080);
WriteLine($"Led Adedi: {led.LedUnit}");
WriteLine($"Çözünürlük: {led.Resolution}");
WriteLine($"Piksel: {led.Pixel(led.Resolution):0,0}");
Write("Piksel Farkı: ");
WriteLine($"{led.Pixel(led.Resolution) - lcd.Pixel(lcd.Resolution):0,0}");
IPixel lcdPixel = new Lcd();
Write("Ekran kaç yıllık:");
WriteLine(lcdPixel.Age(new DateTime(2018, 06, 30)));
Write("Ekran kaç yıllık:");
lcdPixel.AgeWrite(new DateTime(2018, 06, 30));
ReadLine();
public interface IPixel
{
    public Size Resolution { get; set; }
    public int Age(DateTime createDate)
                        => DateTime.Today.Year - createDate.Year;
    public void PixelWrite(Size resolution);
    public void AgeWrite(DateTime crDate) => WriteLine(Age(crDate));
}
public class Panel : IPixel
{
    public Size Resolution { get; set; }
    public int Pixel(Size resolution) => resolution.Width * resolution.Height;
    public void PixelWrite(Size resolution)
                    => WriteLine(resolution.Width * resolution.Height);
}
public class Lcd : Panel
{
    public int CCFLUnit { get; set; }
}
public class Led : Panel
{
    public int LedUnit { get; set; }
}