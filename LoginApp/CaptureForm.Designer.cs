
namespace LoginApp
{
    partial class CaptureForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.FeatureRequiredText = new System.Windows.Forms.Label();
            this.Back_Button = new System.Windows.Forms.Button();
            this.Upload_Button = new System.Windows.Forms.Button();
            this.ID_Label = new System.Windows.Forms.Label();
            this.ID_Textbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(37, 47);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(292, 385);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // StatusText
            // 
            this.StatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusText.Location = new System.Drawing.Point(349, 77);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusText.Size = new System.Drawing.Size(682, 355);
            this.StatusText.TabIndex = 4;
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(349, 34);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(80, 36);
            this.captureButton.TabIndex = 5;
            this.captureButton.Text = "Capture";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(449, 34);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(81, 36);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FeatureRequiredText
            // 
            this.FeatureRequiredText.AutoSize = true;
            this.FeatureRequiredText.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.FeatureRequiredText.Location = new System.Drawing.Point(855, 57);
            this.FeatureRequiredText.Name = "FeatureRequiredText";
            this.FeatureRequiredText.Size = new System.Drawing.Size(133, 17);
            this.FeatureRequiredText.TabIndex = 7;
            this.FeatureRequiredText.Text = "Features required : ";
            // 
            // Back_Button
            // 
            this.Back_Button.Location = new System.Drawing.Point(965, 488);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(99, 41);
            this.Back_Button.TabIndex = 8;
            this.Back_Button.Text = "Back";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // Upload_Button
            // 
            this.Upload_Button.Enabled = false;
            this.Upload_Button.Location = new System.Drawing.Point(551, 34);
            this.Upload_Button.Name = "Upload_Button";
            this.Upload_Button.Size = new System.Drawing.Size(153, 36);
            this.Upload_Button.TabIndex = 9;
            this.Upload_Button.Text = "Upload To Cloud";
            this.Upload_Button.UseVisualStyleBackColor = true;
            this.Upload_Button.Click += new System.EventHandler(this.Upload_Button_Click);
            // 
            // ID_Label
            // 
            this.ID_Label.AutoSize = true;
            this.ID_Label.Location = new System.Drawing.Point(349, 444);
            this.ID_Label.Name = "ID_Label";
            this.ID_Label.Size = new System.Drawing.Size(21, 17);
            this.ID_Label.TabIndex = 10;
            this.ID_Label.Text = "ID";
            // 
            // ID_Textbox
            // 
            this.ID_Textbox.Location = new System.Drawing.Point(376, 444);
            this.ID_Textbox.Name = "ID_Textbox";
            this.ID_Textbox.Size = new System.Drawing.Size(126, 22);
            this.ID_Textbox.TabIndex = 11;
            this.ID_Textbox.TextChanged += new System.EventHandler(this.ID_Textbox_TextChanged);
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 551);
            this.Controls.Add(this.ID_Textbox);
            this.Controls.Add(this.ID_Label);
            this.Controls.Add(this.Upload_Button);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.FeatureRequiredText);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.pictureBox);
            this.Name = "CaptureForm";
            this.Text = "Capture";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label FeatureRequiredText;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Button Upload_Button;
        private System.Windows.Forms.Label ID_Label;
        private System.Windows.Forms.TextBox ID_Textbox;
    }
}