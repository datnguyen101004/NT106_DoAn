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

namespace Server
{
    public partial class server : Form
    {
        TcpListener serverSocket = new TcpListener(IPAddress.Any, 8081);
        List<TcpClient> clientsList = new List<TcpClient>();
        public server()
        {
            InitializeComponent();
        }

        //Handle the choosen of 2 people
        private String handleResult(String choose1, String choose2)
        {
            if (choose1 != null && choose2 != null)
            {
                if (choose1.ToLower().Equals("kéo"))
                {
                    if (choose2.ToLower().Equals("kéo")) return "Result:Draw";
                    if (choose2.ToLower().Equals("búa")) return "Result:Player1 win";
                    if (choose2.ToLower().Equals("bao")) return "Result:Player2 win";
                }
                if (choose1.ToLower().Equals("búa"))
                {
                    if (choose2.ToLower().Equals("kéo")) return "Result:Player1 win";
                    if (choose2.ToLower().Equals("búa")) return "Result:Draw";
                    if (choose2.ToLower().Equals("bao")) return "Result:Player2 win";
                }
                if (choose1.ToLower().Equals("bao"))
                {
                    if (choose2.ToLower().Equals("kéo")) return "Result:Player2 win";
                    if (choose2.ToLower().Equals("búa")) return "Result:Player1 win";
                    if (choose2.ToLower().Equals("bao")) return "Result:Draw";
                }
            }
            return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread acceptThread = new Thread(AcceptClients);
            acceptThread.Start();
        }

        private void AcceptClients()
        {
            try
            {
                richTextBox1.AppendText("Server running on 127.0.0.1:8081" + "\r\n");
                serverSocket.Start();
                while (true)
                {
                    TcpClient clientSocket = serverSocket.AcceptTcpClient();
                    clientsList.Add(clientSocket);
                    if (clientSocket.Connected)
                    {
                        richTextBox1.AppendText("New client connected" + "\r\n");
                    }
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.IsBackground = true;
                    clientThread.Start(clientSocket);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<string> messages = new List<string>();
        private void HandleClient(Object _client)
        {
            TcpClient client = (TcpClient)_client;
            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.AutoFlush = true;
                while (true)
                {
                    string message = reader.ReadToEnd();
                    if (message != null)
                    {
                        BroadcastMessage(message);
                        richTextBox1.AppendText(message + "\r\n");
                        if (message.Contains("play"))
                        {
                            messages.Add(message);
                            if (messages.Count == 2)
                            {
                                String choose1 = messages[0].Substring(messages[0].LastIndexOf(" ")+1);
                                Console.WriteLine(choose1);
                                String choose2 = messages[1].Substring(messages[1].LastIndexOf(" ")+1);
                                Console.WriteLine(choose2);
                                String result = handleResult(choose1, choose2);
                                Console.WriteLine(result);
                                richTextBox1.AppendText(result);
                                BroadcastMessage(result);
                                messages.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private void BroadcastMessage(string message)
        {
            foreach (TcpClient client in clientsList)
            {
                if (!client.Connected)
                {
                    clientsList.Remove(client);
                    richTextBox1.AppendText("Client disconected");
                }
            }
            foreach (TcpClient client in clientsList)
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.AutoFlush = true;
                writer.WriteLine(message);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            serverSocket.Stop();
            Close();
        }
    }
}
