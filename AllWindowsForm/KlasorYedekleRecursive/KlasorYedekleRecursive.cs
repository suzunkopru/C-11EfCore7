using System.Diagnostics;

namespace KlasorYedekleRecursive;

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
        folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
        txtNereden = new TextBox();
        txtNereye = new TextBox();
        btnNereden = new Button();
        btnNereye = new Button();
        btnYedekle = new Button();
        Control[] controls =
            { txtNereden , txtNereye , btnNereden , btnNereye,btnYedekle};
        Controls.AddRange(controls);
        btnNereden.Text = "Nereden";
        btnNereden.Click += btnNereden_Click;
        btnNereye.Text = "Nereye";
        btnNereye.Click += btnNereye_Click;
        btnYedekle.Text = "Yedekle";
        btnYedekle.Click += btnYedekle_Click;
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
    int bDegeri;
    private void btnYedekle_Click(object sender, EventArgs e)
    {
        nereden = txtNereden.Text.Trim();
        if (nereden.Length == 0) return;
        double bSize = KlasorBoyutu(nereden, "*.*");
        if (bSize > 0)
        {
            bDegeri = (int)BoyutDegeri(bSize, SIBirim.MegaByte);
            if (bDegeri == 0) bDegeri =
                    (int)BoyutDegeri(bSize, SIBirim.Byte);
        }
        else
        {
            return;
        }
        nereye = txtNereye.Text.Trim(); ;
        nereye += Path.GetFileName(nereden);
        nereye += DateTime.Now.ToString("yyyy.MM.dd_hh.mm.ss");
        if (!Directory.Exists(nereye))
            Directory.CreateDirectory(nereye);
        KlasorKopyala(nereden, nereye); //Ýþte Recursive satýrý
        MessageBox.Show("Yedek alma iþlemi tamamlandý");
        string spr = Path.DirectorySeparatorChar.ToString();
        Process.Start("Explorer.Exe",
            Path.GetDirectoryName(nereye + spr));
        btnYedekle.Enabled = false;
    }
    private void btnNereye_Click(object sender, EventArgs e)
                                    => YolYaz(txtNereye);

    private void btnNereden_Click(object sender, EventArgs e)
                                    => YolYaz(txtNereden);

    void YolYaz(TextBox nereyeYazayim)
    {
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            nereyeYazayim.Text = folderBrowserDialog.SelectedPath;
        Debug.WriteLine($"Buton Bilgisi {ActiveControl.Text}");
    }
    public void KlasorKopyala(string nereden, string nereye)
    {
        if (nereye.Length <= 248)
        {
            if (!Directory.Exists(nereye)) Directory.CreateDirectory(nereye);
            string[] dosyalar = Directory.GetFiles(nereden);
            if (dosyalar.Length > 0)
                foreach (string dosya in dosyalar)
                {
                    string isim = Path.GetFileName(dosya);
                    string hedef = Path.Combine(nereye, isim);
                    if (dosya.Length <= 260 && isim.Length <= 248)
                        File.Copy(dosya, hedef);
                }
            string[] klasorler = Directory.GetDirectories(nereden);
            if (klasorler.Length > 0)
                foreach (string klasor in klasorler)
                {
                    string isim = Path.GetFileName(klasor);
                    string hedef = Path.Combine(nereye, isim);
                    KlasorKopyala(klasor, hedef);
                    //Ýþte Recursive satýrý
                }
        }
    }
    DirectoryInfo _directoryInfo;
    private double KlasorBoyutu(string path, string desen)
    {
        if (path.Length == 0 || desen.Length == 0) return 0.0;
        _directoryInfo =
            new DirectoryInfo(path);
        IEnumerable<FileInfo> fileInfos =
            _directoryInfo.EnumerateFiles
                (desen, SearchOption.AllDirectories);
        long boyut = fileInfos.
                Sum(x => new FileInfo(x.FullName).Length);
        return boyut;
    }

    public double BoyutDegeri(double byteDeger, SIBirim birimOnTaki,
        int kvt = 1024)
    {
        kvt = kvt != 1_024 ? 1_000 : kvt;
        if (birimOnTaki == SIBirim.Byte) return byteDeger;
        double carpan = Math.Pow(kvt, (int)birimOnTaki);
        return byteDeger / carpan;
    }
    public enum SIBirim
    {
        Byte = 0, KiloByte = 1, MegaByte = 2,
        GigaByte = 3, TeraByte = 4, PetaByte = 5,
        ExaByte = 6, ZettaByte = 7, YottaByte = 8,
        BrontoByte = 9
    }
}

