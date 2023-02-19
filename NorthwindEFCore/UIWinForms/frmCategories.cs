using AutoMapper;
using Business.Interfaces;
using Core.Dtos;
namespace UIWinForms;
public partial class frmCategories : Form
{
    private readonly IServiceCategory serviceCategory;
    private readonly IMapper mapper;
    public frmCategories(IServiceCategory p_serviceCategory, IMapper p_mapper)
    {        
        serviceCategory = p_serviceCategory;
        mapper = p_mapper;
        InitializeComponent();
    }
    private void frmCategories_Load(object sender, EventArgs e)
    {
        dgwCategories.DataSource = mapper.Map<List<DtoCategory>>(serviceCategory.GetAll());
        dgwCategories.AutoResizeRows();
    }
}
