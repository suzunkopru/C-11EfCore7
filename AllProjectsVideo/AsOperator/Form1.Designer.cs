namespace AsOperator
{
    partial class Form1
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
            this.btnTemizle = new System.Windows.Forms.Button();
            this.rchText = new System.Windows.Forms.RichTextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lboxItem = new System.Windows.Forms.ListBox();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(190, 31);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(109, 23);
            this.btnTemizle.TabIndex = 9;
            this.btnTemizle.Text = "Yükle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // rchText
            // 
            this.rchText.Location = new System.Drawing.Point(31, 239);
            this.rchText.Name = "rchText";
            this.rchText.Size = new System.Drawing.Size(100, 96);
            this.rchText.TabIndex = 8;
            this.rchText.Text = "";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(31, 197);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(100, 23);
            this.txtText.TabIndex = 7;
            // 
            // lboxItem
            // 
            this.lboxItem.FormattingEnabled = true;
            this.lboxItem.ItemHeight = 15;
            this.lboxItem.Location = new System.Drawing.Point(31, 80);
            this.lboxItem.Name = "lboxItem";
            this.lboxItem.Size = new System.Drawing.Size(120, 94);
            this.lboxItem.TabIndex = 6;
            // 
            // cmbItem
            // 
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(30, 32);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(121, 23);
            this.cmbItem.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.rchText);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lboxItem);
            this.Controls.Add(this.cmbItem);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnTemizle;
        private RichTextBox rchText;
        private TextBox txtText;
        private ListBox lboxItem;
        private ComboBox cmbItem;
    }
}