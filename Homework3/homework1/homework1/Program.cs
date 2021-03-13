using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    public interface Shape
    {
        public abstract double calArea();
        public abstract void legal();
    }

    public class Rectanglee : Shape
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

        public Rectanglee(double chang,double kuan)
        {
            this.chang = chang;
            this.kuan = kuan;
        }

        public void legal() { if (chang <= 0 && kuan <= 0) { judge=false; } judge= true; }
        public  double calArea() { if (chang <= 0 || kuan <= 0) { return 0; }; return chang * kuan; }


    }

    public class Square : Shape 
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
        public void legal() { if (chang <= 0) { judge = false; } judge = true; }
        public double calArea() { if (chang <= 0) { return 0; } return chang * chang; }

    }
    
    public class Triangle : Shape 
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
            set { chang3= value; }
        }
        public Triangle(double chang1,double chang2 ,double chang3)
        {
            this.chang1 = chang1; 
            this.chang2 = chang2; 
            this.chang3 = chang3; 
        }
        public void legal() { if (chang1 + chang2 < chang3 && chang2 + chang3 < chang1 && chang1 + chang3 < chang2) {   judge= false; } judge =true; }
        public double calArea() 
        {   
            if(chang1 + chang2 < chang3 || chang2 + chang3 < chang1 || chang1 + chang3 < chang2)
            {
                return 0;
            }
            double s =  (chang1+chang2 +chang3)/2;  
            return Math.Sqrt(s* ( s- chang1) * (s - chang2) * (s - chang3));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Shape square = new Square(10);
            Console.WriteLine(square.calArea());
            Shape rectanglee = new Rectanglee(-2, 3);
            Console.WriteLine(rectanglee.calArea());
            Shape triangle = new Triangle(3, 4, 5);
            Console.WriteLine(triangle.calArea());

        }
    }
}
