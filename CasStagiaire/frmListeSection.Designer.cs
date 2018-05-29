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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnouvrir = new System.Windows.Forms.Button();
            this.btnajouter = new System.Windows.Forms.Button();
            this.btnmodifier = new System.Windows.Forms.Button();
            this.bntsupprimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(538, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnouvrir
            // 
            this.btnouvrir.Location = new System.Drawing.Point(32, 312);
            this.btnouvrir.Name = "btnouvrir";
            this.btnouvrir.Size = new System.Drawing.Size(75, 23);
            this.btnouvrir.TabIndex = 1;
            this.btnouvrir.Text = "Ouvrir";
            this.btnouvrir.UseVisualStyleBackColor = true;
            this.btnouvrir.Click += new System.EventHandler(this.btnouvrir_Click);
            // 
            // btnajouter
            // 
            this.btnajouter.Location = new System.Drawing.Point(159, 312);
            this.btnajouter.Name = "btnajouter";
            this.btnajouter.Size = new System.Drawing.Size(75, 23);
            this.btnajouter.TabIndex = 2;
            this.btnajouter.Text = "Ajouter";
            this.btnajouter.UseVisualStyleBackColor = true;
            // 
            // btnmodifier
            // 
            this.btnmodifier.Location = new System.Drawing.Point(332, 309);
            this.btnmodifier.Name = "btnmodifier";
            this.btnmodifier.Size = new System.Drawing.Size(75, 23);
            this.btnmodifier.TabIndex = 3;
            this.btnmodifier.Text = "Modifier";
            this.btnmodifier.UseVisualStyleBackColor = true;
            // 
            // bntsupprimer
            // 
            this.bntsupprimer.Location = new System.Drawing.Point(495, 312);
            this.bntsupprimer.Name = "bntsupprimer";
            this.bntsupprimer.Size = new System.Drawing.Size(75, 20);
            this.bntsupprimer.TabIndex = 4;
            this.bntsupprimer.Text = "Supprimer";
            this.bntsupprimer.UseVisualStyleBackColor = true;
            // 
            // frmListeSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntsupprimer);
            this.Controls.Add(this.btnmodifier);
            this.Controls.Add(this.btnajouter);
            this.Controls.Add(this.btnouvrir);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmListeSection";
            this.Text = "frmListeSection";
            this.Load += new System.EventHandler(this.frmListeSection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnouvrir;
        private System.Windows.Forms.Button btnajouter;
        private System.Windows.Forms.Button btnmodifier;
        private System.Windows.Forms.Button bntsupprimer;
    }
}