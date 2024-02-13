using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Q_MMORPG
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0 , m = 0 , k = 0 ; 
            string[] temp =Console.ReadLine().Split();
            n = Convert.ToInt32(temp[0]);
            m = Convert.ToInt32(temp[1]);
            k = Convert.ToInt32(temp[2]);
            ArrayList yesterdayNode = new ArrayList();
            ArrayList newFoundNode = new ArrayList();
            for (int i = 0 ; i < n ; i++) 
            {
                yesterdayNode.Add(Console.ReadLine());
            }
            for (int i = 0 ;i < m ; i++) 
            {
                yesterdayNode.Remove(Console.ReadLine());
            }
            for(int i = 0 ;i < k; i++)
            {
                yesterdayNode.Add(Console.ReadLine());
            }
            yesterdayNode.Sort();
            for (int i = 0;i < yesterdayNode.Count;i++)
            {
                Console.WriteLine(yesterdayNode[i].ToString());
            }
        }
    }
}
