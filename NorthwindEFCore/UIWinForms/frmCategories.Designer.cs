namespace UIWinForms
{
    partial class frmCategories
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
            this.dgwCategories = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwCategories
            // 
            this.dgwCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwCategories.Location = new System.Drawing.Point(12, 12);
            this.dgwCategories.Name = "dgwCategories";
            this.dgwCategories.RowTemplate.Height = 25;
            this.dgwCategories.Size = new System.Drawing.Size(515, 416);
            this.dgwCategories.TabIndex = 0;
            // 
            // frmCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 450);
            this.Controls.Add(this.dgwCategories);
            this.Name = "frmCategories";
            this.Text = "frmCategories";
            this.Load += new System.EventHandler(this.frmCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgwCategories;
    }
}