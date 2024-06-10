using System;
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
        TcpClient tcpClient = Lobby.tcpClient;
        StreamWriter sw = Lobby.sw;
        StreamReader sr = Lobby.sr;
        Double money = Lobby.money;
        public Play(String roomId, String username)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //Thread receive message from server
            try
            {
                new Thread(new ThreadStart(receiveMessage)).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Set username and roomId
            label1.Text = "Phòng " + roomId;
            label2.Text = username;
            label4.Text = money.ToString();
        }

        //Send message to server
        private void sendMessage(String message)
        {
            try
            {
                sw.WriteLine(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            String message = richTextBox2.Text;
            //Send message
            sendMessage(label1.Text + "(chat):" + label2.Text + ":" + message);
        }

        //Receive message from server
        private void receiveMessage()
        {
            try
            {
                while (tcpClient.Connected)
                {
                    String message = sr.ReadLine();
                    //Receive message from chat
                    if (message != null && message.Contains("chat"))
                    {
                        String finalMessage = message.Substring(message.IndexOf(":")+1);
                        richTextBox1.AppendText(finalMessage + "\r\n");
                    }
                    //Receive result and display the result
                    if (message != null && message.ToLower().Contains("result"))
                    {
                        String finalResult = message.Substring(message.IndexOf(":")+1);
                        label3.Text = finalResult;
                        //If result is draw display result
                        if (finalResult != null && finalResult.Equals("Draw"))
                        {
                            ListViewItem viewItem = new ListViewItem("Draw");
                            listView1.Items.Add(viewItem);
                        }
                        else
                        {
                            String[] history = finalResult.Split(' ');
                            //Display result to history
                            if (history[1].ToLower().Equals("win"))
                            {
                                //If username is equal player win save it, else save lose
                                if (label2.Text.Equals(history[0]))
                                {
                                    ListViewItem viewItem = new ListViewItem("Win");
                                    listView1.Items.Add(viewItem);
                                }
                                else
                                {
                                    ListViewItem viewItem = new ListViewItem("Lose");
                                    listView1.Items.Add(viewItem);
                                }
                            }
                            if (history[1].ToLower().Equals("lose"))
                            {
                                //If username is equal player win save it, else save lose
                                if (label2.Text.Equals(history[0]))
                                {
                                    ListViewItem viewItem = new ListViewItem("Lose");
                                    listView1.Items.Add(viewItem);
                                }
                                else
                                {
                                    ListViewItem viewItem = new ListViewItem("Win");
                                    listView1.Items.Add(viewItem);
                                }
                            }
                        }
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
            sendMessage(label1.Text + "(play):" + label2.Text + " choose kéo");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sendMessage(label1.Text + "(play):" + label2.Text + " choose búa");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sendMessage(label1.Text + "(play):" + label2.Text + " choose bao");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
