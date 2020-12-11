using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day04 : Day<int>
    {
        private string[] RequiredFields = {
            "ecl:", "pid:", "eyr:", "hcl:", "byr:", "iyr:", "hgt:"
        };

        public override int First()
        {
            var passports = ParseInput();
            return passports.Count(p => AreRequiredFieldsPresent(p));
        }

        public override int Second()
        {
            var passports = ParseInput();
            return passports.Count(p => AreRequiredFieldsPresent(p) && AreFieldsValid(p));
        }

        private bool AreFieldsValid(string passport)
        {
            var byr = passport.Substring(passport.IndexOf("byr:") + 4, 4);
            if (!PassportValidator.BirthYear(byr))
                return false;

            var iyr = passport.Substring(passport.IndexOf("iyr:") + 4, 4);
            if (!PassportValidator.IssueYear(iyr))
                return false;

            var eyr = passport.Substring(passport.IndexOf("eyr:") + 4, 4);
            if (!PassportValidator.ExpirationYear(eyr))
                return false;

            var hgtIndex = passport.IndexOf("hgt:");
            var nextSpace = passport.IndexOf(" ", hgtIndex);
            var hgt = "";
            if (nextSpace == -1)
                hgt = passport.Substring(hgtIndex + 4);
            else
                hgt = passport.Substring(hgtIndex + 4, nextSpace - (hgtIndex+4));
            if (!PassportValidator.Height(hgt))
                return false;

            var hcl = passport.Substring(passport.IndexOf("hcl:") + 4, 7);
            if (!PassportValidator.HairColour(hcl))
                return false;

            var ecl = passport.Substring(passport.IndexOf("ecl:") + 4, 3);
            if (!PassportValidator.EyeColour(ecl))
                return false;

            var pid = passport.Substring(passport.IndexOf("pid:") + 4, 9);
            if (!PassportValidator.Id(pid))
                return false;

            return true;
        }

        private bool AreRequiredFieldsPresent(string passport)
        {
            foreach (var field in RequiredFields)
            {
                if (!passport.Contains(field))
                {
                    return false;
                }
            }

            return true;
        }

        private List<string> ParseInput()
        {
            var input = File.ReadAllText("Inputs/Day04.txt").Trim();

            var passports = input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            return passports.Select(p => p.Replace(Environment.NewLine, " ")).ToList();
        }
    }

    public static class PassportValidator
    {
        public static readonly string[] VALID_EYE_COLOURS = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        public static bool BirthYear(string value)
        {
            var intYear = Convert.ToInt32(value);

            return intYear >= 1920 && intYear <= 2002;
        }

        public static bool IssueYear(string value)
        {
            var intYear = Convert.ToInt32(value);

            return intYear >= 2010 && intYear <= 2020;
        }

        public static bool ExpirationYear(string value)
        {
            var intYear = Convert.ToInt32(value);

            return intYear >= 2020 && intYear <= 2030;
        }

        public static bool Height(string value)
        {
            var cm = value.Contains("cm");
            var inches = value.Contains("in");

            if (cm)
            {
                var cmHeight = Convert.ToInt32(value.Replace("cm", ""));
                return cmHeight >= 150 && cmHeight <= 193;
            }
            else if (inches)
            {
                var inHeight = Convert.ToInt32(value.Replace("in", ""));
                return inHeight >= 59 && inHeight <= 76;
            }

            return false;
        }

        public static bool HairColour(string value)
        {
            return Regex.IsMatch(value, "^#{1}[0-9a-f]{6}$");
        }

        public static bool EyeColour(string value)
        {
            return VALID_EYE_COLOURS.Contains(value);
        }

        public static bool Id(string value)
        {
            return Regex.IsMatch(value, "^[0-9]{9}$");
        }
    }
}
