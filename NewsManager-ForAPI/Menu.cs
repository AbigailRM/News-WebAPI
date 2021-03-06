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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void goToArticles_Click(object sender, EventArgs e)
        {
            FrmArticles articles = new FrmArticles();
            articles.ShowDialog();
            Close();
        }

        private void goToAuthors_Click(object sender, EventArgs e)
        {
            FrmAuthors authors = new FrmAuthors();
            authors.ShowDialog();
            Close();
        }

        private void goToSources_Click(object sender, EventArgs e)
        {
            FrmSources sources = new FrmSources();
            sources.ShowDialog();
            Close();
        }
    }
}
