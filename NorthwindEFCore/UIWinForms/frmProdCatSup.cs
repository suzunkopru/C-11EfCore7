using AutoMapper;
using Business.Interfaces;
using Core.Dtos;
namespace UIWinForms;
public partial class frmProdCatSup : Form
{
    private readonly IServiceVwProdCatSup serviceVwProdCatSup;
    private readonly IMapper mapper;
    public frmProdCatSup(IServiceVwProdCatSup p_serviceVwProdCatSup,IMapper p_mapper)
    {
        InitializeComponent();
        serviceVwProdCatSup = p_serviceVwProdCatSup;
        mapper = p_mapper;
    }
    private void frmProdCatSup_Load(object sender, EventArgs e)
    {
        dgwProdCatSup.DataSource = mapper.Map<List<DtoVwProdCatSup>>(serviceVwProdCatSup.GetAll()); 
        dgwProdCatSup.AutoResizeRows();
    }
}
