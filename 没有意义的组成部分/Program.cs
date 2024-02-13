using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 没有意义的组成部分
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<long,int> keyValuePairs = new Dictionary<long,int>();
            int q = 0;
            q = int.Parse(Console.ReadLine());
            long[] a = new long[q];
            int[] k = new int[q];
            for(int i = 0; i < q; i++) 
            {
                string[] input = Console.ReadLine().Split(' ');
                a[i] = long.Parse(input[0]);
                k[i] = int.Parse(input[1]);
            }
            for(int i = 0;i < q; i++)
            {
                keyValuePairs.Clear();
                long j = 2;
                while (a[i]!=1 && j * j < a[i])
                {
                    if (a[i]%j == 0)
                    {
                        a[i] /= j;
                        if (!keyValuePairs.ContainsKey(j))
                        {
                            keyValuePairs.Add(j,1);
                        }
                        else
                        {
                            keyValuePairs[j] += 1;
                        }
                    }
                    else
                    {
                        j++;
                    }
                }
                long sum = 1;
                foreach(long key in keyValuePairs.Keys)
                {
                    if (keyValuePairs[key] < k[i])
                        continue;
                    else
                    {
                        sum *= (long)Math.Pow(key, keyValuePairs[key]);
                    }
                }
                Console.WriteLine(sum);
            }
        }
    }
}
