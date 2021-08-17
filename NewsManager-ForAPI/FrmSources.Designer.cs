
namespace NewsManager_ForAPI
{
    partial class FrmSources
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSources));
            this.panel1 = new System.Windows.Forms.Panel();
            this.goToSources = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSources = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbClean = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goToSources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClean)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.goToSources);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 100);
            this.panel1.TabIndex = 7;
            // 
            // goToSources
            // 
            this.goToSources.Image = ((System.Drawing.Image)(resources.GetObject("goToSources.Image")));
            this.goToSources.Location = new System.Drawing.Point(438, 7);
            this.goToSources.Name = "goToSources";
            this.goToSources.Size = new System.Drawing.Size(59, 54);
            this.goToSources.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.goToSources.TabIndex = 8;
            this.goToSources.TabStop = false;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.MediumPurple;
            this.btnMenu.Location = new System.Drawing.Point(11, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(80, 33);
            this.btnMenu.TabIndex = 31;
            this.btnMenu.Text = "MENU";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Location = new System.Drawing.Point(807, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 33);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(381, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "S O U R C E S";
            // 
            // dgvSources
            // 
            this.dgvSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSources.Location = new System.Drawing.Point(27, 204);
            this.dgvSources.Name = "dgvSources";
            this.dgvSources.RowHeadersWidth = 51;
            this.dgvSources.RowTemplate.Height = 24;
            this.dgvSources.Size = new System.Drawing.Size(759, 250);
            this.dgvSources.TabIndex = 34;
            this.dgvSources.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSources_CellDoubleClick);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(27, 143);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(316, 27);
            this.txtName.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Name:";
            // 
            // pbClean
            // 
            this.pbClean.Image = ((System.Drawing.Image)(resources.GetObject("pbClean.Image")));
            this.pbClean.Location = new System.Drawing.Point(867, 113);
            this.pbClean.Name = "pbClean";
            this.pbClean.Size = new System.Drawing.Size(46, 41);
            this.pbClean.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClean.TabIndex = 36;
            this.pbClean.TabStop = false;
            this.pbClean.Click += new System.EventHandler(this.PbClean_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSave.Location = new System.Drawing.Point(810, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 34);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FrmSources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(932, 472);
            this.Controls.Add(this.pbClean);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvSources);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSources";
            this.Text = "FrmSources";
            this.Load += new System.EventHandler(this.FrmSources_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goToSources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClean)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox goToSources;
        private System.Windows.Forms.DataGridView dgvSources;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbClean;
        private System.Windows.Forms.Button btnSave;
    }
}