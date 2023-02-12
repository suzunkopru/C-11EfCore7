namespace UIWinForms;
public partial class frmProduct : Form
{
    private readonly IDalCategory dalCategory;
    private readonly IDalProduct dalProduct;
    private readonly IDalDtoProductCatName dalPrdCatName;
    private readonly IDalSupplier dalSupplier;
    private readonly IDalCustomer dalCustomer;
    private readonly IDalEmployee dalEmployee;
    private readonly IDalOrder dalOrder;
    private readonly IDalRegion dalRegion;
    private readonly IDalShipper dalShipper;
    private readonly IDalTerritory dalTerritory;
    private readonly IDalVwProdCatSup dalVwProdCatSup;
    private readonly frmCategories frmCat;
    private readonly frmProdCatSup frmCatSup;
    private readonly frmSuppliers frmSup;
    private readonly Product product;
    public frmProduct(
                        IDalProduct p_dalProduct,
                        IDalDtoProductCatName p_dalPrdCatName,
                        IDalCategory p_dalCategory,
                        IDalSupplier p_dalSupplier,
                        IDalVwProdCatSup p_dalVwProdCatSup,
                        frmCategories p_frmCat,
                        frmProdCatSup p_frmCatSup,
                        frmSuppliers p_frmSup,
                        Product p_product)
    {
        dalProduct = p_dalProduct;          //new DalProduct(context);
        dalCategory = p_dalCategory;        //new DalCategory(context);
        dalSupplier = p_dalSupplier;        //new DalSupplier(context);
        dalPrdCatName = p_dalPrdCatName;    //new DalDtoProductCatName(context);
        dalVwProdCatSup = p_dalVwProdCatSup;
        frmCat = p_frmCat;
        frmCatSup = p_frmCatSup;
        frmSup = p_frmSup;
        product = p_product;
        InitializeComponent();
    }
    private void frmProduct_Load(object sender, EventArgs e)
    {
        dgwProducts.DataSource = ProductIncludeData().ToList();
        DgwFormat(dgwProducts);
        dgwProductCatName.DataSource =
            dalPrdCatName.GetProductsCatName(0).ToList();
        DgwFormat(dgwProductCatName);
        CmbCatLoad();
        CmbSupLoad();
    }
    private IQueryable<Product> ProductIncludeData()
     => dalProduct.GetAll()
                  .Include(x => x.Category)
                  .Include(x => x.Supplier);
    private void CmbSupLoad()
    {
        cmbSupplierID.DataSource = dalSupplier.GetAll().ToList();
        cmbSupplierID.DisplayMember = nameof(Supplier.CompanyName);
        cmbSupplierID.ValueMember = nameof(Supplier.SupplierId);
    }
    private void CmbCatLoad()
    {
        cmbCategoryID.DataSource = dalCategory.GetAll().ToList();
        cmbCategories.DataSource = dalCategory.GetAll().ToList();
        cmbCategories.DisplayMember = nameof(Category.CategoryName);
        cmbCategoryID.DisplayMember = nameof(Category.CategoryName);
        cmbCategories.ValueMember = nameof(Category.CategoryId);
        cmbCategoryID.ValueMember = nameof(Category.CategoryId);
    }
    private void cmbCategories_SelectionChangeCommitted
                            (object sender, EventArgs e)
    {
        var cmb = sender as ComboBox;
        var isCatID =
            int.TryParse(cmb.SelectedValue.ToString(),
                                        out var catID);
        if (isCatID)
            dgwProducts.DataSource =
                dalPrdCatName.GetProductsByCategory(catID)
                                                    .ToList();
    }
    private void txtAra_TextChanged(object sender, EventArgs e)
    {
        if (sender is TextBox /*{ TextLength: > 2 }*/ txt)
            dgwProducts.DataSource =
                string.IsNullOrWhiteSpace(txt.Text)
                ? ProductIncludeData().ToList()
                : ProductIncludeData().Where(x => x.ProductName
                .Contains(txt.Text)).ToList();
    }
    private async void btnEkle_Click(object sender, EventArgs e)
    {
        await CUDEntity(CUDType.Insert, product);
        DgwFormat(dgwProducts);
        MessageBox.Show($"{nameof(Product)} inserted");
        btnTumu_Click(null, null);
    }
    private async void btnGuncelle_Click(object sender, EventArgs e)
    {
        await CUDEntity(CUDType.Update, product);
        DgwFormat(dgwProducts);
        MessageBox.Show($"{nameof(Product)} modified");
        btnTumu_Click(null, null);
    }
    private async void btnSil_Click(object sender, EventArgs e)
    {
        if (dgwProducts.CurrentRow == null) return;
        await CUDEntity(CUDType.Delete, product);
        DgwFormat(dgwProducts);
        MessageBox.Show($"{nameof(Product)} deleted");
        satir--;
        btnTumu_Click(null, null);
    }
    private async Task CUDEntity(CUDType cruType, Product prd)
    {
        prd.ProductId = cruType == CUDType.Insert ? 0 :
             ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
        prd.ProductName = txtProductName.Text;
        prd.SupplierId = ToInt32(cmbSupplierID.SelectedValue);
        prd.CategoryId = ToInt32(cmbCategoryID.SelectedValue);
        prd.QuantityPerUnit = txtQuantityPerUnit.Text;
        prd.UnitPrice = ToDecimal(txtUnitPrice.Text);
        prd.UnitsInStock = ToInt16(txtUnitsInStock.Text);
        prd.UnitsOnOrder = ToInt16(txtUnitsOnOrder.Text);
        prd.ReorderLevel = ToInt16(txtReorderLevel.Text);
        prd.Discontinued = rdbDiscontinued.Checked;
        switch (cruType)
        {
            case CUDType.Insert:
                await dalProduct.AddAsync(prd);
                break;
            case CUDType.Update:
                await dalProduct.UpdateAsync(prd);
                break;
            case CUDType.Delete:
                await dalProduct.RemoveAsync(prd);
                break;
            default:
                break;
        }
    }
    private void dgwProducts_CellClick
                (object sender, DataGridViewCellEventArgs e)
    {
        CUDControl();
        GridToControl(sender);
    }
    private void GridToControl(object sender)
    {
        var row = (sender as DataGridView).CurrentRow;
        txtProductId.Text = row.Cells[0].Value.ToString();
        txtProductName.Text = row.Cells[1].Value.ToString();
        cmbSupplierID.SelectedValue = row.Cells[2].Value;
        cmbCategoryID.SelectedValue = row.Cells[3].Value;
        txtQuantityPerUnit.Text = row.Cells[4].Value.ToString();
        txtUnitPrice.Text = row.Cells[5].Value.ToString();
        txtUnitsInStock.Text = row.Cells[6].Value.ToString();
        txtUnitsOnOrder.Text = row.Cells[7].Value.ToString();
        txtReorderLevel.Text = row.Cells[8].Value.ToString();
        rdbDiscontinued.Checked = ToBoolean(row.Cells[9].Value);
    }
    private void btnEkle_MouseMove(object sender,
        MouseEventArgs e) => CUDControl(sender);
    private void btnGuncelle_MouseMove(object sender,
        MouseEventArgs e) => CUDControl(sender);
    private void btnSil_MouseMove(object sender,
        MouseEventArgs e) => CUDControl(sender);
    private void CUDControl(object sender = null)
    {
        var button = (Button)sender;
        if (button == null) return;
        btnEkle.Enabled = true;
        btnYeni.Enabled = true;
        btnSil.Enabled = true;
        btnGuncelle.Enabled = true;
        if (txtProductId.Text != "" && button == btnEkle)
        {
            MessageBox.Show(
                $"""
                Bu ürün zaten mevcuttur, ancak güncelleme
                veya Silme iþlemi yapabilirsiniz ? 
                """);
        }
        else if (txtProductId.Text == "" && button != btnEkle)
        {
            string delUp = button == btnSil ? "Sil" : "Güncelle";
            MessageBox.Show(
                $$"""
                Grid üzerinden bir ürün seçmediniz.
                Hangi ürün {{delUp}}me iþlemine tabi tutulacak seçmeniz gerekir.
                """);
        }
    }
    private void btnYeni_Click(object sender, EventArgs e)
                            => txtProductId.Text = "";
    private void btnTumu_Click(object sender, EventArgs e)
    {
        int satir = dgwProducts.CurrentRow.Cells[0].RowIndex > 1
                            ? dgwProducts.CurrentRow.Cells[0].RowIndex
                            : dgwProducts.RowCount - 1;
        dgwProducts.DataSource = ProductIncludeData().ToList();
        DgwFormat(dgwProducts);
        txtAra.Clear();
        dgwProducts.CurrentCell = dgwProducts.Rows[satir - 1].Cells[1];
    }
    private void btnCategories_Click(object sender, EventArgs e) => frmCat.Show();
    private void btnSupplier_Click(object sender, EventArgs e) => frmSup.Show();
    private void btnDTO_Click(object sender, EventArgs e) => frmCatSup.Show();
    public void DgwFormat(DataGridView dgw)
    {
        int satirNo = 1;
        foreach (DataGridViewRow item in dgw.Rows)
        {
            item.HeaderCell.Value = satirNo.ToString();
            satirNo++;
            if (satirNo > 500) break;
        }
        dgw.AutoResizeRowHeadersWidth
                (DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader);
        dgw.RowsDefaultCellStyle.BackColor = Color.White;
        dgw.AlternatingRowsDefaultCellStyle.BackColor =
        Color.GhostWhite;
        dgw.EditMode = DataGridViewEditMode.EditProgrammatically;
        dgw.AllowUserToDeleteRows = false;
        dgw.AllowUserToAddRows = false;
        dgw.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        dgw.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCells;
        dgw.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
    }
}