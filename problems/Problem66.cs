using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpLeetCode.problems
{
    /// <summary>
    /// You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer.
    /// The digits are ordered from most significant to least significant in left-to-right order.
    /// The large integer does not contain any leading 0's.
    /// 
    /// Increment the large integer by one and return the resulting array of digits.
    /// </summary>
    internal class Problem66 : LeetCodeProblem, ILeetCodeProblem<int[], int[]>
    {
        public Problem66() : base(Difficulty.Easy) { }
        public string FormatOutput(int[] result) => OutputFormatters.Output(result);

        public IEnumerable<(int[], int[])> GetTests()
        {
            yield return (new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 });
            yield return (new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 2 });
            yield return (new int[] { 9 }, new int[] { 1, 0 });
            yield return (new int[] { 9, 8, 9 }, new int[] { 9, 9, 0 });
        }

        public int[] Test(int[] digits)
        {
            bool hasCarry = false;
            bool added = false;
            LinkedList<int> result = new LinkedList<int>();

            for(int i = digits.Length - 1; i >= 0; --i)
            {
                if (digits[i] == 9 && (i == digits.Length - 1 || hasCarry))
                {
                    hasCarry = true;
                    result.AddFirst(0);
                } else if (hasCarry) {
                    hasCarry = false;
                    added = true;
                    result.AddFirst(digits[i] + 1);
                } else
                {
                    if (!added)
                    {
                        added = true;
                        result.AddFirst(digits[i] + 1);
                    } else
                    {
                        result.AddFirst(digits[i]);
                    }
                }
            }

            if (hasCarry)
            {
                result.AddFirst(1);
            }

            return result.ToArray();
        }
    }
}
