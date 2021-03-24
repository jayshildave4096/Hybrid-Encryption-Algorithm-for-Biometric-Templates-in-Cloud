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
        string user;
        public Selection_Page(string username)
        {
            user = username;
            InitializeComponent();
            
        }
        
        
        private void fingerprintCapture_Button_Click(object sender, EventArgs e)
        {
            (new CaptureForm(user)).Show();
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

        public void VerifyButton_Click(object sender, EventArgs e)
        {
            //PythonScript obj = new PythonScript();
            //obj.run_cmd();
        }
    }
}
