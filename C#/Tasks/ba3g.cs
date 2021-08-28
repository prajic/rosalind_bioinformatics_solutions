using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3G
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Eulerian Path Problem
            // Rosalind ID: BA3G
            // URL: http://rosalind.info/problems/ba3g/

            Console.WriteLine("Example: BA3G");

            var firstExample = Constants.BA3GFirstExample;
            Service.WriteGraph(firstExample);

            var firstResult = Service.GetEulerianPath(firstExample);
            Console.WriteLine("Result: ");
            Service.WriteEulerGraph(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA3GSecondExample;
            // Service.WriteGraph(secondExample);

            // var secondResult = Service.GetEulerianPath(secondExample);
            // Service.WriteEulerGraph(secondResult);
        }
    }
}
