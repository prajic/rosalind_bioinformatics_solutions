using System;
using Utils;

namespace RosalindTasks
{
    public static class BA1N
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Generate the d-Neighborhood of a String

            // Rosalind ID: BA1N
            // URL: http://rosalind.info/problems/ba1n/

            Console.WriteLine("Example: BA1N");

            var firstExample = Constants.BA1NFirstExample;
            Console.WriteLine(firstExample);

            var firstResult = Service.GenerateDNeighborhood(firstExample);
            Service.WriteOutput(firstResult);

            Console.WriteLine("Second example:");

            var secondExample = Constants.BA1NSecondExample;
            Console.WriteLine(secondExample);

            var secondResult = Service.GenerateDNeighborhood(secondExample);
            Service.WriteOutput(secondResult);
        }
    }
}
