using System;
using Utils;

namespace RosalindTasks
{
    public static class BA2C
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Profile-most Probable k-mer Problem

            // Rosalind ID: BA2C
            // URL: http://rosalind.info/problems/ba2c/

            Console.WriteLine("Example: BA2C");

            var firstExample = Constants.BA2CFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.FindProfileMostProbableKmer(firstExample);
            Console.WriteLine(firstResult);

            Console.WriteLine("Second example:");

            var secondExample = Constants.BA2CSecondExample;
            Console.WriteLine(secondExample.ToString());

            var secondResult = Service.FindProfileMostProbableKmer(secondExample);
            Console.WriteLine(secondResult);
        }
    }
}
