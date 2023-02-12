namespace AsOperator;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    int sayac = default;
    private void btnTemizle_Click(object sender, EventArgs e)
    {
        if (sayac == 1)
        {
            NesneleriTemizle();
            btnTemizle.Text = "Veri Y�kle";
        }
        if (sayac == 0)
        {
            NesnelereVeriYukle();
            btnTemizle.Text = "Veri Temizle";
        }
        sayac++;
        sayac = sayac > 1 ? 0 : sayac;
    }
    private void NesneleriTemizle()
    {
        foreach (Control item in Controls)
        {
            if (item is ComboBox)
            {
                (item as ComboBox).Items.Clear();
            }
            else if (item is ListBox)
            {
                ((ListBox)item).Items.Clear();
            }
            else if (item is TextBoxBase)
            {
                item.ResetText();
            }
        }
    }
    private void NesnelereVeriYukle()
    {
        cmbItem.Items.Add("1. cmb Eleman�");
        cmbItem.Items.Add("2. cmb Eleman�");
        cmbItem.Items.Add("3. cmb Eleman�");
        lboxItem.Items.Add("1. lbox Eleman�");
        lboxItem.Items.Add("2. lbox Eleman�");
        lboxItem.Items.Add("3. lbox Eleman�");
        txtText.Text = "Deneme Metni";
        rchText.Text = txtText.Text;
    }
}