
namespace NewsManager_ForAPI
{
    partial class FrmConsultArticles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultArticles));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.ptrGoFrmArticle = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.ptrFindArticle = new System.Windows.Forms.PictureBox();
            this.dgvShowArticles = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrGoFrmArticle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrFindArticle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.ptrGoFrmArticle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 100);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumPurple;
            this.button1.Location = new System.Drawing.Point(11, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 33);
            this.button1.TabIndex = 31;
            this.button1.Text = "MENU";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ptrGoFrmArticle
            // 
            this.ptrGoFrmArticle.Image = ((System.Drawing.Image)(resources.GetObject("ptrGoFrmArticle.Image")));
            this.ptrGoFrmArticle.Location = new System.Drawing.Point(523, 8);
            this.ptrGoFrmArticle.Name = "ptrGoFrmArticle";
            this.ptrGoFrmArticle.Size = new System.Drawing.Size(54, 47);
            this.ptrGoFrmArticle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptrGoFrmArticle.TabIndex = 1;
            this.ptrGoFrmArticle.TabStop = false;
            this.ptrGoFrmArticle.Click += new System.EventHandler(this.ptrGoFrmArticle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(459, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "A R T I C L E S";
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBox.Location = new System.Drawing.Point(756, 117);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(295, 27);
            this.txtSearchBox.TabIndex = 7;
            // 
            // ptrFindArticle
            // 
            this.ptrFindArticle.Image = ((System.Drawing.Image)(resources.GetObject("ptrFindArticle.Image")));
            this.ptrFindArticle.Location = new System.Drawing.Point(1060, 110);
            this.ptrFindArticle.Name = "ptrFindArticle";
            this.ptrFindArticle.Size = new System.Drawing.Size(38, 34);
            this.ptrFindArticle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptrFindArticle.TabIndex = 31;
            this.ptrFindArticle.TabStop = false;
            // 
            // dgvShowArticles
            // 
            this.dgvShowArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowArticles.Location = new System.Drawing.Point(12, 175);
            this.dgvShowArticles.Name = "dgvShowArticles";
            this.dgvShowArticles.RowHeadersWidth = 51;
            this.dgvShowArticles.RowTemplate.Height = 24;
            this.dgvShowArticles.Size = new System.Drawing.Size(1086, 391);
            this.dgvShowArticles.TabIndex = 32;
            // 
            // FrmConsultArticles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1110, 616);
            this.Controls.Add(this.dgvShowArticles);
            this.Controls.Add(this.ptrFindArticle);
            this.Controls.Add(this.txtSearchBox);
            this.Controls.Add(this.panel1);
            this.Name = "FrmConsultArticles";
            this.Text = "FrmConsultArticles";
            this.Load += new System.EventHandler(this.FrmConsultArticles_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrGoFrmArticle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrFindArticle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowArticles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox ptrGoFrmArticle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.PictureBox ptrFindArticle;
        private System.Windows.Forms.DataGridView dgvShowArticles;
    }
}