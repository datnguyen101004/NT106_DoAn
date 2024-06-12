using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        String roomID;
        String userName;
        public Play(String roomId, String username)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //Set username and roomId
            label1.Text = "Phòng " + roomId;
            roomID = roomId;
            userName = username;
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
                        label3.Visible = true;
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
                    //Notification when new user join room
                    if (message != null && message.ToLower().Contains("join"))
                    {
                        Console.WriteLine(message + "rec in playroom");
                        label5.Visible = true;
                        String noti = message.Substring(0, message.IndexOf("with")-1);
                        String username = message.Substring(0, message.IndexOf(" "));
                        getMoney(username);
                        label5.Text = noti;
                        label6.Visible = true;
                        label7.Visible = true;
                        label6.Text = username;
                        label7.Text = competitorMoney.ToString();
                        button5.Enabled = true;
                        waitTime(5);
                        label5.Visible = false;
                    }
                    Console.WriteLine(message);
                    if (message != null && message.ToLower().Contains("start"))
                    {
                        Console.WriteLine("Received start game notification");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateStartRoom()
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            button5.Visible = false;
        }

        private Double competitorMoney;

        //Get money
        private async void getMoney(string username)
        {
            String requestParam = "/user/money?username=" + username;
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(requestParam);
            String money = await httpResponseMessage.Content.ReadAsStringAsync();
            competitorMoney = Double.Parse(money);
        }


        //Set time waiting
        private void waitTime(int second)
        {
            Thread.Sleep(second*1000);
        }

        private static HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:8080")
        };

        private async void handleOutRoom(String username, String roomId)
        {
            try
            {
                var outRoomDto = new Dictionary<String, String>();
                outRoomDto.Add("username", username);
                outRoomDto.Add("roomId", roomId);
                String outRoomDtoJson = JsonConvert.SerializeObject(outRoomDto);
                HttpContent httpContent = new StringContent(outRoomDtoJson, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("/user/outRoom", httpContent);
            }
            catch (Exception e) 
            { 
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            handleOutRoom(label2.Text, label1.Text);
            sendMessage(label1.Text + ":" + label2.Text + " out room");
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

        private void Play_Load(object sender, EventArgs e)
        {
            updatePlayRoom();
            //Thread receive message from server
            try
            {
                Thread thread = new Thread(new ThreadStart(receiveMessage));
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void updatePlayRoom()
        {
            //Get info user in room
            String requestParam = "/user/room/info?roomId=" + roomID;
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(requestParam);
            String data = await httpResponseMessage.Content.ReadAsStringAsync();
            InfoUserRoom userInfo = JsonConvert.DeserializeObject<InfoUserRoom>(data);
            if (userInfo != null)
            {
                //if you are host (room has 1 people)
                if (String.IsNullOrEmpty(userInfo.username2))
                {
                    label2.Text = userInfo.username1;
                    label4.Text = userInfo.money1.ToString();
                    label3.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    button5.Enabled = false;
                }
                //room has 2 people
                else
                {
                    if (userName.Equals(userInfo.username1))
                    {
                        label2.Text = userInfo.username1;
                        label4.Text = userInfo.money1.ToString();
                        label6.Text = userInfo.username2;
                        label7.Text = userInfo.money2.ToString();
                    }
                    else
                    {
                        label2.Text = userInfo.username2;
                        label4.Text = userInfo.money2.ToString();
                        label6.Text = userInfo.username1;
                        label7.Text = userInfo.money1.ToString();
                    }
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    label3.Visible = false;
                    label5.Visible = false;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; 
            pictureBox2.Visible = true;
            button5.Visible = false;
            sendMessage(label1.Text + ":start new game");
        }
    }
}
