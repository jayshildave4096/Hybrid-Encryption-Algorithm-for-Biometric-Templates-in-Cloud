using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Selection_Page : Form
    {
        public Selection_Page()
        {
            InitializeComponent();
        }

        private void fingerprintCapture_Button_Click(object sender, EventArgs e)
        {
            (new CaptureForm()).Show();
            this.Close();

        }

        private void fingerprintEncrypt_Button_Click(object sender, EventArgs e)
        {
            (new EncryptForm()).Show();
            this.Close();
        }

        private void faceCapture_Button_Click(object sender, EventArgs e)
        {

        }

        private void faceEncrypt_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
