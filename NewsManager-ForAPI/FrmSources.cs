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
    public partial class FrmSources : Form
    {
        static readonly HttpClient httpClient = new HttpClient();
        private int sourceId = 0;

        private List<SourceDto> sources;

        private SourceDto objSource;

        public FrmSources()
        {
            InitializeComponent();
            httpClient.BaseAddress = new Uri("https://localhost:44344/");

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void FrmSources_Load(object sender, EventArgs e)
        {
            LoadGrid();
            btnDelete.Enabled = false;
        }

        private List<SourceDto> GetSource()
        {
            var response = httpClient.GetAsync("/api/Sources").Result;
            var resText = response.Content.ReadAsStringAsync().Result;

            sources = JsonConvert.DeserializeObject<List<SourceDto>>(resText);

            return sources;
        }

        private void LoadGrid()
        {
            GetSource();

            var list = (from x in sources
                        select new
                        {
                            SourceId = x.SourceId,
                            Source_Name=x.SourceName
                        }).ToList();

            dgvSources.DataSource = list;
            dgvSources.Columns[0].Visible = false;
        }

        private void Clean()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    c.Text = " ";

            }
            objSource = null;

            btnDelete.Enabled = false;
        }


        private void Save()
        {
            if (objSource == null)
            {
                var source = new SourceDto
                {
                    SourceName = txtName.Text
                };

                string json = JsonConvert.SerializeObject(source);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync("/api/Sources", content).Result;

                if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show("Source Was Inserted Correctly!");

                    Clean();
                }
                else
                {
                    MessageBox.Show("¡Something Was Wrong With This Action!");
                }
            }
            else
            {

                objSource.SourceName = txtName.Text;

                string json = JsonConvert.SerializeObject(objSource);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PutAsync("/api/Sources", content).Result;

                if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show("Source Was Updated!");

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

            var response = httpClient.DeleteAsync("/api/Sources/" + objSource.SourceId).Result;

            if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Source Was Deleted!");

                Clean();
            }
            else
            {
                MessageBox.Show("¡Something Was Wrong With This Action!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void PbClean_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void DgvSources_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sourceId = Convert.ToInt32(dgvSources[0, dgvSources.CurrentRow.Index].Value);

            objSource = sources.FirstOrDefault(x => x.SourceId == sourceId);

            txtName.Text = objSource.SourceName;

            btnDelete.Enabled = true;
        }
    }
}
