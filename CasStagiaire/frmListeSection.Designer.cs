namespace CasStagiaire
{
    partial class frmListeSection
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
            this.btnAjoutSec = new System.Windows.Forms.Button();
            this.btnSupSec = new System.Windows.Forms.Button();
            this.btnModifierSec = new System.Windows.Forms.Button();
            this.grdSection = new System.Windows.Forms.DataGridView();
            this.btnouvrir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdSection)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAjoutSec
            // 
            this.btnAjoutSec.Location = new System.Drawing.Point(249, 302);
            this.btnAjoutSec.Name = "btnAjoutSec";
            this.btnAjoutSec.Size = new System.Drawing.Size(75, 23);
            this.btnAjoutSec.TabIndex = 0;
            this.btnAjoutSec.Text = "Ajouter";
            this.btnAjoutSec.UseVisualStyleBackColor = true;
            // 
            // btnSupSec
            // 
            this.btnSupSec.Location = new System.Drawing.Point(507, 302);
            this.btnSupSec.Name = "btnSupSec";
            this.btnSupSec.Size = new System.Drawing.Size(75, 23);
            this.btnSupSec.TabIndex = 1;
            this.btnSupSec.Text = "Supprimer";
            this.btnSupSec.UseVisualStyleBackColor = true;
            // 
            // btnModifierSec
            // 
            this.btnModifierSec.Location = new System.Drawing.Point(378, 302);
            this.btnModifierSec.Name = "btnModifierSec";
            this.btnModifierSec.Size = new System.Drawing.Size(81, 23);
            this.btnModifierSec.TabIndex = 2;
            this.btnModifierSec.Text = "Modifier";
            this.btnModifierSec.UseVisualStyleBackColor = true;
            // 
            // grdSection
            // 
            this.grdSection.AllowUserToAddRows = false;
            this.grdSection.AllowUserToDeleteRows = false;
            this.grdSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSection.Location = new System.Drawing.Point(131, 11);
            this.grdSection.Margin = new System.Windows.Forms.Padding(2);
            this.grdSection.Name = "grdSection";
            this.grdSection.ReadOnly = true;
            this.grdSection.Size = new System.Drawing.Size(451, 213);
            this.grdSection.TabIndex = 3;
            this.grdSection.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnouvrir
            // 
            this.btnouvrir.Location = new System.Drawing.Point(131, 302);
            this.btnouvrir.Name = "btnouvrir";
            this.btnouvrir.Size = new System.Drawing.Size(75, 23);
            this.btnouvrir.TabIndex = 4;
            this.btnouvrir.Text = "Ouvrir";
            this.btnouvrir.UseVisualStyleBackColor = true;
            this.btnouvrir.Click += new System.EventHandler(this.btnouvrir_Click);
            // 
            // frmListeSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 450);
            this.Controls.Add(this.btnouvrir);
            this.Controls.Add(this.grdSection);
            this.Controls.Add(this.btnModifierSec);
            this.Controls.Add(this.btnSupSec);
            this.Controls.Add(this.btnAjoutSec);
            this.Name = "frmListeSection";
            this.Text = "frmListeSection";
            ((System.ComponentModel.ISupportInitialize)(this.grdSection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAjoutSec;
        private System.Windows.Forms.Button btnSupSec;
        private System.Windows.Forms.Button btnModifierSec;
        private System.Windows.Forms.DataGridView grdSection;
        private System.Windows.Forms.Button btnouvrir;
    }
}