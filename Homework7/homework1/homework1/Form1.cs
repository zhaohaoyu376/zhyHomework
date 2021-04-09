using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string str1 = this.textBox1.Text.Trim();
            int n = Convert.ToInt32(str1);
         

            string str2 = this.textBox2.Text.Trim();
            double leng = Convert.ToDouble(str2);

            if (str1.Length == 0 || str2.Length==0)
            {
                //第一种方式提示错误
                MessageBox.Show("有误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBox1.Text = string.Empty;
                this.textBox1.Focus();
                this.textBox2.Text = string.Empty;
                this.textBox2.Focus();
                return;
            }

            //  string str3 = this.textBox3.Text.Trim();
            //double per1 = Convert.ToDouble(str3);

            // string str4 = this.textBox4.Text.Trim();
            //  double per2 = Convert.ToDouble(str4);


            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(n, 300, 350, leng, -Math.PI / 2);
        }


        private Graphics graphics;
        // public int n;
        public bool judge;
        public double leng;
        public double th1;
        //= 30 * Math.PI / 180;
        public double th2;
        //= 20 * Math.PI / 180;
        public double per1;
        //=  0.6;
        public double per2;
            //= 0.7;


        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            string str5 = this.textBox5.Text.Trim();
            double th1 = Convert.ToDouble(str5);
            string str6 = this.textBox6.Text.Trim();
            double th2 = Convert.ToDouble(str6);
            string str3 = this.textBox4.Text.Trim();
            double per1 = Convert.ToDouble(str3);
            string str4 = this.textBox6.Text.Trim();
            double per2 = Convert.ToDouble(str4);
            if (str5.Length == 0 || str6.Length == 0 || str3.Length == 0 || str4.Length == 0)
            {
                judge = false;
            }
            else
            {
                if (n == 0) return;
                double x1 = x0 + leng * Math.Cos(th);
                double y1 = y0 + leng * Math.Sin(th);

                drawLine(x0, y0, x1, y1);

                drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
                drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
            }
            
        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }




    }
}
