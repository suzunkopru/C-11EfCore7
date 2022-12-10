using System.Globalization;
namespace NufusBilgileri;
internal enum MedeniHal { Evli, Bekar };
enum Cinsiyet { Bay, Bayan };
public partial class frmNufusBilgileri : Form
{
    readonly string TarihBicimi = "dd/MM/yyyy";
    readonly List<string> iller = new() { "Adana", "Ad�yaman", "Afyon", "A�r�",
        "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Ayd�n",
        "Bal�kesir", "Bart�n", "Batman", "Bayburt", "Bilecik", "Bing�l",
        "Bitlis", "Bolu", "Burdur", "Bursa", "�anakkale", "�ank�r�", "�orum",
        "Denizli", "Diyarbak�r", "D�zce", "Edirne", "Elaz��", "Erzincan",
        "Erzurum", "Eski�ehir", "Gaziantep", "Giresun", "G�m��hane", "Hakk�ri",
        "Hatay", "I�d�r", "Isparta", "�stanbul", "�zmir", "Kahramanmara�",
        "Karab�k", "Karaman", "Kars", "Kastamonu", "Kayseri", "K�r�kkale",
        "K�rklareli", "K�r�ehir", "Kilis", "Kocaeli", "Konya", "K�tahya",
        "Malatya", "Manisa", "Mardin", "Mersin", "Mu�la", "Mu�", "Nev�ehir",
        "Ni�de", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt",
        "Sinop", "Sivas", "�anl�urfa", "��rnak", "Tekirda�", "Tokat",
        "Trabzon", "Tunceli", "U�ak", "Van", "Yalova", "Yozgat", "Zonguldak" };
    readonly List<string> basliklar = new() {"S.No", "Do�um Tarihi", "Ad Soyad",
        "Do�um Yeri", "Medeni Hali", "Cinsiyet"};
    readonly List<string> isimler = new() { "Ay�e BET�L", "Amine OKUMU�",
        "S�leyman UZUNK�PR�", "Muhammed FAT�H", "Ahmet YAS�N", "Berces M�RDENL�",
        "Mustafa PARLAK", "�mer �REN�", "Burak DEREL�", "Oktay �ENT�RK",
        "Sabri B�RADLI","Hamit G�M��", "�lhan G�M��", "Bekir UZUN",
        "Hamza OKUMU�" };
    ColumnSort columnSort;
    public frmNufusBilgileri()
    {
        InitializeComponent();
        columnSort = new ColumnSort();
        lViKisi.ListViewItemSorter = columnSort;
    }
    private struct KisiBilgi
    {
        internal DateTime dTar;
        internal string adSyd;
        internal string dYer;
        internal MedeniHal medHal;
        internal Cinsiyet cnsy;
    }
    private void frmNufusBilgileri_Load(object sender, EventArgs e)
    {
        chkMedeniHal.Text =
            Enum.GetName(typeof(MedeniHal), (int)MedeniHal.Bekar);
        btnSil.Enabled = false;
        Text = "N�fus Bilgileri";
        ContextMenuStrip menu = new();
        menu.Items.Add("Rasgele Ki�i Ekle");
        menu.ItemClicked += Menu_ItemClicked;
        ContextMenuStrip = menu;
        mskDogTar.Mask = "00/00/0000";
        cmbDogYeri.Items.AddRange(iller.ToArray());
        lBoxIller.Items.AddRange(iller.ToArray());
        dteDogTarihi.CustomFormat = TarihBicimi;
        lViKisi.View = View.Details;
        lViKisi.GridLines = true;
        lViKisi.HeaderStyle = ColumnHeaderStyle.Clickable;
        lViKisi.Sorting = SortOrder.Ascending;
        lViKisi.FullRowSelect = true;
        for (int i = 0; i < basliklar.Count(); i++)
        {
            ColumnHeader columnHeader = new();
            columnHeader.Text = basliklar[i];
            lViKisi.Columns.Add(columnHeader);
        }
        lViKisi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        txtAdSoyad.Focus();
    }
    private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        {
            Random rnd = new();
            int yil = DateTime.Today.Year;
            int yilRnd = rnd.Next(yil - 40, yil - 18 + 1);
            int ay = rnd.Next(1, 12 + 1);
            int ayinSonGunu = DateTime.DaysInMonth(yilRnd, ay);
            int gun = rnd.Next(1, ayinSonGunu + 1);
            int dogYer = rnd.Next(0, iller.Count);
        geri:
            int isim = rnd.Next(0, isimler.Count);
            foreach (ListViewItem item in lViKisi.Items)
            {
                int adStn = basliklar.IndexOf("Ad Soyad");
                if (item.SubItems[adStn].Text == isimler[isim])
                {
                    if (lViKisi.Items.Count == isimler.Count())
                    {
                        MessageBox.Show("Eklenebilecek isimlerin t�m� bitti.");
                        return;
                    }//2. if merdiveni kapsam (scope) biti�i.
                    goto geri;
                } //1. if merdiveni kapsam (scope) biti�i.
            }//foreach (ListViewItem item in lViKisi.Items) d�ng�s� bitti.
            KisiBilgi kisiBilgi = new();
            kisiBilgi.dTar = new DateTime(yilRnd, ay, gun);
            kisiBilgi.adSyd = isimler[isim];
            kisiBilgi.dYer = lBoxIller.Text = iller[dogYer];
            mskDogTar.Text = dteDogTarihi.Text =
                kisiBilgi.dTar.ToString(TarihBicimi);
            txtAdSoyad.Text = kisiBilgi.adSyd;
            cmbDogYeri.Text = kisiBilgi.dYer;
            rdbBayan.Checked = isim <= 1;
            rdbBay.Checked = isim > 1;
            btnEkle_Click(null, null);
        }
    }
    int adStn;
    private void btnEkle_Click(object sender, EventArgs e)
    {
        bool bosmu;
        BosNesneKontrol(out bosmu);
        if (bosmu) return;
        string cinsiyet = Cinsiyeti();
        DateTime tarih;
        bool tarihMi = DateTime.TryParse(mskDogTar.Text, out tarih);
        if (!tarihMi)
        {
            MessageBox.Show
            ($"{mskDogTar.Text} ge�erli de�il.",
                "Do�ru bir tarih bi�imi girmelisiniz.");
            return;
        }
        string[] lists =
        {string.Empty, tarih.ToString(TarihBicimi),  txtAdSoyad.Text.Trim(),
            cmbDogYeri.Text, chkMedeniHal.Text, cinsiyet};
        ListViewItem lvItem = new(lists);
        txtAdSoyad.Text = txtAdSoyad.Text.Trim().Replace("  ", " ");
        if (lViKisi.Items.Count > 0)
        {
            foreach (ListViewItem item in lViKisi.Items)
            {
                adStn = basliklar.IndexOf("Ad Soyad");
                if (item.SubItems[adStn].Text == txtAdSoyad.Text)
                {
                    Color sakla = item.BackColor;
                    item.BackColor = Color.Gold;
                    MessageBox.Show($"{txtAdSoyad.Text} zaten ekli");
                    item.BackColor = sakla;
                    return;
                }
            }
        }
        lViKisi.Items.Add(lvItem);
        BackColor = RgbRenkUret();
        foreach (Control item in pnlGrup.Controls)
        {
            item.BackColor = RgbRenkUret();
        }
        if (lViKisi.Items.Count % 2 != 0) lvItem.BackColor = RgbRenkUret();
        btnSil.Enabled = lViKisi.Items.Count > 0;
        if (lViKisi.Items.Count > 6)
        {
            int rowH = lViKisi.Height / lViKisi.Items.Count;
            lViKisi.Height += rowH;
            Height += rowH;
        }
        SatirNo(lViKisi);
    }
    public Color RgbRenkUret(byte i = 230, byte j = 250)
    {
        Random rnd = new();
        return Color.FromArgb
            (rnd.Next(i, j + 1), rnd.Next(i, j + 1), rnd.Next(i, j + 1));
    }
    public void SatirNo(ListView lvi)
    {
        int sno = basliklar.IndexOf("S.No");
        int sayac = 0;
        foreach (ListViewItem item in lvi.Items)
        {
            item.SubItems[sno].Text = (++sayac).ToString("00");
        }
    }
    private void dteDogTarihi_ValueChanged(object sender, EventArgs e)
    {
        mskDogTar.Text = dteDogTarihi.Value.ToString(TarihBicimi);
    }
    private void lBoxIller_Click(object sender, EventArgs e)
    {
        cmbDogYeri.Text = lBoxIller.Text;
    }
    private void chkMedeniHal_CheckedChanged(object sender, EventArgs e)
    {
        MedeniHalCheck(sender as CheckBox);
    }
    private void MedeniHalCheck(CheckBox chkBox)
    {
        chkBox.Text = chkBox.Checked //Buras� sorgulanan k�s�m
            ? //Buras� true ise �al��an k�s�m
            Enum.GetName(typeof(MedeniHal), (int)MedeniHal.Evli)
            : //Buras� false ise �al��an k�s�m
            Enum.GetName(typeof(MedeniHal), (int)MedeniHal.Bekar);
    }
    private string Cinsiyeti()
    {
        if (rdbBay.Checked)
        {
            return Enum.GetName(typeof(Cinsiyet), (int)Cinsiyet.Bay);
        }
        else if (rdbBayan.Checked)
        {
            return Enum.GetName(typeof(Cinsiyet), (int)Cinsiyet.Bayan);
        }
        return string.Empty;
    }
    private void BosNesneKontrol(out bool bosVarmi)
    {
        bosVarmi = false;
        string boslar = "N�fus bilgileri eklenemiyor.\n";
        foreach (Control item in pnlGrup.Controls)
        {
            if (item.Text == string.Empty)
            {
                if (item is CheckBox) continue;
                if (item is GroupBox)
                {
                    if (!rdbBay.Checked && !rdbBayan.Checked)
                    {
                        boslar += "Cinsiyet Bilgisi Yok\n";
                        bosVarmi = true;
                    }
                }
                else
                {
                    boslar += item.Name + "\n";
                    bosVarmi = true;
                }
            }
        }
        if (bosVarmi == true)
            MessageBox.Show(boslar, "Baz� Nesneler Bo� B�rak�lm��");
    }
    private void txtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = KlavyeTus�zni(txtAdSoyad, e, false);
    }
    public char OndalikAyrac()
    {
        return char.Parse(CultureInfo.CurrentCulture.
            NumberFormat.NumberDecimalSeparator);
    }
    private bool KlavyeTus�zni
        (Control sender, KeyPressEventArgs e, bool StrNum = true)
    {
        if (StrNum)
        {
            bool araVirgul = !sender.Text.Contains(OndalikAyrac());
            e.Handled =
                !(char.IsDigit(e.KeyChar) ||
                  e.KeyChar == (char)Keys.Back || e.KeyChar == OndalikAyrac() &&
                  araVirgul);
        }
        else
        {
            e.Handled =
                char.IsDigit(e.KeyChar) ||
                !char.IsUpper(e.KeyChar) && !char.IsLower(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back;
        }
        return e.Handled;
    }
    private void txtAdSoyad_Click(object sender, EventArgs e)
    {
        txtAdSoyad.SelectAll();
    }
    private void mskDogTar_Click(object sender, EventArgs e)
    {
        mskDogTar.SelectAll();
    }
    bool tikla;
    private void btnSutun_Click(object sender, EventArgs e)
    {
        tikla = !tikla;
        lViKisi.AutoResizeColumns(tikla ?
            ColumnHeaderAutoResizeStyle.HeaderSize :
            ColumnHeaderAutoResizeStyle.ColumnContent);
    }
    private void btnSil_Click(object sender, EventArgs e)
    {
        if (lViKisi.SelectedIndices.Count <= 0)
        {
            MessageBox.Show("Listeden neyi silmemi istiyorsan�z se�melisiniz.");
            return;
        }
        if (lViKisi.Items.Count > 0 && lViKisi.SelectedIndices.Count > 0)
        {
            for (int i = lViKisi.Items.Count - 1; i >= 0; i--)
            {
                if (lViKisi.Items[i].Selected) lViKisi.Items[i].Remove();
            }
            for (int i = 0; i < lViKisi.Items.Count; i++)
            {
                if (lViKisi.Items[i].Selected)
                {
                    lViKisi.Items[i].Remove();
                    i--;
                }
            }
            if (lViKisi.Items.Count > 0)
                lViKisi.Items[lViKisi.Items.Count - 1].Selected = true;
            btnSil.Enabled = lViKisi.Items.Count > 0;
        }
    }
    private void lViKisi_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        if (e.Column == columnSort.e)
        {
            columnSort.sortStatus = columnSort.sortStatus == SortOrder.Ascending
                ?
                columnSort.sortStatus = SortOrder.Descending
                :
                columnSort.sortStatus = SortOrder.Ascending;
        }
        else
        {
            columnSort.e = e.Column;
            columnSort.sortStatus = SortOrder.Ascending;
        }
        lViKisi.Sort();
    }
}
