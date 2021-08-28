using System;
using Utils;

namespace RosalindTasks
{
    public static class BA4D
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Counting Peptides with Given Mass Problem

            // URL: http://rosalind.info/problems/ba4c/

            Console.WriteLine("Example: BA4D");

            var firstExample = Constants.BA4DFirstExample;
            Console.WriteLine(firstExample);

            var firstResult = Service.ComputeNumberOfPeptides(firstExample);
            Console.WriteLine("Result: ");
            Console.WriteLine(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA4DSecondExample;
            // Console.WriteLine(secondExample);

            // var secondResult = Service.ComputeNumberOfPeptides(secondExample);
            // Console.WriteLine(secondResult)
        }
    }
}
