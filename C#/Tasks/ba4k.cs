using System;
using Utils;

namespace RosalindTasks
{
    public static class BA4K
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Linear Peptide Scoring Problem

            // URL: http://rosalind.info/problems/ba4k/

            Console.WriteLine("Example: BA4K");

            var firstExample = Constants.BA4KFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.GetLinearPeptideScore(firstExample);
            Console.WriteLine("Result: ");
            Console.WriteLine(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA4KSecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.GetLinearPeptideScore(secondExample);
            // Console.WriteLine(secondResult)
            
        }
    }
}
