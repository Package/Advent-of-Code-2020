using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day07 : Day<int>
    {
        public Dictionary<string, List<BagCount>> Map { get; set; }

        public override int First()
        {
            Map = ParseBagsFromInput("Day07");

            var bags = CanHoldBag("shiny gold bag", new HashSet<string>());
            return bags.Count;
        }

        public override int Second()
        {
            throw new NotImplementedException();
        }

        public HashSet<string> CanHoldBag(string targetBag, HashSet<string> holdingBags)
        {
            var bags = Map.Where(m => m.Value.FirstOrDefault(bc => bc.BagName == targetBag) != null).ToList();
            foreach (var b in bags)
            {
                holdingBags.Add(b.Key);
                CanHoldBag(b.Key, holdingBags);
            }

            return holdingBags;
        }

        public Dictionary<string, List<BagCount>> ParseBagsFromInput(string fileName)
        {
            var inputs = File.ReadAllLines($"Inputs/{fileName}.txt")
                    .Select(l => l.Replace("bags", "bag").Replace(".", ""))
                    .ToList();

            var bagMap = new Dictionary<string, List<BagCount>>();
            foreach (var line in inputs)
            {
                var split = line.Split(" contain ");
                var bag = split[0];
                var otherBags = split[1];

                if (otherBags.Contains("no other bag"))
                {
                    bagMap.Add(bag, new List<BagCount>());
                }
                else
                {
                    var bagList = new List<BagCount>();

                    var splitOtherBags = otherBags.Split(", ");
                    foreach (var b in splitOtherBags)
                    {
                        var firstSpaceIndex = b.IndexOf(" ");
                        var bagCount = new BagCount
                        {
                            BagName = b.Substring(firstSpaceIndex + 1),
                            NumberOfBags = Convert.ToInt32(b.Substring(0, firstSpaceIndex))
                        };

                        bagList.Add(bagCount);
                    }

                    bagMap.Add(bag, bagList);
                }
            }

            return bagMap;
        }
    }

    public class BagCount
    {
        public int NumberOfBags { get; set; }
        public string BagName { get; set; }
    }
}
