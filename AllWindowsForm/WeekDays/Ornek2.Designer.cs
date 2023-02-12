namespace WeekDays
{
    partial class Ornek2
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
            this.lstBoxWeekDays = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstBoxWeekDays
            // 
            this.lstBoxWeekDays.FormattingEnabled = true;
            this.lstBoxWeekDays.ItemHeight = 15;
            this.lstBoxWeekDays.Location = new System.Drawing.Point(105, 66);
            this.lstBoxWeekDays.Name = "lstBoxWeekDays";
            this.lstBoxWeekDays.Size = new System.Drawing.Size(155, 184);
            this.lstBoxWeekDays.TabIndex = 0;
            // 
            // Ornek2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstBoxWeekDays);
            this.Name = "Ornek2";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Ornek2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lstBoxWeekDays;
    }
}