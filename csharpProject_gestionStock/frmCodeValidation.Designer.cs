namespace csharpProject_gestionStock
{
    partial class frmCodeValidation
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRenvoyerCode = new Guna.UI2.WinForms.Guna2Button();
            this.txtCodeValidation = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbTempsRestant = new System.Windows.Forms.Label();
            this.lbInfoCodeValidation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.btnRenvoyerCode.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(98)))), ((int)(((byte)(174)))));
            this.btnRenvoyerCode.Location = new System.Drawing.Point(181, 270);
            this.btnRenvoyerCode.Name = "btnRenvoyerCode";
            this.btnRenvoyerCode.Size = new System.Drawing.Size(121, 36);
            this.btnRenvoyerCode.TabIndex = 16;
            this.btnRenvoyerCode.Text = "&Renvoyer";
            this.btnRenvoyerCode.Click += new System.EventHandler(this.btnRenvoyerCode_Click);
            // 
            // txtCodeValidation
            // 
            this.txtCodeValidation.BorderRadius = 5;
            this.txtCodeValidation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodeValidation.DefaultText = "";
            this.txtCodeValidation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodeValidation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodeValidation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodeValidation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodeValidation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodeValidation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodeValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCodeValidation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodeValidation.Location = new System.Drawing.Point(181, 196);
            this.txtCodeValidation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodeValidation.Name = "txtCodeValidation";
            this.txtCodeValidation.PasswordChar = '\0';
            this.txtCodeValidation.PlaceholderText = "";
            this.txtCodeValidation.SelectedText = "";
            this.txtCodeValidation.Size = new System.Drawing.Size(339, 29);
            this.txtCodeValidation.TabIndex = 15;
            this.txtCodeValidation.TextChanged += new System.EventHandler(this.txtCodeValidation_TextChanged);
            // 
            // lbTempsRestant
            // 
            this.lbTempsRestant.AutoSize = true;
            this.lbTempsRestant.Location = new System.Drawing.Point(316, 235);
            this.lbTempsRestant.Name = "lbTempsRestant";
            this.lbTempsRestant.Size = new System.Drawing.Size(0, 29);
            this.lbTempsRestant.TabIndex = 14;
            this.lbTempsRestant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbInfoCodeValidation
            // 
            this.lbInfoCodeValidation.AutoSize = true;
            this.lbInfoCodeValidation.Location = new System.Drawing.Point(178, 101);
            this.lbInfoCodeValidation.Name = "lbInfoCodeValidation";
            this.lbInfoCodeValidation.Size = new System.Drawing.Size(0, 29);
            this.lbInfoCodeValidation.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Code de vérification";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 30;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // frmCodeValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(698, 399);
            this.ControlBox = false;
            this.Controls.Add(this.btnRenvoyerCode);
            this.Controls.Add(this.txtCodeValidation);
            this.Controls.Add(this.lbTempsRestant);
            this.Controls.Add(this.lbInfoCodeValidation);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCodeValidation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCodeValidation";
            this.Load += new System.EventHandler(this.frmCodeValidation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button btnRenvoyerCode;
        private Guna.UI2.WinForms.Guna2TextBox txtCodeValidation;
        private System.Windows.Forms.Label lbTempsRestant;
        private System.Windows.Forms.Label lbInfoCodeValidation;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}