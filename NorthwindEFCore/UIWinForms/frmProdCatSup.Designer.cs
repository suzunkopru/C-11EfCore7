namespace UIWinForms
{
    partial class frmProdCatSup
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
            this.dgwProdCatSup = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwProdCatSup)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwProdCatSup
            // 
            this.dgwProdCatSup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwProdCatSup.Location = new System.Drawing.Point(12, 12);
            this.dgwProdCatSup.Name = "dgwProdCatSup";
            this.dgwProdCatSup.RowTemplate.Height = 25;
            this.dgwProdCatSup.Size = new System.Drawing.Size(700, 436);
            this.dgwProdCatSup.TabIndex = 0;
            // 
            // frmProdCatSup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 455);
            this.Controls.Add(this.dgwProdCatSup);
            this.Name = "frmProdCatSup";
            this.Text = "frmProdCatSup";
            this.Load += new System.EventHandler(this.frmProdCatSup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwProdCatSup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgwProdCatSup;
    }
}