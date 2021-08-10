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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private static void Authenticate(string user, string password)
        {

            httpClient.BaseAddress = new Uri("https://localhost:44344/");

            var content = new MultipartFormDataContent("Loading..." + DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            content.Add(new StringContent(user), "user");
            content.Add(new StringContent(password), "password");

            var response = httpClient.PostAsync("/api/Credentials/creadential", content).Result;
            var resText = response.Content.ReadAsStringAsync().Result;
            var resObject = JsonConvert.DeserializeObject<CredentialResponse>(resText);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                try
                {

                }
                catch (Exception)
                {

                    throw;
                }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Authenticate(txtName.Text, txtPassword.Text);
        }

                
    }
}
