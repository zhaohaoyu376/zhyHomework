
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            //录入行和列，为接下来接收数组做准备
            int hang = Convert.ToInt32(Console.ReadLine());
            int lie = Convert.ToInt32(Console.ReadLine());
            int[,] a = new int[hang, lie];

            Console.WriteLine("请输入二维数组：");
            for (int i = 0; i < hang; i++)
            {
                string str = Console.ReadLine();
                string[] tmp = str.Split(" ".ToCharArray());
                for (int j = 0; j < lie; j++)
                {
                    a[i, j] = int.Parse(tmp[j]);//将分割后的字符付给二维数组每个元素
                }
            }

            //输出二维数组
            bool answer = true;
            for (int i = 0; i < hang-1; i++)
            {
                for (int j = 0; j < lie-1; j++)
                {
                    if (a[i, j] != a[i + 1, j + 1])
                    {
                        answer = false;
                    }
                }           
            }

            if (answer)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }

}

