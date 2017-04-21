using System;
using System.Threading;
using System.Diagnostics;
using System.IO;
namespace bnsf
{
    internal static class Program
    {
        private const string Path = @"C:\Program Files (x86)\NCSOFT\BnS\contents\Local\NCWEST\data\";

        [STAThread]
        private static void Main()
        {
            new Thread(Thf).Start();
        }
        private static void Thf()
        {
            var pp = Process.GetProcessesByName("Client").Length;
            while (true)
            {
                var p = Process.GetProcessesByName("Client").Length;
                if(p == 1 && pp == 0)
                        File.Copy($"{Path}editing\\xml64m.dat", $"{Path}xml64.dat", true);
                if (p == 0 && pp == 1)
                        File.Copy($"{Path}editing\\xml64.dat", $"{Path}xml64.dat", true);
                pp = p;
                Thread.Sleep(1000);
            }

        }
    }
}
