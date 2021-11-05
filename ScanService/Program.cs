using System;
using System.Diagnostics;

namespace ScanService
{
    class Program
    {
        static void Main(string[] args)
        {
            string strr = "\n";
            do
            {
                strr = Console.ReadLine();
                string[] strs = strr.Split(' ');
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    string path = Environment.CurrentDirectory;
                    string[] s = path.Split(@"\");
                    string add = s[^1];
                    string full = @"../../../..\scan_util\bin\Debug\" + add + @"\scan_util";
                    myProcess.StartInfo.FileName = full;
                    Console.WriteLine(full);
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.Arguments = strs[2];
                    myProcess.StartInfo.RedirectStandardOutput = true;
                    myProcess.Start();
                    Console.WriteLine(myProcess.StandardOutput.ReadToEnd());
                    myProcess.WaitForExit();
                }
            } while (strr != "\n");
        }
    }
}
