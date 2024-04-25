using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNT106
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private static HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:8080"),
        };

        private async void button1_Click(object sender, EventArgs e)
        {
            String email = textBox1.Text;
            String password = textBox2.Text;
            User user = new User();
            user.email = email;
            user.password = password;
            String json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("/auth/login", content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                String message = await httpResponseMessage.Content.ReadAsStringAsync();
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("login fail");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(new ThreadStart(signup));
            thread.Start();
        }

        private void signup()
        {
            Application.Run(new signup());
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String email = textBox1.Text;
            if (String.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email");
            }
            User user = new User();
            user.recipient = email;
            String body = JsonConvert.SerializeObject(user);
            HttpContent httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await httpClient.PostAsync("/auth/sendForgetMail", httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                String message = await httpResponse.Content.ReadAsStringAsync();
                MessageBox.Show(message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
