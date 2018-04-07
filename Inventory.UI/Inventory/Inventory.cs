using Inventory.DataAccess.Business.Auth;
using Inventory.DataAccess.Business.Inventory;
using Inventory.DataAccess.Models.Inventory;
using Inventory.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory.UI.Inventory
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            PopulateInventory();
        }
        private void PopulateInventory()
        {
            List<ItemStock> itemstock = null;
            itemstock = ItemStockBS.GetAllItemStocks().Where(item => item.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();

            var itemList = new BindingList<ItemStock>(itemstock);

            dataGridView1.DataSource = itemList;

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

                ItemStock record = (ItemStock)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                record.CompanyId = Session.Instance.AuthUser.CompanyId;
                ItemStockBS.AddItemStock(record);
                PopulateInventory();

                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                if (!Access.Instance.CanProceed(Modules.Inventory, Actions.Edit))
                    return;

                ItemStockBS.DeleteItemStock(((ItemStock)dataGridView1.Rows[e.RowIndex].DataBoundItem).ItemStockId);
                PopulateInventory();

                return;
            }
        }
    }
}
