using System;
using Utils;

namespace RosalindTasks
{
    public static class BA4J
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Linear Spectrum Problem

            // URL: http://rosalind.info/problems/ba4j/

            Console.WriteLine("Example: BA4J");

            var firstExample = Constants.BA4JFirstExample;
            Console.WriteLine(firstExample);

            var firstResult = Service.GetLinearSpectrum(firstExample);
            Console.WriteLine("Result: ");
            Service.WriteOutput(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA4JSecondExample;
            // Console.WriteLine(secondExample);

            // var secondResult = Service.GetLinearSpectrum(secondExample);
            // Service.WriteOuput(secondResult)
            
        }
    }
}
