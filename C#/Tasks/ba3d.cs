using System;
using Utils;

namespace RosalindTasks
{
    public static class BA3D
    {
        public static void ExecuteTask()
        {
            // A solution to a ROSALIND bioinformatics problem.
            // Problem Title: De Bruijn Graph from a String Problem
            // Rosalind ID: BA3D
            // URL: http://rosalind.info/problems/ba3d/

            Console.WriteLine("Example: BA3D");

            var firstExample = Constants.BA3DFirstExample;
            Console.WriteLine(firstExample.ToString());

            var firstResult = Service.DeBruijnGraph(firstExample);
            Console.WriteLine("Result:");
            Service.WriteGraph(firstResult);

            // Console.WriteLine("Second example:");

            // var secondExample = Constants.BA3DSecondExample;
            // Coinsole.WriteLine(secondExample.ToString());

            // var secondResult = Service.DeBruijnGraph(secondExample);
            // Service.WriteGraph(secondResult);
        }
    }
}
