using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using ViewModel;

namespace NewsManager_ForAPI
{
    public partial class FrmLogin : Form
    {
        static HttpClient httpClient = new HttpClient();

        public FrmLogin()
        {
            InitializeComponent();

            httpClient.BaseAddress = new Uri("https://localhost:44344/");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void Authenticate(string user, string password)
        {

            var content = new MultipartFormDataContent("Loading..." + DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            content.Add(new StringContent(user), "name");
            content.Add(new StringContent(password), "password");

            var response = httpClient.PostAsync("/api/Credentials/credential", content).Result;
            var resText = response.Content.ReadAsStringAsync().Result;

            try
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resObject = JsonConvert.DeserializeObject<CredentialResponse>(resText);

                    Menu menu = new Menu();
                    menu.ShowDialog();
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Invalid Credentials");
                }
            }
            catch (Exception)
            {
                ///cambiar metodo de captura de excepciones
                throw new ApplicationException("There's An Error With The Server");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Authenticate(txtName.Text, txtPassword.Text);

            
        }

    }
}
