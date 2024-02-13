using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_方程求解
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //获得n和Q
            int equationNum = 0, askTimes = 0;
            string temp = Console.ReadLine();
            equationNum = Convert.ToInt32(temp.Split()[0]);
            askTimes = Convert.ToInt32(temp.Split()[1]);
            //读取方程组，顺便把它拆成3个数,顺便把结果算出来
            long [] ints = new long[3];
            long[] result = new long[equationNum];
            string[] intss = new string[4];
            ArrayList intsString = new ArrayList();
            for (int i = 0; i < equationNum;i++)
            {
                temp = Console.ReadLine();
                intss = temp.Split('x', '=', '+');
                for (int j = 0;j < intss.Length; j++)
                {
                    intsString.Add(intss[j]);
                }
                intsString.Remove("");
                ints[0] = Convert.ToInt64(intsString[0]);
                ints[1] = Convert.ToInt64(intsString[1]);
                ints[2] = Convert.ToInt64(intsString[2]);
                result[i] = (ints[2] - ints[1]) / ints[0];
                for (int j = 0; j < intss.Length; j++)
                {
                    intsString.Remove(intss[j]);
                }
            }
            //先排个序
            QuickSort(result, 0, result.LongLength-1);
            //读取L和R，并直接开始比较，顺便记录
            long l = 0, lNum = 0, rNum = 0, bak = result.LongLength-1, r = 0;
            long count = 0;
            long[] answer = new long[askTimes];
            for (int i = 0; i < askTimes; i ++)
            {
                lNum = count = 0;
                rNum = bak;
                temp = Console.ReadLine() ;
                l = Convert.ToInt32(temp.Split()[0]);
                r = Convert.ToInt32(temp.Split()[1]);
                while (l > result[lNum])
                {
                    lNum++;
                }
                while (r < result[rNum]) 
                { 
                    rNum--; 
                }
                while(lNum <= rNum)
                {
                    if (lNum > 0)
                    {
                        if (result[lNum] != result[lNum - 1]) count++;
                    }
                    else count++;
                    lNum++;
                }
                answer[i] = count;
            }
            for (int i = 0;i < askTimes; i ++)
            {
                    Console.WriteLine(answer[i]);
            }
        }
        static void QuickSort(long[] A, long lo, long hi)
        {
            if (lo > hi)//递归退出条件
            {
                return;
            }
            long i = lo;
            long j = hi;
            long temp = A[i];//取得基准数，空出一个位置
            while (i < j)//当i=j时推出，表示temp左边的数都比temp小，右边的数都比temp大
            {
                while (i < j && temp <= A[j])//从后往前找比temp小的数，将比temp小的数往前移
                {
                    j--;
                }
                A[i] = A[j];//将比基准数小的数放在空出的位置，j的位置又空了出来
                while (i < j && temp >= A[i])//从前往后找比temp大的数，将比temp大的数往后移
                {
                    i++;
                }
                A[j] = A[i];//将比基准数大的数放在hi空出来的位置,如此，i所在的位置又空了出来
            }
            A[i] = temp;
            QuickSort(A, lo, i - 1);//对lo到i-1之间的数再使用快速排序，每次快速排序的结果是找到了基准数应该在的位置
            //其左边的数都<=它，右边的数都>=它，它此时在数组中的位置就是排序好时其应该在的位置。
            QuickSort(A, i + 1, hi);//对i+1到hi之间的数再使用快速排序
        }
    }
}
