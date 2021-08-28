using System;
using Utils;

namespace RosalindTasks
{
    public static class BA2F
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title:Implement RandomizedMotifSearch


            // Rosalind ID: BA2F
            // URL: http://rosalind.info/problems/ba2f/

            Console.WriteLine("Example: BA2F");

            var firstExample = Constants.BA2FFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.RandomizedMotifSearch(firstExample);
            Service.WriteOutput(firstResult);


            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA2FSecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.RandomizedMotifSearch(secondExample);
            // Service.WriteOutput(secondResult);
        }
    }
}
