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

namespace Inventory.UI.Inventory
{
    public partial class Items : Form
    {
        private Dictionary<int, string> mCategoryDict = new Dictionary<int, string>();

        public Items()
        {
            InitializeComponent();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            PopulateInventory();
        }

        private void PopulateInventory()
        {
            List<Item> records = null;
            records = ItemBS.GetAllItems().Where(item => item.IsActive && item.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();
            var categories = CategoryBS.GetAllCategories().Where(item => item.IsActive && item.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();

            var itemList = new BindingList<Item>(records);

            dataGridView1.DataSource = itemList;

            HideUnwantedColumns();

            var itelList = (from rec in categories select new { CategoryId = rec.CategoryId, CategoryName = rec.CategoryName }).ToList().Distinct();

            foreach (var item in itelList)
            {
                if (!mCategoryDict.ContainsKey(item.CategoryId))
                    mCategoryDict.Add(item.CategoryId, item.CategoryName);
            }

            //DataGridViewComboBoxCell bc = new DataGridViewComboBoxCell();
            //bc.DataSource = mCategoryDict.ToArray();
            //bc.ValueMember = "Key";
            //bc.DisplayMember = "Value";

            //DataGridViewColumn cc = new DataGridViewColumn(bc);
            //cc.Name = "Category";
            //cc.HeaderText = "Category";
            //int columnIndex = dataGridView1.Columns.Add(cc);

            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    item.Cells[columnIndex].Value = item.Cells["CategoryId"].Value;
            //}

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
            if (dataGridView1.Columns.Contains("Category"))
                dataGridView1.Columns.Remove("Category");

            if (dataGridView1.Columns.Contains("CategoryId"))
                dataGridView1.Columns["CategoryId"].Visible = false;

            if (dataGridView1.Columns.Contains("ItemId"))
                dataGridView1.Columns["ItemId"].Visible = false;

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
                if (!Access.Instance.CanProceed(Modules.Item, Actions.Edit))
                    return;

                Item record = (Item)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                record.CompanyId = Session.Instance.AuthUser.CompanyId;
                ItemBS.AddItem(record);
                PopulateInventory();

                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                if (!Access.Instance.CanProceed(Modules.Inventory, Actions.Edit))
                    return;

                ItemBS.DeleteItem(((Item)dataGridView1.Rows[e.RowIndex].DataBoundItem).ItemId);
                PopulateInventory();

                return;
            }
        }
    }
}
