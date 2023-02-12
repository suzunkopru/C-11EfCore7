namespace OrnekForm1;
public partial class OrnekForm1 : Form
{
    public OrnekForm1()
    {
        InitializeComponent();
    }
    private string[] iller =
        {"Ýstanbul","Sakarya","Ankara","Ýzmir","Bursa"};
    private void OrnekForm1_Load(object sender, EventArgs e)
    {
        cmbIller.Items.AddRange(iller);   
    }

    private void btnTikla_Click(object sender, EventArgs e)
    {
        cmbIller.Items.Clear();
        Array.Sort(iller);
        cmbIller.Items.AddRange(iller);
        MessageBox.Show(iller[0]);
    }
}