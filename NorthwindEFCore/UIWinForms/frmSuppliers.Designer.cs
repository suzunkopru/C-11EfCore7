namespace UIWinForms
{
    partial class frmSuppliers: Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgwSuppliers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwSuppliers
            // 
            this.dgwSuppliers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgwSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSuppliers.Location = new System.Drawing.Point(13, 12);
            this.dgwSuppliers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgwSuppliers.Name = "dgwSuppliers";
            this.dgwSuppliers.RowTemplate.Height = 25;
            this.dgwSuppliers.Size = new System.Drawing.Size(1069, 271);
            this.dgwSuppliers.TabIndex = 24;
            // 
            // frmSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 289);
            this.Controls.Add(this.dgwSuppliers);
            this.Name = "frmSuppliers";
            this.Text = "frmSuppliers";
            this.Load += new System.EventHandler(this.frmSuppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSuppliers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dgwSuppliers;
    }
}