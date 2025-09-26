using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /// <summary>
    /// Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1.
    /// </summary>
    internal class Problem387 : LeetCodeProblem, ILeetCodeProblem<string, int>
    {
        public Problem387() : base(Difficulty.Easy) { }
        public string FormatOutput(int output) => $"{output}";

        public IEnumerable<(string, int)> GetTests()
        {
            yield return ("leetcode", 0);
            yield return ("loveleetcode", 2);
            yield return ("aabb", -1);
        }

        public int Test(string s)
        {
            /*Dictionary<char, (int, int)> letterCount = new Dictionary<char, (int, int)>();

            for(int i = 0; i < s.Length; ++i)
            {
                if (letterCount.TryGetValue(s[i], out (int, int)val))
                {
                    letterCount[s[i]] = (i, letterCount[s[i]].Item2 + 1);
                } else
                {
                    letterCount[s[i]] = (i, 1);
                }
            }

            int targetIdx = int.MaxValue;

            foreach (var item in letterCount)
            {
                if (item.Value.Item2 == 1)
                {
                    if (item.Value.Item1 < targetIdx)
                    {
                        targetIdx = item.Value.Item1;
                    }
                }                
            }

            return targetIdx == int.MaxValue ? -1 : targetIdx;
            */

            int firstUnique = int.MaxValue;
            for (char c = 'a'; c <= 'z'; c++) {
                if (s.Contains(c)) {
                    if (s.IndexOf(c) == s.LastIndexOf(c)) {
                        firstUnique = Math.Min(firstUnique, s.IndexOf(c));
                    }
                }
            }
            return firstUnique != int.MaxValue ? firstUnique : -1;
        }
    }
}
