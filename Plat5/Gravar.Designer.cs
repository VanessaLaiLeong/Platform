namespace Plat5
{
    partial class Gravar
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
            this.btn_yes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pn_gravar = new System.Windows.Forms.Panel();
            this.pn_gravar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Queres gravar o score?";
            // 
            // btn_yes
            // 
            this.btn_yes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_yes.Font = new System.Drawing.Font("Segoe Script", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_yes.Location = new System.Drawing.Point(105, 131);
            this.btn_yes.Name = "btn_yes";
            this.btn_yes.Size = new System.Drawing.Size(124, 67);
            this.btn_yes.TabIndex = 1;
            this.btn_yes.Text = "Sim";
            this.btn_yes.UseVisualStyleBackColor = false;
            this.btn_yes.Click += new System.EventHandler(this.btn_yes_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Segoe Script", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(304, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 67);
            this.button1.TabIndex = 2;
            this.button1.Text = "Não";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pn_gravar
            // 
            this.pn_gravar.BackColor = System.Drawing.Color.Transparent;
            this.pn_gravar.Controls.Add(this.button1);
            this.pn_gravar.Controls.Add(this.label1);
            this.pn_gravar.Controls.Add(this.btn_yes);
            this.pn_gravar.Location = new System.Drawing.Point(125, 56);
            this.pn_gravar.Name = "pn_gravar";
            this.pn_gravar.Size = new System.Drawing.Size(569, 345);
            this.pn_gravar.TabIndex = 4;
            // 
            // Gravar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Plat5.Properties.Resources.s4m_ur4i_bg_clouds1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pn_gravar);
            this.DoubleBuffered = true;
            this.Name = "Gravar";
            this.Text = "Gravar";
            this.pn_gravar.ResumeLayout(false);
            this.pn_gravar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_yes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pn_gravar;
    }
}