
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace homework3
{

    class Program
    {
        private static void Prime(int b)
        {
            for (int i = 2; i < b; i++)
            {
                if (st(i) == true)
                {
                    Console.WriteLine("{0}",i);
                }
            }
        }

        static bool st(int n)          //判断一个数n是否为质数
        {
            int m = (int)Math.Sqrt(n);  
            for (int i = 2; i <= m; i++)
            {
                if (n % i == 0 && i != n)
                    return false;
            }
            return true;
        }
    
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Prime(num);
            Console.ReadKey();

        }
    }
}
