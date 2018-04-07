using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory.DataAccess.Business;
using Inventory.DataAccess.Business.Auth;
using Inventory.DataAccess.Models;
using Inventory.UI.Common;

namespace Inventory.UI.Customer
{
    public partial class CustomersUI : Form
    {
        List<DataAccess.Models.Customer> mCustomers = null;

        public CustomersUI()
        {
            InitializeComponent();
        }
        private void PopulateCustomers()
        {
            mCustomers = DataAccess.Business.CustomerBS.GetAllCustomers().Where(item => item.IsActive && item.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();

            var customerList = new BindingList<DataAccess.Models.Customer>(mCustomers);

            dataGridView1.DataSource = customerList;

            HideUnwantedColumns();
            GenerateCommonColumns();
        }

        private void GenerateCommonColumns()
        {
            DataGridViewButtonColumn saveButton = new DataGridViewButtonColumn();
            saveButton.HeaderText = "";
            saveButton.Name = "Save";
            saveButton.Text = "Save";
            saveButton.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(saveButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.HeaderText = "";
            deleteButton.Name = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(deleteButton);
        }

        private void HideUnwantedColumns()
        {
            if (dataGridView1.Columns.Contains("ItemStockId"))
                dataGridView1.Columns["ItemStockId"].Visible = false;

            if (dataGridView1.Columns.Contains("CompanyId"))
                dataGridView1.Columns["CompanyId"].Visible = false;

            if (dataGridView1.Columns.Contains("Save"))
                dataGridView1.Columns.Remove("Save");

            if (dataGridView1.Columns.Contains("Delete"))
                dataGridView1.Columns.Remove("Delete");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dataGridView1.Columns["Save"].Index)
            {
                if (!Access.Instance.CanProceed(Modules.Inventory, Actions.Edit))
                    return;

                DataAccess.Models.Customer record = (DataAccess.Models.Customer)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                record.CompanyId = Session.Instance.AuthUser.CompanyId;
                record.RegisteredDate = DateTime.Now;
                CustomerBS.AddCustomer(record);
                PopulateCustomers();

                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                if (!Access.Instance.CanProceed(Modules.Inventory, Actions.Edit))
                    return;

                CustomerBS.DeleteCustomer(((DataAccess.Models.Customer)dataGridView1.Rows[e.RowIndex].DataBoundItem).CustomerId);
                PopulateCustomers();

                return;
            }
        }

        private void CustomersUI_Load(object sender, EventArgs e)
        {
            PopulateCustomers();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Close();
        }
    }
}
