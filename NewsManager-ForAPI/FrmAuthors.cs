using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel;

namespace NewsManager_ForAPI
{
    public partial class FrmAuthors : Form
    {

        static readonly HttpClient httpClient = new HttpClient();
        private int authorId = 0;

        private List<AuthorsDto> authors;

        private AuthorsDto objAuthor;

        public FrmAuthors()
        {
            InitializeComponent();

            httpClient.BaseAddress = new Uri("https://localhost:44344/");

        }

        private void FrmAuthors_Load(object sender, EventArgs e)
        {
            LoadGrid();

            btnDelete.Enabled = false;
        }




        private List<AuthorsDto> GetAuthors()
        {
            var response = httpClient.GetAsync("/api/Authors").Result;
            var resText = response.Content.ReadAsStringAsync().Result;

            authors = JsonConvert.DeserializeObject<List<AuthorsDto>>(resText);

            return authors;
        }

        private void LoadGrid()
        {
            GetAuthors();

            var list = (from x in authors
                        select new
                        {
                            AutorId = x.AuthorId,
                            Author = x.Name+" "+ x.LastName,
                        }).ToList();

            dgvAuthors.DataSource = list;
            dgvAuthors.Columns[0].Visible = false;
        }

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
            if (objAuthor == null)
            {
                var author = new AuthorsDto
                {
                    Name = txtName.Text,
                    LastName = txtLastName.Text
                };

                string json = JsonConvert.SerializeObject(author);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync("/api/Authors", content).Result;

                if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show("Author Was Inserted Correctly!");

                    Clean();
                }
                else
                {
                    MessageBox.Show("¡Something Was Wrong With This Action!");
                }
            }
            else
            {
                objAuthor.Name = txtName.Text;
                objAuthor.LastName = txtLastName.Text;

                string json = JsonConvert.SerializeObject(objAuthor);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PutAsync("/api/Authors", content).Result;

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
            //string json = JsonConvert.SerializeObject(objAuthor);

            //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = httpClient.DeleteAsync("/api/Authors/" + objAuthor.AuthorId).Result;

            if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Author Was Deleted!");

                Clean();
            }
            else
            {
                MessageBox.Show("¡Something Was Wrong With This Action!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void pbClean_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        

        private void AuthorID_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            authorId = Convert.ToInt32(dgvAuthors[0, dgvAuthors.CurrentRow.Index].Value);

            objAuthor = authors.FirstOrDefault(x => x.AuthorId == authorId);

            txtName.Text = objAuthor.Name;
            txtLastName.Text = objAuthor.LastName;

            btnDelete.Enabled = true;

        }
    }
}
