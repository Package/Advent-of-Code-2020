using AdventOfCode.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tests.SolutionTests
{
    [TestClass]
    public class Test_Solution_Day07
    {
        [TestMethod]
        public void Test_Solves_Day06_Part1()
        {
            var day = new Day07();
            var answer = day.First();

            Assert.AreEqual(268, answer);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_Solves_Day06_Part2()
        {
            var day = new Day07();
            var answer = day.Second();
        }

        [TestMethod]
        public void Test_Can_Parse_Example_Input()
        {
            var day = new Day07();
            var parsed = day.ParseBagsFromInput("Day07_Example");

            Assert.AreEqual(9, parsed.Count);
        }
    }
}
