
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ConsoleApp1
{


    class S
    {

        public static void Swap<T>(ref T t1,ref T t2)
        {

            T temp = t1;
            t1 = t2;
            t2 = temp;
        }
    }
    class Stu
    {
        public Stu() {

            name = "Hello";
            age = 22;
        }
        public Stu(string a,int b)
        {
            name = a;
            age = b;


        }
        
        public string name;
        public int age;

    }


    internal class Program
    {
     
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            Console.WriteLine("a="+a+" b="+b);

        }


    }




}
