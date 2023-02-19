using AutoMapper;
using Business.Interfaces;
using Core.Dtos;
namespace UIWinForms;
public partial class frmProduct : Form
{
    private readonly IServiceCategory serviceCategory;
    private readonly IServiceProduct serviceProduct;
    private readonly IServiceDtoProductCatName servicePrdCatName;
    private readonly IServiceSupplier serviceSupplier;
    private readonly IServiceCustomer serviceCustomer;
    private readonly IServiceEmployee serviceEmployee;
    private readonly IServiceOrder serviceOrder;
    private readonly IServiceRegion serviceRegion;
    private readonly IServiceShipper serviceShipper;
    private readonly IServiceTerritory serviceTerritory;
    private readonly IServiceVwProdCatSup serviceVwProdCatSup;
    private readonly IMapper mapper;
    private readonly frmCategories frmCat;
    private readonly frmProdCatSup frmCatSup;
    private readonly frmSuppliers frmSup;
    private readonly Product product;
    public frmProduct(
                        IServiceProduct p_serviceProduct,
                        IServiceDtoProductCatName p_servicePrdCatName,
                        IServiceCategory p_serviceCategory,
                        IServiceSupplier p_serviceSupplier,
                        IServiceVwProdCatSup p_serviceVwProdCatSup,
                        //frmCategories p_frmCat,
                        //frmProdCatSup p_frmCatSup,
                        //frmSuppliers p_frmSup,
                        Product p_product,
                        IMapper p_mapper)
    {
        serviceProduct = p_serviceProduct;          //new ServiceProduct(context);
        serviceCategory = p_serviceCategory;        //new ServiceCategory(context);
        serviceSupplier = p_serviceSupplier;        //new ServiceSupplier(context);
        servicePrdCatName = p_servicePrdCatName;    //new ServiceDtoProductCatName(context);
        serviceVwProdCatSup = p_serviceVwProdCatSup;
        frmCat = new frmCategories(p_serviceCategory, p_mapper); //p_frmCat;
        frmCatSup = new frmProdCatSup(p_serviceVwProdCatSup, p_mapper); //p_frmCatSup;
        frmSup = new frmSuppliers(p_serviceSupplier, p_mapper); //p_frmSup;
        product = p_product;
        mapper = p_mapper;
        InitializeComponent();
    }
    private void frmProduct_Load(object sender, EventArgs e)
    {
        //var dtoProd = mapper.Map<List<DtoProduct>>(ProductIncludeData().ToList());
        dgwProducts.DataSource = mapper.Map<List<DtoProduct>>(ProductIncludeData());
        DgwFormat(dgwProducts);
        dgwProductCatName.DataSource =
            servicePrdCatName.GetProductsCatName(0).ToList();
        DgwFormat(dgwProductCatName);
        CmbCatLoad();
        CmbSupLoad();
    }
    private IQueryable<Product> ProductIncludeData()
     => serviceProduct.GetAll()
                  .Include(x => x.Category)
                  .Include(x => x.Supplier);
    private void CmbSupLoad()
    {
        cmbSupplierID.DataSource = mapper.Map<List<DtoSupplier>>(serviceSupplier.GetAll());
        cmbSupplierID.DisplayMember = nameof(Supplier.CompanyName);
        cmbSupplierID.ValueMember = nameof(Supplier.SupplierId);
    }
    private void CmbCatLoad()
    {
        cmbCategoryID.DataSource = mapper.Map<List<DtoCategory>>(serviceCategory.GetAll());
        cmbCategories.DataSource = mapper.Map<List<DtoCategory>>(serviceCategory.GetAll());
        cmbCategories.DisplayMember = nameof(DtoCategory.CategoryName);
        cmbCategoryID.DisplayMember = nameof(DtoCategory.CategoryName);
        cmbCategories.ValueMember = nameof(DtoCategory.CategoryId);
        cmbCategoryID.ValueMember = nameof(DtoCategory.CategoryId);
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
            mapper.Map<List<Product>>(servicePrdCatName.GetProductsByCategory(catID));
    }
    private void txtAra_TextChanged(object sender, EventArgs e)
    {
        if (sender is TextBox /*{ TextLength: > 2 }*/ txt)
            dgwProducts.DataSource =
                string.IsNullOrWhiteSpace(txt.Text)
                ? mapper.Map<List<Core.Dtos.DtoProduct>>(ProductIncludeData())
                : mapper.Map<List<Core.Dtos.DtoProduct>>(ProductIncludeData().Where(x => x.ProductName
                .Contains(txt.Text)));
    }
    private async void btnEkle_Click(object sender, EventArgs e)
    {
        await CUDEntity(CUDType.Insert, product);
        DgwFormat(dgwProducts);
        MessageBox.Show($"{nameof(Product)} inserted");
        btnTumu_Click(sender as Button, null);
    }
    int row;
    private IServiceDtoProductCatName serviceDtoProductCatName;
    private frmProdCatSup frmProdCatSup;
    private frmSuppliers frmSuppliers;

    private async void btnGuncelle_Click(object sender, EventArgs e)
    {
        row = dgwProducts.CurrentRow.Cells[0].RowIndex;
        await CUDEntity(CUDType.Update, product);
        DgwFormat(dgwProducts);
        MessageBox.Show($"{nameof(Product)} modified");
        btnTumu_Click(sender as Button, null);
    }
    private async void btnSil_Click(object sender, EventArgs e)
    {
        if (dgwProducts.CurrentRow == null) return;
        await CUDEntity(CUDType.Delete, product);
        DgwFormat(dgwProducts);
        MessageBox.Show($"{nameof(Product)} deleted");
        btnTumu_Click(sender as Button, null);
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
                await serviceProduct.AddAsync(prd);
                break;
            case CUDType.Update:
                await serviceProduct.UpdateAsync(prd);
                break;
            case CUDType.Delete:
                await serviceProduct.RemoveAsync(prd);
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
        int satir = dgwProducts.RowCount - 1;
        dgwProducts.DataSource = mapper.Map<List<Core.Dtos.DtoProduct>>(ProductIncludeData().ToList());
        DgwFormat(dgwProducts);
        txtAra.Clear();
        Button? btn = sender as Button;
        int num = btn.Name == btnSil.Name ? -1 : btn.Name == btnEkle.Name ? 1 : 0;
        dgwProducts.CurrentCell = btn.Name == btnGuncelle.Name
            ? dgwProducts.Rows[row].Cells[1]
            : dgwProducts.Rows[satir + num].Cells[1];
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