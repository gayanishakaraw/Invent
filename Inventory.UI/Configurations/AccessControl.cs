using Inventory.DataAccess;
using Inventory.DataAccess.Business.Auth;
using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory.UI.Configurations
{
    public partial class AccessControl : Form
    {
        private int mSelectedPermissionGroupId = 0;
        private string mSelectedPermissionGroupName = string.Empty;

        public AccessControl()
        {
            InitializeComponent();
        }

        private void AccessControl_Load(object sender, EventArgs e)
        {
            PopulatPermissionGroups();
        }

        private void initData()
        {
         
        }

        private void PopulatPermissionGroups()
        {
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.Columns.RemoveAt(i);
            }

            List<PermissionGroup> activePermissionGroup = null;
            using (var context = new AppDbContext())
            {
                activePermissionGroup = PermissionBS.GetAllPermissionsGroups().Where(permissionGroup => permissionGroup.IsActive && permissionGroup.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();
            }

            var permissionGrouplist = new BindingList<PermissionGroup>(activePermissionGroup);

            dataGridView2.DataSource = permissionGrouplist;

            if (dataGridView2.Columns.Contains("CompanyId"))
                dataGridView2.Columns.Remove("CompanyId");

            if (dataGridView2.Columns.Contains("PermissionGroupId"))
                dataGridView2.Columns["PermissionGroupId"].Visible = false;

            if (dataGridView2.Columns.Contains("Permissions"))
                dataGridView2.Columns.Remove("Permissions");

            if (dataGridView2.Columns.Contains("Save"))
                dataGridView2.Columns.Remove("Save");

            if (dataGridView2.Columns.Contains("Delete"))
                dataGridView2.Columns.Remove("Delete");

            GenerateCommonColumns(dataGridView2);
        }

        private void PopulatPermissions(List<Permission> permissions)
        {
            label_permissionGroupName.Text = mSelectedPermissionGroupName;

            if (permissions == null)
                return;

            List<Permission> activePermissions = new List<Permission>();

            using (var context = new AppDbContext())
            {
                activePermissions = permissions.Where(permission => permission.PermissionGroupId == mSelectedPermissionGroupId && permission.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();
            }

            if (dataGridView1.Columns.Contains("Module"))
                dataGridView1.Columns.Remove("Module");

            var permissionslist = new BindingList<Permission>(activePermissions);

            dataGridView1.DataSource = permissionslist;

            DataGridViewTextBoxColumn module = new DataGridViewTextBoxColumn();
            module.HeaderText = "Module";
            module.Name = "Module";
            dataGridView1.Columns.Add(module);

            if (dataGridView1.Columns.Contains("PermissionId"))
                dataGridView1.Columns.Remove("PermissionId");

            if (dataGridView1.Columns.Contains("CompanyId"))
                dataGridView1.Columns.Remove("CompanyId");

            if (dataGridView1.Columns.Contains("PermissionGroupId"))
                dataGridView1.Columns["PermissionGroupId"].Visible = false;

            if (dataGridView1.Columns.Contains("ModuleId"))
                dataGridView1.Columns["ModuleId"].Visible = false;

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["ModuleId"].Value != null)
                    item.Cells["Module"].Value = Enum.GetName(typeof(Modules), item.Cells["ModuleId"].Value);
            }

            //GenerateCommonColumns(dataGridView1, true);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void GenerateCommonColumns(DataGridView grid, bool saveOnly = false)
        {
            DataGridViewButtonColumn saveButton = new DataGridViewButtonColumn();
            saveButton.HeaderText = "";
            saveButton.Name = "Save";
            saveButton.Text = "Save";
            saveButton.UseColumnTextForButtonValue = true;

            grid.Columns.Add(saveButton);

            if (saveOnly)
                return;

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.HeaderText = "";
            deleteButton.Name = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;

            grid.Columns.Add(deleteButton);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var record = (PermissionGroup)dataGridView2.Rows[e.RowIndex].DataBoundItem;
            record.CompanyId = Session.Instance.AuthUser.CompanyId;

            var permissions = PermissionBS.GetPermissionByPermissionGroupId(record.PermissionGroupId);

            mSelectedPermissionGroupId = record.PermissionGroupId;
            mSelectedPermissionGroupName = record.PermissionGroupName;

            if (e.ColumnIndex == dataGridView2.Columns["Save"].Index)
            {
                if (permissions == null || permissions.Count < 1)
                {
                    List<Permission> perms = new List<Permission>();

                    for (int i = 1; i < typeof(Modules).GetEnumNames().Count(); i++)
                    {
                        PermissionBS.AddPermission(new Permission() { PermissionGroupId = mSelectedPermissionGroupId, ModuleId = i, CompanyId = Session.Instance.AuthUser.CompanyId });
                    }
                }

                var entry = PermissionBS.AddPermissionGroup(record);
                mSelectedPermissionGroupId = entry.PermissionGroupId;
                PopulatPermissionGroups();
                PopulatPermissions(PermissionBS.GetPermissionByPermissionGroupId(mSelectedPermissionGroupId));

                return;
            }
            if (e.ColumnIndex == dataGridView2.Columns["Delete"].Index)
            {
                PermissionBS.DeletePermissionByPermissionGroupId(mSelectedPermissionGroupId);
                PopulatPermissionGroups();
                PopulatPermissions(PermissionBS.GetPermissionByPermissionGroupId(mSelectedPermissionGroupId));

                return;
            }

            PopulatPermissions(PermissionBS.GetPermissionByPermissionGroupId(mSelectedPermissionGroupId));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ////var record = dataGridView1.Rows[e.RowIndex];

            ////if (e.ColumnIndex == dataGridView1.Columns["Save"].Index)
            ////{
            ////    Permission perm = new Permission();

            ////    perm.PermissionGroupId = mSelectedPermissionGroupId;
            ////    perm.CompanyId = Session.Instance.AuthUser.CompanyId;
            ////    perm.ModuleId = Enum.GetNames(typeof(Modules)).ToList().IndexOf(dataGridView1.Rows[e.RowIndex].Cells["ModuleId"].Value.ToString());
            ////    perm.FullAccess = (bool)dataGridView1.Rows[e.RowIndex].Cells["FullAccess"].Value;
            ////    perm.CanEdit = (bool)dataGridView1.Rows[e.RowIndex].Cells["CanEdit"].Value;
            ////    perm.CanRead = (bool)dataGridView1.Rows[e.RowIndex].Cells["CanRead"].Value;
            ////    perm.CanView = (bool)dataGridView1.Rows[e.RowIndex].Cells["CanView"].Value;

            ////    PermissionBS.AddPermission(perm);
            ////    return;
            ////}
            ////if (e.ColumnIndex == dataGridView2.Columns["Delete"].Index)
            ////{
            ////    PermissionBS.DeletePermissionByPermissionGroupId(mSelectedPermissionGroupId);
            ////    return;
            ////}
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Permission perm = new Permission();
                perm.PermissionId = ((Permission)dataGridView1.Rows[row.Index].DataBoundItem).PermissionId;
                perm.PermissionGroupId = mSelectedPermissionGroupId;
                perm.CompanyId = Session.Instance.AuthUser.CompanyId;
                perm.ModuleId = (int)dataGridView1.Rows[row.Index].Cells["ModuleId"].Value;
                perm.FullAccess = (bool)dataGridView1.Rows[row.Index].Cells["FullAccess"].Value;
                perm.CanEdit = (bool)dataGridView1.Rows[row.Index].Cells["CanEdit"].Value;
                perm.CanRead = (bool)dataGridView1.Rows[row.Index].Cells["CanRead"].Value;
                perm.CanView = (bool)dataGridView1.Rows[row.Index].Cells["CanView"].Value;

                PermissionBS.AddPermission(perm);
            }

            PopulatPermissions(PermissionBS.GetPermissionByPermissionGroupId(mSelectedPermissionGroupId));
        }
    }
}
