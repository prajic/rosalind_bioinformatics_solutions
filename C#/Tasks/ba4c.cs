using System;
using Utils;

namespace RosalindTasks
{
    public static class BA4C
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Generating Theoretical Spectrum Problem

            // URL: http://rosalind.info/problems/ba4c/

            Console.WriteLine("Example: BA4C");

            var firstExample = Constants.BA4CFirstExample;
            Console.WriteLine(firstExample);

            var firstResult = Service.GetCyclospectrum(firstExample);
            Console.WriteLine("Result: ");
            Service.WriteOutput(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA4CSecondExample;
            // Console.WriteLine(secondExample);

            // var secondResult = Service.GetCyclospectrum(secondExample);
            // Service.WriteOutput(secondResult)
        }
    }
}
