using System;
using System.Windows.Forms;

namespace TCPAndUDPTestTools
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }
        
        //检查是否存在当前窗口，私有方法
        private Boolean ckChildFrm(string frmName)
        {
            foreach (Form childFrm in this.MdiChildren)
            {
                if (childFrm.Name == frmName)
                {
                    if (childFrm.WindowState == FormWindowState.Minimized)
                    {
                        childFrm.WindowState = FormWindowState.Normal;
                    }
                    childFrm.Activate();
                    return true;
                }
            }
            return false;
        }

        private void TCP_IPv4_Server_Click(object sender, EventArgs e)
        {
            TCP_IPv4_Server_Page frm = new TCP_IPv4_Server_Page();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TCP_IPv4_Client_Click(object sender, EventArgs e)
        {
            TCP_IPv4_Client_Page frm = new TCP_IPv4_Client_Page();
            frm.MdiParent = this;
            frm.Show();
        }

        private void UDP_IPv4_Server_Click(object sender, EventArgs e)
        {
            UDP_IPv4_Server_Page frm = new UDP_IPv4_Server_Page();
            frm.MdiParent = this;
            frm.Show();
        }

        private void UDP_IPv4_Client_Click(object sender, EventArgs e)
        {
            UDP_IPv4_Client_Page frm = new UDP_IPv4_Client_Page();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TCP_IPv6_Server_Click(object sender, EventArgs e)
        {
            TCP_IPv6_Server_Page frm = new TCP_IPv6_Server_Page();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TCP_IPv6_Client_Click(object sender, EventArgs e)
        {
            TCP_IPv6_Client_Page frm = new TCP_IPv6_Client_Page();
            frm.MdiParent = this;
            frm.Show();
        }

        private void UDP_IPv6_Server_Click(object sender, EventArgs e)
        {
            UDP_IPv6_Server_Page frm = new UDP_IPv6_Server_Page();
            frm.MdiParent = this;
            frm.Show();
        }

        private void UDP_IPv6_Client_Click(object sender, EventArgs e)
        {
            UDP_IPv6_Client_Page frm = new UDP_IPv6_Client_Page();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
