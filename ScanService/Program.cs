using System;
using System.Diagnostics;
using System.IO;

namespace ScanService
{
    class Program
    {
        static void Main(string[] args)
        {
            string strr = "";
            int counter = 0;
            Console.WriteLine("Scan service was started.\nPress <Enter> to exit...");
            do
            {
                strr = Console.ReadLine();
                if (strr != String.Empty)
                {
                    string[] strs = strr.Split(' ');
                    using (Process myProcess = new Process())
                    {
                        try
                        {
                            myProcess.StartInfo.UseShellExecute = false;
                            string path = Environment.CurrentDirectory;
                            string[] s = path.Split(@"\");
                            string add = s[^1];
                            string full = @"../../../..\scan_util\bin\Debug\" + add + @"\" + strs[0];
                            myProcess.StartInfo.FileName = full;
                            myProcess.StartInfo.CreateNoWindow = true;
                            myProcess.StartInfo.RedirectStandardOutput = true;
                            myProcess.StartInfo.Arguments = strs[2];
                            myProcess.Start();
                            string result = myProcess.StandardOutput.ReadToEnd();
                            string file_path = counter.ToString();
                            counter++;
                            file_path = Path.Combine(file_path + ".txt");
                            if (!File.Exists(file_path))
                            {
                                // Create a file to write to.
                                using (StreamWriter sw = File.CreateText(file_path))
                                {
                                    sw.WriteLine(result);
                                }
                            }
                            myProcess.WaitForExit();
                        } 
                        catch(Exception)
                        {
                            Console.WriteLine("error with executed file");
                        }
                    }
                }
                else
                    break;
            } while (true);
        }
    }
}
