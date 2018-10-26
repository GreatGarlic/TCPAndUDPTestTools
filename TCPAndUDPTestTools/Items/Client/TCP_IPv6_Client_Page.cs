using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace TCPAndUDPTestTools
{
    public partial class TCP_IPv6_Client_Page : Form
    {
        public TCP_IPv6_Client_Page()
        {
            InitializeComponent();       
        }

        byte[] m_dataBuffer = new byte[10];
        IAsyncResult m_result;
        public AsyncCallback m_pfnCallBack;
        public Socket m_clientSocket = null;

        public class SocketPacket
        {
            public SocketPacket(Socket socket)
            {
                string_RemoteEndPoint = socket.RemoteEndPoint;
            }
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[1024];
            public EndPoint string_RemoteEndPoint;
        }


        private delegate void UpdateText(string text);
        private void updateText(string text)
        {
            listBox_Msg.Items.Add(text);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;
            }	
        }

        private void Client_Load(object sender, EventArgs e)
        { 
            if (!Socket.OSSupportsIPv6) MessageBox.Show("系统不支持IPv6地址或IPv6地址未启用！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            for (int i = 0; i < Dns.GetHostEntry(Dns.GetHostName()).AddressList.Length; i++)
            {
                if (Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString().Contains(":"))
                {
                    this.textBox1.Text=Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString();
                }
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listBox_Msg.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (button2.Text)
            {

                case "连接":
                    {
                        try
                        {
                            m_clientSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
                            m_clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                            EndPoint ipeh_Server = new IPEndPoint(IPAddress.Parse(textBox1.Text), Convert.ToInt32(textBox2.Text));
                            if (!m_clientSocket.IsBound)
                            {
                                if (comboBox1.Text == "自动分配")
                                {
                                    m_clientSocket.Bind(new IPEndPoint(IPAddress.IPv6Any, 0));
                                }
                                else
                                {
                                    m_clientSocket.Bind(new IPEndPoint(IPAddress.IPv6Any, Convert.ToInt32(comboBox1.Text)));
                                }
                            }                     
                            if (!m_clientSocket.Connected)
                            {
                                m_clientSocket.Connect(ipeh_Server);
                                WaitForData();
                            }
                            button2.Text = "断开";
                            textBox1.ReadOnly = true;
                            textBox2.ReadOnly = true;
                            comboBox1.Enabled = false;
                            button_SendMsg.Enabled = true;
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                case "断开":
                    {
                        if (m_clientSocket != null)
                        {

                            m_clientSocket.Shutdown(SocketShutdown.Both);
                            m_clientSocket.Close();
                            m_clientSocket = null;
                        }
                        button2.Text = "连接";
                        textBox1.ReadOnly = false;
                        textBox2.ReadOnly = false;
                        comboBox1.Enabled = true;
                        button_SendMsg.Enabled = false;
                        break;
                    }
            }
        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
                int iRx = theSockId.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                System.String szData =theSockId.string_RemoteEndPoint+":"+( new System.String(chars));
                listBox_Msg.Invoke(new UpdateText(updateText), szData);
                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (Exception se)
            {
                this.Invoke(new Action(() =>
                {
                    //MessageBox.Show("服务器断开连接,请检查服务器然后重新连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    listBox_Msg.Items.Add(se.Message);
                    button2.PerformClick();
                }
              ));
            }
        }

        public void WaitForData()
        {
            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket(m_clientSocket);
                theSocPkt.thisSocket = m_clientSocket;
                m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None, m_pfnCallBack, theSocPkt);
            }
            catch (System.Exception se)
            {
                MessageBox.Show(se.Message+"1");
            }
        }

        private void button_SendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                string  msg = textBox_SendMsg.Text;
               
                if (hex_checkbox.Checked)
                {
                    byte[] msgBytes = Utils.StringToBytes(msg);
                   
                    m_clientSocket.Send(msgBytes);
                }
                else {
                    NetworkStream networkStream = new NetworkStream(m_clientSocket);
                    System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);
                    streamWriter.WriteLine(msg);
                    streamWriter.Flush();
                }
                listBox_Msg.Items.Add(m_clientSocket.RemoteEndPoint.ToString() + ":" + msg);
            }
            catch (System.Exception se)
            {
                MessageBox.Show(se.Message);
            }	
        }
      
    }
}
