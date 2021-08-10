using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsManager_ForAPI
{
    public partial class FrmConsultArticles : Form
    {
        string url = "https://localhost:44344/api/Articles";
        public FrmConsultArticles()
        {
            InitializeComponent();
        }

        private void ptrGoFrmArticle_Click(object sender, EventArgs e)
        {
            FrmArticles articles = new FrmArticles();
            articles.ShowDialog();
            this.Hide();
        }

        private async void FrmConsultArticles_Load(object sender, EventArgs e)
        {
            string response = await GetHttp();
        }

        private async Task<string> GetHttp()
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            StreamReader stream = new StreamReader(response.GetResponseStream());

            return await stream.ReadToEndAsync();
        }
    }
}
