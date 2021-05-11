using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManagement;

namespace OrderManagementForm
{
    public partial class Form3 : Form
    {
        public OrderItem OrderItem { set; get; }

        public Form3()
        {
            InitializeComponent();
        }
        public Form3(OrderItem odi):this()
        {
            OrderItem = odi;
            this.OrderItemBindingSource.DataSource = odi;
            productBindingSource.Add(new Product("苹果", 5));
            productBindingSource.Add(new Product("橙子", 7));
            productBindingSource.Add(new Product("梨", 4));

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //cmbProduct.SelectedItem.GetType();
            Product selectedPd = (Product)cmbProduct.SelectedItem;
            //OrderItem = new OrderItem(txtId.Text, selectedPd, Convert.ToInt32(txtNum.Text));
            OrderItem.Prodc = selectedPd;
            OrderItem.Num = Convert.ToInt32(txtNum.Text);
            OrderItem.ItemPrice = OrderItem.Prodc.Price * OrderItem.Num;

            OrderItemBindingSource.ResetBindings(false);

        }
    }
}
