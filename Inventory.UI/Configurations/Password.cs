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
    public partial class Password : Form
    {
        User _user;
        public Password(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
            Owner.Show();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != maskedTextBox2.Text)
            {
                label3.Visible = true;
                label3.Text = "Password doesn't match";
            }
            else
            {
                label3.Visible = false;
                _user.Password = maskedTextBox1.Text;
                this.Close();
                Owner.Show();
            }
        }
    }
}
