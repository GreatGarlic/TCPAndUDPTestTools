namespace TCPAndUDPTestTools
{
    partial class HomePage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.UDP_IPv6_Client = new System.Windows.Forms.Button();
            this.TCP_IPv6_Client = new System.Windows.Forms.Button();
            this.TCP_IPv4_Client = new System.Windows.Forms.Button();
            this.UDP_IPv6_Server = new System.Windows.Forms.Button();
            this.UDP_IPv4_Server = new System.Windows.Forms.Button();
            this.TCP_IPv6_Server = new System.Windows.Forms.Button();
            this.UDP_IPv4_Client = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.TCP_IPv4_Server = new System.Windows.Forms.Button();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.UDP_IPv6_Client);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TCP_IPv6_Client);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TCP_IPv4_Client);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.UDP_IPv6_Server);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.UDP_IPv4_Server);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TCP_IPv6_Server);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.UDP_IPv4_Client);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TCP_IPv4_Server);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(76, 730);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(76, 730);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // UDP_IPv6_Client
            // 
            this.UDP_IPv6_Client.Location = new System.Drawing.Point(3, 486);
            this.UDP_IPv6_Client.Name = "UDP_IPv6_Client";
            this.UDP_IPv6_Client.Size = new System.Drawing.Size(68, 46);
            this.UDP_IPv6_Client.TabIndex = 8;
            this.UDP_IPv6_Client.Text = "UDP/IPv6客户端";
            this.UDP_IPv6_Client.UseVisualStyleBackColor = true;
            this.UDP_IPv6_Client.Click += new System.EventHandler(this.UDP_IPv6_Client_Click);
            // 
            // TCP_IPv6_Client
            // 
            this.TCP_IPv6_Client.Location = new System.Drawing.Point(3, 351);
            this.TCP_IPv6_Client.Name = "TCP_IPv6_Client";
            this.TCP_IPv6_Client.Size = new System.Drawing.Size(68, 46);
            this.TCP_IPv6_Client.TabIndex = 2;
            this.TCP_IPv6_Client.Text = "TCP/IPv6客户端";
            this.TCP_IPv6_Client.UseVisualStyleBackColor = true;
            this.TCP_IPv6_Client.Click += new System.EventHandler(this.TCP_IPv6_Client_Click);
            // 
            // TCP_IPv4_Client
            // 
            this.TCP_IPv4_Client.Location = new System.Drawing.Point(3, 64);
            this.TCP_IPv4_Client.Name = "TCP_IPv4_Client";
            this.TCP_IPv4_Client.Size = new System.Drawing.Size(68, 46);
            this.TCP_IPv4_Client.TabIndex = 0;
            this.TCP_IPv4_Client.Text = "TCP/IPv4客户端";
            this.TCP_IPv4_Client.UseVisualStyleBackColor = true;
            this.TCP_IPv4_Client.Click += new System.EventHandler(this.TCP_IPv4_Client_Click);
            // 
            // UDP_IPv6_Server
            // 
            this.UDP_IPv6_Server.Location = new System.Drawing.Point(3, 434);
            this.UDP_IPv6_Server.Name = "UDP_IPv6_Server";
            this.UDP_IPv6_Server.Size = new System.Drawing.Size(68, 46);
            this.UDP_IPv6_Server.TabIndex = 7;
            this.UDP_IPv6_Server.Text = "UDP/IPv6服务端";
            this.UDP_IPv6_Server.UseVisualStyleBackColor = true;
            this.UDP_IPv6_Server.Click += new System.EventHandler(this.UDP_IPv6_Server_Click);
            // 
            // UDP_IPv4_Server
            // 
            this.UDP_IPv4_Server.Location = new System.Drawing.Point(3, 137);
            this.UDP_IPv4_Server.Name = "UDP_IPv4_Server";
            this.UDP_IPv4_Server.Size = new System.Drawing.Size(68, 46);
            this.UDP_IPv4_Server.TabIndex = 6;
            this.UDP_IPv4_Server.Text = "UDP/IPv4服务端";
            this.UDP_IPv4_Server.UseVisualStyleBackColor = true;
            this.UDP_IPv4_Server.Click += new System.EventHandler(this.UDP_IPv4_Server_Click);
            // 
            // TCP_IPv6_Server
            // 
            this.TCP_IPv6_Server.Location = new System.Drawing.Point(3, 299);
            this.TCP_IPv6_Server.Name = "TCP_IPv6_Server";
            this.TCP_IPv6_Server.Size = new System.Drawing.Size(68, 46);
            this.TCP_IPv6_Server.TabIndex = 3;
            this.TCP_IPv6_Server.Text = "TCP/IPv6服务端";
            this.TCP_IPv6_Server.UseVisualStyleBackColor = true;
            this.TCP_IPv6_Server.Click += new System.EventHandler(this.TCP_IPv6_Server_Click);
            // 
            // UDP_IPv4_Client
            // 
            this.UDP_IPv4_Client.Location = new System.Drawing.Point(3, 189);
            this.UDP_IPv4_Client.Name = "UDP_IPv4_Client";
            this.UDP_IPv4_Client.Size = new System.Drawing.Size(68, 46);
            this.UDP_IPv4_Client.TabIndex = 5;
            this.UDP_IPv4_Client.Text = "UDP/IPv4客户端";
            this.UDP_IPv4_Client.UseVisualStyleBackColor = true;
            this.UDP_IPv4_Client.Click += new System.EventHandler(this.UDP_IPv4_Client_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 730);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // TCP_IPv4_Server
            // 
            this.TCP_IPv4_Server.Location = new System.Drawing.Point(3, 12);
            this.TCP_IPv4_Server.Name = "TCP_IPv4_Server";
            this.TCP_IPv4_Server.Size = new System.Drawing.Size(68, 46);
            this.TCP_IPv4_Server.TabIndex = 1;
            this.TCP_IPv4_Server.Text = "TCP/IPv4服务端";
            this.TCP_IPv4_Server.UseVisualStyleBackColor = true;
            this.TCP_IPv4_Server.Click += new System.EventHandler(this.TCP_IPv4_Server_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1120, 730);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通讯测试工具";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Button TCP_IPv4_Client;
        private System.Windows.Forms.Button TCP_IPv6_Server;
        private System.Windows.Forms.Button TCP_IPv6_Client;
        private System.Windows.Forms.Button TCP_IPv4_Server;
        private System.Windows.Forms.Button UDP_IPv6_Client;
        private System.Windows.Forms.Button UDP_IPv6_Server;
        private System.Windows.Forms.Button UDP_IPv4_Server;
        private System.Windows.Forms.Button UDP_IPv4_Client;
        private System.Windows.Forms.Splitter splitter1;

    }
}

