using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT中国课程报告
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bookNum = 0, myHeight = 0;
            string[] input = Console.ReadLine().Split(' ');
            bookNum = Convert.ToInt32(input[0]);
            myHeight = Convert.ToInt32(input[1]);
            List<int> bookHeight  = new List<int>();
            for(int i = 0; i < bookNum; i++) 
            {
                bookHeight.Add(Convert.ToInt32(Console.ReadLine()));
            }
            bookHeight.Sort();
            bookHeight.Reverse();
            int sumHeight = 0;
            int cnt = 0;
            for( cnt = 0; cnt < bookHeight.Count;cnt++)
            {
                sumHeight += bookHeight[cnt];
                if(sumHeight > myHeight)
                {
                    break;
                }
            }
            Console.WriteLine(cnt +1);
        }
    }
}
