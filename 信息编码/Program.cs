using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 信息编码
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            string[] input = Console.ReadLine().Split(' ');
            n = Convert.ToInt32(input[0]);
            m = Convert.ToInt32(input[1]);
            int[] a = new int[n];
            input = Console.ReadLine().Split(' ');
            for(int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(input[i]);
            }
            int[] c = new int[n+1];
            c[0] = 1;
            for(int i = 1; i < n+1;i++)
            {
                c[i] = c[i-1]*a[i-1];
            }
            int[] b = new int[n];
            for(int i = 0;i < n;i++)
            {
                b[i] = (m % c[i+1] - m % c[i])/c[i];
            }
            foreach(int i in b)
            {
                Console.Write(i+ " ");
            }
        }
    }
}
