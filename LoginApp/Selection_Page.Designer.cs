
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
            this.Capture_Button = new System.Windows.Forms.Button();
            this.Verify_Button = new System.Windows.Forms.Button();
            this.Encrypt_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Capture_Button
            // 
            this.Capture_Button.Location = new System.Drawing.Point(102, 159);
            this.Capture_Button.Name = "Capture_Button";
            this.Capture_Button.Size = new System.Drawing.Size(150, 76);
            this.Capture_Button.TabIndex = 0;
            this.Capture_Button.Text = "Capture/Upload";
            this.Capture_Button.UseVisualStyleBackColor = true;
            // 
            // Verify_Button
            // 
            this.Verify_Button.Location = new System.Drawing.Point(487, 159);
            this.Verify_Button.Name = "Verify_Button";
            this.Verify_Button.Size = new System.Drawing.Size(144, 79);
            this.Verify_Button.TabIndex = 1;
            this.Verify_Button.Text = "Verify";
            this.Verify_Button.UseVisualStyleBackColor = true;
            // 
            // Encrypt_Button
            // 
            this.Encrypt_Button.Location = new System.Drawing.Point(300, 156);
            this.Encrypt_Button.Name = "Encrypt_Button";
            this.Encrypt_Button.Size = new System.Drawing.Size(151, 82);
            this.Encrypt_Button.TabIndex = 2;
            this.Encrypt_Button.Text = "Encrypt/Decrypt";
            this.Encrypt_Button.UseVisualStyleBackColor = true;
            // 
            // Selection_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Encrypt_Button);
            this.Controls.Add(this.Verify_Button);
            this.Controls.Add(this.Capture_Button);
            this.Name = "Selection_Page";
            this.Text = "Selection Page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Capture_Button;
        private System.Windows.Forms.Button Verify_Button;
        private System.Windows.Forms.Button Encrypt_Button;
    }
}