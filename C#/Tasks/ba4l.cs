using System;
using Utils;

namespace RosalindTasks
{
    public static class BA4L
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Trim Problem

            // URL: http://rosalind.info/problems/ba4l/

            Console.WriteLine("Example: BA4L");

            var firstExample = Constants.BA4LFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.Trim(firstExample);
            Console.WriteLine("Result: ");
            Service.WriteOutput(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA4LSecondExample;
            // Console.WriteLine(secondExample.ToString());

            // var secondResult = Service.Trim(secondExample);
            // Service.WriteOutput(secondResult)
            
        }
    }
}
