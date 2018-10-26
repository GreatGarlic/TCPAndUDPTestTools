namespace TCPAndUDPTestTools
{
    partial class TCP_IPv4_Client_Page
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCP_IPv4_Client_Page));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_SendMsg = new System.Windows.Forms.Button();
            this.textBox_SendMsg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_MSG = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // button_SendMsg
            // 
            this.button_SendMsg.Enabled = false;
            this.button_SendMsg.Location = new System.Drawing.Point(329, 363);
            this.button_SendMsg.Name = "button_SendMsg";
            this.button_SendMsg.Size = new System.Drawing.Size(75, 38);
            this.button_SendMsg.TabIndex = 12;
            this.button_SendMsg.Text = "发送";
            this.button_SendMsg.UseVisualStyleBackColor = true;
            this.button_SendMsg.Click += new System.EventHandler(this.button_SendMsg_Click);
            // 
            // textBox_SendMsg
            // 
            this.textBox_SendMsg.Location = new System.Drawing.Point(14, 363);
            this.textBox_SendMsg.Multiline = true;
            this.textBox_SendMsg.Name = "textBox_SendMsg";
            this.textBox_SendMsg.Size = new System.Drawing.Size(309, 38);
            this.textBox_SendMsg.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "目标端口：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(107, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(54, 21);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "9999";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "10.8.1.94";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "服务器IP(v4)：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "本地端口：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "自动分配"});
            this.comboBox1.Location = new System.Drawing.Point(238, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 20);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.Text = "自动分配";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(336, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "连接";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_MSG
            // 
            this.textBox_MSG.Location = new System.Drawing.Point(12, 71);
            this.textBox_MSG.Multiline = true;
            this.textBox_MSG.Name = "textBox_MSG";
            this.textBox_MSG.Size = new System.Drawing.Size(392, 286);
            this.textBox_MSG.TabIndex = 20;
            // 
            // TCP_IPv4_Client_Page
            // 
            this.AcceptButton = this.button_SendMsg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 413);
            this.Controls.Add(this.textBox_MSG);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_SendMsg);
            this.Controls.Add(this.textBox_SendMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TCP_IPv4_Client_Page";
            this.Text = "TCP/IPv4客户端";
            this.Load += new System.EventHandler(this.Client_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_SendMsg;
        private System.Windows.Forms.TextBox textBox_SendMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_MSG;
    }
}