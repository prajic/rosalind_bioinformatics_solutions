using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class Reader
    {
        public static string GetTextFromFile(string fileName)
        {
            var text = "";
            using (var sr = new System.IO.StreamReader($"Utils/Tasks/{fileName}"))
            {
                while (sr.Peek() >= 0)
                {
                    text += sr.ReadLine();
                }
            }
            return text;
        }
        public static List<string> ReadListFromFile(string fileName)
        {
            var list = new List<string>();
            using (var sr = new System.IO.StreamReader($"Utils/Tasks/{fileName}"))
            {
                while (sr.Peek() >= 0)
                {
                    list.Add(sr.ReadLine());
                }
            }
            return list;
        }
        public static List<int> ReadNumbersFromFile(string fileName)
        {
            var list = new List<int>();
            using (var sr = new System.IO.StreamReader($"Utils/Tasks/{fileName}"))
            {
                while (sr.Peek() >= 0)
                {
                    list.Add(int.Parse(sr.ReadLine()));
                }
            }
            return list;
        }
        public static Dictionary<string, List<string>> ReadGraphFromFile(string fileName)
        {
            var adjacency = new Dictionary<string, List<string>>();
            using (var sr = new System.IO.StreamReader($"Utils/Tasks/{fileName}"))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    var lineSplitted = line.Split('>');
                    var key = lineSplitted[0].Replace('-', ' ').Trim();
                    if (!adjacency.ContainsKey(key))
                    {
                        adjacency[key] = new List<string>();
                    }
                    var values = lineSplitted[1].Split(',').Select(pattern => pattern.Trim()).ToList();
                    adjacency[key].AddRange(values);
                }
            }
            return adjacency;
        }

        private static Dictionary<int, List<int>> FillMissingKeys(Dictionary<int, List<int>> adjacency)
        {
            var count = Math.Max(adjacency.Keys.Max(), adjacency.Values.Aggregate((x, y) => y.Zip(x, (a, b) => (a > b) ? a : b).ToList()).ToList().Max());
            var newAdjacency = new Dictionary<int, List<int>>();
            for (var i = 0; i < count + 1; i++)
            {
                if (adjacency.Any(el => el.Key == i || el.Value.Contains(i)))
                {
                    if (adjacency.ContainsKey(i))
                    {
                        newAdjacency[i] = adjacency[i];
                    }
                }
                else
                {
                    newAdjacency[i] = new List<int>();
                }
            }
            return newAdjacency;
        }
        public static Dictionary<int, List<int>> ReadNumberGraphFromFile(string fileName)
        {
            var adjacency = new Dictionary<int, List<int>>();
            using (var sr = new System.IO.StreamReader($"Utils/Tasks/{fileName}"))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    var lineSplitted = line.Split('>');
                    var key = int.Parse(lineSplitted[0].Replace('-', ' ').Trim());
                    if (!adjacency.ContainsKey(key))
                    {
                        adjacency[key] = new List<int>();
                    }
                    var values = lineSplitted[1].Split(',').Select(pattern => int.Parse(pattern.Trim())).ToList();
                    adjacency[key].AddRange(values);

                    values.ForEach(value =>
                    {
                        if (!adjacency.ContainsKey(value))
                        {
                            adjacency[value] = new List<int>();
                        }
                    });
                }
            }
            return adjacency;
        }
        public static List<(string, string)> ReadPairsCompositionFromFile(string fileName)
        {
            var pairs = new List<(string, string)>();
            using (var sr = new System.IO.StreamReader($"Utils/Tasks/{fileName}"))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    var lineSplitted = line.Split('|');
                    pairs.Add((lineSplitted[0].Trim(), lineSplitted[1].Trim()));
                }
            }
            return pairs;
        }
        public static SignedPermutations ReadPermutationsFromFile(string fileName)
        {
            var permutations = new List<int>();
            var content = System.IO.File.ReadAllText($"Utils/Tasks/{fileName}").Replace("(","").Replace(")","");
            foreach(var p in content.Split(" "))
            {
                permutations.Add(int.Parse(p));
            }
            return new SignedPermutations(permutations);
        }
    }
}
