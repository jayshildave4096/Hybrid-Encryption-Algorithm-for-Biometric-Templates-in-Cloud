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

        public Capture Capturer { get; private set; } = new Capture();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Enroller = new DPFP.Processing.Enrollment();
            StatusText.AppendText("The fingerprint reader was disconnected." + "\r\n");
            

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
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
        }
        delegate void SetTextCallback(string text);
        #region EVENT HANDLERS

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
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
        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            /*if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                StatusText.AppendText("The quality of the fingerprint sample is good." + "\r\n");
            else
                StatusText.AppendText("The quality of the fingerprint sample is poor." + "\r\n");*/
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
            Bitmap bImage = bitmap;  // Your Bitmap Image
            System.IO.MemoryStream ms = new MemoryStream();
            bImage.Save(ms, ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage);
            SetText(SigBase64);

            pictureBox.Image = new Bitmap(bitmap, pictureBox.Size);   // fit the image into the picture box

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

        private void saveButton_Click(object sender, EventArgs e)
        {
           
            if (Enroller.FeaturesNeeded > 0)
                MessageBox.Show("MORE FEATURES NEEDED " + Enroller.FeaturesNeeded.ToString());
            else
                MessageBox.Show("Done");
               
           
        }
        private DPFP.Processing.Enrollment Enroller;
    }
}
