using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_小S与NLP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0 , m = 0 ;
            string[] temp = Console.ReadLine().Split();
            n = int.Parse(temp[0]);
            m = int.Parse(temp[1]);
            Dictionary<string,string> codeBook = new Dictionary<string, string>();
            for(int i = 0; i < n; i++) 
            {
                string[] tempCode = Console.ReadLine().Split();
                codeBook.Add('{'+tempCode[0]+'}',tempCode[1]);
            }
            string[] strings = new string[20];
            for(int i = 0;i < m; i++) 
            {
                strings[i] =  Console.ReadLine();
                //foreach (string key in codeBook.Keys)
                //{
                //    strings[i] = strings[i].Replace(key, codeBook[key]);
                //}
            }
            string superBig = null;
            for(int i = 0;i < strings.Length;i++)
            {
                superBig += strings[i] + '|';
            }
            foreach(string key in codeBook.Keys) 
            {
                superBig = superBig.Replace(key, codeBook[key]);
            }
            string[] result = superBig.Split('|');
            for (int i = 0;i < m ; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}