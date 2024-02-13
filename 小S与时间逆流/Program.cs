using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小S与时间逆流
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //获取
            string tempWrongCulture;
            tempWrongCulture =  Console.ReadLine();
            char[] wrongCulture =tempWrongCulture.ToCharArray();
            int length = tempWrongCulture.Length;
            //重排
            ArrayList remakeCulture = new ArrayList();
            char temp;
            for (int l = 0; l < length ; l++) 
            {
                for (int r = l+1 ;r< length ; r++) 
                {
                    for(int i = l ; i < (l + r + 1)/2; i++)
                    {
                        temp = wrongCulture[i];
                        wrongCulture[i] = wrongCulture[l + r - i];
                        wrongCulture[(l + r) - i] = temp;
                    }
                    remakeCulture.Add(new string(wrongCulture));
                    wrongCulture = tempWrongCulture.ToCharArray();
                }
            }
            remakeCulture.Add(new string (wrongCulture));
            //比较排序
            remakeCulture.Sort();
            //输出最小的那个数据
            if (remakeCulture.Count > 0)
                Console.WriteLine(remakeCulture[0]);
            else
                Console.WriteLine(tempWrongCulture);
        }
    }
}

