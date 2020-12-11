using AdventOfCode.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tests.SolutionTests
{
    [TestClass]
    public class Test_Solution_Day06
    {
        [TestMethod]
        public void Test_Solves_Day06_Part1()
        {
            var day = new Day06();
            var answer = day.First();

            Assert.AreEqual(6565, answer);
        }

        [TestMethod]
        public void Test_Solves_Day06_Part2()
        {
            var day = new Day06();
            var answer = day.Second();

            Assert.AreEqual(3137, answer);
        }


        [TestMethod]
        public void Test_Unique_Character_Count()
        {
            var day = new Day06();

            Assert.AreEqual(3, day.GetUniqueAnswers("abc"));
            Assert.AreEqual(3, day.GetUniqueAnswers("aabc"));
            Assert.AreEqual(1, day.GetUniqueAnswers("aaaa"));
            Assert.AreEqual(1, day.GetUniqueAnswers("b"));
        }

        [TestMethod]
        public void Test_Answers_Fully_Contained_Count()
        {
            var day = new Day06();

            Assert.AreEqual(3, day.GetAnswersFullyContained(new string[] { "abc" }));
            Assert.AreEqual(0, day.GetAnswersFullyContained(new string[] { "a", "b", "c" }));
            Assert.AreEqual(1, day.GetAnswersFullyContained(new string[] { "ab", "ac" }));
            Assert.AreEqual(1, day.GetAnswersFullyContained(new string[] { "a", "a", "a", "a" }));
            Assert.AreEqual(1, day.GetAnswersFullyContained(new string[] { "b" }));
        }
    }
}
