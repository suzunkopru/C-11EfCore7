namespace OrnekForm1
{
    partial class OrnekForm1
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
            this.btnTikla = new System.Windows.Forms.Button();
            this.cmbIller = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTikla
            // 
            this.btnTikla.Location = new System.Drawing.Point(195, 33);
            this.btnTikla.Name = "btnTikla";
            this.btnTikla.Size = new System.Drawing.Size(75, 23);
            this.btnTikla.TabIndex = 5;
            this.btnTikla.Text = "Tıklayınız ";
            this.btnTikla.UseVisualStyleBackColor = true;
            this.btnTikla.Click += new System.EventHandler(this.btnTikla_Click);
            // 
            // cmbIller
            // 
            this.cmbIller.FormattingEnabled = true;
            this.cmbIller.Location = new System.Drawing.Point(68, 33);
            this.cmbIller.Name = "cmbIller";
            this.cmbIller.Size = new System.Drawing.Size(121, 23);
            this.cmbIller.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "İllerimiz";
            // 
            // OrnekForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 252);
            this.Controls.Add(this.btnTikla);
            this.Controls.Add(this.cmbIller);
            this.Controls.Add(this.label1);
            this.Name = "OrnekForm1";
            this.Text = "Örnek Form1";
            this.Load += new System.EventHandler(this.OrnekForm1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnTikla;
        private ComboBox cmbIller;
        private Label label1;
    }
}