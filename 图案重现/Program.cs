using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图案重现
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Dictionary<string,int> penis = new Dictionary<string,int>();
            string input = null;
            for (int j = 0; j < n; j++)
            {
                input = null;
                for (int i = 0; i < 8; i++)
                {
                    input += Console.ReadLine();
                }
                if (penis.ContainsKey(input))
                {
                    penis[input]++;
                    Console.WriteLine(penis[input]);
                }
                else
                {
                    penis.Add(input, 1);
                    Console.WriteLine(1);
                }
            }
        }
    }
}
