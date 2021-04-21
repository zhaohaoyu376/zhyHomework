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
    public partial class Form1 : Form
    {
        public List<Order> orders;
        public OrderService ods;
        public int selectedIndex;
        public Order selectedOrder;

        public Form1()
        {
            InitializeComponent();

            //生成商品
            Product p1 = new Product("p01", "苹果", 5);
            Product p2 = new Product("p02", "橙子", 7);
            Product p3 = new Product("p03", "梨", 4);

            //生成客户
            Client c1 = new Client("c01");

            //生成订单项
            OrderItem odi1 = new OrderItem("i01", p1, 1);
            OrderItem odi2 = new OrderItem("i02", p2, 2);
            OrderItem odi3 = new OrderItem("i03", p3, 3);
            OrderItem odi4 = new OrderItem("i04", p2, 4);

            //生成订单项列表
            List<OrderItem> l1 = new List<OrderItem>();
            List<OrderItem> l2 = new List<OrderItem>();
            List<OrderItem> l3 = new List<OrderItem>();

            l1.Add(odi1);
            l1.Add(odi2);
            l2.Add(odi4);
            l2.Add(odi3);
            l3.Add(odi1);

            //生成订单
            Order od1 = new Order("o01", c1, "address1", l1);
            Order od2 = new Order("o02", c1, "address2", l2);
            Order od3 = new Order("o03", c1, "address3", l3);

            orders = new List<Order>();

            //生成订单服务对象
            ods = new OrderService(orders);

            ods.AddOrder(od1);
            ods.AddOrder(od2);
            ods.AddOrder(od3);

            orderBindingSource.DataSource = orders;
            orderItemBindingSource.DataSource = orders[0].Items;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sinfo = txtInfo.Text;

            orders = ods.SearchOrder(cmbOpt.SelectedIndex+1, sinfo).ToList();
            orderBindingSource.DataSource = orders;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
            selectedOrder = orders[selectedIndex];
            orderItemBindingSource.DataSource = selectedOrder.Items;
            orderItemBindingSource.ResetBindings(false);
        }

        private void btnAddOd_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(new Order());
            f2.Show();
        }
    }
}
