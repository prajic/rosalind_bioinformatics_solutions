using System;
using Utils;

namespace RosalindTasks
{
    public static class BA4B
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Protein Translation Problem


            // URL: http://rosalind.info/problems/ba4b/

            Console.WriteLine("Example: BA4B");

            var firstExample = Constants.BA4BFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.GetEncodedPeptide(firstExample);
            Console.WriteLine("Result: ");
            Service.WriteOutput(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA4BSecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.GetEncodedPeptide(secondExample);
            // Service.WriteOutput(secondResult)
        }
    }
}
