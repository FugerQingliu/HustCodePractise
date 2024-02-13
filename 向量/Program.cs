using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 向量
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vectorNum = 0 , vectorDismen = 0 ;
            string[] input = Console.ReadLine().Split(' ');
            vectorNum = Convert.ToInt32(input[0]);
            vectorDismen = Convert.ToInt32(input[1]);
            int[,] vectorArray = new int[vectorNum + 1,vectorDismen];
            for (int i = 1; i < vectorNum+1; i++)
            {
                input = Console.ReadLine().Split(' ');
                for(int j = 0; j < vectorDismen; j++)
                {
                    vectorArray[i,j] = Convert.ToInt32(input[j]);
                }
            }
            for(int i = 1;i < vectorNum+1; i++)
            {
                bool flagI = false;
                for(int j = 1; j < vectorNum+1; j++)
                {
                    bool flagJ = true;
                    for(int k = 0; k < vectorDismen; k++)
                    {
                        if (vectorArray[i, k] < vectorArray[j, k])
                            continue;
                        else
                        {
                            flagJ = false;
                            break;
                        }
                    }
                    if (flagJ)
                    {
                        Console.WriteLine(j);
                        flagI = true;
                        break;
                    }
                }
                if(!flagI)
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
