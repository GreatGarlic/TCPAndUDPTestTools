using System;
using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace TCPAndUDPTestTools
{
    public partial class TCP_IPv6_Server_Page : Form
    {
        public TCP_IPv6_Server_Page()
        {
            InitializeComponent();
        }

        public class SocketPacket
        {
            public SocketPacket(Socket socket, int clientNumber)
            {
                m_currentSocket = socket;
                m_clientNumber = clientNumber;
                string_RemoteEndPoint = socket.RemoteEndPoint;
            }
            public Socket m_currentSocket;
            public int m_clientNumber;
            public byte[] dataBuffer = new byte[1024];
            public EndPoint string_RemoteEndPoint;
        }

        public delegate void UpdateRichEditCallback(string text);
        public delegate void UpdateClientListCallback();
        private AsyncCallback pfnWorkerCallBack;
        private Socket m_mainSocket;
        private ArrayList m_workerSocketList = ArrayList.Synchronized(new System.Collections.ArrayList());
        private int m_clientCount = 0;

        protected override void OnClosing(CancelEventArgs e)
        {
            if (m_mainSocket != null)
            {
                m_mainSocket.Close();
                m_mainSocket = null;
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            if (!Socket.OSSupportsIPv6) MessageBox.Show("系统不支持IPv6地址或IPv6地址未启用！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            for (int i = 0; i < Dns.GetHostEntry(Dns.GetHostName()).AddressList.Length; i++)
            {
                if (Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString().Contains(":"))
                {
                    this.comboBox1.Items.Add(Dns.GetHostEntry(Dns.GetHostName()).AddressList[i].ToString());
                }
            }
            comboBox1.SelectedIndex = 0;
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_RecMsg.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (button1.Text)
            {
                case "监听":
                    {
                        try
                        {
                            button1.Text = "停止";
                            textBox2.ReadOnly = true;
                            m_mainSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
                            m_mainSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                            if (comboBox1.SelectedItem.ToString() == "IPv6Any")
                            {
                                m_mainSocket.Bind(new IPEndPoint(IPAddress.IPv6Any, Convert.ToInt32(textBox2.Text)));
                            }
                            else
                            {
                                m_mainSocket.Bind(new IPEndPoint(IPAddress.Parse(comboBox1.SelectedItem.ToString()), Convert.ToInt32(textBox2.Text)));
                            }
                            m_mainSocket.Listen(10);
                            m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), m_mainSocket);
                            break;
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.Message + "1", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                    }
                case "停止":
                    {
                        button1.Text = "监听";
                        textBox2.ReadOnly = false;
                        CloseSockets();
                        break;
                    }
            }
        }


        private void CloseSockets()
        {
            try
            {
                ConnectedType.Text = "未连接";
                if (m_mainSocket != null)
                {
                    m_mainSocket.Close();
                    m_mainSocket = null;
                }
                for (int i = 0; i < m_workerSocketList.Count; i++)
                {
                    Socket workerSocket = (Socket)m_workerSocketList[i];
                    if (workerSocket != null)
                    {
                        workerSocket.Close();
                        workerSocket = null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "关闭套接字错误");
            }
        }

        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                Socket workerSocket = m_mainSocket.EndAccept(asyn);
                Interlocked.Increment(ref m_clientCount);
                m_workerSocketList.Add(workerSocket);
                string msg = "Welcome " + workerSocket.RemoteEndPoint.ToString();
                this.Invoke(new Action(() =>
                {
                    listBox_RecMsg.Items.Add(workerSocket.RemoteEndPoint.ToString() + " Connected");
                }
                ));
                SendMsgToClient(msg, m_clientCount);
                UpdateClientListControl();
                WaitForData(workerSocket, m_clientCount);
                m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), m_mainSocket);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (System.Exception se)
            {
                //MessageBox.Show(se.Message);
            }
        }

        void SendMsgToClient(string msg, int clientNumber)
        {
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(msg);
            Socket workerSocket = (Socket)m_workerSocketList[clientNumber - 1];
            workerSocket.Send(byData);
        }

        private void UpdateClientListControl()
        {
            if (InvokeRequired)
            {
                ConnectedType.BeginInvoke(new UpdateClientListCallback(UpdateClientList), null);
            }
            else
            {
                UpdateClientList();
            }
        }

        public void WaitForData(Socket soc, int clientNumber)
        {
            SocketPacket theSocPkt = new SocketPacket(soc, clientNumber);
            try
            {
                if (pfnWorkerCallBack == null)
                {
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }
                soc.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None, pfnWorkerCallBack, theSocPkt);
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10053)
                {
                    string msg = theSocPkt.string_RemoteEndPoint.ToString() + " Disconnected";
                    AppendToRichEditControl(msg);
                    m_workerSocketList[theSocPkt.m_clientNumber - 1] = null;
                    UpdateClientListControl();
                }
                else
                {
                    MessageBox.Show(se.Message);
                }
            }
        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacket socketData = (SocketPacket)asyn.AsyncState;
            try
            {
                int iRx = socketData.m_currentSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(socketData.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                AppendToRichEditControl(socketData.string_RemoteEndPoint.ToString() + ":" + szData);
                Socket workerSocket = (Socket)socketData.m_currentSocket;

                if (workerSocket.Poll(1, SelectMode.SelectRead))
                {
                    byte[] temp = new byte[1024];
                    int nRead = workerSocket.Receive(temp);
                    if (nRead == 0)
                    {
                        throw new SocketException(10054);
                    }
                }

                //byte[] byData = System.Text.Encoding.ASCII.GetBytes(szData);
                //workerSocket.Send(byData);
                WaitForData(socketData.m_currentSocket, socketData.m_clientNumber);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054)
                {
                    string msg = socketData.string_RemoteEndPoint.ToString() + " Disconnected";
                    AppendToRichEditControl(msg);
                    m_workerSocketList[socketData.m_clientNumber - 1] = null;
                    UpdateClientListControl();
                }
                else
                {
                    MessageBox.Show(se.Message);
                }
            }
        }

        private void AppendToRichEditControl(string msg)
        {

            if (InvokeRequired)
            {
                object[] pList = { msg };
                listBox_RecMsg.BeginInvoke(new UpdateRichEditCallback(OnUpdateRichEdit), pList);
            }
            else
            {
                OnUpdateRichEdit(msg);
            }
        }

        private void OnUpdateRichEdit(string msg)
        {
            if (msg.Length > 20)
            {
                listBox_RecMsg.Items.Add(msg);
            }
        }

        void UpdateClientList()
        {
            try
            {
                ConnectedType.Text = "未连接";
                for (int i = 0; i < m_workerSocketList.Count; i++)
                {
                    Socket workerSocket = (Socket)m_workerSocketList[i];
                    if (workerSocket != null)
                    {
                        if (workerSocket.Connected)
                        {
                            ConnectedType.Text = "已连接";
                        }
                        else
                        {
                            workerSocket.Close();
                            workerSocket = null;
                        }
                    }
                }
            }
            catch (System.Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = textBox3.Text;
            if (message.Length > 0)
            {
                byte[] buff = System.Text.ASCIIEncoding.UTF8.GetBytes(message);

                for (int i = 0; i < m_workerSocketList.Count; i++)
                {
                    Socket workerSocket = (Socket)m_workerSocketList[i];
                    if (workerSocket != null)
                    {
                        workerSocket.Send(buff);
                        listBox_RecMsg.Items.Add(workerSocket.RemoteEndPoint.ToString() + ":" + message);
                    }
                }
            }
        }
    }
}
