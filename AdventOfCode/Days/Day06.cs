using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Days
{
    public class Day06 : Day<int>
    {
        private List<string> ParseInput()
        {
            return File.ReadAllText("Inputs/Day06.txt").Split(Environment.NewLine + Environment.NewLine).ToList();
        }

        public override int First()
        {
            var input = ParseInput();
            var answers = input.Select(i => i.Replace(Environment.NewLine, "")).ToList();

            return answers.Sum(a => GetUniqueAnswers(a));
        }

        public override int Second()
        {
            var input = ParseInput();
            var answers = input.Select(i => i.Split(Environment.NewLine)).ToList();

            return answers.Sum(a => GetAnswersFullyContained(a));
        }

        public int GetAnswersFullyContained(string[] answers)
        {
            var unique = new HashSet<char>();

            foreach (var answer in answers)
            {
                foreach (var c in answer.ToCharArray())
                {
                    if (answers.Count(a => a.Contains(c)) == answers.Length)
                    {
                        unique.Add(c);
                    }
                }
            }

            return unique.Count;
        }

        public int GetUniqueAnswers(string answers)
        {
            var unique = new HashSet<char>();

            foreach (var c in answers.ToCharArray())
            {
                unique.Add(c);
            }

            return unique.Count;
        }
    }
}
