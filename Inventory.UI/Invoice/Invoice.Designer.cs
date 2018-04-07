namespace Inventory.UI.Invoice
{
    partial class Invoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RecNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_totalAmount = new System.Windows.Forms.TextBox();
            this.textBox_totalTax = new System.Windows.Forms.TextBox();
            this.textBox_TotalDiscount = new System.Windows.Forms.TextBox();
            this.textBox_DueAmount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_customers = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_invoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button_FindInvoice = new System.Windows.Forms.Button();
            this.textBox_invoiceNumber = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(13, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 314);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecNum,
            this.ItemName,
            this.UnitPrice,
            this.SellingPrice,
            this.Delete});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(934, 314);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RecNum
            // 
            this.RecNum.Frozen = true;
            this.RecNum.HeaderText = "#";
            this.RecNum.Name = "RecNum";
            this.RecNum.ReadOnly = true;
            this.RecNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RecNum.Width = 30;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Description";
            this.ItemName.Items.AddRange(new object[] {
            "ABCD",
            "Last 30 minutes",
            "Last 60 minutes",
            "Lunch",
            "Dinner",
            "All Day"});
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 400;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Width = 50;
            // 
            // SellingPrice
            // 
            this.SellingPrice.HeaderText = "Selling Price";
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.ReadOnly = true;
            this.SellingPrice.Width = 50;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Void";
            this.Delete.Name = "Delete";
            this.Delete.Width = 50;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(469, 478);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(92, 17);
            this.label.TabIndex = 1;
            this.label.Text = "Total Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(494, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Tax";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(462, 530);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total Discount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(475, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Due Amount";
            // 
            // textBox_totalAmount
            // 
            this.textBox_totalAmount.Enabled = false;
            this.textBox_totalAmount.Location = new System.Drawing.Point(576, 477);
            this.textBox_totalAmount.Name = "textBox_totalAmount";
            this.textBox_totalAmount.Size = new System.Drawing.Size(198, 20);
            this.textBox_totalAmount.TabIndex = 5;
            // 
            // textBox_totalTax
            // 
            this.textBox_totalTax.Enabled = false;
            this.textBox_totalTax.Location = new System.Drawing.Point(576, 503);
            this.textBox_totalTax.Name = "textBox_totalTax";
            this.textBox_totalTax.Size = new System.Drawing.Size(198, 20);
            this.textBox_totalTax.TabIndex = 6;
            // 
            // textBox_TotalDiscount
            // 
            this.textBox_TotalDiscount.Enabled = false;
            this.textBox_TotalDiscount.Location = new System.Drawing.Point(576, 529);
            this.textBox_TotalDiscount.Name = "textBox_TotalDiscount";
            this.textBox_TotalDiscount.Size = new System.Drawing.Size(198, 20);
            this.textBox_TotalDiscount.TabIndex = 7;
            // 
            // textBox_DueAmount
            // 
            this.textBox_DueAmount.Enabled = false;
            this.textBox_DueAmount.Location = new System.Drawing.Point(576, 555);
            this.textBox_DueAmount.Name = "textBox_DueAmount";
            this.textBox_DueAmount.Size = new System.Drawing.Size(198, 20);
            this.textBox_DueAmount.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(871, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Customer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_AddCustomer_Click);
            // 
            // comboBox_customers
            // 
            this.comboBox_customers.FormattingEnabled = true;
            this.comboBox_customers.Location = new System.Drawing.Point(15, 73);
            this.comboBox_customers.Name = "comboBox_customers";
            this.comboBox_customers.Size = new System.Drawing.Size(850, 21);
            this.comboBox_customers.TabIndex = 10;
            // 
            // dateTimePicker_invoiceDate
            // 
            this.dateTimePicker_invoiceDate.Location = new System.Drawing.Point(746, 111);
            this.dateTimePicker_invoiceDate.Name = "dateTimePicker_invoiceDate";
            this.dateTimePicker_invoiceDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_invoiceDate.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(701, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Date";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(811, 474);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 25);
            this.button2.TabIndex = 13;
            this.button2.Text = "Print Quotation";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(811, 513);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 25);
            this.button3.TabIndex = 14;
            this.button3.Text = "Payment";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button_FindInvoice
            // 
            this.button_FindInvoice.Location = new System.Drawing.Point(13, 23);
            this.button_FindInvoice.Name = "button_FindInvoice";
            this.button_FindInvoice.Size = new System.Drawing.Size(75, 23);
            this.button_FindInvoice.TabIndex = 15;
            this.button_FindInvoice.Text = "Find Invoice";
            this.button_FindInvoice.UseVisualStyleBackColor = true;
            this.button_FindInvoice.Click += new System.EventHandler(this.button_FindInvoice_Click);
            // 
            // textBox_invoiceNumber
            // 
            this.textBox_invoiceNumber.Location = new System.Drawing.Point(100, 25);
            this.textBox_invoiceNumber.Name = "textBox_invoiceNumber";
            this.textBox_invoiceNumber.Size = new System.Drawing.Size(342, 20);
            this.textBox_invoiceNumber.TabIndex = 16;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 495);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(429, 71);
            this.richTextBox1.TabIndex = 17;
            this.richTextBox1.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Remarks";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(811, 551);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(135, 25);
            this.button_save.TabIndex = 19;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(904, 12);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(42, 24);
            this.button_close.TabIndex = 20;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 584);
            this.ControlBox = false;
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox_invoiceNumber);
            this.Controls.Add(this.button_FindInvoice);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker_invoiceDate);
            this.Controls.Add(this.comboBox_customers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_DueAmount);
            this.Controls.Add(this.textBox_TotalDiscount);
            this.Controls.Add(this.textBox_totalTax);
            this.Controls.Add(this.textBox_totalAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.panel1);
            this.Name = "Invoice";
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Invoice_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_totalAmount;
        private System.Windows.Forms.TextBox textBox_totalTax;
        private System.Windows.Forms.TextBox textBox_TotalDiscount;
        private System.Windows.Forms.TextBox textBox_DueAmount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_customers;
        private System.Windows.Forms.DateTimePicker dateTimePicker_invoiceDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_FindInvoice;
        private System.Windows.Forms.TextBox textBox_invoiceNumber;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecNum;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button button_close;
    }
}