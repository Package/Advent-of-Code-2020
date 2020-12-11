using AdventOfCode.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tests.SolutionTests
{
    [TestClass]
    public class Test_Solution_Day05
    {
        [TestMethod]
        public void Test_Solves_Day05_Part1()
        {
            var day = new Day05();
            var answer = day.First();

            Assert.AreEqual(963, answer);
        }

        [TestMethod]
        public void Test_Solves_Day05_Part2()
        {
            var day = new Day05();
            var answer = day.Second();

            Assert.AreEqual(592, answer);
        }

        [TestMethod]
        public void Test_Can_Parse_BoardingPassCode()
        {
            var pass = new BoardingPass("FBFBBFFRLR");
            Assert.AreEqual(44, pass.Row);
            Assert.AreEqual(5, pass.Column);
            Assert.AreEqual(357, pass.Id);

            var pass2 = new BoardingPass("BFFFBBFRRR");
            Assert.AreEqual(70, pass2.Row);
            Assert.AreEqual(7, pass2.Column);
            Assert.AreEqual(567, pass2.Id);

            var pass3 = new BoardingPass("FFFBBBFRRR");
            Assert.AreEqual(14, pass3.Row);
            Assert.AreEqual(7, pass3.Column);
            Assert.AreEqual(119, pass3.Id);

            var pass4 = new BoardingPass("BBFFBBFRLL");
            Assert.AreEqual(102, pass4.Row);
            Assert.AreEqual(4, pass4.Column);
            Assert.AreEqual(820, pass4.Id);
        }
    }
}
