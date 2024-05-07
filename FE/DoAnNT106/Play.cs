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
        public Play(String roomId)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                tcpClient.Connect(iPEndPoint);
                sw = new StreamWriter(tcpClient.GetStream());
                sr = new StreamReader(tcpClient.GetStream());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            label1.Text = "Phòng " + roomId;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            String message = richTextBox2.Text;
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
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
