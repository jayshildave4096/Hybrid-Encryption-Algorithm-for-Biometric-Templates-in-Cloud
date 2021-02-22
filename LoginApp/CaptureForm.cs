using DPFP.Capture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class CaptureForm : Form, DPFP.Capture.EventHandler

    {
       
        public CaptureForm()
        {
            InitializeComponent();
        }
        delegate void SetTextCallback(string text);
        delegate void UpdateStatusCallback(string text);
        delegate void UpdateSaveButtonCallback(bool t);
        public Capture Capturer { get; private set; } = new Capture();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Enroller = new DPFP.Processing.Enrollment();
            saveButton.Enabled = false;
            StatusText.AppendText("The fingerprint reader was disconnected." + "\r\n");
            FeatureRequiredText.Text = "Captures Required:" + Enroller.FeaturesNeeded;
        }
       
        public void Enroll()
        {
            Capturer.EventHandler = this;
            Capturer.StartCapture();
        }
        public void captureButton_Click(object sender, EventArgs e)
        {
            StatusText.Text = "";
            Enroll();
        }

       

        protected virtual void Process(DPFP.Sample Sample)
        {
            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            if (features != null) try
                {
                    SetText("The fingerprint feature set was created.");
                    Enroller.AddFeatures(features);     // Add feature set to template.
                }
                finally
                {
                    UpdateStatus("Captures Required: "+ Enroller.FeaturesNeeded);

                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            if (Enroller.Template == null) { }
                            else {OnTemplate(Enroller.Template); }// report success and stop capturing
                            
                            SetText("Capture complete...Template generated");
                            UpdateSaveButton(true);
                            if (null != Capturer)
                            {
                                try
                                {
                                    Capturer.StopCapture();
                                }
                                catch
                                {
                                    SetText("Can't terminate capture!");
                                }
                            }
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            if (null != Capturer)
                            {
                                try
                                {
                                    Capturer.StopCapture();
                                }
                                catch
                                {
                                    SetText("Can't terminate capture!");
                                }
                            }
                            UpdateStatus("Captures Required: " + Enroller.FeaturesNeeded);
                            OnTemplate(null);
                            if (null != Capturer)
                            {
                                try
                                {
                                    Capturer.StartCapture();
                                    SetText("Using the fingerprint reader, scan your fingerprint.");
                                }
                                catch
                                {
                                    SetText("Can't initiate capture!");
                                }
                            } 
                            break;
                    }
                }
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
        }
      
        #region EVENT HANDLERS

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            ((Capture)Capturer).StopCapture();
            UpdateStatus("Captures Required: " + Enroller.FeaturesNeeded);
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
        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                SetText("The quality of the fingerprint sample is good." + "\r\n");
            else
                SetText("The quality of the fingerprint sample is poor." + "\r\n");
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Fingerprint Template File (*.fpt)|*.fpt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Open(save.FileName, FileMode.Create, FileAccess.Write))
                {
                    Template.Serialize(fs);
                }
            }
            pictureBox.Image = null;
            SetText("TEMPLATE SAVED.\n Click BACK and got to Encrypt/Decrypt");

        }
        private void Back_Button_Click(object sender, EventArgs e)
        {
            (new Selection_Page()).Show();
            this.Close();
        }
        private void Upload_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fingerprint Template File (*.fpt)|*.fpt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.OpenRead(open.FileName))
                {
                    DPFP.Template template = new DPFP.Template(fs);
                    OnTemplate(template);
                }
            }
        }
        #endregion

        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap); // TODO: return bitmap as a result
            return bitmap;     
        }

        private void DrawPicture(Bitmap bitmap)
        {
            /*Bitmap bImage = bitmap;  // Your Bitmap Image
            System.IO.MemoryStream ms = new MemoryStream();
            bImage.Save(ms, ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage);
            SetText(SigBase64);*/
           
            
            //BinaryReader br = new BinaryReader(Template);
            //Byte[] bytes = br.ReadBytes((Int32)Enroller.Template.Bytes.Length);

            pictureBox.Image = new Bitmap(bitmap, pictureBox.Size);   // fit the image into the picture box
            //bitmap.Save(@"C:\Users\davej\Desktop\temp1.bmp");
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

        private void UpdateStatus(string text)
        {
            if (this.FeatureRequiredText.InvokeRequired)
            {
                UpdateStatusCallback d = new UpdateStatusCallback(UpdateStatus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.FeatureRequiredText.Text = text;
            }
        }

        private void UpdateSaveButton(bool t)
        {
            if (this.saveButton.InvokeRequired)
            {
                UpdateSaveButtonCallback d = new UpdateSaveButtonCallback(UpdateSaveButton);
                this.Invoke(d, new object[] { t });
            }
            else
            {
                this.saveButton.Enabled = t;
            }
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

        private void OnTemplate(DPFP.Template template)
        {
            
                Template = template;
                
                if (Template != null)
                    MessageBox.Show("THE FINGERPRINT TEMPLATE IS READY FOR VERFICATION", "Fingerprint Enrollment");
                else
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
          
        }
        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Template Template;

        
    }
}
