﻿
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
            this.Face = new System.Windows.Forms.Label();
            this.faceCapture_Button = new System.Windows.Forms.Button();
            this.faceEncrypt_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fingerprintCapture_Button
            // 
            this.fingerprintCapture_Button.Location = new System.Drawing.Point(188, 133);
            this.fingerprintCapture_Button.Name = "fingerprintCapture_Button";
            this.fingerprintCapture_Button.Size = new System.Drawing.Size(150, 76);
            this.fingerprintCapture_Button.TabIndex = 0;
            this.fingerprintCapture_Button.Text = "Capture/Upload";
            this.fingerprintCapture_Button.UseVisualStyleBackColor = true;
            this.fingerprintCapture_Button.Click += new System.EventHandler(this.fingerprintCapture_Button_Click);
            // 
            // fingerprintEncrypt_Button
            // 
            this.fingerprintEncrypt_Button.Location = new System.Drawing.Point(436, 130);
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
            this.Fingerprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fingerprint.Location = new System.Drawing.Point(287, 71);
            this.Fingerprint.Name = "Fingerprint";
            this.Fingerprint.Size = new System.Drawing.Size(187, 29);
            this.Fingerprint.TabIndex = 3;
            this.Fingerprint.Text = "FINGERPRINT";
            // 
            // Face
            // 
            this.Face.AutoSize = true;
            this.Face.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Face.Location = new System.Drawing.Point(339, 251);
            this.Face.Name = "Face";
            this.Face.Size = new System.Drawing.Size(80, 29);
            this.Face.TabIndex = 4;
            this.Face.Text = "FACE";
            // 
            // faceCapture_Button
            // 
            this.faceCapture_Button.Location = new System.Drawing.Point(188, 310);
            this.faceCapture_Button.Name = "faceCapture_Button";
            this.faceCapture_Button.Size = new System.Drawing.Size(150, 76);
            this.faceCapture_Button.TabIndex = 5;
            this.faceCapture_Button.Text = "Capture/Upload";
            this.faceCapture_Button.UseVisualStyleBackColor = true;
            this.faceCapture_Button.Click += new System.EventHandler(this.faceCapture_Button_Click);
            // 
            // faceEncrypt_Button
            // 
            this.faceEncrypt_Button.Location = new System.Drawing.Point(436, 310);
            this.faceEncrypt_Button.Name = "faceEncrypt_Button";
            this.faceEncrypt_Button.Size = new System.Drawing.Size(151, 76);
            this.faceEncrypt_Button.TabIndex = 6;
            this.faceEncrypt_Button.Text = "Encrypt/Decrypt";
            this.faceEncrypt_Button.UseVisualStyleBackColor = true;
            this.faceEncrypt_Button.Click += new System.EventHandler(this.faceEncrypt_Button_Click);
            // 
            // Selection_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 499);
            this.Controls.Add(this.faceEncrypt_Button);
            this.Controls.Add(this.faceCapture_Button);
            this.Controls.Add(this.Face);
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
        private System.Windows.Forms.Label Face;
        private System.Windows.Forms.Button faceCapture_Button;
        private System.Windows.Forms.Button faceEncrypt_Button;
    }
}