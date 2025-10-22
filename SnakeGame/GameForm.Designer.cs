namespace Snake
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startNewToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseTimer = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.ListBox();
            this.lblShower = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.Cyan;
            this.pbCanvas.Location = new System.Drawing.Point(10, 144);
            this.pbCanvas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(648, 539);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Turquoise;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewToolStrip,
            this.infoToolStrip,
            this.exitToolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(668, 38);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startNewToolStrip
            // 
            this.startNewToolStrip.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.startNewToolStrip.Name = "startNewToolStrip";
            this.startNewToolStrip.Size = new System.Drawing.Size(93, 32);
            this.startNewToolStrip.Text = "شروع دوباره";
            this.startNewToolStrip.Click += new System.EventHandler(this.startNewToolStrip_Click);
            // 
            // infoToolStrip
            // 
            this.infoToolStrip.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.infoToolStrip.Name = "infoToolStrip";
            this.infoToolStrip.Size = new System.Drawing.Size(114, 32);
            this.infoToolStrip.Text = "اطلاعات سازنده";
            this.infoToolStrip.Click += new System.EventHandler(this.infoToolStrip_Click);
            // 
            // exitToolStrip
            // 
            this.exitToolStrip.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.exitToolStrip.Name = "exitToolStrip";
            this.exitToolStrip.Size = new System.Drawing.Size(57, 32);
            this.exitToolStrip.Text = "خروج";
            this.exitToolStrip.Click += new System.EventHandler(this.exitToolStrip_Click);
            // 
            // pauseTimer
            // 
            this.pauseTimer.Tick += new System.EventHandler(this.pauseTimer_Tick);
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.Turquoise;
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblScore.Enabled = false;
            this.lblScore.Font = new System.Drawing.Font("B Nazanin", 16F);
            this.lblScore.FormattingEnabled = true;
            this.lblScore.ItemHeight = 31;
            this.lblScore.Location = new System.Drawing.Point(10, 43);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(648, 62);
            this.lblScore.TabIndex = 5;
            // 
            // lblShower
            // 
            this.lblShower.Font = new System.Drawing.Font("B Nazanin", 17.75F);
            this.lblShower.Location = new System.Drawing.Point(10, 109);
            this.lblShower.Name = "lblShower";
            this.lblShower.Size = new System.Drawing.Size(646, 31);
            this.lblShower.TabIndex = 3;
            this.lblShower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(668, 691);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblShower);
            this.Controls.Add(this.pbCanvas);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("B Nazanin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GameForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startNewToolStrip;
        private System.Windows.Forms.ToolStripMenuItem infoToolStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStrip;
        private System.Windows.Forms.Timer pauseTimer;
        private System.Windows.Forms.ListBox lblScore;
        private System.Windows.Forms.Label lblShower;
    }
}

