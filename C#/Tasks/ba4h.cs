using System;
using Utils;

namespace RosalindTasks
{
    public static class BA4H
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Spectral Convolution Problem

            // URL: http://rosalind.info/problems/ba4h/

            Console.WriteLine("Example: BA4H");

            var firstExample = Constants.BA4HFirstExample;
            Service.WriteOutput(firstExample);

            var firstResult = Service.GetSpectralConvolution(firstExample);
            Console.WriteLine("Result: ");
            Service.WriteOutput(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA4HSecondExample;
            // Service.WriteOuput(secondExample);

            // var secondResult = Service.GetSpectralConvolution(secondExample);
            // Service.WriteOuput(secondResult)
            
        }
    }
}
