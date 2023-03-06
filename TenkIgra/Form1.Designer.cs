
namespace TenkIgra
{
    partial class TankGame
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
            this.Tenk = new System.Windows.Forms.PictureBox();
            this.Score = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Tenk)).BeginInit();
            this.SuspendLayout();
            // 
            // Tenk
            // 
            this.Tenk.Image = global::TenkIgra.Properties.Resources.tigar_2;
            this.Tenk.Location = new System.Drawing.Point(321, 629);
            this.Tenk.Name = "Tenk";
            this.Tenk.Size = new System.Drawing.Size(61, 120);
            this.Tenk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Tenk.TabIndex = 0;
            this.Tenk.TabStop = false;
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Old English Text MT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.Location = new System.Drawing.Point(12, 720);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(118, 32);
            this.Score.TabIndex = 1;
            this.Score.Text = "Score: 0";
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 20;
            // 
            // TankGame
            // 
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(734, 761);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.Tenk);
            this.Name = "TankGame";
            this.Text = "Tank Game";
            ((System.ComponentModel.ISupportInitialize)(this.Tenk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Tenk;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Timer GameTimer;
    }
}

