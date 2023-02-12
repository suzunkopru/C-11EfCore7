﻿using static UIWinForms.GridFormat;
namespace UIWinForms;
public partial class frmCategories : Form
{
    private readonly IDalCategory dalCategory;
    private readonly NorthwindContext context;
    public frmCategories()
    {
        InitializeComponent();
        dalCategory = new DalCategory(context = new());
    }

    private void frmCategories_Load(object sender, EventArgs e)
    {
        DgwFormat(dgwCategories);
        dgwCategories.DataSource = dalCategory.GetAll().ToList();
        dgwCategories.AutoResizeRows();
    }
}
