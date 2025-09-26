using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    /// <summary>
    /// Given two strings s and t, return true if t is an anagram of s, and false otherwise.
    /// 
    /// An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, using all the original letters exactly once.
    /// </summary>
    internal class Problem242 : LeetCodeProblem, ILeetCodeProblem<(string s, string t), bool>
    {
        public Problem242() : base(Difficulty.Easy) { }

        public string FormatOutput(bool output) => output.ToString();

        public IEnumerable<((string s, string t), bool)> GetTests()
        {
            yield return (("anagram", "nagaram"), true);
            yield return (("rat", "car"), false);
        }

        public bool Test((string s, string t) testCase)
        {
            string s = testCase.s;
            string t = testCase.t;

            if (s.Length != t.Length) {
                return false;
            }

            Dictionary<char, int> sCounts = new Dictionary<char, int>();

            for(int i = 0; i < s.Length; ++i)
            {
                sCounts[s[i]] = sCounts.GetValueOrDefault(s[i], 0) + 1;
            }

            for (int i = 0; i < t.Length; ++i)
            {
                if (!sCounts.ContainsKey(t[i]))
                {
                    return false;
                }

                int newCount = sCounts[t[i]] - 1;
                sCounts[t[i]] = newCount;

                if (newCount == 0)
                {
                    sCounts.Remove(t[i]);
                }
            }

            return sCounts.Count == 0;
        }
    }
}
