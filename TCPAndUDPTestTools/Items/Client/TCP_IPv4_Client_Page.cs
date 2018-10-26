using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace TCPAndUDPTestTools
{
    public partial class TCP_IPv4_Client_Page : Form
    {
        public TCP_IPv4_Client_Page()
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
            textBox_MSG.AppendText(text + "\r\n");
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
            if (!Socket.OSSupportsIPv4) MessageBox.Show("系统不支持IPv4地址或IPv4地址未启用！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);   
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.listBox_Msg.Items.Clear();
            this.textBox_MSG.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                switch (button2.Text)
                {
                    case "连接":
                        {
                            m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            m_clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                            EndPoint ipeh_Server = new IPEndPoint(IPAddress.Parse(textBox1.Text), Convert.ToInt32(textBox2.Text));
                            if (!m_clientSocket.IsBound)
                            {
                                if (comboBox1.Text == "自动分配")
                                {
                                    m_clientSocket.Bind(new IPEndPoint(IPAddress.Any, 0));
                                }
                                else
                                {
                                    m_clientSocket.Bind(new IPEndPoint(IPAddress.Any, Convert.ToInt32(comboBox1.Text)));
                                }
                            }
                            m_clientSocket.Connect(ipeh_Server);
                            WaitForData();
                            button2.Text = "断开";
                            textBox1.ReadOnly = true;
                            textBox2.ReadOnly = true;
                            comboBox1.Enabled = false;
                            button_SendMsg.Enabled = true;
                            break;
                        }
                    case "断开":
                        {
                            if (m_clientSocket != null)
                            {
                                //m_clientSocket.Shutdown(SocketShutdown.Both);
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
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                textBox_MSG.Invoke(new UpdateText(updateText), szData);
                WaitForData();
            }

            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (System.Exception se)
            {
                //MessageBox.Show("服务器断开连接,请检查服务器然后重新连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.textBox_MSG.AppendText(se.Message + "\r\n");
                button2.PerformClick();
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
                MessageBox.Show(se.Message);
            }
        }

        private void button_SendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = textBox_SendMsg.Text;
                NetworkStream networkStream = new NetworkStream(m_clientSocket);
                StreamWriter streamWriter = new StreamWriter(networkStream);
                streamWriter.WriteLine(msg);                
                streamWriter.Flush();            
                streamWriter.Close();
                networkStream.Close();              
                textBox_MSG.AppendText(m_clientSocket.LocalEndPoint.ToString() + ":" + msg + "\r\n");
                textBox_SendMsg.Clear();
            }
            catch (System.Exception se)
            {
                MessageBox.Show(se.Message);
            }	
        }
      
    }
}
