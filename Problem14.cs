using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /// <summary>
    /// Write a function to find the longest common prefix string amongst an array of strings.
    /// 
    /// If there is no common prefix, return an empty string "".
    /// </summary>
    internal class Problem14 : LeetCodeProblem, ILeetCodeProblem<string[], string>
    {
        public Problem14() : base(Difficulty.Easy) { }
        public string FormatOutput(string output) => output;

        public IEnumerable<(string[], string)> GetTests()
        {
            yield return (new string[] { "flower", "flow", "flight" }, "fl");
            yield return (new string[] { "dog", "racecar", "car" }, "");
            yield return (new string[] { "" }, "");
            yield return (new string[] { "a", "ab" }, "a");
        }

        public string Test(string[] strs)
        {
            bool useOrig = false;
            if (!useOrig) { 
                return OptimizedApproach(strs);
            }
            
            if (strs.Length == 0) { 
                return "";
            }

            StringBuilder sb = new StringBuilder();
                        
            int maxLen = 0;
            int minLen = int.MaxValue;

            for(int s = 0; s < strs.Length; ++s)
            {
                if (strs[s].Length == 0)
                {
                    return "";
                }
                maxLen = Math.Max(maxLen, strs[s].Length);
                minLen = Math.Min(minLen, strs[s].Length);
            }

            int checkedIdx = 0;
            bool reachedMax = false;

            while (checkedIdx < maxLen)
            {
                char targetChar = strs[0][checkedIdx];
                for(int s = 0; s < strs.Length; ++s)
                {
                    if (strs.Length < checkedIdx)
                    {
                        reachedMax = true;
                        continue;
                    }
                    if (strs[s][checkedIdx] != targetChar)
                    {
                        return sb.ToString();
                    }
                }

                sb.Append(targetChar);
                checkedIdx++;
                if (reachedMax || checkedIdx == minLen) { break; }
            }


            return sb.ToString();
        }

        public string OptimizedApproach(string[] strs)
        {
            if (strs.Length == 0)
            {
                return "";
            }

            // Sort the array in lexographical order
            Array.Sort(strs);

            string first = strs[0];
            string last = strs[strs.Length - 1];

            StringBuilder sb = new StringBuilder();

            // Iterate only over the smallest length string
            for(int i = 0; i < Math.Min(first.Length, last.Length); ++i)
            {
                if (first[i] != last[i])
                {
                    break;
                }
                sb.Append(first[i]);
            }

            return sb.ToString();
        }
    }
}
