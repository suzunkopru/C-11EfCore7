namespace HesapMakinesiTryCatchFinally
{
    partial class HesapMakinesi
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
            this.lblSil = new System.Windows.Forms.Label();
            this.txtSonuc = new System.Windows.Forms.TextBox();
            this.cmbIslemler = new System.Windows.Forms.ComboBox();
            this.btnSonuc = new System.Windows.Forms.Button();
            this.btnIslem = new System.Windows.Forms.Button();
            this.btnSayiEkle = new System.Windows.Forms.Button();
            this.lstSayilar = new System.Windows.Forms.ListBox();
            this.txtSayi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSil
            // 
            this.lblSil.AutoSize = true;
            this.lblSil.Location = new System.Drawing.Point(257, 44);
            this.lblSil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSil.Name = "lblSil";
            this.lblSil.Size = new System.Drawing.Size(99, 15);
            this.lblSil.TabIndex = 13;
            this.lblSil.Text = "<<Sayıyı Çıkar>>";
            this.lblSil.Click += new System.EventHandler(this.lblSil_Click);
            // 
            // txtSonuc
            // 
            this.txtSonuc.Location = new System.Drawing.Point(142, 224);
            this.txtSonuc.Margin = new System.Windows.Forms.Padding(4);
            this.txtSonuc.Name = "txtSonuc";
            this.txtSonuc.Size = new System.Drawing.Size(107, 23);
            this.txtSonuc.TabIndex = 12;
            // 
            // cmbIslemler
            // 
            this.cmbIslemler.FormattingEnabled = true;
            this.cmbIslemler.Location = new System.Drawing.Point(140, 193);
            this.cmbIslemler.Margin = new System.Windows.Forms.Padding(4);
            this.cmbIslemler.Name = "cmbIslemler";
            this.cmbIslemler.Size = new System.Drawing.Size(108, 23);
            this.cmbIslemler.TabIndex = 8;
            // 
            // btnSonuc
            // 
            this.btnSonuc.Location = new System.Drawing.Point(13, 224);
            this.btnSonuc.Margin = new System.Windows.Forms.Padding(4);
            this.btnSonuc.Name = "btnSonuc";
            this.btnSonuc.Size = new System.Drawing.Size(120, 23);
            this.btnSonuc.TabIndex = 9;
            this.btnSonuc.Text = "Sonuç";
            this.btnSonuc.UseVisualStyleBackColor = true;
            this.btnSonuc.Click += new System.EventHandler(this.btnSonuc_Click);
            // 
            // btnIslem
            // 
            this.btnIslem.Location = new System.Drawing.Point(13, 193);
            this.btnIslem.Margin = new System.Windows.Forms.Padding(4);
            this.btnIslem.Name = "btnIslem";
            this.btnIslem.Size = new System.Drawing.Size(120, 23);
            this.btnIslem.TabIndex = 10;
            this.btnIslem.Text = "Yapılacak İşlem";
            this.btnIslem.UseVisualStyleBackColor = true;
            this.btnIslem.Click += new System.EventHandler(this.btnIslem_Click);
            // 
            // btnSayiEkle
            // 
            this.btnSayiEkle.Location = new System.Drawing.Point(13, 14);
            this.btnSayiEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnSayiEkle.Name = "btnSayiEkle";
            this.btnSayiEkle.Size = new System.Drawing.Size(88, 23);
            this.btnSayiEkle.TabIndex = 11;
            this.btnSayiEkle.Text = "Sayı Ekle";
            this.btnSayiEkle.UseVisualStyleBackColor = true;
            this.btnSayiEkle.Click += new System.EventHandler(this.btnSayiEkle_Click);
            // 
            // lstSayilar
            // 
            this.lstSayilar.FormattingEnabled = true;
            this.lstSayilar.ItemHeight = 15;
            this.lstSayilar.Location = new System.Drawing.Point(13, 44);
            this.lstSayilar.Margin = new System.Windows.Forms.Padding(4);
            this.lstSayilar.Name = "lstSayilar";
            this.lstSayilar.Size = new System.Drawing.Size(235, 139);
            this.lstSayilar.TabIndex = 7;
            // 
            // txtSayi
            // 
            this.txtSayi.Location = new System.Drawing.Point(108, 14);
            this.txtSayi.Margin = new System.Windows.Forms.Padding(4);
            this.txtSayi.Name = "txtSayi";
            this.txtSayi.Size = new System.Drawing.Size(140, 23);
            this.txtSayi.TabIndex = 6;
            this.txtSayi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSayi_KeyPress);
            // 
            // HesapMakinesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 279);
            this.Controls.Add(this.lblSil);
            this.Controls.Add(this.txtSonuc);
            this.Controls.Add(this.cmbIslemler);
            this.Controls.Add(this.btnSonuc);
            this.Controls.Add(this.btnIslem);
            this.Controls.Add(this.btnSayiEkle);
            this.Controls.Add(this.lstSayilar);
            this.Controls.Add(this.txtSayi);
            this.Name = "HesapMakinesi";
            this.Text = "Dört İşlem";
            this.Load += new System.EventHandler(this.HesapMakinesi_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HesapMakinesi_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblSil;
        private TextBox txtSonuc;
        private ComboBox cmbIslemler;
        private Button btnSonuc;
        private Button btnIslem;
        private Button btnSayiEkle;
        private ListBox lstSayilar;
        private TextBox txtSayi;
    }
}