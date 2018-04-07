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

namespace Inventory.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            Authentication auth = new Authentication();
            AuthResponse resp = auth.Authenticate(textBox_userID.Text, TextBox_secCode.Text);

            // TESTING
            resp = new AuthResponse();
            resp.CompanyId = 1;
            resp.UserId = 1;
            resp.UserName = "SuperAdmin";
            resp.RoleId = 1;
            resp.Success = true;


            if (resp.Success)
            {
                Session.Instance.AuthUser = resp;
                MainMenu menu = new MainMenu();
                menu.Show();
                this.Hide();
            }
            else
                MessageBox.Show(resp.Message);
        }
    }
}
