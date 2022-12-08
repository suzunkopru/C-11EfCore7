using System.Globalization;
using static System.Convert;

namespace HesapMakinesiTryCatchFinally;
public partial class HesapMakinesi : Form
{
    public HesapMakinesi() => InitializeComponent();
    private enum DortIslem
    { Topla = 0, Cikar = 1, Carp = 2, Bol = 3 }
    private void HesapMakinesi_Load(object sender, EventArgs e)
            => cmbIslemler.Items.AddRange
            (Enum.GetNames(typeof(DortIslem)));
    private void btnIslem_Click(object sender, EventArgs e)
                => ComboBoxSecimYap();
    private void ComboBoxSecimYap()
            => cmbIslemler.SelectedIndex =
               cmbIslemler.SelectedIndex == -1
                ? 0
                : cmbIslemler.SelectedIndex;
    private void lblSil_Click(object sender, EventArgs e)
    {
        ComboBoxSecimYap();
        try
        {
            int secim = lstSayilar.SelectedIndex;
            lstSayilar.Items.RemoveAt(secim);
            lstSayilar.SelectedIndex = secim - 1;
            Hesapla();
            if (lstSayilar.Items.Count == 0)
            {
                txtSonuc.ResetText();
                    lblSil.BackColor = 
                    lstSayilar.BackColor = Color.Empty;
            }
            txtSayi.ResetText();
            lblSil.BackColor = Color.AliceBlue;
        }
        catch (Exception Ex)
        {
            MessageBox.Show
                ($@"{Ex.GetType()} {Ex.Message} ");
        }
        finally
        {
            lstSayilar.BackColor = Color.AliceBlue;
        }
    }
    private void txtSayi_KeyPress(object sender,
                            KeyPressEventArgs e)
            => SadeceOndalikIzni(sender, e);

    char ondalik = char.Parse(CultureInfo.CurrentCulture.
      NumberFormat.NumberDecimalSeparator);
    private void SadeceOndalikIzni
        (object sender, KeyPressEventArgs e)
    {
        char ayrac = ondalik;
        bool araVirgul = (sender as Control)!
            .Text.Contains(ayrac.ToString());
        e.Handled =
            !(char.IsDigit(e.KeyChar) ||
            e.KeyChar == (char)Keys.Back
            || e.KeyChar == ayrac && araVirgul);
    }
    private void btnSayiEkle_Click(object sender, EventArgs e)
    {
        lstSayilar.BackColor = Color.Empty;
        Random random = new Random();
        string rastgele = random.Next().
            ToString($"0{ondalik}0");
        bool varmi = lstSayilar.Items
            .IndexOf(txtSayi.Text) == -1;
        if (txtSayi.Text == string.Empty || varmi == false)
                                txtSayi.Text = rastgele;
        ErrorProvider hataIkonu = new();
        hataIkonu.Icon = SystemIcons.Warning;
        int sayi = 1_000_000_000;
        if (double.Parse(txtSayi.Text) > sayi)
        {
            hataIkonu.SetError(txtSayi,
        $"Sayý {sayi}'den büyük olamaz. " +
                                $"{txtSayi:0,00}");
        }
        if (IsNumeric(txtSayi.Text))
            lstSayilar.Items.Add(txtSayi.Text);
        txtSayi.Select(0, txtSayi.TextLength);
        txtSayi.Focus();
        txtSonuc.ResetText();
    }
    public bool IsNumeric(string Sayi)
        => double.TryParse(Sayi, out double Sayimi);
    private void btnSonuc_Click
        (object sender, EventArgs e) => Hesapla();
    private void Hesapla()
    {
        double Biriktir = 0;
        if (lstSayilar.Items.Count <= 0) return;
        switch (cmbIslemler.SelectedIndex)
        {
            case -1:
                cmbIslemler.Select();
                MessageBox.Show
                    (@"Yapmak istediðiniz iþlemi seçiniz.");
                break;
            case (int)DortIslem.Topla:
                Biriktir = HesMak(Biriktir, DortIslem.Topla);
                break;
            case (int)DortIslem.Cikar:
                Biriktir = HesMak(Biriktir, DortIslem.Cikar);
                break;
            case (int)DortIslem.Carp:
                Biriktir = HesMak(Biriktir, DortIslem.Carp);
                break;
            case (int)DortIslem.Bol:
                Biriktir = HesMak(Biriktir, DortIslem.Bol);
                break;
        }
        txtSonuc.Text = Biriktir.ToString($"0{ondalik}0");
    }
    private double HesMak(double Biriktir, DortIslem islem)
    {
        foreach (var sayi in lstSayilar.Items)
            switch (islem)
            {
                case DortIslem.Topla:
                    Biriktir += ToDouble(sayi);
                    break;
                case DortIslem.Cikar:
                    Biriktir -= ToDouble(sayi);
                    break;
                case DortIslem.Carp:
                    Biriktir *= ToDouble(sayi);
                    break;
                case DortIslem.Bol:
                    Biriktir /= ToDouble(sayi);
                    break;
            }
        return Biriktir;
    }
    private void HesapMakinesi_MouseClick
            (object sender, MouseEventArgs e)
            => MessageBox.Show(e.GetType().Name);
}
