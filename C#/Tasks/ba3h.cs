using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3H
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: String Reconstruction Problem

            // URL: http://rosalind.info/problems/ba3h/

            Console.WriteLine("Example: BA3H");

            var firstExample = Constants.BA3HFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.ReconstructStringFromKmerComposition(firstExample);
            Console.WriteLine("Result: ");
            Console.WriteLine(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA3HSecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.ReconstructStringFromKmerComposition(secondExample);
            // Console.WriteLine(secondResult);
        }
    }
}
