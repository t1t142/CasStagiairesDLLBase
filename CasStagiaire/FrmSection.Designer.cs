namespace CasStagiaire
{
    partial class FrmSection
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
            this.btnAjouter = new System.Windows.Forms.Button();
            this.txtboxid = new System.Windows.Forms.TextBox();
            this.lblidentification = new System.Windows.Forms.Label();
            this.lblNomSection = new System.Windows.Forms.Label();
            this.txtBoxNomSection = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(130, 208);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 23);
            this.btnAjouter.TabIndex = 1;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            // 
            // txtboxid
            // 
            this.txtboxid.Location = new System.Drawing.Point(130, 65);
            this.txtboxid.Name = "txtboxid";
            this.txtboxid.Size = new System.Drawing.Size(182, 20);
            this.txtboxid.TabIndex = 4;
            // 
            // lblidentification
            // 
            this.lblidentification.AutoSize = true;
            this.lblidentification.Location = new System.Drawing.Point(32, 72);
            this.lblidentification.Name = "lblidentification";
            this.lblidentification.Size = new System.Drawing.Size(67, 13);
            this.lblidentification.TabIndex = 5;
            this.lblidentification.Text = "Identification";
            // 
            // lblNomSection
            // 
            this.lblNomSection.AutoSize = true;
            this.lblNomSection.Location = new System.Drawing.Point(32, 153);
            this.lblNomSection.Name = "lblNomSection";
            this.lblNomSection.Size = new System.Drawing.Size(65, 13);
            this.lblNomSection.TabIndex = 7;
            this.lblNomSection.Text = "NomSection";
            // 
            // txtBoxNomSection
            // 
            this.txtBoxNomSection.Location = new System.Drawing.Point(130, 146);
            this.txtBoxNomSection.Name = "txtBoxNomSection";
            this.txtBoxNomSection.Size = new System.Drawing.Size(182, 20);
            this.txtBoxNomSection.TabIndex = 6;
            // 
            // FrmSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNomSection);
            this.Controls.Add(this.txtBoxNomSection);
            this.Controls.Add(this.lblidentification);
            this.Controls.Add(this.txtboxid);
            this.Controls.Add(this.btnAjouter);
            this.Name = "FrmSection";
            this.Text = "FrmSection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.TextBox txtboxid;
        private System.Windows.Forms.Label lblidentification;
        private System.Windows.Forms.Label lblNomSection;
        private System.Windows.Forms.TextBox txtBoxNomSection;
    }
}