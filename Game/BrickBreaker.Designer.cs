﻿
namespace ShopProject.Game
{
    partial class BrickBreaker
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
            this.BrickBreakerTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BrickBreakerTimer
            // 
            this.BrickBreakerTimer.Tick += new System.EventHandler(this.BrickBreakerTimer_Tick);
            // 
            // BrickBreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(562, 453);
            this.Name = "BrickBreaker";
            this.Text = "BrickBreaker";
            this.Load += new System.EventHandler(this.BrickBreaker_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BrickBreaker_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BrickBreaker_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Timer BrickBreakerTimer;
    }
}