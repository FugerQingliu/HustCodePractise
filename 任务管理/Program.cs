using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace 任务管理
{
    public class TaskTreeNode
    {
        public int[] aheadNode;
        public TaskTreeNode()
        {

        }
        public TaskTreeNode(int[] aheadNode) 
        {
            this.aheadNode = aheadNode;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int cntTask = 1;
            ArrayList needToDo = new ArrayList();
            //读取与存储
            int taskNumber = 0;
            taskNumber = Convert.ToInt32(Console.ReadLine());
            int[] tempAheadTask;
            int tempAheadTaskNumber = 0;
            TaskTreeNode[] allTask = new TaskTreeNode[taskNumber];
            for(int i = 0; i < taskNumber; i++)
            {
                allTask[i] = new TaskTreeNode();
            }
            string[] tempString;
            for(int i = 0;  i < taskNumber; i++) 
            {
                tempString = Console.ReadLine().Split(' ');
                tempAheadTaskNumber = Convert.ToInt32(tempString[0]);
                tempAheadTask = new int[tempAheadTaskNumber];
                for(int j = 0;j < tempAheadTaskNumber; j++)
                {
                    tempAheadTask[j] = Convert.ToInt32(tempString[j+1]);
                }
                if (tempAheadTaskNumber == 0)
                    tempAheadTask = new int[0];
                allTask[i].aheadNode = tempAheadTask;
            }
            //计算
            CountAheadTask(allTask, allTask[0], needToDo,ref cntTask);
            Console.WriteLine(cntTask);
        }
        static void CountAheadTask(TaskTreeNode[] allTask,TaskTreeNode node , ArrayList list , ref int cntTask)
        {
            for(int i = 0;i < node.aheadNode.Length;i++)
            {
                //避免重复作业
                if (!list.Contains(node.aheadNode[i]))
                {
                    cntTask++;
                    list.Add(node.aheadNode[i]);
                    CountAheadTask(allTask,allTask[node.aheadNode[i]-1],list,ref cntTask);
                }
            }
        }
    }
}
