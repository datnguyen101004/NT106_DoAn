using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNT106
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private static HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:8080"),
        };

        public class Email{
            public String recipient { get; set; }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String email = textBox2.Text;
            String password = textBox3.Text;
            User user = new User();
            user.username = username;
            user.email = email;
            user.password = password;
            String json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("/auth/register", content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                Email _email = new Email();
                _email.recipient = email;
                String json1 = JsonConvert.SerializeObject(_email);
                HttpContent content1 = new StringContent(json1, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage1 = await httpClient.PostAsync("/auth/sendVerifyMail", content1);
                if (httpResponseMessage1.IsSuccessStatusCode)
                {
                    String message = await httpResponseMessage.Content.ReadAsStringAsync();
                    String message1 = await httpResponseMessage1.Content.ReadAsStringAsync();
                    MessageBox.Show(message + ". " + message1 + ".Please check your mail to verify your account");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Register fail. Email is invalid or exist!");
            }
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
