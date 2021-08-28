using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3C
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Overlap Graph Problem
            // Rosalind ID: BA3C
            // URL: http://rosalind.info/problems/ba3c/

            Console.WriteLine("Example: BA3C");

            var firstExample = Constants.BA3CFirstExample;
            Service.WriteOutput(firstExample);

            var firstResult = Service.Overlap(firstExample);
            Service.WriteGraph(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA3CSecondExample;
            // Service.WriteOutput(secondExample);
            // Console.WriteLine();

            // var secondResult = Service.Overlap(secondExample);
            // Service.WriteGraph(secondResult);
        }
    }
}
