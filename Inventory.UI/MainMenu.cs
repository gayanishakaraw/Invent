using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory.UI.Configurations;

namespace Inventory.UI
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button_Users_Click(object sender, EventArgs e)
        {
            AppConfiguration config = new AppConfiguration();
            config.Show();
        }

        private void button_Invoice_Click(object sender, EventArgs e)
        {
            Invoice.Invoice.Instance.Show();
        }
    }
}
