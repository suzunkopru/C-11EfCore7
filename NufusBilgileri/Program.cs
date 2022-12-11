global using System.Globalization;
namespace NufusBilgileri;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new frmNufusBilgileri());
    }
}