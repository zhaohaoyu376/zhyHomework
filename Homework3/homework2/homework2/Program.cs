using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace homework2
{


    abstract class Shape
    {
        public abstract double calArea();
        public abstract void legal();
    }
    //具体产品子类
    class Rectanglee : Shape
    {
        private double chang;
        private double kuan;
        public static bool judge;

        public double Chang
        {
            get { return chang; }
            set { chang = value; }
        }

        public double Kuan
        {
            get { return kuan; }
            set { kuan = value; }
        }

        public Rectanglee(double chang, double kuan)
        {
            this.chang = chang;
            this.kuan = kuan;
        }

        public override void legal() { if (chang <= 0 && kuan <= 0) { judge = false; } judge = true; }
        public override double calArea() { if (chang <= 0 || kuan <= 0) { return 0; }; return chang * kuan; }


    }

    class Square : Shape
    {
        private double chang;
        public static bool judge;

        public double Chang
        {
            get { return chang; }
            set { chang = value; }
        }
        public Square(double chang)
        {
            this.chang = chang;
        }
        public override void legal() { if (chang <= 0) { judge = false; } judge = true; }
        public override double calArea() { if (chang <= 0) { return 0; } return chang * chang; }

    }

    class Triangle : Shape
    {
        private double chang1;
        private double chang2;
        private double chang3;
        public static bool judge;
        public double Chang1
        {
            get { return chang1; }
            set { chang1 = value; }
        }
        public double Chang2
        {
            get { return chang2; }
            set { chang2 = value; }
        }
        public double Chang3
        {
            get { return chang3; }
            set { chang3 = value; }
        }
        public Triangle(double chang1, double chang2, double chang3)
        {
            this.chang1 = chang1;
            this.chang2 = chang2;
            this.chang3 = chang3;
        }
        public override void legal() { if (chang1 + chang2 < chang3 && chang2 + chang3 < chang1 && chang1 + chang3 < chang2) { judge = false; } judge = true; }
        public override double calArea()
        {
            if (chang1 + chang2 < chang3 || chang2 + chang3 < chang1 || chang1 + chang3 < chang2)
            {
                return 0;
            }
            double s = (chang1 + chang2 + chang3) / 2;
            return Math.Sqrt(s * (s - chang1) * (s - chang2) * (s - chang3));
        }
    }


    //抽象工厂类
    abstract class Factory
    {
        public abstract Shape getShape(int shape);
    }
    //具体工厂
    class LeiFactory : Factory
    {
        public override Shape getShape(int shape)
        {
            switch (shape)
            {
                case 1:
                    return (new Square(10));
                case 2:
                    return (new Rectanglee(3,4));
                case 3:
                    return (new Triangle(3,4,5));
            }
            return new Square(0);
        }
}



    class Program
    {
        //使用工厂方法
        static void Main(string[] args)
        {
            double answer=0;
            for (int i = 0; i < 10; i++)
            {

                Random rd = new Random();
                Factory fact = new LeiFactory();
                Shape lei = fact.getShape(rd.Next(1,3));
                answer = answer + lei.calArea();
            }
            Console.WriteLine(answer);


        }
    }
}
//抽象产品基类

