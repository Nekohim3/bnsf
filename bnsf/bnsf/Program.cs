using System;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace bnsf
{
    static class Program
    {
        private static string path = @"C:\Program Files (x86)\NCSOFT\BnS\contents\Local\NCWEST\data\";
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var th = new Thread(Thf);
            th.Start();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
        private static void Thf()
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
