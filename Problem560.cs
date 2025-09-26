using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /*
     * Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.
     * 
     * A subarray is a contiguous non-empty sequence of elements within an array.
     */
    internal class Problem560 : LeetCodeProblem, ILeetCodeProblem<(int[], int), int>
    {
        public Problem560() : base(Difficulty.Medium) { }
        public string FormatOutput(int result) => result.ToString();
        public IEnumerable<((int[], int), int)> GetTests()
        {
            yield return ((new int[] { 1, 1, 1 }, 2), 2);
            yield return ((new int[] { 1, 2, 3 }, 3), 2);
            yield return ((new int[] { 0, 0, 0, 0, 0 }, 0), 15);
            yield return ((new int[] { 9, 4, 20, 3, 10, 5 }, 33), 3);
        }

        /**
         * We have to find the total number of subarrays whose total element sum equals to k.
         * 
         * The idea is to keep on taking the cumulative sum of the elements as we iterate through the array
         * while keeping track of the number of times a particular cumulative sum has been seen before.
         * 
         * If the sum becomes k, that means all elements up to that index form a valid subarray.
         * 
         * Otherwise, if our current cumulative sum is not equal to k, we check if (current cumulative sum - k) has been seen before.
         * If it has, that means there exists a subarray (or multiple subarrays) that sum up to k.
         * 
         */
        public int Test((int[], int) testCase)
        {
            var (nums, k) = testCase;

            int count = 0;
            int sum = 0;
            Dictionary<int, int> prefixSums = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; ++i)
            {
                sum += nums[i];
                if (sum == k)
                {
                    ++count;
                }

                if (prefixSums.ContainsKey(sum - k))
                {
                    count += prefixSums[sum - k];
                }
                prefixSums[sum] = prefixSums.GetValueOrDefault(sum, 0) + 1;
            }

            return count;
        }
    }
}
