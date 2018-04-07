using Inventory.DataAccess;
using Inventory.DataAccess.Business;
using Inventory.DataAccess.Business.Auth;
using Inventory.DataAccess.Models;
using Inventory.UI.Common;
using Inventory.UI.Models;
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
    public partial class AppConfiguration : Form
    {
        private Dictionary<int, string> mRoleDict = new Dictionary<int, string>();

        public AppConfiguration()
        {
            InitializeComponent();
        }

        private void button_Roles_Click(object sender, EventArgs e)
        {
            PopulateRoles();
        }

        private void PopulateRoles()
        {
            List<Role> roles = null;
            using (var context = new AppDbContext())
            {
                roles = context.Roles.Where(role => role.IsActive && role.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();
            }

            var rolelist = new BindingList<Role>(roles);

            dataGridView1.DataSource = rolelist;

            HideUnwantedColumns();
            GenerateCommonColumns();
        }

        private void button_Users_Click(object sender, EventArgs e)
        {
            PopulateUserGrid();
        }

        private void PopulateUserGrid()
        {
            List<User> users = null;
            List<Role> roles = null;
            using (var context = new AppDbContext())
            {
                users = context.Users.Where(user => user.IsActive && user.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();
                roles = context.Roles.Where(role => role.IsActive && role.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();
            }

            var dataSet = (from user in users
                           join role in roles on user.RoleId equals role.RoleId
                           select new UserModel() { UserName = user.UserName, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Role = role.RoleName, IsActive = user.IsActive }).ToList();

            var userList = new BindingList<User>(users);

            dataGridView1.DataSource = userList;

            HideUnwantedColumns();

            var roleNames = (from role in roles select new { RoleId = role.RoleId, RoleName = role.RoleName }).ToList().Distinct();

            foreach (var role in roleNames)
            {
                if (!mRoleDict.ContainsKey(role.RoleId))
                    mRoleDict.Add(role.RoleId, role.RoleName);
            }

            DataGridViewComboBoxCell bc = new DataGridViewComboBoxCell();
            bc.DataSource = mRoleDict.ToArray();
            bc.ValueMember = "Key";
            bc.DisplayMember = "Value";

            DataGridViewColumn cc = new DataGridViewColumn(bc);
            cc.Name = "Role";
            cc.HeaderText = "Role";
            int columnIndex = dataGridView1.Columns.Add(cc);

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.Cells[columnIndex].Value = item.Cells["RoleId"].Value;
            }

            DataGridViewButtonColumn passwordSet = new DataGridViewButtonColumn();
            passwordSet.HeaderText = "";
            passwordSet.Name = "SetPassword";
            passwordSet.Text = "Password";
            passwordSet.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(passwordSet);

            GenerateCommonColumns();
        }

        private void HideUnwantedColumns()
        {
            if (dataGridView1.Columns.Contains("LogoURL"))
                dataGridView1.Columns["LogoURL"].Visible = false;

            if (dataGridView1.Columns.Contains("UserId"))
                dataGridView1.Columns["UserId"].Visible = false;

            if (dataGridView1.Columns.Contains("CompanyId"))
                dataGridView1.Columns["CompanyId"].Visible = false;

            if (dataGridView1.Columns.Contains("RoleId"))
                dataGridView1.Columns["RoleId"].Visible = false;

            if (dataGridView1.Columns.Contains("Password"))
                dataGridView1.Columns["Password"].Visible = false;

            if (dataGridView1.Columns.Contains("Save"))
                dataGridView1.Columns.Remove("Save");

            if (dataGridView1.Columns.Contains("Delete"))
                dataGridView1.Columns.Remove("Delete");

            if (dataGridView1.Columns.Contains("Role"))
                dataGridView1.Columns.Remove("Role");

            if (dataGridView1.Columns.Contains("SetPassword"))
                dataGridView1.Columns.Remove("SetPassword");
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

        private void button_Organization_Click(object sender, EventArgs e)
        {
            if (PermissionBS.HasFullAccess(Session.Instance.AuthUser.UserId, (int)Modules.Company) ||
                PermissionBS.HasAccessToRead(Session.Instance.AuthUser.UserId, (int)Modules.Company))
            {
                PopulateOrganization();
            }
            else
            {
                MessageBox.Show("User doesn't have access to this module.");
            }
        }

        private void PopulateOrganization()
        {
            List<Company> companies = null;
            using (var context = new AppDbContext())
            {
                companies = context.Companies.Where(role => role.IsActive).ToList();
            }

            var companyList = new BindingList<Company>(companies);

            dataGridView1.DataSource = companyList;

            HideUnwantedColumns();
            GenerateCommonColumns();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dataGridView1.Columns["Save"].Index)
            {
                switch (dataGridView1.Rows[e.RowIndex].DataBoundItem.GetType().Name)
                {
                    case "User":
                        if (!Access.Instance.CanProceed(Modules.User, Actions.Edit))
                            return;

                        User user = (User)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                        user.CompanyId = Session.Instance.AuthUser.CompanyId;
                        user.RoleId = (int)dataGridView1.Rows[e.RowIndex].Cells["Role"].Value;
                        UserBS.AddUser(user);
                        PopulateUserGrid();
                        break;
                    case "Role":
                        if (!Access.Instance.CanProceed(Modules.Role, Actions.Edit))
                            return;

                        RoleBS.AddRole((Role)dataGridView1.Rows[e.RowIndex].DataBoundItem);
                        PopulateRoles();
                        break;
                    case "Company":
                        if (!Access.Instance.CanProceed(Modules.Company, Actions.Edit))
                            return;

                        CompanyBS.AddCompany((Company)dataGridView1.Rows[e.RowIndex].DataBoundItem);
                        PopulateOrganization();
                        break;
                }
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                switch (dataGridView1.Rows[e.RowIndex].DataBoundItem.GetType().Name)
                {
                    case "User":
                        if (!Access.Instance.CanProceed(Modules.User, Actions.Edit))
                            return;

                        UserBS.DeleteUser(((User)dataGridView1.Rows[e.RowIndex].DataBoundItem).UserId);
                        PopulateUserGrid();
                        break;
                    case "Role":
                        if (!Access.Instance.CanProceed(Modules.Role, Actions.Edit))
                            return;

                        RoleBS.DeleteRole(((Role)dataGridView1.Rows[e.RowIndex].DataBoundItem).RoleId);
                        PopulateRoles();
                        break;
                    case "Company":
                        if (!Access.Instance.CanProceed(Modules.Company, Actions.Edit))
                            return;

                        CompanyBS.DeleteCompany(((Company)dataGridView1.Rows[e.RowIndex].DataBoundItem).CompanyId);
                        PopulateOrganization();
                        break;
                }
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["SetPassword"].Index)
            {
                switch (dataGridView1.Rows[e.RowIndex].DataBoundItem.GetType().Name)
                {
                    case "User":
                        User user = (User)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                        Password pwd = new Password(user);
                        pwd.Owner = this;
                        this.Hide();
                        pwd.ShowDialog();
                        UserBS.AddUser(user);
                        break;
                }
                return;
            }
        }

        private void button_Access_Click(object sender, EventArgs e)
        {
            if (Access.Instance.CanProceed(Modules.Permission, Actions.Read) || Access.Instance.CanProceed(Modules.Permission, Actions.Edit))
            {
                AccessControl accessControl = new AccessControl();
                accessControl.Show();
            }
        }
    }
}
