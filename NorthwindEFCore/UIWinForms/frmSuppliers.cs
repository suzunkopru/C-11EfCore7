using AutoMapper;
using Business.Interfaces;
using Core.Dtos;
namespace UIWinForms;
public partial class frmSuppliers: Form
{
    private readonly IServiceSupplier serviceSupplier;
    private readonly IMapper mapper;
    public frmSuppliers(IServiceSupplier p_serviceSupplier, IMapper p_mapper)
    {
        InitializeComponent();
        serviceSupplier = p_serviceSupplier;
        mapper = p_mapper;
    }
    private void frmSuppliers_Load(object sender, EventArgs e)
    {
        dgwSuppliers.DataSource = mapper.Map<List<DtoSupplier>>(serviceSupplier.GetAll());
        dgwSuppliers.AutoResizeRows();
    }
}