using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace RosalindTasks
{
   public static class BA1K
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Computing a Frequency Array
            // Rosalind ID: BA1K
            // URL: http://rosalind.info/problems/ba1k/

            Console.WriteLine("Example: BA1K");
            var firstExample=Constants.BA1KFirstExample;
            Console.WriteLine(firstExample.ToString());

            var result=Service.ComputeFrequencyArray(firstExample);
            Service.WriteOutput(result);
            // Console.WriteLine("Second example:");

            // var secondExample=Constants.BA1KSecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult=Service.ComputeFrequencyArray(secondExample);

            // Service.WriteOutput(secondResult);
            
        }
    }
}
