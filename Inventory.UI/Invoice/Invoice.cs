using Inventory.DataAccess.Business;
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

namespace Inventory.UI.Invoice
{
    public partial class Invoice : Form
    {
        private Order mOrder = null;
        private List<Item> mItems = new List<Item>();
        private Dictionary<int, string> mCustomers = new Dictionary<int, string>();
        private Dictionary<int, string> mItemsDict = new Dictionary<int, string>();

        private static Invoice _instance;

        public static Invoice Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Invoice();
                return _instance;
            }
        }

        private Invoice()
        {
            InitializeComponent();
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            PopulateCustomerDetails();
            PopulateItems();
            mOrder = new Order();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_AddCustomer_Click(object sender, EventArgs e)
        {
            Customer.CustomersUI customer = new Customer.CustomersUI();
            customer.Owner = this;
            this.Enabled = false;
            customer.Show();
            PopulateCustomerDetails();
        }

        public void PopulateItems()
        {
            var activeItems = DataAccess.Business.ItemBS.GetAllItems().Where(item => item.IsActive && item.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();
            var categories = DataAccess.Business.CategoryBS.GetAllCategories().Where(item => item.IsActive && item.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();

            var itemsWithCategory = from item in activeItems
                                    join cat in categories on item.CategoryId equals cat.CategoryId
                                    select new { ItemId = item.ItemId, ItemName = item.ItemName, Price = item.Price, CategoryName = cat.CategoryName };
            foreach (var item in itemsWithCategory)
            {
                string value = string.Format("{0} - {1} - {2}", item.ItemId, item.CategoryName, item.ItemName);
                mItemsDict.Add(item.ItemId, value);
            }
        }

        public void PopulateCustomerDetails()
        {
            var activeCustomers = DataAccess.Business.CustomerBS.GetAllCustomers().Where(item => item.IsActive && item.CompanyId == Session.Instance.AuthUser.CompanyId).ToList();

            foreach (var cust in activeCustomers)
            {
                string value = string.Format("{0} - {1}", (string.IsNullOrEmpty(cust.HandPhone) ? (string.IsNullOrEmpty(cust.LandPhone) ? cust.CustomerId.ToString() : cust.LandPhone) : cust.HandPhone), cust.CustomerName);
                if (!mCustomers.ContainsKey(cust.CustomerId))
                    mCustomers.Add(cust.CustomerId, value);
            }

            this.comboBox_customers.DataSource = mCustomers.ToArray();
        }

        private void button_FindInvoice_Click(object sender, EventArgs e)
        {
            int invoiceNumber = 0;
            int.TryParse(this.textBox_invoiceNumber.Text, out invoiceNumber);
            mOrder = OrderBS.GetOrderById(invoiceNumber);

            PopulateInvoice();
        }

        private void PopulateInvoice()
        {
            if (mOrder == null)
                return;

            List<OrderDetail> records = null;
            records = OrderDetailBS.GetAllOrderDetailsByOrderId(mOrder.OrderId).ToList();

            var itemList = new BindingList<OrderDetail>(records);

            dataGridView1.DataSource = itemList;
            (dataGridView1.Columns["ItemName"] as DataGridViewComboBoxColumn).DataSource = itemList;

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                double total = (double)(mItems.FirstOrDefault(rec => rec.ItemId == records[item.Index].ItemId).Price * records[item.Index].Qty);
                double discountTotal = total * records[item.Index].Discount;
                double taxTotal = (double)(discountTotal * records[item.Index].Tax);

                double totalDue = (total + taxTotal) - discountTotal;

                item.Cells["RecNum"].Value = item.Index + 1;
                item.Cells["ItemName"].Value = mItemsDict[records[item.Index].ItemId];
                item.Cells["UnitPrice"].Value = mItems.FirstOrDefault(rec => rec.ItemId == records[item.Index].ItemId).Price.ToString();
                item.Cells["SellingPrice"].Value = totalDue.ToString();
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            PopulateCustomerDetails();
            this.Hide();
        }
    }
}
