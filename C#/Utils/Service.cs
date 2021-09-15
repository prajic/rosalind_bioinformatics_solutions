using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Utils
{
    public static class Service
    {
        private static string CreateKmer(string dna, int startingIndex, int k)
        {
            return dna.Substring(startingIndex, k);
        }
        private static string ReplaceAtIndex(string pattern, char element, int index)
        {
            return string.Concat(pattern.Select((c, i) => i == index ? element : c));
        }
        private static List<string> GenerateBase(int length)
        {
            var dnaBases = new List<string>();
            var nucleotides = Constants.Nucleotides;
            nucleotides.ForEach(nucleotide =>
               {
                   dnaBases.Add(new string(nucleotide, length));
               });

            return dnaBases;
        }
        private static List<string> GenerateAllKmers(int length)
        {
            var nucleotides = Constants.Nucleotides;
            List<string> allKmers = new List<string>();
            if (length == 0)
            {
                return allKmers;
            }
            if (length == 1)
            {
                foreach (var n in nucleotides)
                {
                    allKmers.Add(n.ToString());
                }
                return allKmers;
            }
            foreach (string x in GenerateAllKmers(length - 1))
            {
                foreach (var n in nucleotides)
                {
                    allKmers.Add(n + x);
                }
            }
            return allKmers;
        }

        private static int CountPattern(string text, string pattern)
        {
            var count = 0;
            Enumerable.Range(0, text.Length - pattern.Length + 1).Select(i => text.Substring(i, pattern.Length)).ToList().ForEach(subString =>
            {
                if (pattern == subString)
                {
                    count += 1;
                }
            });
            return count;
        }

        public static int[] ComputeFrequencyArray(TextNumberInput taskInput)
        {
            var k = taskInput.inputNumber;
            var inputText = taskInput.inputText;
            var frequencyArray = new int[(int)Math.Pow(4, k)];
            var allKmers = GenerateAllKmers(k).OrderBy(kmer => kmer).ToList();
            for (var i = 0; i < frequencyArray.Length; i++)
            {
                frequencyArray[i] = CountPattern(inputText, allKmers[i]);
            }

            return frequencyArray;
        }
        public static long PatternToNumber(string pattern)
        {
            var result = (long)0;
            var k = 0;
            pattern.Reverse().ToList().ForEach(letter =>
            {
                var value = Constants.NucleotidesAsNumber[letter];
                result += (long)(value * Math.Pow(4, k));
                k++;
            });

            return result;
        }
        private static char GetNucleotide(int nucleotideNumber)
        {
            return Constants.NucleotidesAsNumber.FirstOrDefault(nucleotide => nucleotide.Value == nucleotideNumber).Key;
        }
        public static string NumberToPattern(long result, int k)
        {
            var pattern = "";
            var q = result;
            for (int i = 0; i < k; i++)
            {
                long r = q % 4;
                q = (long)(q / 4);
                var letter = GetNucleotide((int)r);
                pattern = pattern + letter;
            }

            return new String(pattern.Reverse().ToArray());
        }
        private static int GetHammingDistance(string firstPattern, string secondPattern)
        {
            var distance = 0;
            if (firstPattern.Length == secondPattern.Length)
            {
                var k = firstPattern.Length;
                for (var i = 0; i < k; i++)
                {
                    if (firstPattern[i] != secondPattern[i])
                    {
                        distance++;
                    }
                }
                return distance;
            }
            return -1;
        }
        public static List<string> GenerateDNeighborhood(TextNumberInput taskInput)
        {
            var allKmers = GenerateAllKmers(taskInput.inputText.Length);

            return allKmers.Where(kmer => GetHammingDistance(kmer, taskInput.inputText) <= taskInput.inputNumber).ToList();

        }
        public static void WriteOutput<T>(T[] array)
        {
            foreach (var el in array)
            {
                Console.Write(" {0} ", el.ToString());
            }
            Console.WriteLine();
        }
        public static void WriteOutput<T>(List<T> list)
        {
            foreach (var el in list)
            {
                Console.Write(" {0} ", el.ToString());
            }
            Console.WriteLine();
        }
        public static void WriteOutputToLines<T>(List<T> list)
        {
            foreach (var el in list)
            {
                Console.WriteLine(" {0} ", el.ToString());
            }
            Console.WriteLine();
        }
        private static List<string> ConvertDNAToKmers(string dna, int k)
        {
            var kmers = Enumerable.Range(0, dna.Length - k + 1).Select(i => dna.Substring(i, k)).ToList();

            return kmers;
        }
        public static int CountPatternOccurancesWithMismatches(string pattern, string dna, int d)
        {
            var count = 0;
            ConvertDNAToKmers(dna, pattern.Length).ForEach(subString =>
             {
                 if (GetHammingDistance(pattern, subString) <= d)
                 {
                     count += 1;
                 }
             });
            return count;
        }
        public static List<string> MotifEnumeration(NumberPairPatternListInput taskInput)
        {
            var allKmers = GenerateAllKmers(taskInput.k);
            var result = new List<string>();

            foreach (var kmer in allKmers)
            {
                bool kmerOccursInAll = true;
                foreach (var pattern in taskInput.patterns)
                {
                    if (CountPatternOccurancesWithMismatches(kmer, pattern, taskInput.d) == 0)
                    {
                        kmerOccursInAll = false;
                    }

                }
                if (kmerOccursInAll)
                {
                    if (!result.Contains(kmer))
                    {
                        result.Add(kmer);
                    }
                }
            }
            return result;
        }
        private static int GetHammingDistanceBetweenKmerAndDNA(string pattern, string dna)
        {
            var min = Int32.MaxValue;
            ConvertDNAToKmers(dna, pattern.Length).ForEach(substring =>
            {
                var distance = GetHammingDistance(pattern, substring);
                min = distance < min ? distance : min;
            });
            return min;
        }
        private static int GetHammingDistanceBetweenKmerAndSet(string pattern, List<string> dnaList)
        {
            var distance = 0;
            dnaList.ForEach(dna =>
            {
                distance += GetHammingDistanceBetweenKmerAndDNA(pattern, dna);
            });
            return distance;
        }

        public static string FindMedianString(NumberPatternListInput taskInput)
        {
            var min = Int32.MaxValue;
            var medianString = "";
            var allKmers = GenerateAllKmers(taskInput.k);
            foreach (var kmer in allKmers)
            {
                var distance = GetHammingDistanceBetweenKmerAndSet(kmer, taskInput.dnaList);
                min = distance < min ? distance : min;
                medianString = distance == min ? kmer : medianString;

            };
            return medianString;
        }
        private static bool IsKmerInText(string kmer, string dna)
        {
            return Regex.IsMatch(dna, kmer);
        }
        private static double GetProbability(string kmer, double[,] profileMatrix)
        {
            var p = (double)1;
            var column = 0;
            foreach (var c in kmer)
            {
                var nucleotideNumber = Constants.NucleotidesAsNumber[c];
                p *= profileMatrix[nucleotideNumber, column];
                column++;
            }
            return p;
        }

        public static string FindProfileMostProbableKmer(DnaNumberProfileMatrix taskInput)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            var k = taskInput.k;
            var maxCount = (double)0;
            var profileMatrix = taskInput.profileMatrix;
            foreach (var kmer in ConvertDNAToKmers(taskInput.dna, k))
            {
                dict[kmer] = GetProbability(kmer, profileMatrix);
                maxCount = dict[kmer] > maxCount ? dict[kmer] : maxCount;
            }
            var dictToList = dict.Where(kmer => kmer.Value >= maxCount).OrderBy(kmer => kmer.Value).ToList();

            return dictToList[0].Key;

        }
        private static int CountMotifs(int nucleotide, int column, List<string> dnaList)
        {
            var letter = GetNucleotide(nucleotide);
            var count = 0;
            dnaList.ForEach(dna =>
            {
                if (dna[column] == letter)
                {
                    count++;
                }
            });
            return count;
        }
        private static double[,] GetProfileMatrix(List<string> dnaList, int k)
        {
            var profileMatrix = new double[4, k];

            for (var i = 0; i < 4; i++)
            {
                for (var ii = 0; ii < k; ii++)
                {
                    profileMatrix[i, ii] = (double)CountMotifs(i, ii, dnaList) / (double)dnaList.Count;
                }
            }
            return profileMatrix;
        }
        private static int GetMotifsScore(List<string> motifs)
        {
            var score = 0;
            var n = motifs[0].Length;
            for (int i = 0; i < n; i++)
            {
                score += (motifs.Count - CountMotifs((int)GetIthColumn(motifs, i), i, motifs));
            }
            return score;
        }

        private static long GetIthColumn(List<string> motifs, int i)
        {
            var counts = new Dictionary<char, int>();
            motifs.ForEach(motif =>
            {
                var nucleotide = motif[i];
                if (counts.ContainsKey(nucleotide))
                {
                    counts[nucleotide]++;
                }
                else
                {
                    counts[nucleotide] = 0;
                }
            });

            var capital = counts.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return Constants.NucleotidesAsNumber[capital];
        }
        public static List<string> GreedyMotifSearch(NumberPairPatternListInput taskInput)
        {
            var result = new List<string>();
            var k = taskInput.k;
            var d = taskInput.d;
            var dnaList = taskInput.patterns;
            foreach (var dna in dnaList)
            {
                result.Add(CreateKmer(dna, 0, k));
            }
            foreach (var motif in ConvertDNAToKmers(dnaList[0], k))
            {
                var motifs = new List<string>();
                motifs.Add(motif);
                for (var i = 1; i < d; i++)
                {
                    var profileMatrix = GetProfileMatrix(motifs, k);
                    motifs.Add(FindProfileMostProbableKmer(new DnaNumberProfileMatrix(dnaList[i], k, profileMatrix)));
                }
                if (GetMotifsScore(motifs) < GetMotifsScore(result))
                {
                    result = motifs;
                }
            }
            return result;

        }
        public static double[,] GetProfileMatrixWithPseudocounts(List<string> dnaList, int k)
        {
            var profileMatrix = new double[4, k];

            for (var i = 0; i < 4; i++)
            {
                for (var ii = 0; ii < k; ii++)
                {
                    profileMatrix[i, ii] = (double)(1 + CountMotifs(i, ii, dnaList)) / (double)(dnaList.Count + 4);
                }
            }
            return profileMatrix;
        }
        public static List<string> GreedyMotifSearchWithPseudocounts(NumberPairPatternListInput taskInput)
        {
            var result = new List<string>();
            var k = taskInput.k;
            var d = taskInput.d;
            foreach (var dna in taskInput.patterns)
            {
                result.Add(ConvertDNAToKmers(dna, k)[0]);
            }

            foreach (string motif in ConvertDNAToKmers(taskInput.patterns[0], k))
            {
                List<string> motifs = new List<string>();
                motifs.Add(motif);
                for (int i = 1; i < d; i++)
                {
                    var profile = GetProfileMatrixWithPseudocounts(motifs, k);
                    motifs.Add(FindProfileMostProbableKmer(new DnaNumberProfileMatrix(taskInput.patterns[i], k, profile)));
                }
                if (GetMotifsScore(motifs) < GetMotifsScore(result))
                {
                    result = motifs;
                }
            }
            return result;
        }

        private static string GetRandomKmer(string text, int k)
        {
            var random = new Random();

            var start = random.Next(0, text.Length - k);

            return text.Substring(start, k);
        }

        private static List<string> GetMotifs(List<string> dna, double[,] profile)
        {
            int t = dna.Count();
            int k = profile.GetLength(1);
            List<string> motifs = new List<string>();
            for (int i = 0; i < t; i++)
            {
                var taskInput = new DnaNumberProfileMatrix(dna[i], k, profile);
                motifs.Add(FindProfileMostProbableKmer(taskInput));
            }
            return motifs;
        }
        private static List<string> RandomizedMotifSearchAtom(NumberPairPatternListInput taskInput)
        {
            var k = taskInput.k;
            var d = taskInput.d;
            var dna = taskInput.patterns;
            var bestMotifs = dna.Select(pattern => GetRandomKmer(pattern, k)).ToList();

            while (true)
            {
                var profile = GetProfileMatrixWithPseudocounts(bestMotifs, k);
                var motifs = GetMotifs(dna, profile);

                if (GetMotifsScore(motifs) < GetMotifsScore(bestMotifs))
                {
                    bestMotifs = motifs;
                }
                else
                {
                    return bestMotifs;
                }
            }
        }
        public static List<string> RandomizedMotifSearch(NumberPairPatternListInput taskInput, int repeats = 1000)
        {
            List<string> bestMotifs = RandomizedMotifSearchAtom(taskInput);
            for (int i = 0; i < repeats; i++)
            {
                List<string> motifs = RandomizedMotifSearchAtom(taskInput);
                if (GetMotifsScore(motifs) < GetMotifsScore(bestMotifs))
                {
                    bestMotifs = motifs;
                }
            }
            return bestMotifs;
        }
        private static string GetProfileRandomKmer(string text, double[,] profileMatrix, int k)
        {
            var random = new Random();
            var probabilities = new List<double>();
            ConvertDNAToKmers(text, k).ForEach(kmer =>
            {
                probabilities.Add(GetProbability(kmer, profileMatrix));
            });
            var sum = probabilities.Sum();
            probabilities.ForEach(p => p = p / sum);
            var randDouble = random.NextDouble();
            var s = (double)0;
            for (var i = 0; i < probabilities.Count; i++)
            {
                s += probabilities[i];
                if (randDouble < s)
                {
                    return CreateKmer(text, i, k);
                }
            }
            return CreateKmer(text, probabilities.Count - 1, k);
        }
        private static List<string> GibbsSamplerAtom(NumberTrioListInput taskInput)
        {
            var random = new Random();
            var k = taskInput.k;
            var t = taskInput.t;
            var N = taskInput.N;
            var dna = taskInput.dna;

            var result = RandomizedMotifSearchAtom(new NumberPairPatternListInput(k, t, dna));
            var motifs = new List<string>(result);

            for (var i = 1; i < N; i++)
            {
                var index = random.Next(0, t);
                var temp = new List<string>(motifs);

                temp.RemoveAt(index);
                var profileMatrix = GetProfileMatrixWithPseudocounts(temp, k);
                motifs[index] = GetProfileRandomKmer(dna[index], profileMatrix, k);
                if (GetMotifsScore(motifs) < GetMotifsScore(result))
                {
                    result = motifs;
                }
            }
            return result;

        }
        public static List<string> GibbsSampler(NumberTrioListInput taskInput, int repeats = 1000)
        {
            var result = GibbsSamplerAtom(taskInput);

            for (var i = 1; i < repeats; i++)
            {
                var motifs = GibbsSamplerAtom(taskInput);
                if (GetMotifsScore(motifs) < GetMotifsScore(result))
                {
                    result = motifs;
                }
            }
            return result;
        }

        public static int DistanceBetweenPaternAndDNA(PatternAndDnaInput taskInput)
        {
            var pattern = taskInput.pattern;
            var dna = taskInput.dna;
            var distance = 0;
            var k = pattern.Length;

            dna.ForEach(text =>
            {
                var hammingDistance = int.MaxValue;
                ConvertDNAToKmers(text, k).ForEach(kmer =>
                {
                    var computedHammingDistance = GetHammingDistance(pattern, kmer);
                    if (hammingDistance > computedHammingDistance)
                    {
                        hammingDistance = computedHammingDistance;
                    }
                });
                distance = distance + hammingDistance;
            });
            return distance;
        }


        public static List<string> StringCompositionProblem(TextNumberInput taskInput)
        {
            var pattern = taskInput.inputText;
            var k = taskInput.inputNumber;

            var kmers = ConvertDNAToKmers(pattern, k);
            kmers.Sort();

            return kmers;
        }
        public static string ReconstructStringFromGenome(List<string> genome)
        {
            return genome.Skip(1).Aggregate(genome[0], (accumulator, next) =>
            {
                return accumulator + next.ToArray().Last().ToString();
            });
        }

        public static void WriteGraph<T>(Dictionary<T, List<T>> adjacency)
        {
            foreach (var key in adjacency.Keys)
            {
                var allAdjacent = "";
                foreach (var adjacent in adjacency[key])
                {
                    allAdjacent += String.Format("{0}, ", adjacent);
                }
                if (allAdjacent.Length > 0)
                {
                    Console.WriteLine(" {0} --> {1}", key, allAdjacent.Substring(0, allAdjacent.Length - 2));
                }
            }
            Console.WriteLine();
        }

        public static Dictionary<string, List<string>> Overlap(List<string> patterns)
        {
            var k = patterns[0].Length;
            var adjacency = new Dictionary<string, List<string>>();
            patterns.Sort();
            patterns.ForEach(pattern =>
            {
                adjacency[pattern] = new List<string>();
                patterns.ForEach(patternToCompare =>
                {
                    if (pattern.Substring(1) == patternToCompare.Substring(0, k - 1) && pattern != patternToCompare)
                    {
                        if (!adjacency[pattern].Contains(patternToCompare))
                        {
                            adjacency[pattern].Add(patternToCompare);
                        }
                    }
                });
            });
            return adjacency;
        }

        public static Dictionary<string, List<string>> DeBruijnGraph(TextNumberInput taskInput)
        {
            var k = taskInput.inputNumber;
            var pattern = taskInput.inputText;

            var adjacency = new Dictionary<string, List<string>>();
            return Overlap(ConvertDNAToKmers(pattern, k - 1));
        }

        public static Dictionary<string, List<string>> DeBruijnGraph(List<string> patterns)
        {
            var adjacency = new Dictionary<string, List<string>>();
            patterns.OrderBy(pattern => pattern).ToList().ForEach(pattern =>
              {
                  var prefix = pattern.Substring(0, pattern.Length - 1);
                  if (!adjacency.Keys.Contains(prefix))
                  {
                      adjacency[prefix] = new List<string>();
                  }
                  adjacency[prefix].Add(pattern.Substring(1));
              });
            return adjacency;
        }


        private static List<(T, T)> GetSingleCycle<T>(Dictionary<T, List<T>> adjacency, List<T> starts)
        {
            var origin = default(T);
            foreach (var start in starts)
            {
                if (adjacency.Keys.Contains(start))
                {
                    origin = start;
                    break;
                }
            }
            var cycle = new List<(T, T)>();
            var first = origin;
            while (true)
            {
                if (adjacency.Keys.Contains(first))
                {
                    var second = adjacency[first][0];
                    cycle.Add((first, second));
                    if (adjacency[first].Count == 1)
                    {
                        adjacency.Remove(first);
                    }
                    else
                    {
                        adjacency[first] = adjacency[first].Skip(1).ToList();
                    }
                    if (EqualityComparer<T>.Default.Equals(second, origin))
                    {
                        break;
                    }
                    else
                    {
                        first = second;
                    }
                }
                else
                {
                    break;
                }
            }
            return cycle;
        }

        private static int GetStartingIndexOfCycle<T>(List<(T, T)> cycle, T start)
        {
            var startingIndex = int.MinValue;
            for (var i = 0; i < cycle.Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(cycle[i].Item1, start))
                {
                    startingIndex = i;
                    break;
                }
            }
            return startingIndex;

        }
        public static List<(T, T)> GetEulerianCycle<T>(Dictionary<T, List<T>> adjacency)
        {
            var edgesDict = new Dictionary<T, List<(T, T)>>();
            foreach (var key in adjacency.Keys)
            {
                edgesDict[key] = new List<(T, T)>();
                foreach (var node in adjacency[key])
                {
                    edgesDict[key].Add((key, node));
                }
            }
            var random = new Random();
            var index = random.Next(adjacency.Keys.Count - 1);
            var v0 = adjacency.Keys.ToList()[index];
            var cycle = new List<(T, T)>();
            var nodes = new List<T>() { v0 };
            var startingNode = default(T);

            foreach (var node in adjacency[v0])
            {
                if (!cycle.Contains((v0, node)))
                {
                    if (edgesDict[v0].Contains((v0, node)))
                    {
                        cycle.Add((v0, node));
                        edgesDict[v0].Remove((v0, node));
                        nodes.Add(node);
                        startingNode = node;
                        break;
                    }
                }
            }
            while (!EqualityComparer<T>.Default.Equals(startingNode, v0))
            {
                foreach (var node in adjacency[startingNode])
                {
                    if (!cycle.Contains((startingNode, node)))
                    {
                        if (edgesDict[startingNode].Contains((startingNode, node)))
                        {
                            cycle.Add((startingNode, node));
                            edgesDict[startingNode].Remove((startingNode, node));
                            nodes.Add(node);
                            startingNode = node;
                            break;
                        }
                    }
                }
            }
            var cycles = new List<List<(T, T)>>() { cycle };
            var flag = false;
            for (var i = 1; i < nodes.Count; i++)
            {
                if (edgesDict[nodes[i]].Count > 0)
                {
                    v0 = nodes[i];
                    flag = true;
                    break;
                }
            }
            while (flag)
            {
                nodes = new List<T>() { v0 };

                cycle = new List<(T, T)>();
                startingNode = default(T);
                foreach (var node in adjacency[v0])
                {
                    if (!cycle.Contains((v0, node)))
                    {
                        if (edgesDict[v0].Contains((v0, node)))
                        {
                            cycle.Add((v0, node));
                            edgesDict[v0].Remove((v0, node));
                            nodes.Add(node);
                            startingNode = node;
                            break;
                        }
                    }
                }
                while (!EqualityComparer<T>.Default.Equals(startingNode, v0))
                {
                    foreach (var node in adjacency[startingNode])
                    {
                        if (!cycle.Contains((startingNode, node)))
                        {
                            if (edgesDict[startingNode].Contains((startingNode, node)))
                            {
                                cycle.Add((startingNode, node));
                                edgesDict[startingNode].Remove((startingNode, node));
                                nodes.Add(node);
                                startingNode = node;
                                break;
                            }
                        }
                    }
                }
                cycles.Add(cycle);
                flag = false;
                cycles = new List<List<(T, T)>>() { EulerianCycle(cycles) };
                foreach (var el in cycles[0])
                {
                    nodes.Add(el.Item2);
                }
                for (var i = 1; i < nodes.Count; i++)
                {
                    if (edgesDict[nodes[i]].Count > 0)
                    {
                        v0 = nodes[i];
                        flag = true;
                        break;
                    }
                }
            }
            return cycles.First();
        }
        private static List<(T, T)> EulerianCycle<T>(List<List<(T, T)>> cycles)
        {
            var eulerian = new List<(T, T)>();
            var removed = new List<(T, T)>();

            foreach (var el in cycles[0])
            {
                eulerian.Add(el);
                removed.Add(el);
                if (EqualityComparer<T>.Default.Equals(el.Item2, cycles[1][0].Item1))
                {
                    break;
                }
            }
            foreach (var el in removed)
            {
                cycles[0].Remove(el);
            }
            for (var i = 1; i > -1; i--)
            {
                removed = new List<(T, T)>();
                foreach (var el in cycles[i])
                {
                    eulerian.Add(el);
                    removed.Add(el);
                }
                foreach (var el in removed)
                {
                    cycles[i].Remove(el);
                }
            }
            return eulerian;
        }
        public static void WriteEulerGraph(List<(int, int)> eulerianCycle)
        {
            Console.WriteLine();
            foreach (var el in eulerianCycle)
            {
                Console.Write(" {0} -> ", el.Item1.ToString(), el.Item2.ToString());
            }
            var last = eulerianCycle.Last().Item2;
            Console.Write("{0} ", last);
            Console.WriteLine();
        }
        private static List<T> GetUnbalancedDegrees<T>(Dictionary<T, List<T>> adjacency)
        {
            var unbalancedNodesDict = new Dictionary<T, int>();
            foreach (var key in adjacency.Keys)
            {
                var inputDegree = 0;
                foreach (var secondKey in adjacency.Keys)
                {
                    if (!EqualityComparer<T>.Default.Equals(key, secondKey))
                    {
                        foreach (var node in adjacency[secondKey])
                        {
                            if (EqualityComparer<T>.Default.Equals(node, key))
                            {
                                inputDegree++;
                            }
                        }
                    }
                }
                if (adjacency[key].Count != inputDegree)
                {
                    unbalancedNodesDict[key] = inputDegree - adjacency[key].Count;
                }
            }
            var unbalancedNodes = new List<T>() { default(T), default(T) };
            foreach (var key in unbalancedNodesDict.Keys)
            {
                if (unbalancedNodesDict[key] > 0)
                {
                    unbalancedNodes[0] = key;
                }
                if (unbalancedNodesDict[key] < 0)
                {
                    unbalancedNodes[1] = key;
                }
            }
            return unbalancedNodes;
        }
        private static (Dictionary<T, List<T>>, List<T>) GetBalancedGraph<T>(Dictionary<T, List<T>> adjacency)
        {
            var startEnd = GetUnbalancedDegrees(adjacency);
            adjacency[startEnd[0]].Add((startEnd[1]));
            return (adjacency, startEnd);
        }
        public static List<(T, T)> GetEulerianPath<T>(Dictionary<T, List<T>> adjacency)
        {
            var balanced = GetBalancedGraph(adjacency);
            var cycles = GetEulerianCycle(new Dictionary<T, List<T>>(balanced.Item1));
            var path1 = new List<(T, T)>();
            var path2 = new List<(T, T)>();
            var path = path1;
            foreach (var el in cycles)
            {
                if (EqualityComparer<T>.Default.Equals(el.Item1, balanced.Item2[0]) && EqualityComparer<T>.Default.Equals(el.Item2, balanced.Item2[1]))
                {
                    path = path2;
                }
                path.Add(el);
            }
            var result = path2.Concat(path1).ToList();
            return result.Skip(1).ToList();
        }

        private static Dictionary<string, List<string>> GetGraphFromStringList(List<string> strings)
        {
            var nodes = new List<string>();
            var adjacency = new Dictionary<string, List<string>>();
            foreach (var text in strings)
            {
                nodes.Add(text.Substring(0, text.Length - 1));
                nodes.Add(text.Substring(1));
            }
            nodes = nodes.Distinct().ToList();
            nodes.ForEach(node =>
            {
                adjacency[node] = new List<string>();
                strings.ForEach(text =>
                {
                    if (text.Substring(0, text.Length - 1) == node)
                    {
                        adjacency[node].Add(text.Substring(1));
                    }
                });
            });
            return adjacency;
        }
        public static string ReconstructStringFromKmerComposition(NumberPatternListInput taskInput)
        {
            var k = taskInput.k;
            var kmers = taskInput.dnaList;
            var adjacency = GetGraphFromStringList(kmers);
            var result = ConvertEulerianPathToString(GetEulerianPath(adjacency));

            return result;
        }
        private static string ConvertEulerianPathToString(List<(string, string)> eulerianPath)
        {
            var result = "";
            for (var i = 0; i < eulerianPath.Count; i++)
            {
                var el = eulerianPath[i];
                if (i == 0)
                {
                    result += el.Item1;
                }
                else
                {
                    result += el.Item1.Substring(el.Item1.Length - 1);
                }
                if (i == eulerianPath.Count - 1)
                {
                    result += el.Item2.Substring(el.Item2.Length - 1);
                }
            }

            return result;
        }
        private static List<string> GenerateAllBinaryStrings(int n)
        {
            var binaryStrings = new List<string>();
            for (var i = 0; i < Math.Pow(n, 2); i++)
            {
                var binaryNumber = Convert.ToString(i, 2);
                if (binaryNumber.Length < n)
                {
                    var numberOfZeros = n - binaryNumber.Length;
                    binaryNumber = new string('0', numberOfZeros) + binaryNumber;

                }
                binaryStrings.Add(binaryNumber);
            }
            return binaryStrings;
        }
        public static string FindKUniversalCircularString(int k)
        {
            var allStrings = GenerateAllBinaryStrings(k);

            var graph = GetGraphFromStringList(allStrings);

            var cycles = GetEulerianCycle(graph);

            return ConvertEulerianPathToString(cycles).Substring(3);
        }
        public static List<((string, string), (string, string))> GetPairedDebruijnPairs(List<(string, string)> pairs)
        {
            var deBruijnPairs = new List<((string, string), (string, string))>();
            foreach (var pair in pairs)
            {
                var first = pair.Item1;
                var second = pair.Item2;
                var firstPair = (first.Substring(0, first.Length - 1), second.Substring(0, second.Length - 1));
                var secondPair = (first.Substring(1), second.Substring(1));
                deBruijnPairs.Add((firstPair, secondPair));

            }
            return deBruijnPairs;
        }
        private static string GetStringSpelledByPatterns(List<string> patterns)
        {
            //             string=patterns[0]
            // for x in patterns[1:]:
            //     string=string+x[-1]
            // return string
            var result = patterns[0];
            patterns.Skip(1).ToList().ForEach(pattern =>
            {
                result += pattern.Substring(pattern.Length - 1);
            });
            return result;
        }
        public static string ReconstructStringFromReadPairsComposition(NumberPairPatternListCompositionsInput taskInput)
        {

            var pairs = taskInput.pairs;
            var k = taskInput.k;
            var d = taskInput.d;
            var deBruijnPairs = GetPairedDebruijnPairs(pairs);
            var firstDeBruijn = deBruijnPairs[0];
            var nodes = new List<string>() { string.Format("{0}|{1}", firstDeBruijn.Item2.Item1, firstDeBruijn.Item2.Item2) };
            var nextPattern = deBruijnPairs[1];
            nodes.Add(nextPattern.Item1.Item1.Substring(0, nextPattern.Item1.Item1.Length - 1));
            foreach (var deBruijnPair in deBruijnPairs)
            {
                nodes.Add(deBruijnPair.Item2.Item1.Substring(deBruijnPair.Item2.Item1.Length - 1));
            }
            nextPattern = deBruijnPairs[deBruijnPairs.Count - d - 2];
            nodes.Add((nextPattern.Item2.Item2));

            foreach (var deBruijnPair in deBruijnPairs.Skip(deBruijnPairs.Count - d - 1))
            {
                var newNode = deBruijnPair.Item2.Item2;
                nodes.Add(newNode.Substring(newNode.Length - 1));
            }

            var result = string.Join("", nodes);
            return result;
        }


        public static string GetGappedGenomePath(NumberPairPatternListCompositionsInput taskInput)
        {
            var pairs = taskInput.pairs;
            var k = taskInput.k;
            var d = taskInput.d;
            var firstPatterns = pairs.Select(el => el.Item1).ToList();
            var secondPatterns = pairs.Select(el => el.Item2).ToList();

            var prefixString = GetStringSpelledByPatterns(firstPatterns);
            var suffixString = GetStringSpelledByPatterns(secondPatterns);

            for (var i = k + d + 1; i < prefixString.Length; i++)
            {
                if (prefixString[i] != suffixString[i - k - d])
                {
                    return "There is no string spelled by the gapped patterns";
                }
            }
            return string.Concat(prefixString, suffixString.Substring(suffixString.Length - k - d));
        }

        private static Dictionary<string, string> GetAminoDictionary()
        {
            var aminos = Constants.Aminos;
            var aminoDict = new Dictionary<string, string>();
            foreach (var amino in aminos)
            {
                aminoDict[amino.Substring(0, amino.Length - 1)] = amino[amino.Length - 1].ToString();
            }
            return aminoDict;
        }

        public static string GetProteinTranslation(string rnaPattern)
        {
            var aminoDict = GetAminoDictionary();
            var peptide = "";
            for (var i = 0; i < rnaPattern.Length; i += 3)
            {
                var rnaKey = rnaPattern.Substring(i, 3);
                if (aminoDict[rnaKey] == "*")
                {
                    break;
                }
                else
                {
                    peptide += aminoDict[rnaKey];
                }
            }
            return peptide;
        }
        private static string TranscriptDna(string dnaPattern)
        {
            return dnaPattern.Replace('T', 'U');
        }
        private static string DeTranscriptRna(string rnaPattern)
        {
            return rnaPattern.Replace('U', 'T');

        }
        private static string GetComplement(string dnaPattern)
        {
            var complement = "";
            dnaPattern.ToList().ForEach(letter =>
            {
                complement += GetNucleotideComplement(letter);
            });
            return complement;
        }
        private static string GetReversePattern(string dnaPattern)
        {
            return string.Join("", dnaPattern.Reverse());
        }
        private static char GetNucleotideComplement(char letter)
        {
            if (letter == 'A')
            {
                return 'T';
            }
            else if (letter == 'T')
            {
                return 'A';
            }
            else if (letter == 'G')
            {
                return 'C';
            }
            else if (letter == 'C')
            {
                return 'G';
            }
            else
            {
                return letter;
            }

        }
        private static string GetReverseComplement(string dnaPattern)
        {
            var result = GetReversePattern(GetComplement(dnaPattern));
            return result;
        }
        private static bool IsDnaEncodingPeptide(string dna, string peptide)
        {
            var reversedComplementPattern = GetReverseComplement(dna);
            var rna = TranscriptDna(dna);
            var rnaComplement = TranscriptDna(reversedComplementPattern);
            var translatedRna = GetProteinTranslation(rna);
            var translatedRnaComplement = GetProteinTranslation(rnaComplement);

            return translatedRna == peptide || translatedRnaComplement == peptide;
            // GGCCAT
        }

        public static List<string> GetEncodedPeptide(TextPairInput taskInput)
        {
            var result = new List<string>();
            var dnaPattern = taskInput.dna;
            var peptide = taskInput.peptide;
            var peptideLength = peptide.Length;
            for (var i = 0; i < dnaPattern.Length - 3 * peptideLength + 1; i++)
            {
                var pattern = dnaPattern.Substring(i, 3 * peptideLength);
                if (IsDnaEncodingPeptide(pattern, peptide))
                {
                    result.Add(pattern);
                }
            }
            return result;
        }
        private static List<string> GetAllSubPeptides(string peptide)
        {
            var subPeptides = new List<string>() { "", peptide };
            var peptideDoubled = string.Concat(peptide, peptide);
            for (var i = 1; i < peptide.Length; i++)
            {
                for (var ii = 0; ii < peptide.Length; ii++)
                {
                    subPeptides.Add(peptideDoubled.Substring(ii, i));
                }
            }
            return subPeptides;
        }
        private static int GetPeptideMass(string peptide)
        {
            var aminoMasses = Constants.AminoMasses;
            var mass = 0;
            peptide.ToList().ForEach(character =>
            {
                mass += aminoMasses[character];
            });
            return mass;
        }
        public static List<int> GetCyclospectrum(string peptide)
        {
            var subPeptides = GetAllSubPeptides(peptide);
            var spectrum = new List<int>();
            subPeptides.ForEach(subPeptide =>
            {
                var mass = GetPeptideMass(subPeptide);
                spectrum.Add(mass);
            });
            var result = spectrum.OrderBy(m => m).ToList();
            return result;
        }
        private static long GetAllCombinationsWorker(int mass, List<int> aminoMasses, Dictionary<int, long> counter)
        {
            if (counter.ContainsKey(mass))
            {
                return counter[mass];
            }

            if (mass < 0)
            {
                return 0;
            }
            if (mass == 0)
            {
                return 1;
            }
            counter[mass] = 0;
            foreach (var aminoMass in aminoMasses)
            {
                counter[mass] += GetAllCombinationsWorker(mass - aminoMass, aminoMasses, counter);
            }
            return counter[mass];

        }
        public static long ComputeNumberOfPeptides(int mass)
        {
            var masses = Constants.AminoMasses.Values.Distinct().ToList();
            var counter = new Dictionary<int, long>();
            var result = GetAllCombinationsWorker(mass, masses, counter);
            return result;
        }
        public static int GetCyclicPeptideScore(TextNumberListInput taskInput)
        {
            var peptide = taskInput.pattern;
            var spectrum = taskInput.numbers;
            var counter = 0;
            foreach (var value in GetCyclospectrum(peptide))
            {
                if (spectrum.Contains(value))
                {
                    counter += 1;
                }
            }
            return counter;
        }
        public static List<int> GetSpectralConvolution(List<int> masses)
        {
            var result = new List<int>();
            foreach (var a in masses)
            {
                foreach (var b in masses)
                {
                    if (a - b > 0)
                    {
                        result.Add(a - b);
                    }
                }
            }
            result = result.OrderBy(a => a.ToString()).ToList();

            return result;
        }
        public static List<int> GetLinearSpectrum(string peptide)
        {
            var aminoMassesDict = Constants.AminoMasses;
            var aminoAcids = aminoMassesDict.Keys.ToList();
            var aminoMasses = aminoMassesDict.Values.ToList();
            return GetLinearSpectrum(peptide, aminoAcids, aminoMasses);
        }

        private static List<int> GetLinearSpectrum(string peptide, List<char> aminoAcids, List<int> aminoMasses)
        {
            var prefixMass = new List<int>() { 0 };
            for (var i = 0; i < peptide.Length; i++)
            {
                for (var ii = 0; ii < aminoAcids.Count; ii++)
                {
                    if (aminoAcids[ii] == peptide[i])
                    {
                        prefixMass.Add(prefixMass[i] + aminoMasses[ii]);
                    }
                }
            }
            var linearSpectrum = new List<int>() { 0 };
            for (var i = 0; i < peptide.Length; i++)
            {
                for (var ii = i + 1; ii < peptide.Length + 1; ii++)
                {
                    linearSpectrum.Add(prefixMass[ii] - prefixMass[i]);
                }
            }
            linearSpectrum.Sort();
            return linearSpectrum;
        }
        private static List<int> GetLinearSpectrumList(string peptide)
        {
            var subPeptides = new List<string>() { "", peptide };
            for (var i = 1; i < peptide.Length; i++)
            {
                for (var ii = 0; ii < peptide.Length - i + 1; ii++)
                {
                    int length = ii + i - ii + 1;
                    subPeptides.Add(peptide.Substring(ii, i));
                }
            }
            var spectrum = new List<int>();
            foreach (var subpeptide in subPeptides)
            {
                spectrum.Add(GetPeptideMass(subpeptide));
            }
            spectrum.Sort();
            return spectrum;

        }
        public static int GetLinearPeptideScore(TextNumberListInput taskInput)
        {
            var spectrum = taskInput.numbers;
            var peptide = taskInput.pattern;
            var counter = 0;
            var linearSpectrum = GetLinearSpectrumList(peptide);
            foreach (var value in linearSpectrum)
            {
                if (spectrum.Contains(value))
                {
                    counter++;
                    spectrum.Remove(value);
                }
            }
            return counter;
        }

        public static List<string> Trim(TextListNumberListNumberInput taskInput)
        {
            var peptides = taskInput.patterns;
            var spectrum = taskInput.numbers;
            var n = taskInput.k;

            var linearScores = new List<int>();
            foreach (var peptide in peptides)
            {
                linearScores.Add(GetLinearPeptideScore(new TextNumberListInput(peptide, new List<int>(spectrum))));
            }
            var newOrdering = linearScores
            .Select((linearScore, index) => new { linearScore, index })
            .OrderByDescending(item => item.linearScore)
            .ToArray();

            linearScores = newOrdering.Select(item => linearScores[item.index]).ToList();
            peptides = newOrdering.Select(item => peptides[item.index]).ToList();

            return peptides.Where((_, index) => linearScores[index] >= linearScores[n - 1]).ToList();

        }
        public static int GetChange(NumberNumbersListInput taskInput)
        {
            var money = taskInput.number;
            var coins = taskInput.numbers;
            var minNumberCoins = new List<int>() { 0 };
            for (var i = 0; i < money + 1; i++)
            {
                minNumberCoins.Add(int.MaxValue);
                for (var ii = 0; ii < coins.Count; ii++)
                {
                    if (i >= coins[ii])
                    {
                        if (minNumberCoins[i - coins[ii]] + 1 < minNumberCoins[i])
                        {
                            minNumberCoins[i] = minNumberCoins[i - coins[ii]] + 1;
                        }
                    }
                }
            }
            return minNumberCoins[money];
        }
        public static List<SignedPermutations> GreedySort(SignedPermutations signedPermutations)
        {
            var permutations = signedPermutations.permutations;
            var reversalList = new List<List<int>>();
            for (var i = 1; i <= permutations.Count; i++)
            {
                var newPermutations = new List<int>();
                if (permutations[i - 1] != i)
                {
                    var l = 0;
                    if (permutations.Contains(i))
                    {
                        l = permutations.IndexOf(i);
                    }
                    if (permutations.Contains(-i))
                    {
                        l = permutations.IndexOf(-i);
                    }
                    newPermutations = new List<int>(permutations);
                    for (var ii = i - 1; ii <= l; ii++)
                    {
                        newPermutations[ii] = -permutations[l - (ii - i) - 1];
                    }
                    reversalList.Add(newPermutations);
                    permutations = newPermutations;
                }
                if (permutations[i - 1] == -i)
                {
                    newPermutations = new List<int>(permutations);
                    newPermutations[i - 1] = i;
                    reversalList.Add(newPermutations);
                    permutations = newPermutations;
                }
            }
            var result = new List<SignedPermutations>();
            foreach (var list in reversalList)
            {
                result.Add(new SignedPermutations(list));
            }
            return result;
        }
    }
}