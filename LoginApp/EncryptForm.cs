using DPFP;
using DPFP.Capture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginApp
{
    public partial class EncryptForm :Form, DPFP.Capture.EventHandler
    {
        private DPFP.Template Template;
        DPFP.Template template;
        string username = "", password = "";
        public EncryptForm(string u,string p)
        {
            username = u;
            password = p;
            InitializeComponent();
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fingerprint Template File (*.fpt)|*.fpt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Open(open.FileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    template = new DPFP.Template(fs);
                    template.Serialize(fs);
                    fs.Position = 0;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes(template.Bytes.Length);
                    textBox3.Text = String.Join("", Array.ConvertAll(bytes, byteValue => byteValue.ToString()));
                    File.WriteAllText("D:\\t.txt", textBox3.Text);
                    OnTemplate(template);
                    fs.Close();
                    
                }
            }
            

        }
     
        private void OnTemplate(DPFP.Template template)
        {

            Template = template;

            if (Template != null)
                MessageBox.Show("THE FINGERPRINT TEMPLATE IS READY FOR ENCRYPTION", "Message");
            else
                MessageBox.Show("LOAD ERROR", "Error");

        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            throw new NotImplementedException();
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            throw new NotImplementedException();
        }

        private void Encrypt_Button_Click(object sender, EventArgs e)
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            PythonScript obj = new PythonScript();
            string text=obj.run_algo("encrypt", "w7jDuMOrJgRPwq0pJlJBw6wjw4oUwoTDn2RAwoTChMOfwqPChA==",  "D:\\t.txt");
            watch.Stop();
            label2.Text = "Encryption Time :" + (float)watch.ElapsedMilliseconds/1000 + "secs";
            FileInfo fi = new FileInfo(@"C:\Users\davej\Desktop\m.fpt");
            label3.Text = "File Size : " + (float)fi.Length/1000 + "Kb";
            string encrypted_text = File.ReadAllText(@"D:\d.txt", Encoding.UTF8);
            byte[] b = Encoding.UTF8.GetBytes(encrypted_text);
            string base64 = Convert.ToBase64String(b);
            textBox2.Text = base64;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new Selection_Page(username, password)).Show();
            this.Close();
        }
    }
	
}
