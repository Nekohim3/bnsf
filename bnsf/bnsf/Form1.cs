using System;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace bnsf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string path = @"C:\Program Files (x86)\NCSOFT\BnS\contents\Local\NCWEST\data\";
        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            var th = new Thread(Thf);
            th.Start();
        }
        private void Thf()
        {
            var pp = Process.GetProcessesByName("Client").Length;
            while (true)
            {
                var p = Process.GetProcessesByName("Client").Length;
                if (p == 1)
                {
                    if (pp == 0)
                        File.Copy($"{path}editing\\xml64m.dat", $"{path}xml64.dat", true);
                }
                else
                {
                    if (pp == 1)
                        File.Copy($"{path}editing\\xml64.dat", $"{path}xml64.dat", true);
                }
                pp = p;
                Thread.Sleep(1000);
            }

        }
    }
}
