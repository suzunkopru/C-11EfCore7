using AutoMapper;
using static UIWinForms.GridFormat;
namespace UIWinForms;
public partial class frmCategories : Form
{
    private readonly IDalCategory dalCategory;
    public readonly IMapper mapper;
    public frmCategories(IDalCategory p_dalCategory, IMapper p_mapper)
    {        
        dalCategory = p_dalCategory;
        mapper = p_mapper;
        InitializeComponent();
    }
    private void frmCategories_Load(object sender, EventArgs e)
    {
        DgwFormat(dgwCategories);
        dgwCategories.DataSource = mapper.Map<List<Category>>(dalCategory.GetAll());
        dgwCategories.AutoResizeRows();
    }
}
