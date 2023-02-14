using AutoMapper;
using static UIWinForms.GridFormat;
namespace UIWinForms;
public partial class frmCategories : Form
{
    private readonly IDalCategory dalCategory;
    public frmCategories(IDalCategory p_dalCategory)
    {
        InitializeComponent();
        dalCategory = p_dalCategory;
    }

    private void frmCategories_Load(object sender, EventArgs e)
    {
        DgwFormat(dgwCategories);
        dgwCategories.DataSource = mapper.Map<List<Category>>(dalCategory.GetAll());
        dgwCategories.AutoResizeRows();
    }
}
