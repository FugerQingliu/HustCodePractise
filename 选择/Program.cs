using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 选择
{
    internal class Program
    {
        static int numCount = 0, waysCount = 0, chooseNum = 0;
        static void Main(string[] args)
        {
            // 初步收集信息
            string[] input = Console.ReadLine().Split(' ');
            numCount = Convert.ToInt32(input[0]);
            chooseNum = Convert.ToInt32(input[1]);
            // 第二级收集表信息
            input = Console.ReadLine().Split(' ');
            int[] givenNumList = new int[numCount];
            int allNum = 0 , temp = 0 ;
            for(int i = 0; i < numCount; i++)
            {
                temp = Convert.ToInt32(input[i]);
                allNum += temp;
                givenNumList[i] = temp;
            }
            // 造一个质数表
            bool[] primeNumberList = new bool[allNum + 1];
            for(int i = 0;i < allNum + 1; i++)
            {
                primeNumberList[i] = true;
            }
            primeNumberList[0] = false;
            primeNumberList[1] = false;
            for(int i = 0;i * i <= allNum ; i++) 
            {
                if (primeNumberList[i])
                {
                    for(int j = i * i; j <= allNum ; j += i) 
                    {
                        primeNumberList[j] = false;
                    }
                }
            }
            // 因为要所有可能，那就暴力遍历出所有可能 
            int iterationCount = 0;
            ArrayList arrayList = Violence(primeNumberList, givenNumList, iterationCount, 0);
            // 检查所有可能性是否是质数
            for(int i = 0; i < arrayList.Count ; i++)
            {
                if (primeNumberList[(int)arrayList[i]])
                        waysCount++;
            }
            Console.WriteLine(waysCount);
        }
        // 暴力用的函数，用了递归来实现所有组合
        static public ArrayList Violence(bool[]primeNumberList , int[]givenNumber ,int iterationCount,int aheadNumber)
        {
            int temp = 0;
            ArrayList returnAnswer = new ArrayList();
            if(iterationCount == 0)
            {
                for (int i = aheadNumber; i < numCount - chooseNum + iterationCount + 1; i++)
                {
                    temp = givenNumber[i];
                    ArrayList nextItrationReturn = Violence(primeNumberList, givenNumber, iterationCount + 1, i);
                    for (int j = 0; j < nextItrationReturn.Count; j++)
                    {
                        temp += (int)nextItrationReturn[j];
                        returnAnswer.Add(temp);
                        temp = givenNumber[i];
                    }
                }
            }
            else if(iterationCount != chooseNum-1)
            {
                for(int i = aheadNumber + 1; i < numCount - chooseNum + iterationCount + 1; i++)
                {
                    temp = givenNumber[i];
                    ArrayList nextItrationReturn = Violence(primeNumberList, givenNumber , iterationCount + 1, i);
                    for(int j = 0; j < nextItrationReturn.Count; j++)
                    {
                        temp += (int) nextItrationReturn[j];
                        returnAnswer.Add(temp);
                        temp = givenNumber[i];
                    }
                }
            }
            else
            {
                for (int i = aheadNumber + 1;i < numCount - chooseNum + iterationCount + 1 ; i++)
                {
                    returnAnswer.Add(givenNumber[i]);
                }
            }
            return returnAnswer ;
        }
    }
}
