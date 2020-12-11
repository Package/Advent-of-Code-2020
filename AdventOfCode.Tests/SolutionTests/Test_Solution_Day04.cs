using AdventOfCode.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tests.SolutionTests
{
    [TestClass]
    public class Test_Solution_Day04
    {
        [TestMethod]
        public void Test_Solves_Day04_Part1()
        {
            var day = new Day04();
            var answer = day.First();

            Assert.AreEqual(206, answer);
        }

        [TestMethod]
        public void Test_Solves_Day04_Part2()
        {
            var day = new Day04();
            var answer = day.Second();

            // Todo: fix
            Assert.AreEqual(124, answer);
        }

        [TestMethod]
        public void Test_Passport_Validator()
        {
            Assert.IsFalse(PassportValidator.BirthYear("2010"));
            Assert.IsTrue(PassportValidator.BirthYear("1994"));

            Assert.IsFalse(PassportValidator.IssueYear("1999"));
            Assert.IsTrue(PassportValidator.IssueYear("2015"));

            Assert.IsFalse(PassportValidator.ExpirationYear("2010"));
            Assert.IsTrue(PassportValidator.ExpirationYear("2025"));

            Assert.IsFalse(PassportValidator.Height("150in"));
            Assert.IsTrue(PassportValidator.Height("185cm"));

            Assert.IsFalse(PassportValidator.HairColour("#abcdez"));
            Assert.IsTrue(PassportValidator.HairColour("#c6c6c6"));

            Assert.IsFalse(PassportValidator.EyeColour("blue"));
            Assert.IsTrue(PassportValidator.EyeColour("blu"));

            Assert.IsFalse(PassportValidator.Id("1239"));
            Assert.IsTrue(PassportValidator.Id("123456789"));
        }
    }
}
