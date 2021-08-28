using System;
using Utils;

namespace RosalindTasks
{
    public static class BA2D
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Implement GreedyMotifSearch

            // Rosalind ID: BA2D
            // URL: http://rosalind.info/problems/ba2d/

            Console.WriteLine("Example: BA2D");

            var firstExample = Constants.BA2DFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.GreedyMotifSearch(firstExample);
            Service.WriteOutput(firstResult);


            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA2DSecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.GreedyMotifSearch(secondExample);
            // Service.WriteOutput(secondResult);
        }
    }
}
