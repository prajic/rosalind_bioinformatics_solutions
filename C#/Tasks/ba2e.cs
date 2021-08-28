using System;
using Utils;

namespace RosalindTasks
{
    public static class BA2E
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title:Implement GreedyMotifSearch with Pseudocounts

            // Rosalind ID: BA2E
            // URL: http://rosalind.info/problems/ba2e/

            Console.WriteLine("Example: BA2E");

            var firstExample = Constants.BA2EFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.GreedyMotifSearchWithPseudocounts(firstExample);
            Service.WriteOutput(firstResult);


            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA2ESecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.GreedyMotifSearch(secondExample);
            // Service.WriteOutput(secondResult);
        }
    }
}
