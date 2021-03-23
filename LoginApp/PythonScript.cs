using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp
{
    class PythonScript : Selection_Page
    {
        public string run_rc4(string op,string password,string key)
        {
            string fileName = @"D:\work\Code\MajorProject\rc4.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"D:\ProgramData\python.exe", string.Format("{0} {1} {2} {3}", fileName, op, password, key))
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                
        };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            
            return output;

            
        }

        public string run_algo(string op, string key, string path)
        {
            string fileName = @"C:\Users\davej\Desktop\my.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"D:\ProgramData\python.exe", string.Format("{0} {1} {2} {3}", fileName, op, key, path))
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,

            };
            p.Start();
            
            string  output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            
            return output;

        }
    }
}
