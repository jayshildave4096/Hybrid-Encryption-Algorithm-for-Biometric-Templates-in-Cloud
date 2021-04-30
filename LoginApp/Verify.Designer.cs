
namespace LoginApp
{
    partial class Verify
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.Back_Button = new System.Windows.Forms.Button();
            this.FileLoadButton = new System.Windows.Forms.Button();
            this.Capture_Button = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.FARTextBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(261, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load From DataBase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID*";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // StatusText
            // 
            this.StatusText.Location = new System.Drawing.Point(261, 54);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(489, 335);
            this.StatusText.TabIndex = 3;
            // 
            // Back_Button
            // 
            this.Back_Button.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back_Button.Location = new System.Drawing.Point(662, 395);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(74, 37);
            this.Back_Button.TabIndex = 4;
            this.Back_Button.Text = "Back";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // FileLoadButton
            // 
            this.FileLoadButton.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLoadButton.Location = new System.Drawing.Point(467, 15);
            this.FileLoadButton.Name = "FileLoadButton";
            this.FileLoadButton.Size = new System.Drawing.Size(201, 36);
            this.FileLoadButton.TabIndex = 5;
            this.FileLoadButton.Text = "Load From Computer";
            this.FileLoadButton.UseVisualStyleBackColor = true;
            this.FileLoadButton.Click += new System.EventHandler(this.FileLoadButton_Click);
            // 
            // Capture_Button
            // 
            this.Capture_Button.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Capture_Button.Location = new System.Drawing.Point(261, 395);
            this.Capture_Button.Name = "Capture_Button";
            this.Capture_Button.Size = new System.Drawing.Size(115, 36);
            this.Capture_Button.TabIndex = 6;
            this.Capture_Button.Text = "Capture";
            this.Capture_Button.UseVisualStyleBackColor = true;
            this.Capture_Button.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(16, 46);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(230, 385);
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // FARTextBox
            // 
            this.FARTextBox.AutoSize = true;
            this.FARTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FARTextBox.Location = new System.Drawing.Point(389, 405);
            this.FARTextBox.Name = "FARTextBox";
            this.FARTextBox.Size = new System.Drawing.Size(47, 20);
            this.FARTextBox.TabIndex = 8;
            this.FARTextBox.Text = "FAR:";
            // 
            // Verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FARTextBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.Capture_Button);
            this.Controls.Add(this.FileLoadButton);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Verify";
            this.Text = "Verify";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Button FileLoadButton;
        private System.Windows.Forms.Button Capture_Button;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label FARTextBox;
    }
}