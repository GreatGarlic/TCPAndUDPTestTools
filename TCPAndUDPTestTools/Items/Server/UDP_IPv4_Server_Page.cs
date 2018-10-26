using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TCPAndUDPTestTools
{
    public partial class UDP_IPv4_Server_Page : Form
    {
        public UDP_IPv4_Server_Page()
        {
            InitializeComponent();
        }
        
        Socket SocketListener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);  

        protected override void OnClosing(CancelEventArgs e)
        {
            SocketListener.Close();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            if (!Socket.OSSupportsIPv4 ) MessageBox.Show("系统不支持IPv4地址或IPv4地址未启用！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            for (int i = 0; i < Dns.GetHostEntry(Dns.GetHostName()).AddressList.Length; i++)
            {
                if (Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString().Contains("."))
                {
                    this.comboBox1.Items.Add(Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString());
                }
            }
            comboBox1.SelectedIndex = 0;
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SocketListener.Close();
                SocketListener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                Thread thread = new Thread(IPv4ServerMessage);
                thread.IsBackground = true;
                switch (button1.Text)
                {
                    case "监听":
                        {
                            if (!SocketListener.IsBound)
                            {
                                if (comboBox1.SelectedItem.ToString()=="Any")
                                {
                                    SocketListener.Bind(new IPEndPoint(IPAddress.Any, Convert.ToInt32(textBox2.Text)));
                                }
                                else SocketListener.Bind(new IPEndPoint(IPAddress.Parse(comboBox1.SelectedItem.ToString()), Convert.ToInt32(textBox2.Text)));
                            }
                            thread.Start();
                            button1.Text = "停止";
                            textBox2.ReadOnly = true;

                            break;
                        }
                    case "停止":
                        {
                            button1.Text = "监听";
                            textBox2.ReadOnly = false;
                            thread.Abort();
                            break;
                        }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }

        void IPv4ServerMessage()
        {
            try
            {
                while (true)
                {
                    EndPoint Remote = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
                    byte[] buff = new byte[1024];
                    int len;
                    string tmp = string.Empty;
                    while ((len = SocketListener.ReceiveFrom(buff, ref Remote)) > 0)
                    {
                        tmp = System.Text.ASCIIEncoding.UTF8.GetString(buff, 0, len);
                        this.listBox1.Items.Add(Remote + "：" + tmp);
                        byte[] buff_back = System.Text.ASCIIEncoding.UTF8.GetBytes(tmp);
                        SocketListener.SendTo(buff_back, Remote);
                        buff = new byte[1024];
                    }
                }
            }
            catch (System.Exception)
            {

            }
        }

    }
}
