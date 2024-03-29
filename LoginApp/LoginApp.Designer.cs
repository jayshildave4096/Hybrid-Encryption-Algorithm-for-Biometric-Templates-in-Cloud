﻿
namespace LoginApp
{
    partial class LoginApp
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
            this.Login_Button = new System.Windows.Forms.Button();
            this.Register_Button = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.AWS_Button = new System.Windows.Forms.RadioButton();
            this.GCP_Button = new System.Windows.Forms.RadioButton();
            this.Username_TxtBox = new System.Windows.Forms.TextBox();
            this.Password_TxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Login_Button
            // 
            this.Login_Button.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Button.ForeColor = System.Drawing.Color.Black;
            this.Login_Button.Location = new System.Drawing.Point(187, 274);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(121, 31);
            this.Login_Button.TabIndex = 0;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Register_Button
            // 
            this.Register_Button.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_Button.Location = new System.Drawing.Point(364, 274);
            this.Register_Button.Name = "Register_Button";
            this.Register_Button.Size = new System.Drawing.Size(116, 31);
            this.Register_Button.TabIndex = 1;
            this.Register_Button.Text = "Register";
            this.Register_Button.UseVisualStyleBackColor = true;
            this.Register_Button.Click += new System.EventHandler(this.Register_Button_Click);
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(166, 125);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(102, 24);
            this.Username.TabIndex = 2;
            this.Username.Text = "Username";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(166, 168);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(96, 24);
            this.Password.TabIndex = 3;
            this.Password.Text = "Password";
            // 
            // AWS_Button
            // 
            this.AWS_Button.AutoSize = true;
            this.AWS_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AWS_Button.Location = new System.Drawing.Point(245, 224);
            this.AWS_Button.Name = "AWS_Button";
            this.AWS_Button.Size = new System.Drawing.Size(63, 22);
            this.AWS_Button.TabIndex = 4;
            this.AWS_Button.TabStop = true;
            this.AWS_Button.Text = "AWS";
            this.AWS_Button.UseVisualStyleBackColor = true;
            // 
            // GCP_Button
            // 
            this.GCP_Button.AutoSize = true;
            this.GCP_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GCP_Button.Location = new System.Drawing.Point(350, 224);
            this.GCP_Button.Name = "GCP_Button";
            this.GCP_Button.Size = new System.Drawing.Size(62, 22);
            this.GCP_Button.TabIndex = 5;
            this.GCP_Button.TabStop = true;
            this.GCP_Button.Text = "GCP";
            this.GCP_Button.UseVisualStyleBackColor = true;
            // 
            // Username_TxtBox
            // 
            this.Username_TxtBox.BackColor = System.Drawing.SystemColors.Info;
            this.Username_TxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Username_TxtBox.Location = new System.Drawing.Point(279, 128);
            this.Username_TxtBox.Name = "Username_TxtBox";
            this.Username_TxtBox.Size = new System.Drawing.Size(201, 22);
            this.Username_TxtBox.TabIndex = 7;
            // 
            // Password_TxtBox
            // 
            this.Password_TxtBox.BackColor = System.Drawing.SystemColors.Info;
            this.Password_TxtBox.Location = new System.Drawing.Point(279, 171);
            this.Password_TxtBox.Name = "Password_TxtBox";
            this.Password_TxtBox.Size = new System.Drawing.Size(201, 22);
            this.Password_TxtBox.TabIndex = 8;
            // 
            // LoginApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(669, 393);
            this.Controls.Add(this.Password_TxtBox);
            this.Controls.Add(this.Username_TxtBox);
            this.Controls.Add(this.GCP_Button);
            this.Controls.Add(this.AWS_Button);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.Register_Button);
            this.Controls.Add(this.Login_Button);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginApp";
            this.Text = "LoginApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Button Register_Button;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.RadioButton AWS_Button;
        private System.Windows.Forms.RadioButton GCP_Button;
        private System.Windows.Forms.TextBox Username_TxtBox;
        private System.Windows.Forms.TextBox Password_TxtBox;
    }
}

