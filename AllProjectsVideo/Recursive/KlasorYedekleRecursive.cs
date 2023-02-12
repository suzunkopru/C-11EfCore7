using System.Diagnostics;
using static System.IO.Directory;
namespace Recursive;
public partial class KlasorYedekleRecursive : Form
{
    public KlasorYedekleRecursive() => InitializeComponent();
    FolderBrowserDialog folderBrowserDialog;
    TextBox txtNereden, txtNereye;
    Button btnNereden, btnNereye, btnYedekle;
    string nereden, nereye;
    private void KlasorYedekleRecursive_Load
        (object sender, EventArgs e)
    {
        Size = new Size(400, 200);
        folderBrowserDialog = new();
        folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
        txtNereden = new();
        txtNereye = new();
        btnNereden = new();
        btnNereye = new();
        btnYedekle = new();
        Control[] controls =
            { txtNereden , txtNereye , btnNereden , btnNereye,btnYedekle};
        Controls.AddRange(controls);
        btnNereden.Text = "Nereden";
        btnNereden.Click += BtnNereden_Click;
        btnNereye.Text = "Nereye";
        btnNereye.Click += BtnNereye_Click;
        btnYedekle.Text = "Yedekle";
        btnYedekle.Click += BtnYedekle_Click;
        btnNereden.Left = btnNereye.Left = btnYedekle.Left = 10;
        txtNereden.Left = txtNereye.Left = btnNereden.Right + 2;
        txtNereden.Width = txtNereye.Width = 250;
        txtNereden.Top = btnNereden.Top = 10;
        txtNereye.Top = btnNereye.Top =
            btnNereden.Top + btnNereden.Height + 3;
        btnYedekle.Top = btnNereye.Top + btnNereye.Height + 3;
        btnYedekle.Left = Width / 3;
        txtNereden.Text = "D:\\GitHub\\CSharp11";
        txtNereye.Text = "D:\\GitHub\\";
    }

    private void BtnYedekle_Click(object? sender, EventArgs e)
    {
        nereden = txtNereden.Text.Trim();
        if (nereden.Length == 0) return;
        nereye = txtNereye.Text.Trim();
    }

    private void BtnNereye_Click(object? sender, EventArgs e)
                                        => YolYaz(txtNereye);

    private void YolYaz(TextBox nereyeYazayim)
    {
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            nereyeYazayim.Text = folderBrowserDialog.SelectedPath;
            Debug.WriteLine($"Týklanan TextBox Bilgisi {ActiveControl.Text}");
        }
    }

    private void BtnNereden_Click(object? sender, EventArgs e)
                                        => YolYaz(txtNereden);
    public void KlasorKopyala(string nereden, string nereye)
    {
        if (nereye.Length <= 248)
        {
            if (!Exists(nereye)) CreateDirectory(nereye);
            string[] dosyalar = GetFiles(nereden);
            if (dosyalar.Length > 0)
                foreach (string dosya in dosyalar)
                {
                    string isim = Path.GetFileName(dosya);
                    string hedef = Path.Combine(nereye, isim);
                    if (dosya.Length <= 260 && isim.Length <= 248)
                        File.Copy(dosya, hedef);
                }
            string[] klasorler = GetDirectories(nereden);
            if (klasorler.Length > 0)
                foreach (string klasor in klasorler)
                {
                    string isim = Path.GetFileName(klasor);
                    string hedef = Path.Combine(nereye, isim);
                    KlasorKopyala(klasor, hedef);
                }
        }
    }
}