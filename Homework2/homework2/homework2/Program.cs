using System;

namespace homework2
{


    class Program
    {
        static void Main(string[] args)
        {
            int all=0;
            int average=0;
            int max;
            int min;

            string value = Console.ReadLine();

            //用标点分开
            string[] vals = value.Split(' ');

            //输出并转化为int数组
            Console.WriteLine("分开展示各值");
            int[] num = new int[vals.Length];
            num[0] = int.Parse(vals[0]);
            max = num[0];
            min = num[0];
            for (int i = 0; i < vals.Length; i++)
            {
                num[i] = int.Parse(vals[i]);
                all = all + num[i];
                if (num[i] > max)
                {
                    max = num[i];
                }
                if (num[i] < min)
                {
                    min = num[i];
                }
            }
            average = all / num.Length;

            Console.WriteLine("{0}", max);
            Console.WriteLine("{0}", min);
            Console.WriteLine("{0}", average);
            Console.WriteLine("{0}", all);

        }
    }
}
