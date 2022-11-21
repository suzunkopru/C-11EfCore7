namespace ClassAndProperty;
public class Motor : IMotor
{
    public Motor()
    {
        Renk = Color.Bisque;
        VitesSayisi = 5;
        YakitCinsi = "Benzin";
    }
    public Color Renk { get; set; }
    public byte VitesSayisi { get; set; }
    public string YakitCinsi { get; set; }
}
