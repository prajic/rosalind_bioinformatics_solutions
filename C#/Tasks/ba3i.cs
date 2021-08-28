using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3I
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: k-Universal Circular String Problem

            // URL: http://rosalind.info/problems/ba3i/

            Console.WriteLine("Example: BA3I");

            var firstExample = Constants.BA3IFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.FindKUniversalCircularString(firstExample);
            Console.WriteLine("Result: ");
            Console.WriteLine(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA3ISecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.FindKUniversalCircularString(secondExample);
            // Console.WriteLine(secondResult);
        }
    }
}
