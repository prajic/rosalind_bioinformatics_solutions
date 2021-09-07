using System;
using Utils;

namespace RosalindTasks
{
    public static class BA6A
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Implement GreedySorting

            // URL: http://rosalind.info/problems/ba5a/

            Console.WriteLine("Example: BA6A");

            var firstExample = Constants.BA6AFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.GreedySort(firstExample);
            Console.WriteLine("Result: ");
            Service.WriteOutputToLines(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA6ASecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.GetChange(secondExample);
            // Service.WriteOutputToLines(secondResult);
            
        }
    }
}
