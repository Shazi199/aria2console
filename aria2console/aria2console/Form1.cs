using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aria2console
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Process process;

        private void button1_Click(object sender, EventArgs e)
        {
            startProcess();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopProcess();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopProcess();
        }

        public void startProcess()
        {
            if (process == null || process.HasExited)
            {
                process = new Process();
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "aria2c.exe";

                info.Arguments = "--conf-path=aria2.conf";
                info.UseShellExecute = false;
                info.RedirectStandardInput = false;
                info.RedirectStandardOutput = false;
                info.CreateNoWindow = true;
                process.StartInfo = info;

                try
                {
                    process.Start();
                    notifyIcon1.Text = "aria2已启动";
                }
                catch
                {
                    process = null;
                }
            }
        }

        private void stopProcess()
        {
            if (process != null && !process.HasExited)
            {
                process.Kill();
                notifyIcon1.Text = "aria2已停止";
            }
        }

        private void 启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startProcess();
        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopProcess();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopProcess();
            Application.Exit();
        }

        private void 启动WEBUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://aria2c.com/");
        }
    }
}
