using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3J
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: String Reconstruction from Read-Pairs Problem

            // URL: http://rosalind.info/problems/ba3j/

            Console.WriteLine("Example: BA3J");

            var firstExample = Constants.BA3JFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.ReconstructStringFromReadPairsComposition(firstExample);
            Console.WriteLine("Result: ");
            Console.WriteLine(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA3JSecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.ReconstructStringFromReadPairsComposition(secondExample);
            // Console.WriteLine(secondResult);
        }
    }
}
