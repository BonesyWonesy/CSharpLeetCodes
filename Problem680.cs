using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /*
     * Given a string s, return true if the s can be palindrome after deleting at most one character from it.
    */
    internal class Problem680 : LeetCodeProblem, ILeetCodeProblem<string, bool>
    {
        public Problem680() : base(Difficulty.Easy) { }

        public string FormatOutput(bool result) => result.ToString();

        public IEnumerable<(string, bool)> GetTests()
        {
            return new (string, bool)[]
            {
                ("aba", true),
                ("abca", true),
                ("abc", false),
                ("deeee", true)
            };
        }

        private bool IsPalendrome(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;                    
                }
                ++left;
                --right;
            }
            return true;
        }

        public bool Test(string testCase)
        {
            int left = 0;
            int right = testCase.Length - 1;

            while (left < right)
            {
                if (testCase[left] != testCase[right])
                {
                    return IsPalendrome(testCase, left + 1, right) || IsPalendrome(testCase, left, right - 1);
                } else
                {
                    ++left;
                    --right;
                }
            }

            return true;
        }

    }
}
