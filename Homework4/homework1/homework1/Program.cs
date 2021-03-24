using System;

namespace homework1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t) { Next = null; Data = t; }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }


        public void ForEach(Action<T> action)
        {
            Node<T> a = head;
            do
            {
                action(a.Data);
                a = a.Next;
            } while (a != null);
        }
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }

            Console.WriteLine("所有的元素");

            int all = 0;

            Action<int> action = delegate (int item)
            {
                Console.WriteLine(item);
                all = all + item;
            };

            intlist.ForEach(action);
            int max = int.MinValue;
            int min = int.MaxValue;

            intlist.ForEach(m => { if (m > max) { max = m; } });

            intlist.ForEach(n => { if (n < min) { min = n; } });

            Console.WriteLine("最大");
            Console.WriteLine(max);
            Console.WriteLine("最小");
            Console.WriteLine(min);
            Console.WriteLine("全部");
            Console.WriteLine(all);





        }
    }
}
