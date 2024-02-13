using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 直接输出
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 获取value并转化
            // 获取value，并且换成2进制
            int value = Convert.ToInt32(Console.ReadLine());
            string transformValue = Convert.ToString(value, 2);
            #endregion
            #region 输出
            // 简单输出初始
            //for (int i = 0,cnt = 0; i < transformValue.Length; i++) 
            //{
            //    if (cnt == 0 && transformValue[i] == '1')
            //    {
            //        Console.Write('2' + "(" + (transformValue.Length - 1 - i) + ")");
            //        cnt ++;
            //    }
            //    else if (cnt != 0 && transformValue[i] == '1')
            //    {
            //        Console.Write('+');
            //        Console.Write('2' + "(" + (transformValue.Length - 1 - i) + ")");
            //    }
            //}
            // 复杂输出
            Console.WriteLine(Binary(transformValue));
            #endregion
        }
        #region 具体操作
        static string Binary(string transformValue)
        {
            string temp = null;
            for (int i = 0, cnt = 0; i < transformValue.Length; i++)
            {
                if (transformValue[i] == '1')
                {
                    if (cnt == 0 && transformValue[i] == '1' && i == transformValue.Length - 1)
                    {
                        temp = "2(0)";
                        cnt++;
                    }
                    else if (cnt != 0 && transformValue[i] == '1' && i == transformValue.Length - 1)
                        temp += "+2(0)";
                    else if (cnt == 0 && transformValue[i] == '1' && i == transformValue.Length - 2)
                    {
                        temp = "2";
                        cnt++;
                    }
                    else if (cnt != 0 && transformValue[i] == '1' && i == transformValue.Length - 2)
                    {
                        temp += "+2";
                    }
                    else if (cnt == 0 && transformValue[i] == '1')
                    {
                        cnt++;
                        temp = ('2' + "(" + Binary(TransformToBinary(transformValue.Length - 1 - i)) + ")");
                    }
                    else if (cnt != 0 && transformValue[i] == '1')
                    {
                        temp += '+' + ('2' + "(" + Binary(TransformToBinary(transformValue.Length - 1 - i)) + ")");
                    }
                }
            }
            return temp;
        }
        static string TransformToBinary(int value)
        {
            return Convert.ToString(value, 2);
        }
        #endregion
    }
}
