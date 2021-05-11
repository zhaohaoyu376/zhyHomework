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
    public partial class Form2 : Form
    {
        public Order CurrentOrder { set; get; }
        public Form2()
        {
            InitializeComponent();
            
            List<Client> Clients = ClientService.GetAll();
            if (Clients.Count == 0)
            {
                ClientService.Add(new Client("c01"));
                ClientService.Add(new Client("c02"));
                ClientService.Add(new Client("c03"));

                Clients = ClientService.GetAll();
            }
            clientBindingSource.DataSource = Clients;


        }
        public Form2(Order od):this()
        {
            InitializeComponent();
            //clientBindingSource.Add(new Client("c01"));
            CurrentOrder = od;
            orderItemBindingSource.DataSource = CurrentOrder.Items;
            orderBindingSource.DataSource = CurrentOrder;
            CurrentOrder.Client = (Client)clientBindingSource.Current;

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(new OrderItem());
            //f3.Show();
            try
            {
                if (f3.ShowDialog() == DialogResult.OK)
                {
                    int index = 0;
                    if (CurrentOrder.Items.Count != 0)
                    {
                        index = CurrentOrder.Items.Max(i => i.Index) + 1;
                    }
                    f3.OrderItem.Index = index;
                    CurrentOrder.AddItem(f3.OrderItem);
                    orderItemBindingSource.ResetBindings(false);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            CurrentOrder.Address = txtAddress.Text;
            CurrentOrder.Client = (Client)cmbClient.SelectedItem;
            //CurrentOrder.ClientID= (Client)cmbClient.SelectedItem.
            //CurrentOrder.
        }
    }
}
