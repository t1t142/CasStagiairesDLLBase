namespace CasStagiaire
{
    partial class frmAjoutSection
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
            this.texboxidSec = new System.Windows.Forms.TextBox();
            this.groupBoxSection = new System.Windows.Forms.GroupBox();
            this.lblnomSec = new System.Windows.Forms.Label();
            this.textBoxSec = new System.Windows.Forms.TextBox();
            this.lblidSec = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerDebut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.lbldatedebutSec = new System.Windows.Forms.Label();
            this.btnAjout = new System.Windows.Forms.Button();
            this.groupBoxSection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // texboxidSec
            // 
            this.texboxidSec.Location = new System.Drawing.Point(111, 23);
            this.texboxidSec.Name = "texboxidSec";
            this.texboxidSec.Size = new System.Drawing.Size(66, 20);
            this.texboxidSec.TabIndex = 0;
            // 
            // groupBoxSection
            // 
            this.groupBoxSection.Controls.Add(this.lblnomSec);
            this.groupBoxSection.Controls.Add(this.textBoxSec);
            this.groupBoxSection.Controls.Add(this.lblidSec);
            this.groupBoxSection.Controls.Add(this.texboxidSec);
            this.groupBoxSection.Location = new System.Drawing.Point(57, 31);
            this.groupBoxSection.Name = "groupBoxSection";
            this.groupBoxSection.Size = new System.Drawing.Size(449, 135);
            this.groupBoxSection.TabIndex = 1;
            this.groupBoxSection.TabStop = false;
            this.groupBoxSection.Text = "Ajout Listes sections";
            // 
            // lblnomSec
            // 
            this.lblnomSec.AutoSize = true;
            this.lblnomSec.Location = new System.Drawing.Point(17, 60);
            this.lblnomSec.Name = "lblnomSec";
            this.lblnomSec.Size = new System.Drawing.Size(74, 13);
            this.lblnomSec.TabIndex = 4;
            this.lblnomSec.Text = "Nom Section :";
            // 
            // textBoxSec
            // 
            this.textBoxSec.Location = new System.Drawing.Point(111, 57);
            this.textBoxSec.Name = "textBoxSec";
            this.textBoxSec.Size = new System.Drawing.Size(231, 20);
            this.textBoxSec.TabIndex = 3;
            // 
            // lblidSec
            // 
            this.lblidSec.AutoSize = true;
            this.lblidSec.Location = new System.Drawing.Point(36, 26);
            this.lblidSec.Name = "lblidSec";
            this.lblidSec.Size = new System.Drawing.Size(58, 13);
            this.lblidSec.TabIndex = 2;
            this.lblidSec.Text = "IdSection :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerDebut);
            this.groupBox1.Controls.Add(this.dateTimePickerFin);
            this.groupBox1.Controls.Add(this.lblDateFin);
            this.groupBox1.Controls.Add(this.lbldatedebutSec);
            this.groupBox1.Location = new System.Drawing.Point(57, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 113);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // dateTimePickerDebut
            // 
            this.dateTimePickerDebut.Location = new System.Drawing.Point(54, 44);
            this.dateTimePickerDebut.Name = "dateTimePickerDebut";
            this.dateTimePickerDebut.Size = new System.Drawing.Size(163, 20);
            this.dateTimePickerDebut.TabIndex = 6;
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Location = new System.Drawing.Point(269, 45);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(150, 20);
            this.dateTimePickerFin.TabIndex = 5;
            // 
            // lblDateFin
            // 
            this.lblDateFin.AutoSize = true;
            this.lblDateFin.Location = new System.Drawing.Point(236, 51);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(27, 13);
            this.lblDateFin.TabIndex = 4;
            this.lblDateFin.Text = "Fin :";
            // 
            // lbldatedebutSec
            // 
            this.lbldatedebutSec.AutoSize = true;
            this.lbldatedebutSec.Location = new System.Drawing.Point(17, 44);
            this.lbldatedebutSec.Name = "lbldatedebutSec";
            this.lbldatedebutSec.Size = new System.Drawing.Size(42, 13);
            this.lbldatedebutSec.TabIndex = 3;
            this.lbldatedebutSec.Text = "Debut :";
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(111, 324);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(75, 23);
            this.btnAjout.TabIndex = 6;
            this.btnAjout.Text = "Ajouter";
            this.btnAjout.UseVisualStyleBackColor = true;
            // 
            // frmAjoutSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSection);
            this.Name = "frmAjoutSection";
            this.Text = "frmAjoutSection";
            this.Load += new System.EventHandler(this.frmAjoutSection_Load);
            this.groupBoxSection.ResumeLayout(false);
            this.groupBoxSection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox texboxidSec;
        private System.Windows.Forms.GroupBox groupBoxSection;
        private System.Windows.Forms.Label lblnomSec;
        private System.Windows.Forms.TextBox textBoxSec;
        private System.Windows.Forms.Label lblidSec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDebut;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.Label lbldatedebutSec;
        private System.Windows.Forms.Button btnAjout;
    }
}