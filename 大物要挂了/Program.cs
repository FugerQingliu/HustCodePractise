using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大物要挂了
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //整体思路是对于每一个科目，要筛选出二人相差时间最少的组合方案，然后取较高时间作为该科目的最终时间
            //第一步就是收集每一个科目有多少题目
            int s1 = 0 , s2 = 0 , s3 = 0, s4 = 0 ;
            string[] input = Console.ReadLine().Split(' ');
            s1 = int.Parse(input[0]);
            s2 = int.Parse(input[1]);
            s3 = int.Parse(input[2]);
            s4 = int.Parse(input[3]);
            //第二步是获取每一个科目的题目的用时是多少
            int[] question1 = new int[s1];
            int[] question2 = new int[s2];
            int[] question3 = new int[s3];
            int[] question4 = new int[s4];
            input = Console.ReadLine().Split(' ');
            for(int i = 0; i < s1; i++)
            {
                question1[i] = int.Parse(input[i]);
            }
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < s2; i++)
            {
                question2[i] = int.Parse(input[i]);
            }
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < s3; i++)
            {
                question3[i] = int.Parse(input[i]);
            }
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < s4; i++)
            {
                question4[i] = int.Parse(input[i]);
            }
            //第三步是获得相差最小的组合
            //由于需要多种组合，所以这里又要用递归了啊啊啊啊
            Console.WriteLine(SingleClassTime(question1) + SingleClassTime(question2) + SingleClassTime(question3) + SingleClassTime(question4));
        }
        //哈哈！暴力！穷举！爽！
        static ArrayList Violence(int chooseCount , int chooseLimitation , int aheadChoose , int[]question,int cnt)
        {
            ArrayList returnAnswer = new ArrayList();
            ArrayList temp;
            int addTemp = 0;
            if (cnt == 0)
            {
                if (chooseCount < chooseLimitation)
                {
                    for (int i = 0; i < question.Length - chooseLimitation + chooseCount; i++)
                    {
                        temp = Violence(chooseCount + 1, chooseLimitation, i, question, cnt + 1);
                        for (int j = 0; j < temp.Count; j++)
                        {
                            addTemp = question[i] + (int)temp[j];
                            returnAnswer.Add(addTemp);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < question.Length; i++)
                    {
                        returnAnswer.Add(question[i]);
                    }
                }
            }
            else
            {
                if (chooseCount < chooseLimitation)
                {
                    for (int i = aheadChoose + 1; i < question.Length - chooseLimitation + chooseCount; i++)
                    {
                        temp = Violence(chooseCount + 1, chooseLimitation, i, question,cnt+1);
                        for (int j = 0; j < temp.Count; j++)
                        {
                            addTemp = question[i] + (int)temp[j];
                            returnAnswer.Add(addTemp);
                        }
                    }
                }
                else
                {
                    for (int i = aheadChoose+1; i < question.Length; i++)
                    {
                        returnAnswer.Add(question[i]);
                    }
                }
            }
            return returnAnswer;
        }
        // 计算每科最短用时！
        static int SingleClassTime(int[] question)
        {
            int chooseCount = 0, aheadChoose = 0, sum = 0, time = 0 ;
            for (int i = 0; i < question.Length; i++)
                sum += question[i];
            ArrayList allList = new ArrayList();
            ArrayList difference = new ArrayList();
            for (int i = 0; i < question.Length / 2 + 1; i++)
            {
                allList.AddRange(Violence(chooseCount, i, aheadChoose, question,0));
            }
            for (int i = 0; i < allList.Count; i++)
            {
                difference.Add(Math.Abs(sum - 2 * (int)allList[i]));
            }
            difference.Sort();
            time = (sum + (int)difference[0]) / 2;
            return time;
        }
    }
}
