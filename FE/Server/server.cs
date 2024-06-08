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
            if (choose1 == null || choose2 == null)
            {
                if (choose1.ToLower().Equals("kéo"))
                {
                    if (choose2.ToLower().Equals("kéo")) return "Hòa";
                    if (choose2.ToLower().Equals("búa")) return "Player1 Thua";
                    if (choose2.ToLower().Equals("bao")) return "Player1 Thắng";
                }
                if (choose1.ToLower().Equals("búa"))
                {
                    if (choose2.ToLower().Equals("kéo")) return "Player1 Thắng";
                    if (choose2.ToLower().Equals("búa")) return "Player1 Hòa";
                    if (choose2.ToLower().Equals("bao")) return "Player1 Thua";
                }
                if (choose1.ToLower().Equals("bao"))
                {
                    if (choose2.ToLower().Equals("kéo")) return "Player1 Thua";
                    if (choose2.ToLower().Equals("búa")) return "Player1 Thắng";
                    if (choose2.ToLower().Equals("bao")) return "Player1 Hòa";
                }
            }
            return null;
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
                    string message = reader.ReadLine();
                    if (message != null)
                    {
                        BroadcastMessage(message);
                        richTextBox1.AppendText(message + "\r\n");
                        if (message.Contains("choose"))
                        {
                            messages.Add(message);
                            if (messages.Count == 2)
                            {
                                int choose1 = int.Parse(messages[0].Substring(messages[0].Length - 1));
                                int choose2 = int.Parse(messages[1].Substring(messages[1].Length - 1));
                                if (choose1 > choose2)
                                {
                                    BroadcastMessage("Result: Player1 win");
                                    richTextBox1.AppendText("Result: Player1 win");
                                }
                                else if (choose2 > choose1)
                                {
                                    BroadcastMessage("Result: Player2 win");
                                    richTextBox1.AppendText("Result: Player2 win");
                                }
                                else
                                {
                                    BroadcastMessage("Result: Equal");
                                    richTextBox1.AppendText("Result: Equal");
                                }
                                messages.Clear();
                            }
                        }
                    }
                    Console.WriteLine(messages.Count);
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
