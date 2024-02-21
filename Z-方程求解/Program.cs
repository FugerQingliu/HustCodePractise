using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace Z_方程求解
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0 , q = 0 ;
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            q = int.Parse(input[1]);
            HashSet<int> origin = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                int num1 = 0,num2 = 0,num3 = 0;
                num1 = QuickRead();
                num2 = QuickRead();
                num3 = QuickRead();
                int temp = (num3 - num2) / num1;
                if (!origin.Contains(temp))
                    origin.Add(temp);
            }
            int count = origin.Count;
            int[] ints = origin.ToArray();
            Array.Sort(ints);
            for(int i = 0; i < q; i++)
            {
                int cnt = 0;
                int left = QuickRead();
                int right = QuickRead();
                if (right - left < 114514)
                {
                    if (count > right - left)
                    {
                        for (int j = left; j < right + 1; j++)
                        {
                            if (origin.Contains(j))
                            {
                                cnt++;
                            }
                        }
                    }
                    else
                    {
                        foreach (int j in origin)
                        {
                            if (left <= j && j <= right)
                            {
                                cnt++;
                            }
                        }
                    }
                }
                else
                {
                    int leftOrder = BiggerOrEqual(ints, left);
                    int rightOrder = LessOrEqual(ints, right);
                    if (rightOrder >= leftOrder)
                        cnt = rightOrder - leftOrder + 1;
                    else
                        cnt = 0;
                }
                Console.WriteLine(cnt);
            }
        }
        static int QuickRead()
        {
            int x = 0, f = 1;
            int ch = Console.Read();
            while(ch < '0' || ch > '9')
            {
                if (ch == '-')
                    f = -1;
                ch = Console.Read();
            }
            while(ch >= '0' && ch <= '9')
            {
                x = x  * 10 + ch - '0';
                ch = Console.Read();
            }
            return x * f;
        }
        static int BinarySearch(int[] input, int b)
        {
            int left = 0, right = input.Length - 1;
            int middle = (left + right) / 2;
            while (left < right)
            {
                if (input[middle] == b)
                    return middle;
                else if (input[middle] < b)
                {
                    left = middle + 1;
                    middle = (left + right) / 2;
                }
                else
                {
                    right = middle - 1;
                    middle = (left + right) / 2;
                }
            }
            return middle;
        }
        static int BiggerOrEqual(int[] input, int b)
        {
            int given = BinarySearch(input, b);
            while (input[given] >= b && given > 0)
                given--;
            if (input[given] >= b)
                return given;
            else
                return given + 1;
        }
        static int LessOrEqual(int[] input, int b)
        {
            int given = BinarySearch(input, b);
            int len = input.Length - 1;
            while (input[given] <= b && given < len)
                given++;
            if (input[given] <= b)
                return given;
            else
                return given - 1;
        }
    }
}
