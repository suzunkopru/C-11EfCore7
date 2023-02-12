namespace UIWinForms;
public partial class frmSuppliers: Form
{
    private readonly IDalSupplier dalSupplier;
    public frmSuppliers(IDalSupplier p_dalSupplier)
    {
        InitializeComponent();
        dalSupplier = p_dalSupplier;
    }
    private void frmSuppliers_Load(object sender, EventArgs e)
    {
        dgwSuppliers.DataSource = dalSupplier.GetAll().ToList();
        dgwSuppliers.AutoResizeRows();
    }
}