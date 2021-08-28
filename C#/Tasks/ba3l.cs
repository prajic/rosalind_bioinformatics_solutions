using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3L
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Gapped Genome Path String Problem

            // URL: http://rosalind.info/problems/ba3l/

            Console.WriteLine("Example: BA3L");

            var firstExample = Constants.BA3LFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.GetGappedGenomePath(firstExample);
            Console.WriteLine("Result: ");
            Console.WriteLine(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA3LSecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.ReconstructStringFromReadPairsComposition(secondExample);
            // Console.WriteLine(secondResult);
        }
    }
}
