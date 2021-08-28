using System;
using Utils;

namespace RosalindTasks
{
    public static class BA1M
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Implement NumberToPattern

            // Rosalind ID: BA1M
            // URL: http://rosalind.info/problems/ba1m/

            Console.WriteLine("Example: BA1M");

            var firstExample = Constants.BA1MFirstExample;
            Console.WriteLine("Number:{0}, k:{1}", firstExample.Item1, firstExample.Item2);

            var firstResult = Service.NumberToPattern(firstExample.Item1, firstExample.Item2);
            Console.WriteLine(firstResult);

            Console.WriteLine("Second example:");

            var secondExample = Constants.BA1MSecondExample;
            Console.WriteLine("Number:{0}, k:{1}", secondExample.Item1, secondExample.Item2);

            var secondResult = Service.NumberToPattern(secondExample.Item1, secondExample.Item2);
            Console.WriteLine(secondResult);
        }
    }
}
