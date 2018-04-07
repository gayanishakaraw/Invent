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
            this.button_Inventory = new System.Windows.Forms.Button();
            this.button_Invoice = new System.Windows.Forms.Button();
            this.button_Reports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Users
            // 
            this.button_Users.Location = new System.Drawing.Point(301, 195);
            this.button_Users.Name = "button_Users";
            this.button_Users.Size = new System.Drawing.Size(96, 33);
            this.button_Users.TabIndex = 0;
            this.button_Users.Text = "Configurations";
            this.button_Users.UseVisualStyleBackColor = true;
            this.button_Users.Click += new System.EventHandler(this.button_Users_Click);
            // 
            // button_Inventory
            // 
            this.button_Inventory.Location = new System.Drawing.Point(12, 12);
            this.button_Inventory.Name = "button_Inventory";
            this.button_Inventory.Size = new System.Drawing.Size(92, 45);
            this.button_Inventory.TabIndex = 1;
            this.button_Inventory.Text = "Inventory";
            this.button_Inventory.UseVisualStyleBackColor = true;
            // 
            // button_Invoice
            // 
            this.button_Invoice.Location = new System.Drawing.Point(110, 12);
            this.button_Invoice.Name = "button_Invoice";
            this.button_Invoice.Size = new System.Drawing.Size(189, 45);
            this.button_Invoice.TabIndex = 2;
            this.button_Invoice.Text = "Invoice | Sales";
            this.button_Invoice.UseVisualStyleBackColor = true;
            this.button_Invoice.Click += new System.EventHandler(this.button_Invoice_Click);
            // 
            // button_Reports
            // 
            this.button_Reports.Location = new System.Drawing.Point(305, 12);
            this.button_Reports.Name = "button_Reports";
            this.button_Reports.Size = new System.Drawing.Size(92, 45);
            this.button_Reports.TabIndex = 4;
            this.button_Reports.Text = "Reports";
            this.button_Reports.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 242);
            this.Controls.Add(this.button_Reports);
            this.Controls.Add(this.button_Invoice);
            this.Controls.Add(this.button_Inventory);
            this.Controls.Add(this.button_Users);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Users;
        private System.Windows.Forms.Button button_Inventory;
        private System.Windows.Forms.Button button_Invoice;
        private System.Windows.Forms.Button button_Reports;
    }
}