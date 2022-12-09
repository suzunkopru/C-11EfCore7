using System.Diagnostics;
using System.Numerics;
using System.Text;
using Timer = System.Windows.Forms.Timer;
namespace FileWordImageMenuTabControlEtc;
public partial class WordWebPicture : Form
{
    public WordWebPicture() => InitializeComponent();
    #region Bu sýnýf için genel kullanýma açýk deðiþkenler
    private StatusStrip _statusStrip;
    DirectoryInfo _directoryInfo;
    private RichTextBox _richTextBox;
    private Font _font;
    private FontDialog _fontDialog;
    private ColorDialog _colorDialog;
    private OpenFileDialog _oFileDialog;
    private SaveFileDialog _saveFileDialog;
    private WebBrowser _webBrowser;
    private PictureBox _pictureBox;
    private TabControl _tabControl;
    private TabPage _tabMetin, _tabWeb, _tabResim;
    private string _filter;
    private List<string> _whrPct;
    private int _whichPict = 0;
    private int _i;
    private bool _baslat = false;
    private Timer _timer;
    #endregion Bu sýnýf için genel kullanýma açýk deðiþkenler
    private void WordWebPicture_Load(object sender, System.EventArgs e)
    {
        #region Form Ayarlarý
        WindowState = FormWindowState.Maximized;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Left = Top = 0;
        Size = Screen.PrimaryScreen!.WorkingArea.Size;
        #endregion Form Ayarlarý
        #region Ana Menüler
        MenuStrip menuStrip = new();
        ToolStripMenuItem tsmItemDosya =
       new ToolStripMenuItem("Dosya Ýþlemleri");
        ToolStripMenuItem tsmItemMetin =
       new ToolStripMenuItem("Metin Ýþlemleri");
        ToolStripMenuItem tsmItemWeb =
       new ToolStripMenuItem("Web Ýþlemleri");
        ToolStripMenuItem tsmItemResim =
       new ToolStripMenuItem("Resim Ýþlemleri");
        ToolStripMenuItem[] anaMenuItem =
       { tsmItemDosya, tsmItemMetin, tsmItemWeb, tsmItemResim };
        menuStrip.Items.AddRange(anaMenuItem);
        #endregion Ana Menüler
        #region Dosya Menüsü Alt Menüleri
        ToolStripMenuItem tsmItemDosyaAc = new("Dosya Aç");
        tsmItemDosyaAc.Click += tsmItemDosyaAc_Click;
        ToolStripMenuItem tsmItemDosyaKaydet = new("Dosya Kaydet");
        tsmItemDosyaKaydet.Click += tsmItemDosyaKaydet_Click;
        ToolStripMenuItem[] tsmItemDosyaAlt =
                    { tsmItemDosyaAc, tsmItemDosyaKaydet};
        tsmItemDosya.DropDownItems.AddRange(tsmItemDosyaAlt);
        ToolStripMenuItem tsmItemDosyaKaydetTum =
       new("Dosya Kaydet Tüm Tipler");
        tsmItemDosyaKaydet.DropDownItems.Add(tsmItemDosyaKaydetTum);
        tsmItemDosyaKaydetTum.Click += TsmItemDosyaKaydetTum_Click;
        #endregion Dosya Menüsü Alt Menüleri
        #region Metin Menüsü Alt Menüleri
        ToolStripMenuItem tsmItmMtnFnt = new("Font Ayarla");
        tsmItmMtnFnt.Click += tsmItmMtnFnt_Click;
        ToolStripMenuItem tsmItmMtnRnk = new("Renk Ayarla");
        tsmItmMtnRnk.Click += tsmItmMtnRnk_Click;
        ToolStripMenuItem tsmItemMetinArkaplan =
       new ToolStripMenuItem("Arkaplan Rengi Ayarla");
        tsmItemMetinArkaplan.Click += TsmItemMetinArkaplan_Click;
        ToolStripMenuItem[] tsmItemMetinAlt =
        { tsmItmMtnFnt, tsmItmMtnRnk, tsmItemMetinArkaplan };
        tsmItemMetin.DropDownItems.AddRange(tsmItemMetinAlt);
        #endregion Metin Menüsü Alt Menüleri
        #region Web Menüsü Alt Menüleri
        ToolStripMenuItem tsmItemMetinDoviz = new();
        tsmItemMetinDoviz.Text = "Merkez Bankasý Döviz Kurlarý";
        tsmItemMetinDoviz.Click += TsmItemDoviz_Click;
        ToolStripTextBox tsmItemMetinAdres = new();
        ToolTip toolTip = new();
        toolTip.ShowAlways = true;
        toolTip.IsBalloon = true;
        toolTip.ToolTipIcon = ToolTipIcon.Info;
        toolTip.ToolTipTitle = "Arama Ýþlemi";
        toolTip.UseAnimation = true;
        toolTip.UseFading = true;
        string aciklama = "google ile aranacak metni yazýnýz".ToUpper();
        toolTip.SetToolTip(tsmItemMetinAdres.TextBox!, aciklama);
        tsmItemMetinAdres.Text = @"Süleyman UZUNKÖPRÜ";
        tsmItemMetinAdres.Size = new(300, tsmItemMetinAdres.Height);
        tsmItemMetinAdres.Click += TsmItemMetinAdres_Click!;
        tsmItemMetinAdres.MouseEnter += TsmItemMetinAdres_MouseEnter!;
        ToolStripItem[] tsmItemWebAlt =
       { tsmItemMetinDoviz, tsmItemMetinAdres};
        tsmItemWeb.DropDownItems.AddRange(tsmItemWebAlt);
        #endregion Web Menüsü Alt Menüleri
        #region Resim Menüsü Alt Menüleri
        ToolStripMenuItem toolStripMenuItemSlayt = new();
        toolStripMenuItemSlayt.Text = @"Slayt Gösterisi";
        ToolStripItem[] tsmItemResimAlt =
       { toolStripMenuItemSlayt};
        toolStripMenuItemSlayt.Click += ToolStripMenuItemSlayt_Click!;
        tsmItemResim.DropDownItems.AddRange(tsmItemResimAlt);
        #endregion Resim Menüsü Alt Menüleri
        #region Sekmeler ve Sekme Sayfalarý
        Controls.Add(menuStrip);
        _tabControl = new();
        _tabControl.Left = 10;
        _tabControl.Top = menuStrip.Height;
        _tabControl.Width = Width - 50;
        _statusStrip = new();
        Controls.Add(_statusStrip);
        _tabControl.Height =
            Height - menuStrip.Height - _statusStrip.Height - 45;
        _tabMetin = new();
        _tabMetin.Text = "Zengin Metin Biçimi";
        _tabWeb = new();
        _tabWeb.Text = "Web Browser";
        _tabResim = new();
        _tabResim.Text = "Resim Ýþlemleri";
        _tabResim.Click += _tabResim_Click!;
        _tabControl.Controls.Add(_tabMetin);
        _tabControl.Controls.Add(_tabWeb);
        _tabControl.Controls.Add(_tabResim);
        Controls.Add(_tabControl);
        _richTextBox = new RichTextBox();
        _richTextBox.Size = _tabMetin.Size;
        _webBrowser = new WebBrowser();
        _webBrowser.Size = _tabWeb.Size;
        _webBrowser.ScriptErrorsSuppressed = true;
        _tabMetin.Controls.Add(_richTextBox);
        _tabWeb.Controls.Add(_webBrowser);
        _tabResim.Controls.Add(_pictureBox);
        _richTextBox.Text = @"Bu bir deneme metnidir.";
        _richTextBox.Text += Environment.NewLine;
        _richTextBox.Text += @"Yeni satýra bir metin daha yazdým.";
        _font = new Font("Arial", 16, FontStyle.Bold);
        //_richTextBox.Font = _font;
        _richTextBox.SelectAll();
        _richTextBox.SelectionFont = _font;
        _richTextBox.SelectionColor = Color.DarkOrange;
        #endregion Sekmeler ve Sekme Sayfalarý
        #region Dosyalama Ýþlemleri Ýçin Tanýmlamalar.
        _directoryInfo =
       new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent;
        _filter = "Zengin Metin Biçimi Dosyalarý (*.rtf)|*.rtf" +
        "|" +
        "Text Dosyalar (*.txt)|*.txt";
        #endregion Dosyalama Ýþlemleri Ýçin Tanýmlamalar.
        PictureLoad();
    }
    #region Dosya Ýþlemleri
    private void tsmItemDosyaKaydet_Click(object sender, EventArgs e)
    {
        SaveDialog(_filter);
    }
    private void TsmItemDosyaKaydetTum_Click(object sender, EventArgs e)
    {
        SaveDialog("Tüm Dosyalar (*.*)|*.*");
    }
    private void SaveDialog(string filter)
    {
        _tabControl.SelectedTab = _tabMetin;
        _saveFileDialog = new SaveFileDialog();
        _saveFileDialog.Filter = filter;
        _saveFileDialog.Title = @"Dosya Kaydetme Ýþlemi";
        _saveFileDialog.InitialDirectory = _directoryInfo.FullName;
        FileSave(_richTextBox);
    }
    private void tsmItemDosyaAc_Click(object sender, EventArgs e)
    {
        _tabControl.SelectedTab = _tabMetin;
        _oFileDialog = new OpenFileDialog();
        FileOpen(_richTextBox);
    }
    private void FileOpen(RichTextBox richTextBox)
    {
        _richTextBox.Text = string.Empty;
        _oFileDialog.InitialDirectory = _directoryInfo.FullName;
        _oFileDialog.Title = @"Açmak istediðiniz dosyayý seçiniz.";
        _oFileDialog.Filter = _filter;
        if (_oFileDialog.ShowDialog() == DialogResult.OK
       && _oFileDialog.FileName.Length > 0)
        {
            string uzanti = Path.GetExtension(_oFileDialog.FileName);
            if (uzanti == ".txt")
            {
                StreamReader sReader = new StreamReader
               (_oFileDialog.FileName, Encoding.UTF8);
                string okunanVeri = sReader.ReadToEnd();
                _richTextBox.Text = okunanVeri;
                sReader.Close();
                sReader.Dispose();
            }
            else if (uzanti == ".rtf")
            {
                richTextBox.LoadFile(_oFileDialog.FileName,
               RichTextBoxStreamType.RichText);
            }
        }
    }
    private void FileSave(RichTextBox richTextBox)
    {
        if (string.IsNullOrWhiteSpace(richTextBox.Text)) return;
        _saveFileDialog.Title = @"Dosya Kaydediliyor.";
        _saveFileDialog.FileName =
            Path.GetRandomFileName().Replace(".", "");
        if (_saveFileDialog.ShowDialog() == DialogResult.OK
       && _saveFileDialog.FileName.Length > 0)
        {
            string uzanti = Path.GetExtension(_saveFileDialog.FileName);
            if (uzanti == ".txt")
            {
                StreamWriter sWriter = new StreamWriter
               (_saveFileDialog.FileName, false, Encoding.UTF8);
                sWriter.WriteLine(richTextBox.Rtf);
                sWriter.Close();
                sWriter.Dispose();
            }
            else if (uzanti == ".rtf")
            {
                richTextBox.SaveFile(
               _saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }
    }
    #endregion Dosya Ýþlemleri
    #region Kelime Ýþlemci (rtf ve txt) Metotlarý
    private void tsmItmMtnFnt_Click(object sender, EventArgs e)
    {
        if (_richTextBox.SelectedText.Length == 0)
        {
            _richTextBox.SelectAll();
            _richTextBox.Font = _font;
        }
        _tabControl.SelectedTab = _tabMetin;
        _fontDialog = new FontDialog();
        _fontDialog.ShowColor = true;
        _fontDialog.ShowEffects = true;
        _fontDialog.ShowApply = true;
        _fontDialog.Apply += _fontDialog_Apply!;
        if (_fontDialog.ShowDialog() != DialogResult.OK)
        {
            FontAyarla(_fontDialog, _richTextBox);
        }
    }
    private void _fontDialog_Apply(object sender, EventArgs e)
    {
        FontAyarla(sender as FontDialog, _richTextBox);
    }
    private void FontAyarla(FontDialog fontDialog, dynamic control)
    {
        try
        {
            control.SelectAll();
            control.Font = fontDialog.Font;
            control.ForeColor = fontDialog.Color;
        }
        catch (Exception)
        {
            string mesaj = $$"""
                {{control}} için SelectAll metodu veya Font
                yada ForeColor özeliði yok
                """;
            MessageBox.Show(mesaj);
        }
    }
    private void tsmItmMtnRnk_Click(object sender, EventArgs e)
    {
        _colorDialog = new ColorDialog();
        if (_colorDialog.ShowDialog() != DialogResult.OK ||
       _richTextBox.SelectedText.Length == 0)
        {
            MessageBox.Show(@"Seçili bir metin bulunamadý",
           @"Renklendirilecek metni seçmelisiniz.");
            return;
        }
        _tabControl.SelectedTab = _tabMetin;
        _richTextBox.SelectionColor = _colorDialog.Color;
    }
    private void TsmItemMetinArkaplan_Click
                        (object sender, System.EventArgs e)
    {
        _tabControl.SelectedTab = _tabMetin;
        if (_colorDialog.ShowDialog() != DialogResult.OK ||
       _richTextBox.SelectedText.Length == 0) return;
        _richTextBox.BackColor = _colorDialog.Color;
    }
    #endregion Kelime Ýþlemci (rtf ve txt) Metotlarý
    #region Web Ýþlem Metotlarý
    private void TsmItemMetinAdres_MouseEnter(object sender, EventArgs e)
    {
        _tabControl.SelectedTab = _tabWeb;
        _webBrowser.Navigate
            ($"http://google.com/search?q= {sender}");
    }
    private void TsmItemDoviz_Click(object sender, EventArgs e)
    {
        _tabControl.SelectedTab = _tabWeb;
        string[] Diller = { "tr", "en" };
        DialogResult dialogResult = MessageBox.Show
        (@"Sayfa Türkçe Açýlsýn mý?",
       @"Dil Seçimi", MessageBoxButtons.YesNo);
        string DilSecimi =
       dialogResult == DialogResult.Yes ? Diller[0] : Diller[1];
        string link = "https://tcmb.gov.tr/wps/wcm/connect/";
        link += $"{DilSecimi}/tcmb+{DilSecimi}";
        link += "/main+page+site+area/";
        link += dialogResult == DialogResult.Yes ? "Bugun" : "Today";
        _webBrowser.Navigate(link);
    }
    private void TsmItemMetinAdres_Click(object sender, EventArgs e)
    {
        _tabControl.SelectedTab = _tabWeb;
        _webBrowser.Navigate(sender.ToString());
    }
    #endregion Web Ýþlem Metotlarý
    #region Resim Ýþlemleri için Metotlar
    private void _tabResim_Click(object sender, EventArgs e)
    {
        PictureLoad();
    }
    private void PictureLoad()
    {
        if (_whrPct != null) return;
        _whrPct = Directory.GetFiles("../../../Resimler", "*.jpg").ToList();
        TableLayoutPanel tableLayoutPanel = new();
        tableLayoutPanel.Dock = DockStyle.Left;
        tableLayoutPanel.ColumnCount = 2;
        _pictureBox = new();
        _pictureBox.Size = tableLayoutPanel.Size = _tabResim.Size;
        foreach (string myPictures in _whrPct)
        {
            Button btnForPicture = new();
            btnForPicture.Margin = new(0);
            btnForPicture.BackgroundImage = Image.FromFile(myPictures);
            btnForPicture.BackgroundImageLayout = ImageLayout.Stretch;
            btnForPicture.Tag = _i++;
            btnForPicture.MouseUp += btnForPicture_MouseUp!;
            btnForPicture.MouseHover += btnForPicture_MouseHover!;
            tableLayoutPanel.Controls.Add(btnForPicture);
        }
        decimal ResimAdet = (decimal)tableLayoutPanel.Controls.Count / 2;
        ResimAdet = Math.Ceiling(ResimAdet);
        int btnGenislik = 0;
        foreach (Control item in tableLayoutPanel.Controls)
        {
            if (item is Button)
            {
                int genislik = tableLayoutPanel.Height / (int)ResimAdet;
                item.Width = item.Height = genislik;
            }
            btnGenislik = item.Width;
        }
        tableLayoutPanel.Width = (btnGenislik * 2) + 30;
        _pictureBox.AutoSize = true;
        _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        tableLayoutPanel.RowCount = (int)ResimAdet;
        _tabResim.Controls.Add(tableLayoutPanel);
        _tabResim.Controls.Add(_pictureBox);
        double bSize = KlasorBoyutu(_directoryInfo.FullName, "*.jpg");
        ToolStripSeparator separator;
        ToolStripStatusLabel sLabel;
        List<string> durumCubuguMetni = new()
   {
            $"{_i} adet resim yüklendi. Yüklenen resimlerin boyutu: "   ,
            $"{bSize:N0} Byte " ,
            $"{BoyutDegeri(bSize, SIBirim.MegaByte):N0} " +
            $"{SIBirim.MegaByte}"   ,
            $"{BoyutDegeri(bSize, SIBirim.GigaByte):N2} " +
            $"{SIBirim.GigaByte }"
   };
        int durumCubuguAdet = durumCubuguMetni.Count;
        for (int i = 0; i < durumCubuguAdet; i++)
        {
            separator = new ToolStripSeparator();
            _statusStrip.Items.Add(separator);
            sLabel = new ToolStripStatusLabel();
            sLabel.Text = durumCubuguMetni[i];
            sLabel.BorderSides = ToolStripStatusLabelBorderSides.All;
            _statusStrip.Items.Add(sLabel);
        }
    }
    private void btnForPicture_MouseUp(object sender, MouseEventArgs e)
    {
        switch (e.Button)
        {
            case MouseButtons.Left:
                _pictureBox.Image = Image.FromFile
               (_whrPct[Convert.ToInt32((sender as Button).Tag)]);
                break;
            case MouseButtons.Right:
                string yol =
               _whrPct[Convert.ToInt32((sender as Button).Tag)];
                _myStart(yol);
                DirectoryInfo directoryInfo = new DirectoryInfo(yol).Parent;
                _myStart(directoryInfo.FullName);
                FileInfo fileInfo = new FileInfo(yol);
                string dosyaBilgi = $"Boyut {fileInfo.Length:N0} Byte" +
                $"\nDosya Adý: {fileInfo.Name}" +
                $"\nDosya Yolu: {directoryInfo.FullName}";
                MessageBox.Show(dosyaBilgi, "Dosyanýz Hakkýnda");
                break;
        }
    }
    private void btnForPicture_MouseHover(object sender, EventArgs e)
    {
        string yol = _whrPct[Convert.ToInt32((sender as Button).Tag)];
        ToolTip toolTip = new ToolTip();
        toolTip.ShowAlways = true;
        toolTip.IsBalloon = true;
        toolTip.ToolTipIcon = ToolTipIcon.Info;
        toolTip.ToolTipTitle = "DOSYA BOYUTU BÝLGÝSÝ";
        toolTip.UseAnimation = true;
        toolTip.UseFading = true;
        toolTip.AutomaticDelay = 1_000;
        double byt = DosyaBoyutu(yol);
        string aciklama = $"{byt:N2} {SIBirim.Byte} ";
        aciklama += $"\n{BoyutDegeri(byt, SIBirim.MegaByte):N2} ";
        aciklama += $"{SIBirim.MegaByte}";
        DirectoryInfo dInfo = _directoryInfo;
        aciklama += $"\nDosya yolu: {dInfo.FullName + yol}";
        toolTip.SetToolTip(sender as Button, aciklama);
    }
    private void ToolStripMenuItemSlayt_Click(object sender, EventArgs e)
    {
        _timer = new Timer();
        _timer.Interval = 1_000;
        _tabControl.SelectedTab = _tabResim;
        _timer.Tick += timer_Tick;
        if (_baslat)
        {
            ((sender as ToolStripMenuItem)!).Text = "Slaytý Baslat";
            _timer.Stop();
            _baslat = false;
        }
        else
        {
            ((sender as ToolStripMenuItem)!).Text = "Slaytý Durdur";
            _timer.Start();
            _baslat = true;
        }
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        if (!_baslat) return; //Eðer _baslat baþlamadý ise metodu sonlandýr.
        _whichPict++;
        if (_whichPict > _whrPct.Count - 1) _whichPict = 0;
        _pictureBox.ImageLocation = _whrPct[_whichPict];
    }
    #endregion Resim Ýþlemleri için Metotlar
    #region Dosya Boyut Bilgileri
    private double KlasorBoyutu(string path, string desen)
    {
        var fileInfos =
            _directoryInfo.EnumerateFiles(desen, SearchOption.AllDirectories);
        var boyut = fileInfos.Sum(x => new FileInfo(x.FullName).Length);
        return boyut;
    }
    private double DosyaBoyutu(string path)
    {
        FileInfo fileInfo = new FileInfo(path);
        return fileInfo.Length;
    }
    public double BoyutDegeri(double byteDeger, SIBirim birimOnTaki,
            int kuvvet = 1024)
    {
        kuvvet = kuvvet != 1_024 ? 1_000 : kuvvet;
        if (birimOnTaki == SIBirim.Byte) return byteDeger;
        double carpan = Math.Pow(kuvvet, (int)birimOnTaki);
        Boyutlar();
        return byteDeger / carpan;
    }
    public double BoyutDegeri(double deger, SIBirim gelenBirim,
            SIBirim cevirBirim, int kuvvet = 1024)
    {
        kuvvet = kuvvet != 1_024 ? 1_000 : kuvvet;
        int birimFarki = (int)gelenBirim - (int)cevirBirim;
        double carpan;
        if (birimFarki > 0)
        {
            carpan = birimFarki / (double)kuvvet;
        }
        else
        {
            carpan = Math.Pow(kuvvet, birimFarki);
        }
        return deger / carpan;
    }
    private void Boyutlar()
    {
        for (int i = 1; i <= 9; i++)
        {
            Debug.WriteLine(BigInteger.Pow(1024, i).ToString("0,0"));
        }
        int deger = 1_024;
        Debug.Write(BoyutDegeri
            (deger, SIBirim.GigaByte, SIBirim.MegaByte));
        Debug.WriteLine($" {SIBirim.MegaByte} {deger} {SIBirim.GigaByte}");
    }
    public enum SIBirim
    {
        Byte = 0,       //8 bit
        KiloByte = 1,
        MegaByte = 2,
        GigaByte = 3,
        TeraByte = 4,
        PetaByte = 5,
        ExaByte = 6,
        ZettaByte = 7,
        YottaByte = 8,
        BrontoByte = 9
    }
    #endregion Dosya Boyut Bilgileri
    private static void _myStart(string yol)
    {
        Process prc = new Process();
        prc.StartInfo = new ProcessStartInfo(yol)
        {
            UseShellExecute = true
        };
        prc.Start();
    }
}