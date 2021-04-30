
namespace LoginApp
{
    partial class Selection_Page
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fingerprintCapture_Button = new System.Windows.Forms.Button();
            this.fingerprintEncrypt_Button = new System.Windows.Forms.Button();
            this.Fingerprint = new System.Windows.Forms.Label();
            this.VerifyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fingerprintCapture_Button
            // 
            this.fingerprintCapture_Button.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fingerprintCapture_Button.Location = new System.Drawing.Point(90, 127);
            this.fingerprintCapture_Button.Name = "fingerprintCapture_Button";
            this.fingerprintCapture_Button.Size = new System.Drawing.Size(150, 76);
            this.fingerprintCapture_Button.TabIndex = 0;
            this.fingerprintCapture_Button.Text = "Capture/Upload";
            this.fingerprintCapture_Button.UseVisualStyleBackColor = true;
            this.fingerprintCapture_Button.Click += new System.EventHandler(this.fingerprintCapture_Button_Click);
            // 
            // fingerprintEncrypt_Button
            // 
            this.fingerprintEncrypt_Button.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fingerprintEncrypt_Button.Location = new System.Drawing.Point(292, 127);
            this.fingerprintEncrypt_Button.Name = "fingerprintEncrypt_Button";
            this.fingerprintEncrypt_Button.Size = new System.Drawing.Size(151, 79);
            this.fingerprintEncrypt_Button.TabIndex = 2;
            this.fingerprintEncrypt_Button.Text = "Encrypt/Decrypt";
            this.fingerprintEncrypt_Button.UseVisualStyleBackColor = true;
            this.fingerprintEncrypt_Button.Click += new System.EventHandler(this.fingerprintEncrypt_Button_Click);
            // 
            // Fingerprint
            // 
            this.Fingerprint.AutoSize = true;
            this.Fingerprint.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fingerprint.Location = new System.Drawing.Point(287, 71);
            this.Fingerprint.Name = "Fingerprint";
            this.Fingerprint.Size = new System.Drawing.Size(183, 28);
            this.Fingerprint.TabIndex = 3;
            this.Fingerprint.Text = "FINGERPRINT";
            // 
            // VerifyButton
            // 
            this.VerifyButton.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyButton.Location = new System.Drawing.Point(485, 127);
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.Size = new System.Drawing.Size(144, 79);
            this.VerifyButton.TabIndex = 7;
            this.VerifyButton.Text = "Verify";
            this.VerifyButton.UseVisualStyleBackColor = true;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // Selection_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(734, 291);
            this.Controls.Add(this.VerifyButton);
            this.Controls.Add(this.Fingerprint);
            this.Controls.Add(this.fingerprintEncrypt_Button);
            this.Controls.Add(this.fingerprintCapture_Button);
            this.Name = "Selection_Page";
            this.Text = "Selection Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fingerprintCapture_Button;
        private System.Windows.Forms.Button fingerprintEncrypt_Button;
        private System.Windows.Forms.Label Fingerprint;
        private System.Windows.Forms.Button VerifyButton;
    }
}