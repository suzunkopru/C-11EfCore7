using AutoMapper;
using Core.Dtos;
namespace UIWinForms;
public partial class frmCategories : Form
{
    private readonly IDalCategory dalCategory;
    private readonly IMapper mapper;
    public frmCategories(IDalCategory p_dalCategory, IMapper p_mapper)
    {        
        dalCategory = p_dalCategory;
        mapper = p_mapper;
        InitializeComponent();
    }
    private void frmCategories_Load(object sender, EventArgs e)
    {
        dgwCategories.DataSource = mapper.Map<List<DtoCategory>>(dalCategory.GetAll());
        dgwCategories.AutoResizeRows();
    }
}
