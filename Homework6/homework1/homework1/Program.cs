using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace homework1
{

    [Serializable]
    public class Good              //商品类
    {
        private int number;
        private string name;
        private string customer;
        private double price;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public Good()
        {
            this.Name = string.Empty;
            this.customer = string.Empty;
            this.Number = 0;
            this.Price = 0;

        }

        public Good(int number, string name, string customer, double price)
        {
            this.name = name;
            this.number = number;
            this.customer = customer;
            this.price = price;
        }


    }


    [Serializable]
    public class Goods   //对于单个商品操作
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Customer { get; set; }
        public double Money { get; set; }


        public List<Good> good = new List<Good>();

        public Goods()//无参构造函数
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.Customer = string.Empty;
            this.Money = 0;
        }

        public int CompareTo(object obj)
        {
            Goods a = obj as Goods;
            return this.Id.CompareTo(a.Id);
        }

        public override bool Equals(object obj)
        {
            Goods a = obj as Goods;
            return this.Id == a.Id;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Id);
        }

        public Goods(int id, string customer, string name,double money)
        {
            this.Id = id;
            this.Customer = customer;
            this.Name = name;
            this.Money = money;
        }



        public void addGood(int number,string name, string customer, double price)   //添加订单项
        {
            Good a = new Good(number,name,customer, price);
            this.good.Add(a);
        }

        public void removeGood() //删除订单项
        {
            try
            {
                Console.WriteLine("订单编号");
                int a = Convert.ToInt32(Console.ReadLine());
                this.good.RemoveAt(a);

            }
            catch
            {
                Console.WriteLine("error");
            }

        }

        public void showGood()  //展示订单项
        {
          // Console.WriteLine("输入商品信息");
            foreach (Good a in this.good)
            {

                Console.WriteLine("{0} {1} {2} {3}", a.Name, a.Number,a,Customer, a.Price);
            }
        }

    }


    [Serializable]
    public class AllOrder  
    {
        public List<Goods> order = new List<Goods>();

        public AllOrder()
        {

        }
        public string Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Good));
            using (FileStream fs =new FileStream("s.xml", FileMode.Open))
            {
                return File.ReadAllText("s.xml");
            }

        }

        public void Import(int id, string name,string customer,double money)
        {
            Goods a = new Goods(id, name, customer, money);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Goods));
            using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, a);
            }
        }

        public void ShowOrder()
        {
            foreach (Goods a in this.order)
            {
                Console.WriteLine("{0} {1} {2} {3}", a.Id, a.Name,a.Customer,  a.Money);
                a.showGood();
                Export();
            }
        }

        public void addGood()          //增加订单
        {
            try
            {
                Console.WriteLine("订单编号:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("商品名字：");
                string name = Console.ReadLine();
                Console.WriteLine("用户名字:");
                string customer = Console.ReadLine();
                Console.WriteLine("价格：");
                double money = Convert.ToInt32(Console.ReadLine());
                Goods a = new Goods(id, name,customer,money );
                bool same = false;

                foreach (Goods m in this.order)
                {
                    if (m.Equals(a)) same = true;
                }

                if (same)
                {
                    Console.WriteLine("重复");
                }
                else
                {
                    order.Add(a);
                    Import(id, name, customer, money);
                }
            }
            catch
            {
                Console.WriteLine("error");
            }

        }

        public void removeGood()           //删除订单
        {
            try
            {
                Console.WriteLine("订单号：");
                int id = Convert.ToInt32(Console.ReadLine());
                int index = 0;
                foreach (Goods a in this.order)
                {
                    if (a.Id == id) index = this.order.IndexOf(a);
                }

                this.order.RemoveAt(index); 
                Console.WriteLine("删除成功"); 

            }
            catch
            {
                Console.WriteLine("error");
            }

        }

        public void changeGood()
        {
            try
            {
                Console.WriteLine("订单编号:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("商品名字：");
                string name = Console.ReadLine();
                Console.WriteLine("用户名字:");
                string customer = Console.ReadLine();
                Console.WriteLine("价格：");
                double money = Convert.ToInt32(Console.ReadLine());
                Goods a = new Goods(id, name, customer, money);

                int index = 0;
                foreach (Goods aa in this.order)
                {
                    if (a.Id == id) index = this.order.IndexOf(a);
                }
                this.order.RemoveAt(index);

                order.Add(a);

            }
            catch
            {
                Console.WriteLine("error");
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            // string[,,,] arr;
            //string[,,,] arr = new string[,,,] { { { { "1", "蛋糕", "小明", "10r" } } } };
            Console.WriteLine("选择所用功能");
            Console.WriteLine("1.添加订单");
            Console.WriteLine("2.删除订单");
            Console.WriteLine("3.修改订单");
            Console.WriteLine("4.查询订单");

            AllOrder x = new AllOrder();
            bool again = true;
            while (again)
            {
                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        x.addGood();
                        break;

                    case "2":
                        x.removeGood();
                        break;

                    case "3":
                        x.changeGood();

                        break;

                    case "4":
                        x.ShowOrder();
                        break;

                    default:
                        Console.WriteLine("无效的输入. 请选择1-4的数字");
                        break;
                }

                Console.WriteLine("还要继续吗,继续输入1  退出输入 2");
                string b = Console.ReadLine();
                switch (b)
                {
                    case "1":
                        again = true;
                        break;
                    case "2":
                        again = false;
                        break;
                    default:
                        Console.WriteLine("输入错误");
                        break;

                }
            }
        }
    }

}
