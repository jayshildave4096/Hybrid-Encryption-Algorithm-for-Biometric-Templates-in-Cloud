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
            string fileName = @"C:\Users\davej\Desktop\rc4.py";

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
    }
}
