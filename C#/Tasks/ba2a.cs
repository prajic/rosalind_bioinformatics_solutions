using System;
using Utils;

namespace RosalindTasks
{
    public static class BA2A
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Implement MotifEnumeration

            // Rosalind ID: BA2A
            // URL: http://rosalind.info/problems/ba2a/

            Console.WriteLine("Example: BA2A");

            var firstExample = Constants.BA2AFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.MotifEnumeration(firstExample);
            Service.WriteOutput(firstResult);

            Console.WriteLine("Second example:");

            var secondExample = Constants.BA2ASecondExample;
            Console.WriteLine(secondExample.ToString());

            var secondResult = Service.MotifEnumeration(secondExample);
            Service.WriteOutput(secondResult);
        }
    }
}
