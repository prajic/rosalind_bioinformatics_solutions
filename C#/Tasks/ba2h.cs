using System;
using Utils;

namespace RosalindTasks
{
    public static class BA2H
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title:Compute DistanceBetweenPatternAndStrings

            // Rosalind ID: BA2H
            // URL: http://rosalind.info/problems/ba2h/

            Console.WriteLine("Example: BA2h");

            var firstExample = Constants.BA2HFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.DistanceBetweenPaternAndDNA(firstExample);
            Console.WriteLine(firstResult);


            Console.WriteLine("Second example:");

            var secondExample = Constants.BA2HSecondExample;
            Console.WriteLine(secondExample.ToString());

            var secondResult = Service.DistanceBetweenPaternAndDNA(secondExample);
            Console.WriteLine(secondResult);
        }
    }
}
