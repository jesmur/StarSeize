namespace MyGame
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.pbHeart = new System.Windows.Forms.PictureBox();
            this.itemTimer = new System.Windows.Forms.Timer(this.components);
            this.pbPause = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).BeginInit();
            this.SuspendLayout();
            // 
            // animationTimer
            // 
            this.animationTimer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pbHeart
            // 
            this.pbHeart.Image = ((System.Drawing.Image)(resources.GetObject("pbHeart.Image")));
            this.pbHeart.Location = new System.Drawing.Point(2, 1);
            this.pbHeart.Name = "pbHeart";
            this.pbHeart.Size = new System.Drawing.Size(53, 49);
            this.pbHeart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHeart.TabIndex = 0;
            this.pbHeart.TabStop = false;
            // 
            // itemTimer
            // 
            this.itemTimer.Interval = 1000;
            this.itemTimer.Tick += new System.EventHandler(this.itemTimer_Tick);
            // 
            // pbPause
            // 
            this.pbPause.Image = ((System.Drawing.Image)(resources.GetObject("pbPause.Image")));
            this.pbPause.Location = new System.Drawing.Point(162, 249);
            this.pbPause.Name = "pbPause";
            this.pbPause.Size = new System.Drawing.Size(904, 265);
            this.pbPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPause.TabIndex = 1;
            this.pbPause.TabStop = false;
            this.pbPause.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 750);
            this.Controls.Add(this.pbPause);
            this.Controls.Add(this.pbHeart);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1280, 789);
            this.MinimumSize = new System.Drawing.Size(1280, 789);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.PictureBox pbHeart;
        private System.Windows.Forms.Timer itemTimer;
        private System.Windows.Forms.PictureBox pbPause;
    }
}

