using System;
using Utils;

namespace RosalindTasks
{
    public static class BA4A
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: Protein Translation Problem


            // URL: http://rosalind.info/problems/ba4a/

            Console.WriteLine("Example: BA4A");

            var firstExample = Constants.BA4AFirstExample;
            Console.WriteLine(firstExample);

            var firstResult = Service.GetProteinTranslation(firstExample);
            Console.WriteLine("Result: ");
            Console.WriteLine(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA4ASecondExample;
            // Console.WriteLine(secondExample);

            // var secondResult = Service.GetProteinTranslation(secondExample);
            // Console.WriteLine(secondResult);
        }
    }
}
