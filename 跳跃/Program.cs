using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 跳跃
{
    internal class Program
    {
        struct Vector
        {
            public int x;
            public int y;
            public static Vector operator +(Vector a, Vector b)
            {
                Vector v = new Vector();
                v.x = a.x + b.x;
                v.y = a.y + b.y;
                return v;
            }
        }
        static void Main(string[] args)
        {
            int n, m;
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);
            Vector[] vectorArray = new Vector[n];
            for(int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(' ');
                vectorArray[i].x = int.Parse(input[0]);
                vectorArray[i].y = int.Parse(input[1]);
            }
            Vector[] vectors = new Vector[m];
            for (int i = 0; i < m; i++)
            {
                input = Console.ReadLine().Split(' ');
                vectors[i].x = int.Parse(input[0]);
                vectors[i].y = int.Parse(input[1]);
            }
            for(int i = 0;i < m; i++) 
            {
                for(int j = 0; j < n; j++)
                {
                    vectors[i] += vectorArray[j];
                }
            }
            for(int i = 0; i < m; i++)
            {
                Console.WriteLine(vectors[i].x + " " + vectors[i].y);
            }
        }
    }
}
