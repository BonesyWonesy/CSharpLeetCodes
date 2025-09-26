using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    internal class Problem125 : LeetCodeProblem, ILeetCodeProblem<string, bool>
    {
        public Problem125() : base(Difficulty.Easy) { }
        public string FormatOutput(bool result) => result.ToString();
        public IEnumerable<(string, bool)> GetTests()
        {
            return new (string, bool)[]
            {
                ("A man, a plan, a canal: Panama", true),
                ("race a car", false),
                (" ", true),
                ("0P", false)
            };
        }

        public bool Test(string testCase)
        {
            int leftIdx = 0;
            int rightIdx = testCase.Length - 1;

            while (leftIdx < rightIdx)
            {
                if (!char.IsLetterOrDigit(testCase[leftIdx]))
                {
                    ++leftIdx;
                    continue;
                }

                if (!char.IsLetterOrDigit(testCase[rightIdx]))
                {
                    --rightIdx;
                    continue;
                }

                if (char.ToLower(testCase[leftIdx]) != char.ToLower(testCase[rightIdx]))
                {
                    return false;
                }

                ++leftIdx;
                --rightIdx;
            }

            return true;
        }
    }
}
