using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsManager_ForAPI
{
    public partial class FrmArticles : Form
    {
        public FrmArticles()
        {
            InitializeComponent();
        }

        private void FrmArticles_Load(object sender, EventArgs e)
        {

        }

        private void ptrGetArticles_Click(object sender, EventArgs e)
        {
            FrmConsultArticles consultArticles = new FrmConsultArticles();
            consultArticles.ShowDialog();
            this.Hide();
        }
    }
}
