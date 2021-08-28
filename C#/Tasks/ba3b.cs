using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3B
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: String Spelled by a Genome Path Problem
            // Rosalind ID: BA3B
            // URL: http://rosalind.info/problems/ba3b/

            Console.WriteLine("Example: BA3B");

            var firstExample = Constants.BA3BFirstExample;
            Service.WriteOutput(firstExample);

            var firstResult = Service.ReconstructStringFromGenome(firstExample);
            Console.WriteLine(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA3BSecondExample;
            // Service.WriteOutput(secondExample);
            // Console.WriteLine();
            
            // var secondResult = Service.ReconstructStringFromGenome(secondExample);
            // Console.WriteLine(secondResult);
        }
    }
}
