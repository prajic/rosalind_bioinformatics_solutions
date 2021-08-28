using System;
using Utils;

namespace RosalindTasks
{
    public static class BA2G
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title:Implement GibbsSampler 


            // Rosalind ID: BA2G
            // URL: http://rosalind.info/problems/ba2g/

            Console.WriteLine("Example: BA2g");

            var firstExample = Constants.BA2GFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.GibbsSampler(firstExample);
            Service.WriteOutput(firstResult);


            Console.WriteLine("Second example:");

            var secondExample = Constants.BA2GSecondExample;
            Console.WriteLine(secondExample.ToString());

            var secondResult = Service.GibbsSampler(secondExample);
            Service.WriteOutput(secondResult);
        }
    }
}
