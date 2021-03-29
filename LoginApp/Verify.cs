using DPFP;
using DPFP.Capture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace LoginApp
{
    public partial class Verify : Form, DPFP.Capture.EventHandler
    {
        //Initialisation
        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Template Template;
        
        
        private DPFP.Verification.Verification Verificator;
        string sqlquery = String.Empty, response = "";
        int ID;
        delegate void SetTextCallback(string text);
        delegate void UpdateStatusCallback(int FAR);
        SqlConnection conn;
        SqlCommand query;
        SqlDataReader dataReader;
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        string password = "";
        public Verify(string p)
        {
            password = p;
            InitializeComponent();
        }
        public Capture Capturer { get; private set; } = new Capture();
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Enroller = new DPFP.Processing.Enrollment();
            
            StatusText.AppendText("Load Template" + "\r\n");
            Verificator = new DPFP.Verification.Verification();


        }
        public void captureButton_Click(object sender, EventArgs e)
        {

            StatusText.Text = "";
            Enroll(); 

        }
        public void Enroll()
        {
            Capturer.EventHandler = this;
            Capturer.StartCapture();
        }
        protected virtual void Process(DPFP.Sample Sample)
        {
            

            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
            if (Template == null)
            {
                MessageBox.Show("empty template");
            }
            else
            {
                // Check quality of the sample and start verification if it's good
                // TODO: move to a separate task
                if (features != null)
                {
                    // Compare the feature set with our template
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, Template, ref result);
                    UpdateStatus(result.FARAchieved);
                    if (result.Verified)
                        SetText("The fingerprint was VERIFIED.");
                    else
                        SetText("The fingerprint was NOT VERIFIED.");
                    DrawPicture(ConvertSampleToBitmap(Sample));
                }
            }
        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap); // TODO: return bitmap as a result
            return bitmap;
        }
        private void DrawPicture(Bitmap bitmap)
        {
            pictureBox.Image = new Bitmap(bitmap, pictureBox.Size);   // fit the image into the picture box

        }
        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);            // TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            ((Capture)Capturer).StopCapture();
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            SetText("The finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            SetText("The fingerprint reader was touched.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            SetText("The fingerprint reader was connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            SetText("The fingerprint reader was disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                SetText("The quality of the fingerprint sample is good." + "\r\n");
            else
                SetText("The quality of the fingerprint sample is poor." + "\r\n");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ID = Int32.Parse(textBox1.Text);
        }
        private void UpdateStatus(int FAR)
        {
            if (this.FARTextBox.InvokeRequired)
            {
                UpdateStatusCallback d = new UpdateStatusCallback(UpdateStatus);
                this.Invoke(d, new object[] { FAR });
            }
            else
            {
                this.FARTextBox.Text = "FAR: " + FAR.ToString();
            }
        }
        private void SetText(string text)
        {
            if (this.StatusText.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.StatusText.AppendText(text + "\r\n");
            }
        }

        private void FileLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fingerprint Template File (*.fpt)|*.fpt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Open(open.FileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    Template = new DPFP.Template(fs);
                    Template.Serialize(fs);
                    fs.Position = 0;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes(Template.Bytes.Length);
                    OnTemplate(Template);
                    fs.Close();

                }
            }
        }
        private void OnTemplate(DPFP.Template template)
        {

            Template = template;

            if (Template != null)
               SetText("THE FINGERPRINT TEMPLATE IS READY FOR VERIFITCATION");
            else
               SetText("LOAD ERROR");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter ID to load from Database");
            }
            else {
                conn = new SqlConnection();
                conn.ConnectionString = "Data Source=database-3.cjdjsdhihrxl.us-east-1.rds.amazonaws.com,1433;Initial Catalog=UserDetails;User ID=Jayshil;Password=yjayshil";
                conn.Open();
                
                                

                Console.WriteLine(password);
                sqlquery = $"select * from Templates where secretkey='{password}' and ID={ID}";
                query = new SqlCommand(sqlquery, conn);
                dataReader = query.ExecuteReader();
                string[] values = new string[12];
                while (dataReader.Read())
                {
                    byte[] b;
                    for (int i = 2; i < 10; i++)
                    {
                        b = Convert.FromBase64String(dataReader.GetValue(i).ToString().Replace("\n", ""));
                        values[i] = System.Text.Encoding.UTF8.GetString(b);
                    }
                    b = Convert.FromBase64String(dataReader.GetValue(0).ToString());
                    values[0] = System.Text.Encoding.UTF8.GetString(b);
                    values[1] = dataReader.GetValue(1).ToString();
                    values[11] = dataReader.GetValue(11).ToString();

                }
                dataReader.Close();
                query.Dispose();
                conn.Close();
                string[] keys = { values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9] };
                string decrypted_text = File.ReadAllText("D:\\my.txt", Encoding.UTF8);
                byte[] bytes = Encoding.UTF8.GetBytes(decrypted_text);
                

                Template = new DPFP.Template();
                Template.DeSerialize(bytes);
                
                SetText("Template Loaded, Click Capture to Verify");
            }
            
            
            
            
        }
    }
}
