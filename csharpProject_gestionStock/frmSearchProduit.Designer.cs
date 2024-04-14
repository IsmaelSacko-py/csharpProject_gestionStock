namespace csharpProject_gestionStock
{
    partial class frmSearchProduit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtProduit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrixUnitaire = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbCategorie = new System.Windows.Forms.ComboBox();
            this.dgSearchProduit = new System.Windows.Forms.DataGridView();
            this.btnSearchProduit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchProduit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produit";
            // 
            // txtProduit
            // 
            this.txtProduit.Location = new System.Drawing.Point(19, 30);
            this.txtProduit.Name = "txtProduit";
            this.txtProduit.Size = new System.Drawing.Size(194, 24);
            this.txtProduit.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Catégorie";
            // 
            // txtPrixUnitaire
            // 
            this.txtPrixUnitaire.Location = new System.Drawing.Point(505, 32);
            this.txtPrixUnitaire.Name = "txtPrixUnitaire";
            this.txtPrixUnitaire.Size = new System.Drawing.Size(194, 24);
            this.txtPrixUnitaire.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Prix unitaire";
            // 
            // cbbCategorie
            // 
            this.cbbCategorie.FormattingEnabled = true;
            this.cbbCategorie.Location = new System.Drawing.Point(262, 30);
            this.cbbCategorie.Name = "cbbCategorie";
            this.cbbCategorie.Size = new System.Drawing.Size(194, 26);
            this.cbbCategorie.TabIndex = 2;
            // 
            // dgSearchProduit
            // 
            this.dgSearchProduit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearchProduit.Location = new System.Drawing.Point(19, 84);
            this.dgSearchProduit.Name = "dgSearchProduit";
            this.dgSearchProduit.Size = new System.Drawing.Size(975, 394);
            this.dgSearchProduit.TabIndex = 7;
            this.dgSearchProduit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSearchProduit_CellContentClick);
            // 
            // btnSearchProduit
            // 
            this.btnSearchProduit.Location = new System.Drawing.Point(849, 28);
            this.btnSearchProduit.Name = "btnSearchProduit";
            this.btnSearchProduit.Size = new System.Drawing.Size(145, 26);
            this.btnSearchProduit.TabIndex = 4;
            this.btnSearchProduit.Text = "&Rechercher";
            this.btnSearchProduit.UseVisualStyleBackColor = true;
            this.btnSearchProduit.Click += new System.EventHandler(this.btnSearchProduit_Click);
            // 
            // frmSearchProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 490);
            this.ControlBox = false;
            this.Controls.Add(this.btnSearchProduit);
            this.Controls.Add(this.dgSearchProduit);
            this.Controls.Add(this.cbbCategorie);
            this.Controls.Add(this.txtPrixUnitaire);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProduit);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSearchProduit";
            this.Text = "Recherche Produit";
            this.Load += new System.EventHandler(this.frmSearchProduit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchProduit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProduit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrixUnitaire;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbCategorie;
        private System.Windows.Forms.DataGridView dgSearchProduit;
        private System.Windows.Forms.Button btnSearchProduit;
    }
}