using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自动售货机
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowNum = 0, colNum = 0, merchandiseKindNum = 0;
            string[] input = Console.ReadLine().Split(' ');
            rowNum = Convert.ToInt32(input[0]);
            colNum = Convert.ToInt32(input[1]);
            merchandiseKindNum = Convert.ToInt32(input[2]);
            string[] input2 = Console.ReadLine().Split(' ');
            List<int> height = new List<int>();
            foreach (string s in input2)
            {
                height.Add(Convert.ToInt32(s));
            }
            height.Sort();
            int[] colCount = new int[rowNum+1];
            for (int i = 0; i < colCount.Length; i++)
            {
                colCount[i] = 0;
            }
            bool isBoom = false;
            foreach(int row in height)
            {
                if(row <= rowNum )
                {
                    PutMerchandise(row, colCount , colNum,ref isBoom);
                    if (isBoom)
                    {
                        Console.WriteLine("No");
                        break;
                    }
                }
                else
                {
                    PutMerchandise(rowNum, colCount , colNum , ref isBoom);
                    if (isBoom)
                    {
                        Console.WriteLine("No");
                        break;
                    }
                }
            }
            if (!isBoom)
                Console.WriteLine("Yes");
        }
        static void PutMerchandise(int row, int[] colCount , int colNum , ref bool isBoom)
        {
            if(row > 0)
            {
                if (colCount[row] < colNum) 
                {
                    colCount[row]++;
                }
                else
                {
                    PutMerchandise(row - 1, colCount, colNum,ref isBoom);
                }
            }
            else
            {
                isBoom = true;
                return;
            }
        }
        
    }
}
