using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3A
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: String Composition Problem

            // Rosalind ID: BA3A
            // URL: http://rosalind.info/problems/ba3a/

            Console.WriteLine("Example: BA3A");

            var firstExample = Constants.BA3AFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.StringCompositionProblem(firstExample);
            Service.WriteOutput(firstResult);


            Console.WriteLine("Second example:");

            var secondExample = Constants.BA3ASecondExample;
            Console.WriteLine(secondExample.ToString());

            var secondResult = Service.StringCompositionProblem(secondExample);
            Service.WriteOutput(secondResult);
        }
    }
}
