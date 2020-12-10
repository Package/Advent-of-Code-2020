using AdventOfCode.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tests.SolutionTests
{
    [TestClass]
    public class Test_Solution_Day02
    {

        [TestMethod]
        public void Test_Can_Parse_PasswordPolicy()
        {
            var policy = PasswordPolicy.Parse("1-3 a: abcde");
            Assert.AreEqual(policy.Min, 1);
            Assert.AreEqual(policy.Max, 3);
            Assert.AreEqual(policy.Character, 'a');
            Assert.AreEqual(policy.Password, "abcde");

            policy = PasswordPolicy.Parse("1-3 b: cdefg");
            Assert.AreEqual(policy.Min, 1);
            Assert.AreEqual(policy.Max, 3);
            Assert.AreEqual(policy.Character, 'b');
            Assert.AreEqual(policy.Password, "cdefg");

            policy = PasswordPolicy.Parse("2-9 c: ccccccccc");
            Assert.AreEqual(policy.Min, 2);
            Assert.AreEqual(policy.Max, 9);
            Assert.AreEqual(policy.Character, 'c');
            Assert.AreEqual(policy.Password, "ccccccccc");
        }

        [TestMethod]
        public void Test_Solves_Day02_Part1()
        {
            var day = new Day02();
            var answer = day.First();

            Assert.AreEqual(416, answer);
        }

        [TestMethod]
        public void Test_Solves_Day02_Part2()
        {
            var day = new Day02();
            var answer = day.Second();

            Assert.AreEqual(688, answer);
        }
    }
}
