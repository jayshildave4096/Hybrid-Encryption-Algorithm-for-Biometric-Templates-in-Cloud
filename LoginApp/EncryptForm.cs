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
        public EncryptForm()
        {
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
                    encrpyt_Box.Text = String.Join("", Array.ConvertAll(bytes, byteValue => byteValue.ToString()));
                    File.WriteAllText("D:\\t.txt", encrpyt_Box.Text);
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
            String FolderPath=String.Empty;
            FolderBrowserDialog fb = new FolderBrowserDialog();

            if (fb.ShowDialog() == DialogResult.OK)
                FolderPath = fb.SelectedPath;
            
            PythonScript obj = new PythonScript();
            string text=obj.run_algo("encrypt", "w7jDuMOrJgRPwq0pJlJBw6wjw4oUwoTDn2RAwoTChMOfwqPChA==",  "D:\\t.txt");
            // Console.WriteLine(text);
            //string d = obj.run_algo("decrypt", "w7jDuMOrJgRPwq0pJlJBw6wjw4oUwoTDn2RAwoTChMOfwqPChA==", text);
            //Console.WriteLine(encrpyt_Box.Text == d);
            Console.WriteLine(encrpyt_Box.Text.Length);
            string allText = File.ReadAllText(@"D:\d.txt", Encoding.UTF8);
           
            Console.WriteLine(allText.Length);
        }
    }
	
}
