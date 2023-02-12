namespace UIWinForms
{
    partial class frmProduct
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgwProductCatName = new System.Windows.Forms.DataGridView();
            this.grbUrunler = new System.Windows.Forms.GroupBox();
            this.btnDTO = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnYeni = new System.Windows.Forms.Button();
            this.rdbDiscontinued = new System.Windows.Forms.RadioButton();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.lblReorder = new System.Windows.Forms.Label();
            this.lblCategoryId = new System.Windows.Forms.Label();
            this.cmbCategoryID = new System.Windows.Forms.ComboBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.lblProductId = new System.Windows.Forms.Label();
            this.lblSupplierId = new System.Windows.Forms.Label();
            this.cmbSupplierID = new System.Windows.Forms.ComboBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtUnitsInStock = new System.Windows.Forms.TextBox();
            this.txtQuantityPerUnit = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPerUnit = new System.Windows.Forms.Label();
            this.txtUnitsOnOrder = new System.Windows.Forms.TextBox();
            this.lblUnitsOrder = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.grbProduct = new System.Windows.Forms.GroupBox();
            this.btnTumu = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.lblUrunAra = new System.Windows.Forms.Label();
            this.dgwProducts = new System.Windows.Forms.DataGridView();
            this.grbCategories = new System.Windows.Forms.GroupBox();
            this.btnCategories = new System.Windows.Forms.Button();
            this.lblKategoriler = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwProductCatName)).BeginInit();
            this.grbUrunler.SuspendLayout();
            this.grbProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwProducts)).BeginInit();
            this.grbCategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwProductCatName
            // 
            this.dgwProductCatName.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgwProductCatName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwProductCatName.Location = new System.Drawing.Point(2, 453);
            this.dgwProductCatName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgwProductCatName.Name = "dgwProductCatName";
            this.dgwProductCatName.RowTemplate.Height = 25;
            this.dgwProductCatName.Size = new System.Drawing.Size(431, 321);
            this.dgwProductCatName.TabIndex = 26;
            // 
            // grbUrunler
            // 
            this.grbUrunler.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbUrunler.Controls.Add(this.btnDTO);
            this.grbUrunler.Controls.Add(this.btnSupplier);
            this.grbUrunler.Controls.Add(this.btnYeni);
            this.grbUrunler.Controls.Add(this.rdbDiscontinued);
            this.grbUrunler.Controls.Add(this.txtReorderLevel);
            this.grbUrunler.Controls.Add(this.lblReorder);
            this.grbUrunler.Controls.Add(this.lblCategoryId);
            this.grbUrunler.Controls.Add(this.cmbCategoryID);
            this.grbUrunler.Controls.Add(this.txtProductId);
            this.grbUrunler.Controls.Add(this.lblProductId);
            this.grbUrunler.Controls.Add(this.lblSupplierId);
            this.grbUrunler.Controls.Add(this.cmbSupplierID);
            this.grbUrunler.Controls.Add(this.btnGuncelle);
            this.grbUrunler.Controls.Add(this.btnSil);
            this.grbUrunler.Controls.Add(this.btnEkle);
            this.grbUrunler.Controls.Add(this.txtUnitsInStock);
            this.grbUrunler.Controls.Add(this.txtQuantityPerUnit);
            this.grbUrunler.Controls.Add(this.lblStock);
            this.grbUrunler.Controls.Add(this.lblPerUnit);
            this.grbUrunler.Controls.Add(this.txtUnitsOnOrder);
            this.grbUrunler.Controls.Add(this.lblUnitsOrder);
            this.grbUrunler.Controls.Add(this.txtUnitPrice);
            this.grbUrunler.Controls.Add(this.lblPrice);
            this.grbUrunler.Controls.Add(this.txtProductName);
            this.grbUrunler.Controls.Add(this.lblProductName);
            this.grbUrunler.Location = new System.Drawing.Point(271, 12);
            this.grbUrunler.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbUrunler.Name = "grbUrunler";
            this.grbUrunler.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbUrunler.Size = new System.Drawing.Size(906, 144);
            this.grbUrunler.TabIndex = 24;
            this.grbUrunler.TabStop = false;
            this.grbUrunler.Text = "Ürünler";
            // 
            // btnDTO
            // 
            this.btnDTO.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDTO.Location = new System.Drawing.Point(793, 85);
            this.btnDTO.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDTO.Name = "btnDTO";
            this.btnDTO.Size = new System.Drawing.Size(88, 27);
            this.btnDTO.TabIndex = 22;
            this.btnDTO.Text = "View DTO";
            this.btnDTO.UseVisualStyleBackColor = false;
            this.btnDTO.Click += new System.EventHandler(this.btnDTO_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSupplier.Location = new System.Drawing.Point(80, 110);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(40, 23);
            this.btnSupplier.TabIndex = 21;
            this.btnSupplier.Text = "Aç";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnYeni
            // 
            this.btnYeni.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnYeni.Location = new System.Drawing.Point(11, 19);
            this.btnYeni.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(88, 27);
            this.btnYeni.TabIndex = 19;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.UseVisualStyleBackColor = false;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // rdbDiscontinued
            // 
            this.rdbDiscontinued.AutoSize = true;
            this.rdbDiscontinued.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdbDiscontinued.Location = new System.Drawing.Point(794, 58);
            this.rdbDiscontinued.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rdbDiscontinued.Name = "rdbDiscontinued";
            this.rdbDiscontinued.Size = new System.Drawing.Size(95, 19);
            this.rdbDiscontinued.TabIndex = 18;
            this.rdbDiscontinued.TabStop = true;
            this.rdbDiscontinued.Text = "Discontinued";
            this.rdbDiscontinued.UseVisualStyleBackColor = true;
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.Location = new System.Drawing.Point(644, 111);
            this.txtReorderLevel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(129, 23);
            this.txtReorderLevel.TabIndex = 10;
            // 
            // lblReorder
            // 
            this.lblReorder.AutoSize = true;
            this.lblReorder.Location = new System.Drawing.Point(533, 118);
            this.lblReorder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReorder.Name = "lblReorder";
            this.lblReorder.Size = new System.Drawing.Size(81, 15);
            this.lblReorder.TabIndex = 15;
            this.lblReorder.Text = "Reorder Level:";
            // 
            // lblCategoryId
            // 
            this.lblCategoryId.AutoSize = true;
            this.lblCategoryId.Location = new System.Drawing.Point(264, 60);
            this.lblCategoryId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoryId.Name = "lblCategoryId";
            this.lblCategoryId.Size = new System.Drawing.Size(72, 15);
            this.lblCategoryId.TabIndex = 14;
            this.lblCategoryId.Text = "Category ID:";
            // 
            // cmbCategoryID
            // 
            this.cmbCategoryID.FormattingEnabled = true;
            this.cmbCategoryID.Location = new System.Drawing.Point(380, 57);
            this.cmbCategoryID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbCategoryID.Name = "cmbCategoryID";
            this.cmbCategoryID.Size = new System.Drawing.Size(129, 23);
            this.cmbCategoryID.TabIndex = 5;
            // 
            // txtProductId
            // 
            this.txtProductId.Enabled = false;
            this.txtProductId.Location = new System.Drawing.Point(127, 57);
            this.txtProductId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(129, 23);
            this.txtProductId.TabIndex = 2;
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(6, 64);
            this.lblProductId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(65, 15);
            this.lblProductId.TabIndex = 11;
            this.lblProductId.Text = "Product Id:";
            // 
            // lblSupplierId
            // 
            this.lblSupplierId.AutoSize = true;
            this.lblSupplierId.Location = new System.Drawing.Point(6, 113);
            this.lblSupplierId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSupplierId.Name = "lblSupplierId";
            this.lblSupplierId.Size = new System.Drawing.Size(67, 15);
            this.lblSupplierId.TabIndex = 10;
            this.lblSupplierId.Text = "Supplier ID:";
            // 
            // cmbSupplierID
            // 
            this.cmbSupplierID.FormattingEnabled = true;
            this.cmbSupplierID.Location = new System.Drawing.Point(127, 110);
            this.cmbSupplierID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbSupplierID.Name = "cmbSupplierID";
            this.cmbSupplierID.Size = new System.Drawing.Size(129, 23);
            this.cmbSupplierID.TabIndex = 4;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGuncelle.Location = new System.Drawing.Point(203, 19);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(88, 27);
            this.btnGuncelle.TabIndex = 13;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            this.btnGuncelle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnGuncelle_MouseMove);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSil.Location = new System.Drawing.Point(300, 19);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(88, 27);
            this.btnSil.TabIndex = 14;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            this.btnSil.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSil_MouseMove);
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEkle.Location = new System.Drawing.Point(106, 19);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(88, 27);
            this.btnEkle.TabIndex = 12;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            this.btnEkle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEkle_MouseMove);
            // 
            // txtUnitsInStock
            // 
            this.txtUnitsInStock.Location = new System.Drawing.Point(644, 57);
            this.txtUnitsInStock.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUnitsInStock.Name = "txtUnitsInStock";
            this.txtUnitsInStock.Size = new System.Drawing.Size(129, 23);
            this.txtUnitsInStock.TabIndex = 8;
            // 
            // txtQuantityPerUnit
            // 
            this.txtQuantityPerUnit.Location = new System.Drawing.Point(380, 84);
            this.txtQuantityPerUnit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtQuantityPerUnit.Name = "txtQuantityPerUnit";
            this.txtQuantityPerUnit.Size = new System.Drawing.Size(129, 23);
            this.txtQuantityPerUnit.TabIndex = 6;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(533, 60);
            this.lblStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(82, 15);
            this.lblStock.TabIndex = 3;
            this.lblStock.Text = "Units In Stock:";
            // 
            // lblPerUnit
            // 
            this.lblPerUnit.AutoSize = true;
            this.lblPerUnit.Location = new System.Drawing.Point(264, 88);
            this.lblPerUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPerUnit.Name = "lblPerUnit";
            this.lblPerUnit.Size = new System.Drawing.Size(101, 15);
            this.lblPerUnit.TabIndex = 3;
            this.lblPerUnit.Text = "Quantity Per Unit:";
            // 
            // txtUnitsOnOrder
            // 
            this.txtUnitsOnOrder.Location = new System.Drawing.Point(644, 84);
            this.txtUnitsOnOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUnitsOnOrder.Name = "txtUnitsOnOrder";
            this.txtUnitsOnOrder.Size = new System.Drawing.Size(129, 23);
            this.txtUnitsOnOrder.TabIndex = 9;
            // 
            // lblUnitsOrder
            // 
            this.lblUnitsOrder.AutoSize = true;
            this.lblUnitsOrder.Location = new System.Drawing.Point(533, 91);
            this.lblUnitsOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnitsOrder.Name = "lblUnitsOrder";
            this.lblUnitsOrder.Size = new System.Drawing.Size(89, 15);
            this.lblUnitsOrder.TabIndex = 1;
            this.lblUnitsOrder.Text = "Units On Order:";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(380, 111);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(129, 23);
            this.txtUnitPrice.TabIndex = 7;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(264, 113);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(61, 15);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "Unit Price:";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(127, 84);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(129, 23);
            this.txtProductName.TabIndex = 3;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(6, 88);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(87, 15);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Product Name:";
            // 
            // grbProduct
            // 
            this.grbProduct.Controls.Add(this.btnTumu);
            this.grbProduct.Controls.Add(this.txtAra);
            this.grbProduct.Controls.Add(this.lblUrunAra);
            this.grbProduct.Location = new System.Drawing.Point(10, 81);
            this.grbProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbProduct.Name = "grbProduct";
            this.grbProduct.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbProduct.Size = new System.Drawing.Size(253, 75);
            this.grbProduct.TabIndex = 23;
            this.grbProduct.TabStop = false;
            this.grbProduct.Text = "Ürünler";
            // 
            // btnTumu
            // 
            this.btnTumu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnTumu.Location = new System.Drawing.Point(85, 42);
            this.btnTumu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTumu.Name = "btnTumu";
            this.btnTumu.Size = new System.Drawing.Size(130, 27);
            this.btnTumu.TabIndex = 2;
            this.btnTumu.Text = "Tümünü Görüntüle";
            this.btnTumu.UseVisualStyleBackColor = false;
            this.btnTumu.Click += new System.EventHandler(this.btnTumu_Click);
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(85, 18);
            this.txtAra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(129, 23);
            this.txtAra.TabIndex = 1;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // lblUrunAra
            // 
            this.lblUrunAra.AutoSize = true;
            this.lblUrunAra.Location = new System.Drawing.Point(16, 22);
            this.lblUrunAra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrunAra.Name = "lblUrunAra";
            this.lblUrunAra.Size = new System.Drawing.Size(57, 15);
            this.lblUrunAra.TabIndex = 1;
            this.lblUrunAra.Text = "Ürün Ara:";
            // 
            // dgwProducts
            // 
            this.dgwProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgwProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwProducts.Location = new System.Drawing.Point(2, 162);
            this.dgwProducts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgwProducts.Name = "dgwProducts";
            this.dgwProducts.RowTemplate.Height = 25;
            this.dgwProducts.Size = new System.Drawing.Size(1167, 285);
            this.dgwProducts.TabIndex = 25;
            this.dgwProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwProducts_CellClick);
            // 
            // grbCategories
            // 
            this.grbCategories.Controls.Add(this.btnCategories);
            this.grbCategories.Controls.Add(this.lblKategoriler);
            this.grbCategories.Controls.Add(this.cmbCategories);
            this.grbCategories.Location = new System.Drawing.Point(10, 11);
            this.grbCategories.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbCategories.Name = "grbCategories";
            this.grbCategories.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbCategories.Size = new System.Drawing.Size(253, 63);
            this.grbCategories.TabIndex = 22;
            this.grbCategories.TabStop = false;
            this.grbCategories.Text = "Kategoriler";
            // 
            // btnCategories
            // 
            this.btnCategories.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCategories.Location = new System.Drawing.Point(90, 22);
            this.btnCategories.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(40, 23);
            this.btnCategories.TabIndex = 20;
            this.btnCategories.Text = "Aç";
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // lblKategoriler
            // 
            this.lblKategoriler.AutoSize = true;
            this.lblKategoriler.Location = new System.Drawing.Point(16, 25);
            this.lblKategoriler.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKategoriler.Name = "lblKategoriler";
            this.lblKategoriler.Size = new System.Drawing.Size(67, 15);
            this.lblKategoriler.TabIndex = 1;
            this.lblKategoriler.Text = "Kategoriler:";
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(132, 22);
            this.cmbCategories.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(121, 23);
            this.cmbCategories.TabIndex = 0;
            this.cmbCategories.SelectionChangeCommitted += new System.EventHandler(this.cmbCategories_SelectionChangeCommitted);
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1179, 453);
            this.Controls.Add(this.dgwProductCatName);
            this.Controls.Add(this.grbUrunler);
            this.Controls.Add(this.grbProduct);
            this.Controls.Add(this.dgwProducts);
            this.Controls.Add(this.grbCategories);
            this.Name = "frmProduct";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwProductCatName)).EndInit();
            this.grbUrunler.ResumeLayout(false);
            this.grbUrunler.PerformLayout();
            this.grbProduct.ResumeLayout(false);
            this.grbProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwProducts)).EndInit();
            this.grbCategories.ResumeLayout(false);
            this.grbCategories.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgwProductCatName;
        private GroupBox grbUrunler;
        private Button btnDTO;
        private Button btnSupplier;
        private Button btnYeni;
        private RadioButton rdbDiscontinued;
        private TextBox txtReorderLevel;
        private Label lblReorder;
        private Label lblCategoryId;
        private ComboBox cmbCategoryID;
        private TextBox txtProductId;
        private Label lblProductId;
        private Label lblSupplierId;
        private ComboBox cmbSupplierID;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnEkle;
        private TextBox txtUnitsInStock;
        private TextBox txtQuantityPerUnit;
        private Label lblStock;
        private Label lblPerUnit;
        private TextBox txtUnitsOnOrder;
        private Label lblUnitsOrder;
        private TextBox txtUnitPrice;
        private Label lblPrice;
        private TextBox txtProductName;
        private Label lblProductName;
        private GroupBox grbProduct;
        private Button btnTumu;
        private TextBox txtAra;
        private Label lblUrunAra;
        private DataGridView dgwProducts;
        private GroupBox grbCategories;
        private Button btnCategories;
        private Label lblKategoriler;
        private ComboBox cmbCategories;
    }
}