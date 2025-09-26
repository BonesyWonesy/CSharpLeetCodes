using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpLeetCode.problems
{
    /// <summary>
    /// You are a product manager and currently leading a team to develop a new product.
    /// Unfortunately, the latest version of your product fails the quality check.
    /// Since each version is developed based on the previous version, all the versions
    /// after a bad version are also bad.
    /// 
    /// Suppose you have n versions[1, 2, ..., n] and you want to find out the first bad one,
    /// which causes all the following ones to be bad.
    /// 
    /// You are given an API bool isBadVersion(version) which returns whether version is bad.Implement a function to find the first bad version.You should minimize the number of calls to the API.
    /// </summary>
    internal class Problem278 : LeetCodeProblem, ILeetCodeProblem<(int, int), int>
    {
        public Problem278() : base(Difficulty.Easy) { }

        public string FormatOutput(int output) => $"{output}";

        public IEnumerable<((int, int), int)> GetTests()
        {
            yield return ((5, 4), 4);
            yield return ((1, 1), 1);
            yield return ((9, 6), 6);
        }
        private bool IsBadVersion(int version, int answ)
        {
            return version >= answ;
        }

        /// <summary>
        /// A simple approach would just be iterate over till finding the first. A quicker solution is to perform a binary search.
        /// A linear approach would be O(n) in complexity
        /// Binary searching should take a lot less time and be O(log n) in time
        /// </summary>
        /// <param name="testCase"></param>
        /// <returns></returns>
        public int Test((int, int) testCase)
        {
            return ExponentialSearch(testCase.Item1, testCase.Item2);
            int lowestVer = 1;
            int highestVer = testCase.Item2;

            while (lowestVer <= highestVer)
            {
                int middleVer = lowestVer + (highestVer - lowestVer) / 2;
                if (IsBadVersion(middleVer, testCase.Item2))
                {
                    highestVer = middleVer - 1;
                }
                else
                {
                    lowestVer = middleVer + 1;
                }
            }

            return lowestVer;
        }

        public int ExponentialSearch(int version, int answ)
        {
            int lowerBound = 1;
            int upperBound = 1;

            while (!IsBadVersion(upperBound, answ))
            {
                lowerBound = upperBound;
                upperBound = upperBound * 2;
            }

            while (lowerBound <= upperBound) {
                int middleVersion = lowerBound + (upperBound - lowerBound) / 2;
                if (IsBadVersion(middleVersion, answ))
                {
                    upperBound = middleVersion - 1;
                } else
                {
                    lowerBound = middleVersion + 1;
                }
            }

            return lowerBound;
        }
    }
}
