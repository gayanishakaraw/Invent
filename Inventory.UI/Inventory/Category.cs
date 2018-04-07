using Inventory.DataAccess.Business;
using Inventory.DataAccess.Business.Auth;
using Inventory.DataAccess.Models;
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
    public partial class CategoryUI : Form
    {
        public CategoryUI()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Category_Load(object sender, EventArgs e)
        {
            PopulateCategories();
        }

        private void PopulateCategories()
        {
            List<Category> categories = null;
            categories = CategoryBS.GetAllCategories().Where(cat => cat.IsActive && cat.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();

            var categorylist = new BindingList<Category>(categories);

            dataGridView1.DataSource = categorylist;

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
            if (dataGridView1.Columns.Contains("CategoryId"))
                dataGridView1.Columns["CategoryId"].Visible = false;

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
                if (!Access.Instance.CanProceed(Modules.Category, Actions.Edit))
                    return;

                Category category = (Category)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                category.CompanyId = Session.Instance.AuthUser.CompanyId;
                CategoryBS.AddCategory(category);
                PopulateCategories();

                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                if (!Access.Instance.CanProceed(Modules.Category, Actions.Edit))
                    return;

                CategoryBS.DeleteCategory(((Category)dataGridView1.Rows[e.RowIndex].DataBoundItem).CategoryId);
                PopulateCategories();

                return;
            }
        }
    }
}
