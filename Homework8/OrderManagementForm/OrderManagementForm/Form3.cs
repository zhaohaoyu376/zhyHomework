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
        Product p1 = new Product("p01", "苹果", 5);
        Product p2 = new Product("p02", "橙子", 7);
        Product p3 = new Product("p03", "梨", 4);
        public Form3()
        {
            InitializeComponent();
            productBindingSource.Add(p1);
            productBindingSource.Add(p2);
            productBindingSource.Add(p3);

        }
    }
}
