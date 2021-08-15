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
using System.Globalization;

namespace NewsManager_ForAPI
{
    public partial class FrmArticles : Form
    {
        static HttpClient httpClient = new HttpClient();        

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
            
        }

        private void ptrGetArticles_Click(object sender, EventArgs e)
        {
            
        }

        private void Save()
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
            }
            else
            {
                MessageBox.Show("¡Something Was Wrong With This Action!");
            }
        }

        private void label12_MouseClick(object sender, MouseEventArgs e)
        {
            FrmConsultArticles consultArticles = new FrmConsultArticles();
            consultArticles.ShowDialog();
            this.Close();
        }

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

            //httpClient.Dispose();
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

        private void lbSeeArticles_MouseClick(object sender, MouseEventArgs e)
        {
            lbSeeArticles.ForeColor = Color.Aqua;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
