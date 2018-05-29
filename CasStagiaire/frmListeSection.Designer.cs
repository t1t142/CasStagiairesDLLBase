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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnouvrir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAjoutSec
            // 
            this.btnAjoutSec.Location = new System.Drawing.Point(332, 372);
            this.btnAjoutSec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAjoutSec.Name = "btnAjoutSec";
            this.btnAjoutSec.Size = new System.Drawing.Size(100, 28);
            this.btnAjoutSec.TabIndex = 0;
            this.btnAjoutSec.Text = "Ajouter";
            this.btnAjoutSec.UseVisualStyleBackColor = true;
            // 
            // btnSupSec
            // 
            this.btnSupSec.Location = new System.Drawing.Point(676, 372);
            this.btnSupSec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSupSec.Name = "btnSupSec";
            this.btnSupSec.Size = new System.Drawing.Size(100, 28);
            this.btnSupSec.TabIndex = 1;
            this.btnSupSec.Text = "Supprimer";
            this.btnSupSec.UseVisualStyleBackColor = true;
            // 
            // btnModifierSec
            // 
            this.btnModifierSec.Location = new System.Drawing.Point(504, 372);
            this.btnModifierSec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModifierSec.Name = "btnModifierSec";
            this.btnModifierSec.Size = new System.Drawing.Size(108, 28);
            this.btnModifierSec.TabIndex = 2;
            this.btnModifierSec.Text = "Modifier";
            this.btnModifierSec.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(197, 155);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(645, 185);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnouvrir
            // 
            this.btnouvrir.Location = new System.Drawing.Point(197, 372);
            this.btnouvrir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnouvrir.Name = "btnouvrir";
            this.btnouvrir.Size = new System.Drawing.Size(100, 28);
            this.btnouvrir.TabIndex = 4;
            this.btnouvrir.Text = "Ouvrir";
            this.btnouvrir.UseVisualStyleBackColor = true;
            // 
            // frmListeSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 554);
            this.Controls.Add(this.btnouvrir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnModifierSec);
            this.Controls.Add(this.btnSupSec);
            this.Controls.Add(this.btnAjoutSec);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmListeSection";
            this.Text = "frmListeSection";
            this.Load += new System.EventHandler(this.frmListeSection_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAjoutSec;
        private System.Windows.Forms.Button btnSupSec;
        private System.Windows.Forms.Button btnModifierSec;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnouvrir;
    }
}