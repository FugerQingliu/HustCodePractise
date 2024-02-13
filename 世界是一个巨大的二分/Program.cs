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
            int cnt = 0 , left = 0 , right = 0 , middle = 0;
            bool flag = false;
            for(int i = 0; i < m ; i++)
            {
                switch (checks[i].ty)
                {
                    case 1:
                        cnt = 0;
                        flag = false;
                        for(left = 0 , right = n - 1; left <= right;)
                        {
                            middle = (left + right) / 2;
                            if (ints[middle] > checks[i].x)
                                right = middle - 1;
                            else if (ints[middle] < checks[i].x)
                                left = middle + 1;
                            else
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            for (int j = middle; j < n; j++)
                            {
                                if (ints[j] == checks[i].x)
                                    cnt++;
                                else
                                    break;
                            }
                            for (int j = middle-1; j >= 0; j--)
                            {
                                if (ints[j] == checks[i].x)
                                    cnt++;
                                else
                                    break;
                            }
                        }
                        answer[i] = cnt;
                        break;
                    case 2:
                        cnt = 0;
                        flag = false;
                        for (left = 0, right = n - 1; left <= right;)
                        {
                            middle = (left + right) / 2;
                            if (ints[middle] < checks[i].x)
                                left = middle + 1;
                            else if (ints[middle] > checks[i].y)
                                right = middle - 1;
                            else
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            for (int j = middle; j < n; j++)
                            {
                                if (ints[j] <= checks[i].y)
                                    cnt++;
                                else
                                    break;
                            }
                            for (int j = middle-1; j >= 0; j--)
                            {
                                if (ints[j] >= checks[i].x)
                                    cnt++;
                                else
                                    break;
                            }
                        }
                        answer[i] = cnt;
                        break;
                    case 3:
                        cnt = 0;
                        flag = false;
                        for (left = 0, right = n - 1; left <= right;)
                        {
                            middle = (left + right) / 2;
                            if (ints[middle] < checks[i].x)
                                left = middle + 1;
                            else if (ints[middle] >= checks[i].y)
                                right = middle - 1;
                            else
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            for (int j = middle; j < n; j++)
                            {
                                if (ints[j] < checks[i].y)
                                    cnt++;
                                else
                                    break;
                            }
                            for (int j = middle - 1; j >= 0; j--)
                            {
                                if (ints[j] >= checks[i].x)
                                    cnt++;
                                else
                                    break;
                            }
                        }
                        answer[i] = cnt;
                        break;
                    case 4:
                        cnt = 0;
                        flag = false;
                        for (left = 0, right = n - 1; left <= right;)
                        {
                            middle = (left + right) / 2;
                            if (ints[middle] <= checks[i].x)
                                left = middle + 1;
                            else if (ints[middle] > checks[i].y)
                                right = middle - 1;
                            else
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            for (int j = middle; j < n; j++)
                            {
                                if (ints[j] <= checks[i].y)
                                    cnt++;
                                else
                                    break;
                            }
                            for (int j = middle - 1; j >= 0; j--)
                            {
                                if (ints[j] > checks[i].x)
                                    cnt++;
                                else
                                    break;
                            }
                        }
                        answer[i] = cnt;
                        break;
                    case 5:
                        cnt = 0;
                        flag = false;
                        for (left = 0, right = n - 1; left <= right;)
                        {
                            middle = (left + right) / 2;
                            if (ints[middle] <= checks[i].x)
                                left = middle + 1;
                            else if (ints[middle] >= checks[i].y)
                                right = middle - 1;
                            else
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            for (int j = middle; j < n; j++)
                            {
                                if (ints[j] < checks[i].y)
                                    cnt++;
                                else
                                    break;
                            }
                            for (int j = middle - 1; j >= 0; j--)
                            {
                                if (ints[j] > checks[i].x)
                                    cnt++;
                                else
                                    break;
                            }
                        }
                        answer[i] = cnt;
                        break;
                }
            }
            foreach (int i in answer)
                Console.WriteLine(i);
        }
    }
}
