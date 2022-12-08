namespace Sil
{
    partial class Form1
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.pnlGrup = new System.Windows.Forms.Panel();
            this.mskDogTar = new System.Windows.Forms.MaskedTextBox();
            this.grpCinsiyet = new System.Windows.Forms.GroupBox();
            this.rdbBayan = new System.Windows.Forms.RadioButton();
            this.rdbBay = new System.Windows.Forms.RadioButton();
            this.chkMedeniHal = new System.Windows.Forms.CheckBox();
            this.cmbDogYeri = new System.Windows.Forms.ComboBox();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.lblMedeniHal = new System.Windows.Forms.Label();
            this.lblCinsiyet = new System.Windows.Forms.Label();
            this.lblDogYer = new System.Windows.Forms.Label();
            this.lblDogTar = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lViKisi = new System.Windows.Forms.ListView();
            this.lBoxIller = new System.Windows.Forms.ListBox();
            this.dteDogTarihi = new System.Windows.Forms.DateTimePicker();
            this.btnSutun = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.pnlGrup.SuspendLayout();
            this.grpCinsiyet.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(514, 76);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(6);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 26;
            // 
            // pnlGrup
            // 
            this.pnlGrup.Controls.Add(this.mskDogTar);
            this.pnlGrup.Controls.Add(this.grpCinsiyet);
            this.pnlGrup.Controls.Add(this.chkMedeniHal);
            this.pnlGrup.Controls.Add(this.cmbDogYeri);
            this.pnlGrup.Controls.Add(this.txtAdSoyad);
            this.pnlGrup.Location = new System.Drawing.Point(126, 65);
            this.pnlGrup.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGrup.Name = "pnlGrup";
            this.pnlGrup.Size = new System.Drawing.Size(219, 157);
            this.pnlGrup.TabIndex = 25;
            // 
            // mskDogTar
            // 
            this.mskDogTar.Location = new System.Drawing.Point(10, 13);
            this.mskDogTar.Margin = new System.Windows.Forms.Padding(2);
            this.mskDogTar.Name = "mskDogTar";
            this.mskDogTar.Size = new System.Drawing.Size(199, 20);
            this.mskDogTar.TabIndex = 7;
            // 
            // grpCinsiyet
            // 
            this.grpCinsiyet.Controls.Add(this.rdbBayan);
            this.grpCinsiyet.Controls.Add(this.rdbBay);
            this.grpCinsiyet.Location = new System.Drawing.Point(10, 116);
            this.grpCinsiyet.Margin = new System.Windows.Forms.Padding(2);
            this.grpCinsiyet.Name = "grpCinsiyet";
            this.grpCinsiyet.Padding = new System.Windows.Forms.Padding(2);
            this.grpCinsiyet.Size = new System.Drawing.Size(197, 35);
            this.grpCinsiyet.TabIndex = 11;
            this.grpCinsiyet.TabStop = false;
            // 
            // rdbBayan
            // 
            this.rdbBayan.AutoSize = true;
            this.rdbBayan.Location = new System.Drawing.Point(52, 16);
            this.rdbBayan.Margin = new System.Windows.Forms.Padding(2);
            this.rdbBayan.Name = "rdbBayan";
            this.rdbBayan.Size = new System.Drawing.Size(55, 17);
            this.rdbBayan.TabIndex = 10;
            this.rdbBayan.TabStop = true;
            this.rdbBayan.Text = "Bayan";
            this.rdbBayan.UseVisualStyleBackColor = true;
            // 
            // rdbBay
            // 
            this.rdbBay.AutoSize = true;
            this.rdbBay.Location = new System.Drawing.Point(4, 16);
            this.rdbBay.Margin = new System.Windows.Forms.Padding(2);
            this.rdbBay.Name = "rdbBay";
            this.rdbBay.Size = new System.Drawing.Size(43, 17);
            this.rdbBay.TabIndex = 10;
            this.rdbBay.TabStop = true;
            this.rdbBay.Text = "Bay";
            this.rdbBay.UseVisualStyleBackColor = true;
            // 
            // chkMedeniHal
            // 
            this.chkMedeniHal.AutoSize = true;
            this.chkMedeniHal.Location = new System.Drawing.Point(10, 101);
            this.chkMedeniHal.Margin = new System.Windows.Forms.Padding(2);
            this.chkMedeniHal.Name = "chkMedeniHal";
            this.chkMedeniHal.Size = new System.Drawing.Size(15, 14);
            this.chkMedeniHal.TabIndex = 1;
            this.chkMedeniHal.UseVisualStyleBackColor = true;
            // 
            // cmbDogYeri
            // 
            this.cmbDogYeri.FormattingEnabled = true;
            this.cmbDogYeri.Location = new System.Drawing.Point(10, 68);
            this.cmbDogYeri.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDogYeri.Name = "cmbDogYeri";
            this.cmbDogYeri.Size = new System.Drawing.Size(199, 21);
            this.cmbDogYeri.TabIndex = 2;
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(10, 41);
            this.txtAdSoyad.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(199, 20);
            this.txtAdSoyad.TabIndex = 8;
            // 
            // lblMedeniHal
            // 
            this.lblMedeniHal.AutoSize = true;
            this.lblMedeniHal.Location = new System.Drawing.Point(53, 164);
            this.lblMedeniHal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMedeniHal.Name = "lblMedeniHal";
            this.lblMedeniHal.Size = new System.Drawing.Size(61, 13);
            this.lblMedeniHal.TabIndex = 20;
            this.lblMedeniHal.Text = "Medeni Hal";
            // 
            // lblCinsiyet
            // 
            this.lblCinsiyet.AutoSize = true;
            this.lblCinsiyet.Location = new System.Drawing.Point(53, 195);
            this.lblCinsiyet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCinsiyet.Name = "lblCinsiyet";
            this.lblCinsiyet.Size = new System.Drawing.Size(43, 13);
            this.lblCinsiyet.TabIndex = 21;
            this.lblCinsiyet.Text = "Cinsiyet";
            // 
            // lblDogYer
            // 
            this.lblDogYer.AutoSize = true;
            this.lblDogYer.Location = new System.Drawing.Point(53, 134);
            this.lblDogYer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDogYer.Name = "lblDogYer";
            this.lblDogYer.Size = new System.Drawing.Size(62, 13);
            this.lblDogYer.TabIndex = 22;
            this.lblDogYer.Text = "Doğum Yeri";
            // 
            // lblDogTar
            // 
            this.lblDogTar.AutoSize = true;
            this.lblDogTar.Location = new System.Drawing.Point(53, 78);
            this.lblDogTar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDogTar.Name = "lblDogTar";
            this.lblDogTar.Size = new System.Drawing.Size(70, 13);
            this.lblDogTar.TabIndex = 23;
            this.lblDogTar.Text = "Doğum Tarihi";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(53, 109);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 13);
            this.lblName.TabIndex = 24;
            this.lblName.Text = "Ad Soyad";
            // 
            // lViKisi
            // 
            this.lViKisi.HideSelection = false;
            this.lViKisi.Location = new System.Drawing.Point(53, 254);
            this.lViKisi.Margin = new System.Windows.Forms.Padding(2);
            this.lViKisi.Name = "lViKisi";
            this.lViKisi.Size = new System.Drawing.Size(454, 131);
            this.lViKisi.TabIndex = 19;
            this.lViKisi.UseCompatibleStateImageBehavior = false;
            // 
            // lBoxIller
            // 
            this.lBoxIller.FormattingEnabled = true;
            this.lBoxIller.Location = new System.Drawing.Point(348, 105);
            this.lBoxIller.Margin = new System.Windows.Forms.Padding(2);
            this.lBoxIller.Name = "lBoxIller";
            this.lBoxIller.Size = new System.Drawing.Size(159, 147);
            this.lBoxIller.TabIndex = 18;
            // 
            // dteDogTarihi
            // 
            this.dteDogTarihi.Location = new System.Drawing.Point(348, 76);
            this.dteDogTarihi.Margin = new System.Windows.Forms.Padding(2);
            this.dteDogTarihi.Name = "dteDogTarihi";
            this.dteDogTarihi.Size = new System.Drawing.Size(159, 20);
            this.dteDogTarihi.TabIndex = 17;
            // 
            // btnSutun
            // 
            this.btnSutun.Location = new System.Drawing.Point(232, 226);
            this.btnSutun.Margin = new System.Windows.Forms.Padding(2);
            this.btnSutun.Name = "btnSutun";
            this.btnSutun.Size = new System.Drawing.Size(96, 24);
            this.btnSutun.TabIndex = 14;
            this.btnSutun.Text = "Sütun Genişliği";
            this.btnSutun.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(145, 226);
            this.btnSil.Margin = new System.Windows.Forms.Padding(2);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 24);
            this.btnSil.TabIndex = 15;
            this.btnSil.Text = "Listeden Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(66, 226);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 24);
            this.btnEkle.TabIndex = 16;
            this.btnEkle.Text = "Listeye Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlGrup.ResumeLayout(false);
            this.pnlGrup.PerformLayout();
            this.grpCinsiyet.ResumeLayout(false);
            this.grpCinsiyet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel pnlGrup;
        private System.Windows.Forms.MaskedTextBox mskDogTar;
        private System.Windows.Forms.GroupBox grpCinsiyet;
        private System.Windows.Forms.RadioButton rdbBayan;
        private System.Windows.Forms.RadioButton rdbBay;
        private System.Windows.Forms.CheckBox chkMedeniHal;
        private System.Windows.Forms.ComboBox cmbDogYeri;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.Label lblMedeniHal;
        private System.Windows.Forms.Label lblCinsiyet;
        private System.Windows.Forms.Label lblDogYer;
        private System.Windows.Forms.Label lblDogTar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ListView lViKisi;
        private System.Windows.Forms.ListBox lBoxIller;
        private System.Windows.Forms.DateTimePicker dteDogTarihi;
        private System.Windows.Forms.Button btnSutun;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
    }
}

