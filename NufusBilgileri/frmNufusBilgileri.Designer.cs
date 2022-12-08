namespace NufusBilgileri
{
    partial class frmNufusBilgileri
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Nüfus Bilgileri";
            this.btnEkle = new System.Windows.Forms.Button();
            this.chkMedeniHal = new System.Windows.Forms.CheckBox();
            this.cmbDogYeri = new System.Windows.Forms.ComboBox();
            this.dteDogTarihi = new System.Windows.Forms.DateTimePicker();
            this.mskDogTar = new System.Windows.Forms.MaskedTextBox();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDogTar = new System.Windows.Forms.Label();
            this.lblDogYer = new System.Windows.Forms.Label();
            this.rdbBay = new System.Windows.Forms.RadioButton();
            this.lblCinsiyet = new System.Windows.Forms.Label();
            this.lblMedeniHal = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.grpCinsiyet = new System.Windows.Forms.GroupBox();
            this.rdbBayan = new System.Windows.Forms.RadioButton();
            this.lBoxIller = new System.Windows.Forms.ListBox();
            this.lViKisi = new System.Windows.Forms.ListView();
            this.btnSutun = new System.Windows.Forms.Button();
            this.pnlGrup = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.grpCinsiyet.SuspendLayout();
            this.pnlGrup.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(21, 166);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 24);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Listeye Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // chkMedeniHal
            // 
            this.chkMedeniHal.AutoSize = true;
            this.chkMedeniHal.Location = new System.Drawing.Point(10, 101);
            this.chkMedeniHal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkMedeniHal.Name = "chkMedeniHal";
            this.chkMedeniHal.Size = new System.Drawing.Size(15, 14);
            this.chkMedeniHal.TabIndex = 1;
            this.chkMedeniHal.UseVisualStyleBackColor = true;
            this.chkMedeniHal.CheckedChanged += new System.EventHandler(this.chkMedeniHal_CheckedChanged);
            // 
            // cmbDogYeri
            // 
            this.cmbDogYeri.FormattingEnabled = true;
            this.cmbDogYeri.Location = new System.Drawing.Point(10, 68);
            this.cmbDogYeri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbDogYeri.Name = "cmbDogYeri";
            this.cmbDogYeri.Size = new System.Drawing.Size(199, 21);
            this.cmbDogYeri.TabIndex = 2;
            // 
            // dteDogTarihi
            // 
            this.dteDogTarihi.Location = new System.Drawing.Point(303, 16);
            this.dteDogTarihi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dteDogTarihi.Name = "dteDogTarihi";
            this.dteDogTarihi.Size = new System.Drawing.Size(159, 20);
            this.dteDogTarihi.TabIndex = 3;
            this.dteDogTarihi.ValueChanged += new System.EventHandler(this.dteDogTarihi_ValueChanged);
            // 
            // mskDogTar
            // 
            this.mskDogTar.Location = new System.Drawing.Point(10, 13);
            this.mskDogTar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mskDogTar.Name = "mskDogTar";
            this.mskDogTar.Size = new System.Drawing.Size(199, 20);
            this.mskDogTar.TabIndex = 7;
            this.mskDogTar.Click += new System.EventHandler(this.mskDogTar_Click);
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(10, 41);
            this.txtAdSoyad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(199, 20);
            this.txtAdSoyad.TabIndex = 8;
            this.txtAdSoyad.Click += new System.EventHandler(this.txtAdSoyad_Click);
            this.txtAdSoyad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdSoyad_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 49);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Ad Soyad";
            // 
            // lblDogTar
            // 
            this.lblDogTar.AutoSize = true;
            this.lblDogTar.Location = new System.Drawing.Point(8, 18);
            this.lblDogTar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDogTar.Name = "lblDogTar";
            this.lblDogTar.Size = new System.Drawing.Size(70, 13);
            this.lblDogTar.TabIndex = 9;
            this.lblDogTar.Text = "Doğum Tarihi";
            // 
            // lblDogYer
            // 
            this.lblDogYer.AutoSize = true;
            this.lblDogYer.Location = new System.Drawing.Point(8, 74);
            this.lblDogYer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDogYer.Name = "lblDogYer";
            this.lblDogYer.Size = new System.Drawing.Size(62, 13);
            this.lblDogYer.TabIndex = 9;
            this.lblDogYer.Text = "Doğum Yeri";
            // 
            // rdbBay
            // 
            this.rdbBay.AutoSize = true;
            this.rdbBay.Location = new System.Drawing.Point(4, 16);
            this.rdbBay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbBay.Name = "rdbBay";
            this.rdbBay.Size = new System.Drawing.Size(43, 17);
            this.rdbBay.TabIndex = 10;
            this.rdbBay.TabStop = true;
            this.rdbBay.Text = "Bay";
            this.rdbBay.UseVisualStyleBackColor = true;
            // 
            // lblCinsiyet
            // 
            this.lblCinsiyet.AutoSize = true;
            this.lblCinsiyet.Location = new System.Drawing.Point(8, 135);
            this.lblCinsiyet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCinsiyet.Name = "lblCinsiyet";
            this.lblCinsiyet.Size = new System.Drawing.Size(43, 13);
            this.lblCinsiyet.TabIndex = 9;
            this.lblCinsiyet.Text = "Cinsiyet";
            // 
            // lblMedeniHal
            // 
            this.lblMedeniHal.AutoSize = true;
            this.lblMedeniHal.Location = new System.Drawing.Point(8, 104);
            this.lblMedeniHal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMedeniHal.Name = "lblMedeniHal";
            this.lblMedeniHal.Size = new System.Drawing.Size(61, 13);
            this.lblMedeniHal.TabIndex = 9;
            this.lblMedeniHal.Text = "Medeni Hal";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(100, 166);
            this.btnSil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 24);
            this.btnSil.TabIndex = 0;
            this.btnSil.Text = "Listeden Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // grpCinsiyet
            // 
            this.grpCinsiyet.Controls.Add(this.rdbBayan);
            this.grpCinsiyet.Controls.Add(this.rdbBay);
            this.grpCinsiyet.Location = new System.Drawing.Point(10, 116);
            this.grpCinsiyet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpCinsiyet.Name = "grpCinsiyet";
            this.grpCinsiyet.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpCinsiyet.Size = new System.Drawing.Size(197, 35);
            this.grpCinsiyet.TabIndex = 11;
            this.grpCinsiyet.TabStop = false;
            // 
            // rdbBayan
            // 
            this.rdbBayan.AutoSize = true;
            this.rdbBayan.Location = new System.Drawing.Point(52, 16);
            this.rdbBayan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbBayan.Name = "rdbBayan";
            this.rdbBayan.Size = new System.Drawing.Size(55, 17);
            this.rdbBayan.TabIndex = 10;
            this.rdbBayan.TabStop = true;
            this.rdbBayan.Text = "Bayan";
            this.rdbBayan.UseVisualStyleBackColor = true;
            // 
            // lBoxIller
            // 
            this.lBoxIller.FormattingEnabled = true;
            this.lBoxIller.Location = new System.Drawing.Point(303, 45);
            this.lBoxIller.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lBoxIller.Name = "lBoxIller";
            this.lBoxIller.Size = new System.Drawing.Size(159, 147);
            this.lBoxIller.TabIndex = 5;
            this.lBoxIller.Click += new System.EventHandler(this.lBoxIller_Click);
            // 
            // lViKisi
            // 
            this.lViKisi.HideSelection = false;
            this.lViKisi.Location = new System.Drawing.Point(8, 194);
            this.lViKisi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lViKisi.Name = "lViKisi";
            this.lViKisi.Size = new System.Drawing.Size(454, 131);
            this.lViKisi.TabIndex = 6;
            this.lViKisi.UseCompatibleStateImageBehavior = false;
            this.lViKisi.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lViKisi_ColumnClick);
            // 
            // btnSutun
            // 
            this.btnSutun.Location = new System.Drawing.Point(187, 166);
            this.btnSutun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSutun.Name = "btnSutun";
            this.btnSutun.Size = new System.Drawing.Size(96, 24);
            this.btnSutun.TabIndex = 0;
            this.btnSutun.Text = "Sütun Genişliği";
            this.btnSutun.UseVisualStyleBackColor = true;
            this.btnSutun.Click += new System.EventHandler(this.btnSutun_Click);
            // 
            // pnlGrup
            // 
            this.pnlGrup.Controls.Add(this.mskDogTar);
            this.pnlGrup.Controls.Add(this.grpCinsiyet);
            this.pnlGrup.Controls.Add(this.chkMedeniHal);
            this.pnlGrup.Controls.Add(this.cmbDogYeri);
            this.pnlGrup.Controls.Add(this.txtAdSoyad);
            this.pnlGrup.Location = new System.Drawing.Point(81, 5);
            this.pnlGrup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlGrup.Name = "pnlGrup";
            this.pnlGrup.Size = new System.Drawing.Size(219, 157);
            this.pnlGrup.TabIndex = 12;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(469, 16);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 13;
            // 
            // frmNufusBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 330);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.pnlGrup);
            this.Controls.Add(this.lblMedeniHal);
            this.Controls.Add(this.lblCinsiyet);
            this.Controls.Add(this.lblDogYer);
            this.Controls.Add(this.lblDogTar);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lViKisi);
            this.Controls.Add(this.lBoxIller);
            this.Controls.Add(this.dteDogTarihi);
            this.Controls.Add(this.btnSutun);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmNufusBilgileri";
            this.Load += new System.EventHandler(this.frmNufusBilgileri_Load);
            this.grpCinsiyet.ResumeLayout(false);
            this.grpCinsiyet.PerformLayout();
            this.pnlGrup.ResumeLayout(false);
            this.pnlGrup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.CheckBox chkMedeniHal;
        private System.Windows.Forms.ComboBox cmbDogYeri;
        private System.Windows.Forms.DateTimePicker dteDogTarihi;
        private System.Windows.Forms.MaskedTextBox mskDogTar;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDogTar;
        private System.Windows.Forms.Label lblDogYer;
        private System.Windows.Forms.RadioButton rdbBay;
        private System.Windows.Forms.Label lblCinsiyet;
        private System.Windows.Forms.Label lblMedeniHal;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.GroupBox grpCinsiyet;
        private System.Windows.Forms.RadioButton rdbBayan;
        private System.Windows.Forms.ListBox lBoxIller;
        private System.Windows.Forms.ListView lViKisi;
        private System.Windows.Forms.Button btnSutun;
        private System.Windows.Forms.Panel pnlGrup;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}