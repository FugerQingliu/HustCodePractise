using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 走路
{
    class Block
    {
        public int color = 2;
        public Block[] blocks;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 获取棋盘信息，包括棋盘多大和棋盘有颜色的格子有多少
            int sizeOfChessBoard = 0, numberOfColoredBlock = 0;
            string[] input = Console.ReadLine().Split(' ');
            sizeOfChessBoard = int.Parse(input[0]);
            numberOfColoredBlock = int.Parse(input[1]);
            // 记录有色格子
            // 依靠金币数的深度优先搜索
            // 输出
        }
        //回头写个函数用作魔法判断
    }
}
