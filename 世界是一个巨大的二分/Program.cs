using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace 世界是一个巨大的二分
{
    class Num
    {
        public int ty = 0;
        public int x;
        public int y;
        public Num(int ty ,int x) 
        {
            this.ty = ty;
            this.x = x;
        }
        public Num(int ty, int x, int y) : this(ty, x)
        {
            this.y = y;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]), m = int.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            
            int[] ints = new int[n];
            for (int i = 0; i < n; i++)
            {
                ints[i] = int.Parse(input[i]);
            }
            Array.Sort(ints);
            List<Num> checks = new List<Num>();
            for(int i = 0;i < m; i++) 
            {
                input = Console.ReadLine().Split(' ');
                switch (int.Parse(input[0])) 
                {
                    case 1:
                        checks.Add(new Num(int.Parse(input[0]), int.Parse(input[1])));
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        checks.Add(new Num(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2])));
                        break;
                }
            }
            int[] answer = new int[m];
            int left, right;
            for (int i = 0; i < m ; i++)
            {
                switch (checks[i].ty)
                {
                    case 1:
                        left = BiggerOrEqual(ints, checks[i].x);
                        right = LessOrEqual(ints, checks[i].x);
                        if(right >= left)
                            answer[i] = right - left + 1;
                        else
                            answer[i] = 0;
                        break;
                    case 2:
                        left = BiggerOrEqual(ints, checks[i].x);
                        right = LessOrEqual(ints, checks[i].y);
                        if (right >= left)
                            answer[i] = right - left + 1;
                        else
                            answer[i] = 0;
                        break;
                    case 3:
                        left = BiggerOrEqual(ints, checks[i].x);
                        right = LessOrEqual(ints, checks[i].y);
                        while (ints[right] == checks[i].y && right > 0)
                            right--;
                        if (right > left)
                            answer[i] = right - left + 1;
                        else
                            answer[i] = 0;
                        break;
                    case 4:
                        left = BiggerOrEqual(ints, checks[i].x);
                        right = LessOrEqual(ints, checks[i].y);
                        while (ints[left] == checks[i].x && left < ints.Length - 1)
                            left ++;
                        if (right > left)
                            answer[i] = right - left + 1;
                        else
                            answer[i] = 0;
                        break;
                    case 5:
                        left = BiggerOrEqual(ints, checks[i].x);
                        right = LessOrEqual(ints, checks[i].y);
                        while (ints[right] == checks[i].y && right > 0)
                            right--;
                        while (ints[left] == checks[i].x && left < ints.Length - 1)
                            left++;
                        if (right > left)
                            answer[i] = right - left + 1;
                        else
                            answer[i] = 0;
                        break;
                }
            }
            foreach (int i in answer)
                Console.WriteLine(i);
        }
        static int BinarySearch(int[] input, int b)
        {
            int left = 0 , right = input.Length - 1 ;
            int middle = (left + right)/2 ;
            while(left < right) 
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
            if(input[given] >= b)
                return given;
            else
                return given + 1;
        }
        static int LessOrEqual(int[] input, int b)
        {
            int given = BinarySearch(input , b);
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
