using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Days
{
    public class Day05 : Day<int>
    {
        public override int First()
        {
            var inputs = File.ReadAllLines("Inputs/Day05.txt");
            return inputs.Select(i => new BoardingPass(i)).Max(i => i.Id);
        }

        public override int Second()
        {
            throw new NotImplementedException();
        }
    }

    public class BoardingPass
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }

        public BoardingPass(string code)
        {
            Code = code;

            Row = ParseCode(Code.Substring(0, 7), 'F', 'B', 0, 127);
            Column = ParseCode(Code.Substring(7), 'L', 'R', 0, 7);

            Id = (Row * 8) + Column;
        }

        private int ParseCode(string codes, char lower, char upper, int min, int max)
        {
            int minRange = min;
            int maxRange = max;

            for (var index = 0; index < codes.Length; index++)
            {
                var code = codes[index];

                if (index == codes.Length - 1)
                {
                    return (code == lower ? minRange : maxRange);
                }
                else if (code == lower)
                {
                    maxRange = minRange + ((maxRange - minRange) / 2);
                }
                else if (code == upper)
                {
                    minRange = 1 + (minRange + ((maxRange - minRange) / 2));
                }
            }

            return -1;
        }
    }
}
