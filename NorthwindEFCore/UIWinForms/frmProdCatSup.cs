namespace UIWinForms;
public partial class frmProdCatSup : Form
{
    private readonly IDalVwProdCatSup dalVwProdCatSup;
    public frmProdCatSup(IDalVwProdCatSup p_dalVwProdCatSup)
    {
        InitializeComponent();
        dalVwProdCatSup = p_dalVwProdCatSup;
    }
    private void frmProdCatSup_Load(object sender, EventArgs e)
    {
        dgwProdCatSup.DataSource = dalVwProdCatSup.GetAll().ToList();
        dgwProdCatSup.AutoResizeRows();
    }
}
