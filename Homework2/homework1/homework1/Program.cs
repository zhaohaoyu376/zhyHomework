using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace homework1
{
    class Maths
    {
        private int num;

        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("输入有误");
                }
                else
                {
                    num = value;
                }
            }
        }


        public static bool isPrime(int num)
        {
            if (num < 2)
                return false;
            if (num == 2 || num == 3)
            {
                return true;
            }
            if (num % 6 != 1 && num % 6 != 5)
            {
                return false;
            }
            int sqr = (int)Math.Sqrt(num);
            for (int i = 5; i <= sqr; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }


        public void Answer(int num)
        {   
            for(int i = 2; i < num; i++)
            {
                if(num%i==0 && isPrime(i) == true)
                {
                    Console.WriteLine(i);
                }
            }

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Maths maths = new Maths();
            Console.WriteLine("输入数");
            maths.Num = Convert.ToInt32(Console.ReadLine());
            maths.Answer(maths.Num);    
            Console.ReadLine();
        }
    }
}
