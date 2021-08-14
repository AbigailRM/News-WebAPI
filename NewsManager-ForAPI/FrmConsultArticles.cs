using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel;
using Newtonsoft.Json;

namespace NewsManager_ForAPI
{
    public partial class FrmConsultArticles : Form
    {
        string url = "https://localhost:44344/api/Articles";

        static HttpClient httpClient = new HttpClient();
        List<ArticlesDto> articles;

        public FrmConsultArticles()
        {
            InitializeComponent();
        }

        private void FrmConsultArticles_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void ptrGoFrmArticle_Click(object sender, EventArgs e)
        {
            FrmArticles articles = new FrmArticles();
            articles.ShowDialog();
            this.Close();
        }

        private async Task<List<ArticlesDto>> GetArticles()
        {
            string response = await GetHttp();

            articles = JsonConvert.DeserializeObject<List<ArticlesDto>>(response);

            return articles;
        }

        private async void LoadGrid()
        {
            await GetArticles();

            var list = (from x in articles
                        where x.Title.ToLower().Contains(txtSearchBox.Text.ToLower())
                        || x.Author.ToLower().Contains(txtSearchBox.Text.ToLower())
                        select new
                        {
                            Article_ID = x.ArticleId,
                            Author = x.Author,
                            Title = x.Title,
                            Description = x.Description,
                            Content = x.Content,
                            Url_To_Article = x.UrltoArticle,
                            Url_To_Image = x.UrltoImage,
                            Published_At = x.PublishedAt,
                            Category = x.CategoryName,
                            Country = x.CountryName,
                            Language = x.LanguageName
                        }).ToList();

            dgvShowArticles.DataSource = list;
            dgvShowArticles.Columns[0].Visible = false;
        }

        

        private async Task<string> GetHttp()
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            StreamReader stream = new StreamReader(response.GetResponseStream());

            return await stream.ReadToEndAsync();
        }

        private async void ptrFindArticle_Click(object sender, EventArgs e)
        {
            LoadGrid();
            //await GetArticles();

            //var list = (from x in articles
            //            where x.Title.ToLower().Contains(txtSearchBox.Text.ToLower())
            //            || x.Author.ToLower().Contains(txtSearchBox.Text.ToLower())
            //            select new
            //            {
            //                Article_ID = x.ArticleId,
            //                Author = x.Author,
            //                Title = x.Title,
            //                Description = x.Description,
            //                Content = x.Content,
            //                Url_To_Article = x.UrltoArticle,
            //                Url_To_Image = x.UrltoImage,
            //                Published_At = x.PublishedAt,
            //                Category = x.CategoryName,
            //                Country = x.CountryName,
            //                Language = x.LanguageName
            //            })

            //dgvShowArticles.DataSource = list;
            //dgvShowArticles.Columns[0].Visible = false;
        }
    }
}
