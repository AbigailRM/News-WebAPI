
namespace NewsManager_ForAPI
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.goToArticles = new System.Windows.Forms.PictureBox();
            this.goToAuthors = new System.Windows.Forms.PictureBox();
            this.goToSources = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.goToArticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goToAuthors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goToSources)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // goToArticles
            // 
            this.goToArticles.Image = ((System.Drawing.Image)(resources.GetObject("goToArticles.Image")));
            this.goToArticles.Location = new System.Drawing.Point(84, 175);
            this.goToArticles.Name = "goToArticles";
            this.goToArticles.Size = new System.Drawing.Size(126, 121);
            this.goToArticles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.goToArticles.TabIndex = 0;
            this.goToArticles.TabStop = false;
            this.goToArticles.Click += new System.EventHandler(this.goToArticles_Click);
            // 
            // goToAuthors
            // 
            this.goToAuthors.Image = ((System.Drawing.Image)(resources.GetObject("goToAuthors.Image")));
            this.goToAuthors.Location = new System.Drawing.Point(337, 175);
            this.goToAuthors.Name = "goToAuthors";
            this.goToAuthors.Size = new System.Drawing.Size(135, 121);
            this.goToAuthors.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.goToAuthors.TabIndex = 1;
            this.goToAuthors.TabStop = false;
            this.goToAuthors.Click += new System.EventHandler(this.goToAuthors_Click);
            // 
            // goToSources
            // 
            this.goToSources.Image = ((System.Drawing.Image)(resources.GetObject("goToSources.Image")));
            this.goToSources.Location = new System.Drawing.Point(574, 175);
            this.goToSources.Name = "goToSources";
            this.goToSources.Size = new System.Drawing.Size(123, 121);
            this.goToSources.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.goToSources.TabIndex = 2;
            this.goToSources.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "ARTICLES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "AUTHORS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(579, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "SOURCES";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(266, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 40);
            this.label4.TabIndex = 4;
            this.label4.Text = "NEWS MANAGER";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(801, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goToSources);
            this.Controls.Add(this.goToAuthors);
            this.Controls.Add(this.goToArticles);
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.goToArticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goToAuthors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goToSources)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox goToArticles;
        private System.Windows.Forms.PictureBox goToAuthors;
        private System.Windows.Forms.PictureBox goToSources;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
    }
}

