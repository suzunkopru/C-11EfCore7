namespace AllWindowsForm;
public partial class OrnekFrom1 : Form
{
    public OrnekFrom1()
    {
        InitializeComponent();
    }

    private string[] iller =
        {"Ýstanbul","Sakarya","Ankara","Ýzmir","Bursa"};
    private void Ornek1_Load(object sender, EventArgs e)
    {
        cmbIller.Items.AddRange(items: iller);
    }

    private void btnTikla_Click(object sender, EventArgs e)
    {
        cmbIller.Items.Clear();
        Array.Sort(iller);      
        cmbIller.Items.AddRange(iller);
        MessageBox.Show(iller[0]);
    }
}