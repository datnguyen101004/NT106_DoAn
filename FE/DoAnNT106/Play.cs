﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
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
        public Play(String roomId, String username)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                tcpClient.Connect(iPEndPoint);
                sw = new StreamWriter(tcpClient.GetStream());
                sr = new StreamReader(tcpClient.GetStream());
                sw.AutoFlush = true;
                Thread receiveThread = new Thread(new ThreadStart(receiveMessage));
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            label1.Text = "Phòng " + roomId;
            label2.Text = username;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            String message = richTextBox2.Text;
            //Send message
            sw.WriteLine(label1.Text + ": " + message);
        }

        private void receiveMessage()
        {
            try
            {
                while (tcpClient.Connected)
                {
                    String message = sr.ReadLine();
                    if (message != null && (message.Contains(label1.Text) || message.Contains("Result")))
                    {
                        richTextBox1.AppendText(message + "\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sw.WriteLine(label1.Text + " choose : kéo");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sw.WriteLine(label1.Text + " choose : búa");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sw.WriteLine(label1.Text + " choose : bao");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
