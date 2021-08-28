using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace RosalindTasks
{
   public static class BA1L
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Implement PatternToNumber

            // Rosalind ID: BA1L
            // URL: http://rosalind.info/problems/ba1l/

            Console.WriteLine("Example: BA1L");

            var firstExample=Constants.BA1LFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult=Service.PatternToNumber(firstExample);
            Console.WriteLine(firstResult);

            Console.WriteLine("Second example:");

            var secondExample=Constants.BA1LSecondExample;
            Console.WriteLine(secondExample);

            var secondResult=Service.PatternToNumber(secondExample);
            Console.WriteLine(secondResult);            
        }
    }
}
