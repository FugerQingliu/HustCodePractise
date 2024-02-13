using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 写着玩玩
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 1, 2, 3, 4 };
            for(int i = 0; i < ints.Length; i++)
            {
                Console.WriteLine(ints[i]);
            }
            Array.Reverse(ints);
            for(int i = 0;i < ints.Length; i++)
            {
                Console.WriteLine(ints[i]);
            }
        }
    }
}
