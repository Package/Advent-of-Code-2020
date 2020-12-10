using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Days
{
    public class Day01 : Day<long>
    {
        private const int TARGET = 2020;
        private string[] Inputs = File.ReadAllLines("Inputs/Day01.txt");

        public override long First()
        {
            for (var x = 0; x < Inputs.Length; x++)
            {
                for (var y = 0; y < Inputs.Length; y++)
                {
                    if (x == y)
                        continue;

                    var targetCheck = MeetsTarget(Inputs[x], Inputs[y]);
                    if (targetCheck > -1)
                        return targetCheck;
                }
            }

            return -1;
        }

        public override long Second()
        {
            for (var x = 0; x < Inputs.Length; x++)
            {
                for (var y = 0; y < Inputs.Length; y++)
                {
                    for (var z = 0; z < Inputs.Length; z++)
                    {
                        if (x == y || x == z || y == z)
                            continue;

                        var targetCheck = MeetsTarget(Inputs[x], Inputs[y], Inputs[z]);
                        if (targetCheck > -1)
                            return targetCheck;
                    }
                }
            }

            return -1;
        }

        public long MeetsTarget(params string[] inputs)
        {
            long sum = 0;
            long times = 1;

            foreach (var input in inputs)
            {
                var asInt = Convert.ToInt32(input);

                sum += asInt;
                times *= asInt;
            }

            return sum == TARGET ? times : -1;
        }
    }
}
