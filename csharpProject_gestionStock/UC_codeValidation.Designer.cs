namespace csharpProject_gestionStock
{
    partial class UC_codeValidation
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lbTempsRestant = new System.Windows.Forms.Label();
            this.lbInfoCodeValidation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodeValidation = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRenvoyerCode = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 26;
            this.guna2Elipse1.TargetControl = this;
            // 
            // lbTempsRestant
            // 
            this.lbTempsRestant.AutoSize = true;
            this.lbTempsRestant.Location = new System.Drawing.Point(315, 230);
            this.lbTempsRestant.Name = "lbTempsRestant";
            this.lbTempsRestant.Size = new System.Drawing.Size(0, 18);
            this.lbTempsRestant.TabIndex = 9;
            this.lbTempsRestant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbInfoCodeValidation
            // 
            this.lbInfoCodeValidation.AutoSize = true;
            this.lbInfoCodeValidation.Location = new System.Drawing.Point(177, 96);
            this.lbInfoCodeValidation.Name = "lbInfoCodeValidation";
            this.lbInfoCodeValidation.Size = new System.Drawing.Size(0, 18);
            this.lbInfoCodeValidation.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Code de vérification";
            // 
            // txtCodeValidation
            // 
            this.txtCodeValidation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodeValidation.DefaultText = "";
            this.txtCodeValidation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodeValidation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodeValidation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodeValidation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodeValidation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodeValidation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodeValidation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodeValidation.Location = new System.Drawing.Point(180, 191);
            this.txtCodeValidation.Name = "txtCodeValidation";
            this.txtCodeValidation.PasswordChar = '\0';
            this.txtCodeValidation.PlaceholderText = "";
            this.txtCodeValidation.SelectedText = "";
            this.txtCodeValidation.Size = new System.Drawing.Size(339, 29);
            this.txtCodeValidation.TabIndex = 10;
            this.txtCodeValidation.TextChanged += new System.EventHandler(this.txtCodeValidation_TextChanged);
            // 
            // btnRenvoyerCode
            // 
            this.btnRenvoyerCode.BorderRadius = 5;
            this.btnRenvoyerCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRenvoyerCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRenvoyerCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRenvoyerCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRenvoyerCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnRenvoyerCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenvoyerCode.ForeColor = System.Drawing.Color.White;
            this.btnRenvoyerCode.Location = new System.Drawing.Point(180, 264);
            this.btnRenvoyerCode.Name = "btnRenvoyerCode";
            this.btnRenvoyerCode.Size = new System.Drawing.Size(91, 28);
            this.btnRenvoyerCode.TabIndex = 11;
            this.btnRenvoyerCode.Text = "&Renvoyer";
            this.btnRenvoyerCode.Click += new System.EventHandler(this.btnRenvoyerCode_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UC_codeValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnRenvoyerCode);
            this.Controls.Add(this.txtCodeValidation);
            this.Controls.Add(this.lbTempsRestant);
            this.Controls.Add(this.lbInfoCodeValidation);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_codeValidation";
            this.Size = new System.Drawing.Size(699, 392);
            this.Load += new System.EventHandler(this.UC_codeValidation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox txtCodeValidation;
        private System.Windows.Forms.Label lbTempsRestant;
        private System.Windows.Forms.Label lbInfoCodeValidation;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnRenvoyerCode;
        private System.Windows.Forms.Timer timer1;
    }
}
