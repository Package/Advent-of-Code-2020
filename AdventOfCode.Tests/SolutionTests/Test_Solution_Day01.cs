using AdventOfCode.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tests.SolutionTests
{
    [TestClass]
    public class Test_Solution_Day01
    {
        [TestMethod]
        public void Test_Solves_Day01_Part1()
        {
            var day = new Day01();
            var answer = day.First();

            Assert.AreEqual(806656, answer);
        }

        [TestMethod]
        public void Test_Solves_Day01_Part2()
        {
            var day = new Day01();
            var answer = day.Second();

            Assert.AreEqual(230608320, answer);
        }
    }
}
