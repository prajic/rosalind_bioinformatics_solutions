using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3E
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: De Bruijn Graph from k-mers Problem
            // Rosalind ID: BA3D
            // URL: http://rosalind.info/problems/ba3e/

            Console.WriteLine("Example: BA3E");

            var firstExample = Constants.BA3EFirstExample;
            Service.WriteOutput(firstExample);

            var firstResult = Service.DeBruijnGraph(firstExample);
            Console.WriteLine("Result: ");
            Service.WriteGraph(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA3ESecondExample;
            // Service.WriteOutput(secondExample);

            // var secondResult = Service.DeBruijnGraph(secondExample);
            // Service.WriteGraph(secondResult);
        }
    }
}
