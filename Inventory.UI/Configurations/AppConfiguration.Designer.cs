namespace Inventory.UI.Configurations
{
    partial class AppConfiguration
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
            this.button_Organization = new System.Windows.Forms.Button();
            this.button_Users = new System.Windows.Forms.Button();
            this.button_Roles = new System.Windows.Forms.Button();
            this.button_Access = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Organization
            // 
            this.button_Organization.Location = new System.Drawing.Point(15, 12);
            this.button_Organization.Name = "button_Organization";
            this.button_Organization.Size = new System.Drawing.Size(75, 38);
            this.button_Organization.TabIndex = 0;
            this.button_Organization.Text = "Organization";
            this.button_Organization.UseVisualStyleBackColor = true;
            this.button_Organization.Click += new System.EventHandler(this.button_Organization_Click);
            // 
            // button_Users
            // 
            this.button_Users.Location = new System.Drawing.Point(177, 12);
            this.button_Users.Name = "button_Users";
            this.button_Users.Size = new System.Drawing.Size(75, 38);
            this.button_Users.TabIndex = 0;
            this.button_Users.Text = "Users";
            this.button_Users.UseVisualStyleBackColor = true;
            this.button_Users.Click += new System.EventHandler(this.button_Users_Click);
            // 
            // button_Roles
            // 
            this.button_Roles.Location = new System.Drawing.Point(96, 12);
            this.button_Roles.Name = "button_Roles";
            this.button_Roles.Size = new System.Drawing.Size(75, 38);
            this.button_Roles.TabIndex = 0;
            this.button_Roles.Text = "Roles";
            this.button_Roles.UseVisualStyleBackColor = true;
            this.button_Roles.Click += new System.EventHandler(this.button_Roles_Click);
            // 
            // button_Access
            // 
            this.button_Access.Location = new System.Drawing.Point(258, 12);
            this.button_Access.Name = "button_Access";
            this.button_Access.Size = new System.Drawing.Size(75, 38);
            this.button_Access.TabIndex = 0;
            this.button_Access.Text = "Access Control";
            this.button_Access.UseVisualStyleBackColor = true;
            this.button_Access.Click += new System.EventHandler(this.button_Access_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(15, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 390);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(852, 390);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // AppConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 468);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Access);
            this.Controls.Add(this.button_Roles);
            this.Controls.Add(this.button_Users);
            this.Controls.Add(this.button_Organization);
            this.Name = "AppConfiguration";
            this.Text = "Configurations";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Organization;
        private System.Windows.Forms.Button button_Users;
        private System.Windows.Forms.Button button_Roles;
        private System.Windows.Forms.Button button_Access;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}