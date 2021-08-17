using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using ViewModel;

namespace NewsManager_ForAPI
{
    public partial class FrmArticles : Form
    {
        static readonly HttpClient httpClient = new HttpClient();

        ArticlesDto objArticle;
        List<ArticlesDto> articles;


        public FrmArticles()
        {
            InitializeComponent();

            httpClient.BaseAddress = new Uri("https://localhost:44344/");
        }

        private void FrmArticles_Load(object sender, EventArgs e)
        {
            GetAuthors();
            GetCategories();
            GetCountries();
            GetLanguages();
            GetSources();

            btnDelete.Enabled = false;
            
        }

        private void PtrGetArticles_Click(object sender, EventArgs e)
        {
            
        }

        
        private void SeeArticles_MouseClick(object sender, MouseEventArgs e)
        {

            FrmConsultArticles consultArticles = new FrmConsultArticles();
            consultArticles.ShowDialog();

            if (consultArticles.articleId != 0)
                LoadArticle(consultArticles.articleId);
        }


        private List<ArticlesDto> GetArticles()
        {
            var response = httpClient.GetAsync("/api/Articles").Result;
            var resText = response.Content.ReadAsStringAsync().Result;

            articles = JsonConvert.DeserializeObject<List<ArticlesDto>>(resText);

            return articles;
        }

        private void LoadArticle(int articleId)
        {
            btnDelete.Enabled = true;

            GetArticles();

            objArticle = articles.FirstOrDefault(x => x.ArticleId == articleId);

            txtContent.Text = objArticle.Content;
            txtDescription.Text = objArticle.Description;
            txtTitle.Text = objArticle.Title;
            txtURLArticle.Text = objArticle.UrltoArticle;
            txtURLImage.Text = objArticle.UrltoImage;

            cbAuthor.SelectedValue = objArticle.AuthorId;
            cbCategory.SelectedValue = objArticle.CategoryId;
            cbCountry.SelectedValue = objArticle.CountryId;
            cbLanguage.SelectedValue = objArticle.LanguageId;
            cbSource.SelectedValue = objArticle.SourceId;            

        }

        

        //Metodos para llenar los ComboBox

        private void GetAuthors()
        {
            var response = httpClient.GetAsync("/api/Authors").Result;
            var resText = response.Content.ReadAsStringAsync().Result;

            List<AuthorsDto> AuthorList = JsonConvert.DeserializeObject<List<AuthorsDto>>(resText);
            
            foreach (var i in AuthorList)
            {
                i.Name += " " + i.LastName;
            };

            var DefaultItem = new AuthorsDto { AuthorId = 0, Name = "Select" };
            AuthorList.Insert(0, DefaultItem);

            cbAuthor.DataSource = AuthorList;
            cbAuthor.DisplayMember = "Name";
            cbAuthor.ValueMember = "AuthorId";

        }


        private void GetSources()
        {
            var response = httpClient.GetAsync("/api/Sources").Result;
            var resText = response.Content.ReadAsStringAsync().Result;

            List<SourceDto> SourceList = JsonConvert.DeserializeObject<List<SourceDto>>(resText);

            var DefaultItem = new SourceDto { SourceId = 0, SourceName = "Select" };
            SourceList.Insert(0, DefaultItem);

            cbSource.DataSource = SourceList;
            cbSource.DisplayMember = "SourceName";
            cbSource.ValueMember = "SourceId";

        }

        private void GetCountries()
        {
            var response = httpClient.GetAsync("/api/Countries").Result;
            var resText = response.Content.ReadAsStringAsync().Result;

            List<CountriesDto> CountryList = JsonConvert.DeserializeObject<List<CountriesDto>>(resText);

            var DefaultItem = new CountriesDto { CountryId = 0, Name = "Select" };
            CountryList.Insert(0, DefaultItem);

            cbCountry.DataSource = CountryList;
            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "CountryId";

        }

        private void GetCategories()
        {
            var response = httpClient.GetAsync("/api/Categories").Result;
            var resText = response.Content.ReadAsStringAsync().Result;

            List<CategoriesDto> CategoryList = JsonConvert.DeserializeObject<List<CategoriesDto>>(resText);

            var DefaultItem = new CategoriesDto { CategoryId = 0, Name = "Select" };
            CategoryList.Insert(0, DefaultItem);

            cbCategory.DataSource = CategoryList;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "CategoryId";

        }

        private void GetLanguages()
        {
            var response = httpClient.GetAsync("/api/Languages").Result;
            var resText = response.Content.ReadAsStringAsync().Result;

            List<LanguagesDto> LanguageList = JsonConvert.DeserializeObject<List<LanguagesDto>>(resText);

            var DefaultItem = new LanguagesDto { LanguageId = 0, Name = "Select" };
            LanguageList.Insert(0, DefaultItem);

            cbLanguage.DataSource = LanguageList;
            cbLanguage.DisplayMember = "Name";
            cbLanguage.ValueMember = "LanguageId";

        }



        //Los metodos a continuación son para realizar el CRUD en la tabla de Articles

        private void Clean()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    c.Text = " ";
                if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = 0;

            }

            btnDelete.Enabled = false;
        }

        private void Save()
        {
            if (objArticle == null)
            {
                var articles = new ArticlesDto
                {
                    Title = txtTitle.Text,
                    AuthorId = cbAuthor.SelectedIndex,
                    Description = txtDescription.Text,
                    Content = txtContent.Text,
                    UrltoArticle = txtURLArticle.Text,
                    UrltoImage = txtURLImage.Text,
                    PublishedAt = DateTime.Now,
                    SourceId = cbSource.SelectedIndex,
                    CategoryId = cbCategory.SelectedIndex,
                    CountryId = cbCountry.SelectedIndex,
                    LanguageId = cbLanguage.SelectedIndex,
                    UserId = 1,
                    CreateDate = DateTime.Now
                };

                string json = JsonConvert.SerializeObject(articles);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync("/api/Articles", content).Result;

                if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show("Article Was Inserted Correctly!");

                    Clean();
                }
                else
                {
                    MessageBox.Show("¡Something Was Wrong With This Action!");
                }
            }
            else
            {
                objArticle.Title = txtTitle.Text;
                objArticle.AuthorId = cbAuthor.SelectedIndex;
                objArticle.Description = txtDescription.Text;
                objArticle.Content = txtContent.Text;
                objArticle.UrltoArticle = txtURLArticle.Text;
                objArticle.UrltoImage = txtURLImage.Text;
                objArticle.PublishedAt = DateTime.Now;
                objArticle.SourceId = cbSource.SelectedIndex;
                objArticle.CategoryId = cbCategory.SelectedIndex;
                objArticle.CountryId = cbCountry.SelectedIndex;
                objArticle.LanguageId = cbLanguage.SelectedIndex;
                objArticle.UserId = 1;
                //objArticle.CreateDate = DateTime.Now;


                string json = JsonConvert.SerializeObject(objArticle);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PutAsync("/api/Articles", content).Result;

                if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show("Article Was Updated Correctly!");

                    Clean();
                }
                else
                {
                    MessageBox.Show("¡Something Was Wrong With This Action!");
                }
            }

            
        }

        private void Delete()
        {

        }


        private void lbSeeArticles_MouseClick(object sender, MouseEventArgs e)
        {
            lbSeeArticles.ForeColor = Color.Aqua;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void pboxClean_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }
    }
}
