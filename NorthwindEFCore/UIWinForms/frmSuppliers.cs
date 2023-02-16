using AutoMapper;
using Core.Dtos;
namespace UIWinForms;
public partial class frmSuppliers: Form
{
    private readonly IDalSupplier dalSupplier;
    private readonly IMapper mapper;
    public frmSuppliers(IDalSupplier p_dalSupplier, IMapper p_mapper)
    {
        InitializeComponent();
        dalSupplier = p_dalSupplier;
        mapper = p_mapper;
    }
    private void frmSuppliers_Load(object sender, EventArgs e)
    {
        dgwSuppliers.DataSource = mapper.Map<List<DtoSupplier>>(dalSupplier.GetAll());
        dgwSuppliers.AutoResizeRows();
    }
}