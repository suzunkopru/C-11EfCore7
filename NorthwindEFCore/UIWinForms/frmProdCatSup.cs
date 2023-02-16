using AutoMapper;
using Core.Dtos;
namespace UIWinForms;
public partial class frmProdCatSup : Form
{
    private readonly IDalVwProdCatSup dalVwProdCatSup;
    private readonly IMapper mapper;
    public frmProdCatSup(IDalVwProdCatSup p_dalVwProdCatSup,IMapper p_mapper)
    {
        InitializeComponent();
        dalVwProdCatSup = p_dalVwProdCatSup;
        mapper = p_mapper;
    }
    private void frmProdCatSup_Load(object sender, EventArgs e)
    {
        dgwProdCatSup.DataSource = mapper.Map<List<DtoVwProdCatSup>>(dalVwProdCatSup.GetAll()); 
        dgwProdCatSup.AutoResizeRows();
    }
}
