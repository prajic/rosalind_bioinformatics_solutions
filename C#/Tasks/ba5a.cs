using System;
using Utils;

namespace RosalindTasks
{
    public static class BA5A
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: The Change Problem

            // URL: http://rosalind.info/problems/ba5a/

            Console.WriteLine("Example: BA5A");

            var firstExample = Constants.BA5AFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.GetChange(firstExample);
            Console.WriteLine("Result: ");
            Console.WriteLine(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA5ASecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.GetChange(secondExample);
            // Console.WriteLine(secondResult)
            
        }
    }
}
