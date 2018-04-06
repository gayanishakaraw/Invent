namespace Inventory.UI
{
    partial class MainMenu
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
            this.button_Users = new System.Windows.Forms.Button();
            this.button_Company = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Users
            // 
            this.button_Users.Location = new System.Drawing.Point(399, 293);
            this.button_Users.Name = "button_Users";
            this.button_Users.Size = new System.Drawing.Size(96, 45);
            this.button_Users.TabIndex = 0;
            this.button_Users.Text = "Configurations";
            this.button_Users.UseVisualStyleBackColor = true;
            this.button_Users.Click += new System.EventHandler(this.button_Users_Click);
            // 
            // button_Company
            // 
            this.button_Company.Location = new System.Drawing.Point(12, 12);
            this.button_Company.Name = "button_Company";
            this.button_Company.Size = new System.Drawing.Size(92, 45);
            this.button_Company.TabIndex = 1;
            this.button_Company.Text = "Organisations";
            this.button_Company.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Organizations";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_Company);
            this.Controls.Add(this.button_Users);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Users;
        private System.Windows.Forms.Button button_Company;
        private System.Windows.Forms.Button button1;
    }
}