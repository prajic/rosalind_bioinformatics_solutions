using System;
using Utils;

namespace RosalindTasks
{
    public static class BA2B
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Median String Problem

            // Rosalind ID: BA2B
            // URL: http://rosalind.info/problems/ba2b/

            Console.WriteLine("Example: BA2B");

            var firstExample = Constants.BA2BFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.FindMedianString(firstExample);
            Console.WriteLine(firstResult);

            Console.WriteLine("Second example:");

            var secondExample = Constants.BA2BSecondExample;
            Console.WriteLine(secondExample.ToString());

            var secondResult = Service.FindMedianString(secondExample);
            Console.WriteLine(secondResult);
        }
    }
}
