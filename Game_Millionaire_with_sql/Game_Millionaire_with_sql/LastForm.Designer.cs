namespace Game_Millionaire_with_sql
{
    partial class LastForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LastForm));
            this.txtScoreLastForm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNameLastForm = new System.Windows.Forms.Label();
            this.btnExitLat = new System.Windows.Forms.Button();
            this.btnHomeLast = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScoreLastForm
            // 
            this.txtScoreLastForm.BackColor = System.Drawing.Color.DarkGray;
            this.txtScoreLastForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScoreLastForm.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtScoreLastForm.Location = new System.Drawing.Point(668, 612);
            this.txtScoreLastForm.Name = "txtScoreLastForm";
            this.txtScoreLastForm.Size = new System.Drawing.Size(279, 62);
            this.txtScoreLastForm.TabIndex = 5;
            this.txtScoreLastForm.Text = "1.000$";
            this.txtScoreLastForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(482, 612);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 62);
            this.label1.TabIndex = 4;
            this.label1.Text = "You Won:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(314, 594);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(818, 102);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // txtNameLastForm
            // 
            this.txtNameLastForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameLastForm.Location = new System.Drawing.Point(562, 506);
            this.txtNameLastForm.Name = "txtNameLastForm";
            this.txtNameLastForm.Size = new System.Drawing.Size(364, 68);
            this.txtNameLastForm.TabIndex = 9;
            this.txtNameLastForm.Text = "name";
            this.txtNameLastForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExitLat
            // 
            this.btnExitLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitLat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExitLat.Location = new System.Drawing.Point(992, 710);
            this.btnExitLat.Name = "btnExitLat";
            this.btnExitLat.Size = new System.Drawing.Size(108, 50);
            this.btnExitLat.TabIndex = 8;
            this.btnExitLat.Text = "Exit";
            this.btnExitLat.UseVisualStyleBackColor = true;
            this.btnExitLat.Click += new System.EventHandler(this.btnExitLat_Click);
            // 
            // btnHomeLast
            // 
            this.btnHomeLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeLast.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHomeLast.Location = new System.Drawing.Point(419, 710);
            this.btnHomeLast.Name = "btnHomeLast";
            this.btnHomeLast.Size = new System.Drawing.Size(108, 50);
            this.btnHomeLast.TabIndex = 7;
            this.btnHomeLast.Text = "Home";
            this.btnHomeLast.UseVisualStyleBackColor = true;
            this.btnHomeLast.Click += new System.EventHandler(this.btnHomeLast_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(562, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(364, 68);
            this.label3.TabIndex = 10;
            this.label3.Text = "CONGRADULATIONS 🤗😍😍";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Game_Millionaire_with_sql.Properties.Resources.BackGround_Millionaire;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1564, 853);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNameLastForm);
            this.Controls.Add(this.btnExitLat);
            this.Controls.Add(this.btnHomeLast);
            this.Controls.Add(this.txtScoreLastForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LastForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LastForm";
            this.Load += new System.EventHandler(this.LastForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtScoreLastForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtNameLastForm;
        private System.Windows.Forms.Button btnExitLat;
        private System.Windows.Forms.Button btnHomeLast;
        private System.Windows.Forms.Label label3;
    }
}