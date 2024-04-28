using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNT106
{
    public partial class Play : Form
    {
        String ip = "127.0.0.1";
        int port = 8081;
        TcpClient tcpClient = new TcpClient();
        StreamWriter sw;
        StreamReader sr;
        public Play()
        {
            InitializeComponent();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            tcpClient.Connect(iPEndPoint);
            sw = new StreamWriter(tcpClient.GetStream());
            sr = new StreamReader(tcpClient.GetStream());
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            String message = bt_keo.Text;
            //Send message
            sw.AutoFlush = true;
            sw.WriteLine(message);
            sw.Flush();
            //Receive message
            Thread receiveThread = new Thread(new ThreadStart(receiveMessage));
            receiveThread.Start();
        }

        private void receiveMessage()
        {
            try
            {
                while (tcpClient.Connected)
                {
                    String message = sr.ReadLine();
                    if (message != null)
                    {
                        richTextBox1.AppendText(message + "\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sr.Close();
                sw.Close();
                tcpClient.Close();
            }
        }
    }
}
