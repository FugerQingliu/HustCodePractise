using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace 变换
{
    internal class Program
    {
        struct Transform
        {
            public int type;
            public float value;
        }
        struct Node
        {
            public int i;
            public int j;
            public long x;
            public long y;
        }
        static void Main(string[] args)
        {
            int n = 0, m = 0;
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);
            Transform[] transforms = new Transform[n + 1];
            for(int i = 1; i < n+1;i++)
            {
                input = Console.ReadLine().Split(' ');
                transforms[i].type = int.Parse(input[0]);
                transforms[i].value = float.Parse(input[1]);
            }
            Node[] nodes = new Node[m];
            for(int i = 0; i< m ;i++)
            {
                input = Console.ReadLine().Split(' ');
                nodes[i].i = int.Parse(input[0]);
                nodes[i].j = int.Parse(input[1]);
                nodes[i].x = long.Parse(input[2]);
                nodes[i].y = long.Parse(input[3]);
            }
            for(int i = 0;i<m; i++)
            {
                float k = 1f , th = 0;
                for(int j = nodes[i].i; j <= nodes[i].j; j++)
                {
                    switch (transforms[j].type)
                    {
                        case 1:
                            k *= transforms[j].value; break;
                        case 2:
                            th += transforms[j].value;break;
                    }
                }
                Console.WriteLine(k*(nodes[i].x * Math.Cos(th) - nodes[i].y * Math.Sin(th)) + " " + k * (nodes[i].x *Math.Sin(th) + nodes[i].y * Math.Cos(th)));
            }
        }
    }
}
