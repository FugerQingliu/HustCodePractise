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
            int n, q;
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            q = int.Parse(input[1]);
            List<int> answer = new List<int>();
            for(int i = 0; i < n; i++)
            {
                input =Console.ReadLine().Split('x','=');
                int num = (int.Parse(input[2]) - int.Parse(input[1])) / int.Parse(input[0]);
                if (!answer.Contains(num))
                    answer.Add(num);
            }
            answer.Sort();
            for(int i = 0; i < q; i++)
            {
                input = Console.ReadLine().Split(' ');
                Console.WriteLine(BiggerSearch2(answer, int.Parse(input[1])) - BiggerSearch(answer, int.Parse(input[0])));
            }
        }
        static int BinarySearch(List<int> array,int value)
        {
            int left = 0 , right = array.Count-1;
            int middle = (left + right) / 2;
            while(left < right)
            {
                if (array[middle] == value)
                    return middle;
                else if (array[middle] < value)
                {
                    left = middle + 1;
                    middle = (left + right) / 2;
                }
                else
                {
                    right = middle - 1;
                    middle = (right + left) / 2;
                }
            }
            return middle;
        }
        static int BiggerSearch(List<int> array,int value)
        {
            int nearAddress = BinarySearch(array, value);
            if (nearAddress > 0)
            {
                while (array[nearAddress] > value)
                {
                    nearAddress--;
                }
            }
            if (nearAddress < array.Count - 1 )
            {
                while (array[nearAddress] < value)
                {
                    nearAddress++;
                }
            }
            return nearAddress;
        }
        static int BiggerSearch2(List<int> array, int value)
        {
            int nearAddress = BinarySearch(array, value);
            if (nearAddress < array.Count - 1)
            {
                while (array[nearAddress] <= value)
                {
                    nearAddress++;
                }
            }
            if (nearAddress > 0)
            {
                while (array[nearAddress] > value)
                {
                    nearAddress--;
                }
            }
            if (array[nearAddress] == value)
                return nearAddress+1;
            return nearAddress;
        }
    }
}
