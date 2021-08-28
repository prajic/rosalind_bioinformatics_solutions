using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3F
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Eulerian Cycle Problem
            // Rosalind ID: BA3F
            // URL: http://rosalind.info/problems/ba3f/

            Console.WriteLine("Example: BA3F");

            var firstExample = Constants.BA3FFirstExample;
            Service.WriteGraph(firstExample);

            var firstResult = Service.GetEulerianCycle(firstExample);
            Console.WriteLine("Result: ");
            Service.WriteEulerGraph(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA3FSecondExample;
            // Service.WriteGraph(secondExample);

            // var secondResult = Service.GetEulerianCycle(secondExample);
            // Console.WriteLine("Result: ");
            // Service.WriteEulerGraph(secondResult);
        }
    }
}
