﻿namespace Inventory.UI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_userID = new System.Windows.Forms.TextBox();
            this.TextBox_secCode = new System.Windows.Forms.MaskedTextBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Security Code";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "User ID";
            // 
            // textBox_userID
            // 
            this.textBox_userID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_userID.Location = new System.Drawing.Point(112, 20);
            this.textBox_userID.Name = "textBox_userID";
            this.textBox_userID.Size = new System.Drawing.Size(159, 20);
            this.textBox_userID.TabIndex = 6;
            // 
            // TextBox_secCode
            // 
            this.TextBox_secCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBox_secCode.Location = new System.Drawing.Point(112, 60);
            this.TextBox_secCode.Name = "TextBox_secCode";
            this.TextBox_secCode.PasswordChar = '*';
            this.TextBox_secCode.Size = new System.Drawing.Size(159, 20);
            this.TextBox_secCode.TabIndex = 7;
            // 
            // button_Login
            // 
            this.button_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Login.BackgroundImage")));
            this.button_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Login.Location = new System.Drawing.Point(94, 94);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(97, 30);
            this.button_Login.TabIndex = 8;
            this.button_Login.Text = "Login";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 136);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_userID);
            this.Controls.Add(this.TextBox_secCode);
            this.Controls.Add(this.button_Login);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_userID;
        private System.Windows.Forms.MaskedTextBox TextBox_secCode;
        private System.Windows.Forms.Button button_Login;
    }
}