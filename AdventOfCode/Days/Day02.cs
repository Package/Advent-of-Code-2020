using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Days
{
    public class Day02 : Day<int>
    {
        public override int First()
        {
            var inputs = File.ReadAllLines("Inputs/Day02.txt");

            var policies = new List<PasswordPolicy>();
            foreach (var line in inputs)
            {
                policies.Add(PasswordPolicy.Parse(line));
            }

            return policies.Count(p => p.IsValid());
        }

        public override int Second()
        {
            throw new NotImplementedException();
        }
    }

    public class PasswordPolicy
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char Character { get; set; }
        public string Password { get; set; }

        public static PasswordPolicy Parse(string line)
        {
            var policy = new PasswordPolicy();

            var firstSpaceIndex = line.IndexOf(" ");

            var lengths = line.Substring(0, firstSpaceIndex).Split("-");
            policy.Min = Convert.ToInt32(lengths[0]);
            policy.Max = Convert.ToInt32(lengths[1]);

            policy.Character = line[firstSpaceIndex + 1];

            policy.Password = line.Substring(line.IndexOf(": ") + 2);

            return policy;
        }

        public bool IsValid()
        {
            var countInPassword = Password.Count(p => p == Character);

            return countInPassword >= Min && countInPassword <= Max;
        }
    }
}
