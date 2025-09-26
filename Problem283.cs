using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /// <summary>
    /// Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
    /// Note that you must do this in-place without making a copy of the array.
    /// </summary>
    internal class Problem283 : LeetCodeProblem, ILeetCodeProblem<int[], int[]>
    {
        public Problem283() : base(Difficulty.Easy) { }

        public string FormatOutput(int[] result) => OutputFormatters.Output(result);

        public IEnumerable<(int[], int[])> GetTests()
        {
            yield return (new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 });
            yield return (new int[] { 0, 0, 1, 4, 0, 8, 10 }, new int[] { 1, 4, 8, 10, 0, 0, 0 });
            yield return (new int[] { 1, 2, 3, 0, 0, 0, 11, 12, 13 }, new int[] { 1, 2, 3, 11, 12, 13, 0, 0, 0 });
            yield return (new int[] { 0 }, new int[] { 0 });
        }

        public int[] Test(int[] nums)
        {
            // 0, 1, 0, 3, 12  nz = 0, i = 0
            // 1, 0, 0, 2, 12  nz = 0, i = 1 => nz = 1
            // 1, 0, 0, 2, 12  nz = 1, i = 2
            // 1, 2, 0, 0, 12  nz = 1, i = 3 => nz = 2
            // 1, 2, 12, 0, 0  nz = 2, i = 4 => nz = 3

            int insertIdx = 0;

            for (int n = 0; n < nums.Length; ++n)
            {
                if (nums[n] != 0)
                {
                    int t = nums[n];
                    nums[n] = nums[insertIdx];
                    nums[insertIdx] = t;
                    ++insertIdx;
                }
            }

            return nums;
        }
    }
}
