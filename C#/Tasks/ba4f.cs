using System;
using Utils;

namespace RosalindTasks
{
    public static class BA4F
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Cyclic Peptide Scoring Problem

            // URL: http://rosalind.info/problems/ba4f/

            Console.WriteLine("Example: BA4F");

            var firstExample = Constants.BA4FFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.GetCyclicPeptideScore(firstExample);
            Console.WriteLine("Result: ");
            Console.WriteLine(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA4FSecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.GetCyclicPeptideScore(secondExample);
            // Console.WriteLine(secondResult)
        }
    }
}
