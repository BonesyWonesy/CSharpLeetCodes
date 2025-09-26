using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /**
     * 
     * Given a string s of '(' , ')' and lowercase English characters.
     * 
     * Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions ) so that the resulting parentheses string is valid and return any valid string.
     * 
     * Formally, a parentheses string is valid if and only if:
     * - It is the empty string, contains only lowercase characters, or
     * - It can be written as AB (A concatenated with B), where A and B are valid strings, or
     * - It can be written as (A), where A is a valid string.
     * 
     */
    internal class Problem1249 : LeetCodeProblem, ILeetCodeProblem<string, string>
    {
        public Problem1249() : base(Difficulty.Medium) { }
        public string FormatOutput(string output) => output;

        public IEnumerable<(string, string)> GetTests()
        {
            yield return ("lee(t(c)o)de)", "lee(t(c)o)de");
            yield return ("a)b(c)d", "ab(c)d");
            yield return ("))((", "");
        }

        public string Test(string testCase)
        {
            List<int> toRemove = new List<int>();
            int parenMatch = 0;

            for( int l = 0; l < testCase.Length; ++l)
            {
                if (testCase[l] == '(')
                {
                    ++parenMatch;
                } else if (testCase[l] == ')')
                {
                    if (parenMatch == 0)
                    {
                        toRemove.Add(l);
                    }
                    else { --parenMatch; }
                }
            }

            parenMatch = 0;
            for (int r = testCase.Length - 1; r >= 0; --r)
            {
                if (testCase[r] == ')')
                {
                    ++parenMatch;
                } else if (testCase[r] == '(')
                {
                    if (parenMatch == 0)
                    {
                        toRemove.Add(r);
                    }
                    else
                    {
                        --parenMatch;
                    }
                }
            }

            toRemove.Sort();

            string result = testCase;

            for(int r = toRemove.Count - 1; r >= 0; --r)
            {
                result = result.Remove(toRemove[r], 1);
            }

            return result;
        }
    }
}
