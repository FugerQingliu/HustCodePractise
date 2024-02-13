using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 测试负数读取
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int i = int.Parse(input[0]);
            int j = int.Parse(input[1]);
            int n = int.Parse(input[2]);
            int m = int.Parse(input[3]);
            Console.WriteLine(i+" " + j+" "+n + " " + m);
        }
    }
}
