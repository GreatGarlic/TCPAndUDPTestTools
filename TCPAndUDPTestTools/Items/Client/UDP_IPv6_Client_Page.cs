using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace TCPAndUDPTestTools
{
    public partial class UDP_IPv6_Client_Page : Form
    {
        public UDP_IPv6_Client_Page()
        {
            InitializeComponent();
        }

        Socket socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                socket.Close();
                socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint ipeh_Server = new IPEndPoint(IPAddress.Parse(textBox1.Text), Convert.ToInt32(textBox2.Text));
                if (!socket.IsBound && comboBox1.Text != "自动分配")
                {
                    IPEndPoint ipeh_Local = new IPEndPoint(IPAddress.IPv6Any, Convert.ToInt32(comboBox1.Text));//Dns.GetHostByName(Dns.GetHostName()).AddressList[0]
                    socket.Bind(ipeh_Local);
                }

                if (!socket.Connected)
                {
                    socket.Connect(ipeh_Server);
                }
                Thread thread = new Thread(sendmessage);
                thread.IsBackground = true;
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
                thread.Start();
                Thread thread1 = new Thread(socketlister);
                thread1.IsBackground = true;
                if (thread1.IsAlive)
                {
                    thread1.Abort();
                }
                thread1.Start();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void sendmessage()
        {
            try
            {
                string message = textBox3.Text;
                if (message.Length > 0)
                {
                    byte[] buff = System.Text.ASCIIEncoding.UTF8.GetBytes(message);
                    this.listBox1.Items.Add(socket.LocalEndPoint + "：" + message);
                    socket.Send(buff);
                }
            }
            catch (System.Exception)
            {

            }
        }

        void socketlister()
        {
            try
            {
                byte[] buff = new byte[1024];
                int len;
                while ((len = socket.Receive(buff)) != 0)
                {
                    this.listBox1.Items.Add(socket.RemoteEndPoint + "：" + System.Text.ASCIIEncoding.UTF8.GetString(buff, 0, len));
                    buff = new byte[1024];
                }
                socket.Shutdown(SocketShutdown.Both);
            }
            catch (System.Exception)
            {

            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            socket.Close();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            if (!Socket.OSSupportsIPv6) MessageBox.Show("系统不支持IPv6地址或IPv6地址未启用！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }
    }
}
