using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 技能冷却
{
    internal class Program
    {
        struct CD
        {
            public int cd;
            public int cost;
        }
        static void Main(string[] args)
        {
            int n, m, k;
            string[] input = Console.ReadLine().Split(' ');
            n = Convert.ToInt32(input[0]);
            m = Convert.ToInt32(input[1]);
            k = Convert.ToInt32(input[2]);
            CD[] CDs = new CD[n];
            for (int i = 0; i < n; i++) 
            {
                input = Console.ReadLine().Split(' ');
                CDs[i].cd = Convert.ToInt32(input[0]);
                CDs[i].cost = Convert.ToInt32(input[1]);
            }
            Array.Sort(CDs, (a, b) =>
            {
                return a.cd > b.cd ? -1 : 1;
            });
            while(m >= CDs[0].cost)
            {
                if (CDs[0].cd == k)
                {
                    break;
                }
                else
                {
                    m -= CDs[0].cost;
                    CDs[0].cd --;
                    Array.Sort(CDs, (a, b) =>
                    {
                        return a.cd > b.cd ? -1 : 1;
                    });
                }
            }
            Console.WriteLine(CDs[0].cd);
        }
    }
}
