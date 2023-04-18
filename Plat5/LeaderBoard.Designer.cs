namespace Plat5
{
    partial class LeaderBoard
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
            this.lb_board = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lb_board
            // 
            this.lb_board.FormattingEnabled = true;
            this.lb_board.Location = new System.Drawing.Point(132, 88);
            this.lb_board.Name = "lb_board";
            this.lb_board.Size = new System.Drawing.Size(497, 264);
            this.lb_board.TabIndex = 0;
            this.lb_board.SelectedIndexChanged += new System.EventHandler(this.lb_board_SelectedIndexChanged);
            // 
            // LeaderBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Plat5.Properties.Resources.s4m_ur4i_bg_clouds1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_board);
            this.DoubleBuffered = true;
            this.Name = "LeaderBoard";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LeaderBoard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_board;
    }
}