namespace AllWindowsForm
{
    partial class OrnekFrom1
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIller = new System.Windows.Forms.ComboBox();
            this.btnTikla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "İllerimiz";
            // 
            // cmbIller
            // 
            this.cmbIller.FormattingEnabled = true;
            this.cmbIller.Location = new System.Drawing.Point(84, 32);
            this.cmbIller.Name = "cmbIller";
            this.cmbIller.Size = new System.Drawing.Size(121, 23);
            this.cmbIller.TabIndex = 1;
            // 
            // btnTikla
            // 
            this.btnTikla.Location = new System.Drawing.Point(211, 32);
            this.btnTikla.Name = "btnTikla";
            this.btnTikla.Size = new System.Drawing.Size(75, 23);
            this.btnTikla.TabIndex = 2;
            this.btnTikla.Text = "Tıklayınız ";
            this.btnTikla.UseVisualStyleBackColor = true;
            this.btnTikla.Click += new System.EventHandler(this.btnTikla_Click);
            // 
            // Ornek1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTikla);
            this.Controls.Add(this.cmbIller);
            this.Controls.Add(this.label1);
            this.Name = "Ornek1";
            this.Text = "Örnek 1";
            this.Load += new System.EventHandler(this.Ornek1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cmbIller;
        private Button btnTikla;
    }
}