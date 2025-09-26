using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /// <summary>
    /// Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
    /// </summary>
    internal class Problem28 : LeetCodeProblem, ILeetCodeProblem<(string, string), int>
    {
        public Problem28() : base(Difficulty.Easy) { }
        public string FormatOutput(int output) => output.ToString();

        public IEnumerable<((string, string), int)> GetTests()
        {
            yield return (("sadbutsad", "sad"), 0);
            yield return (("leetcode", "leeto"), -1);
            yield return (("aaaa", "aaa"), -1);
            yield return (("mississippi", "issip"), 4);
        }

        public int Test((string, string) testCase)
        {
            string haystack = testCase.Item1;
            string needle = testCase.Item2;

            int n = 0;
            int startIdx = -1;

            for(int h = 0; h < haystack.Length; ++h)
            {
                if (haystack[h] == needle[n] && startIdx == -1)
                {
                    startIdx = h;
                    while(h < haystack.Length && n < needle.Length)
                    {
                        if (haystack[h] == needle[n])
                        {
                            ++h;
                            ++n;
                        }
                        else { break; }                 
                    }

                    if (n == needle.Length) {
                        break;
                    } else {
                        h = startIdx;
                        startIdx = -1;
                        n = 0;
                    }
                } else
                {
                    startIdx = -1;
                    n = 0;
                }
            }

            return startIdx;
        }
    }
}
