using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    internal class Problem34 : LeetCodeProblem, ILeetCodeProblem<(int[], int), int[]>
    {
        public Problem34() : base(Difficulty.Medium) { }

        public string FormatOutput(int[] result) => "[" + string.Join(", ", result) + "]";
        public IEnumerable<((int[], int), int[])> GetTests()
        {
            yield return ((new int[] { 5, 7, 7, 8, 8, 10 }, 8), new int[] { 3, 4 });
            yield return ((new int[] { 5, 7, 7, 8, 8, 10 }, 6), new int[] { -1, -1});
            yield return ((new int[] { }, 0), new int[] { -1, -1 });
            yield return ((new int[] { 7, 8, 8, 8, 8, 8, 8, 8, 8, 9 }, 8), new int[] { 1, 8 });
        }

        public int[] Test((int[], int) testCase)
        {
            
            int[] result = new int[]{ -1, -1 };

            if (testCase.Item1.Length == 0)
            {
                return result;
            }

            int firstIndex = SearchArray(testCase.Item1, testCase.Item2, 0, testCase.Item1.Length - 1, true);
            int lastIndex = SearchArray(testCase.Item1, testCase.Item2, 0, testCase.Item1.Length - 1, false);

            result[0] = firstIndex;
            result[1] = lastIndex;
            return result;
        }

        public int SearchArray(int[] nums, int target, int startIndex, int endIndex, bool min)
        {
            if (startIndex > endIndex)
            {
                return -1;
            }

            int midIndex = (startIndex + endIndex) / 2;

            if (nums[midIndex] == target)
            {
                int minIndex = SearchArray(nums, target, startIndex, midIndex - 1, true);
                int maxIndex = SearchArray(nums, target, midIndex + 1, endIndex, false);

                if (minIndex == -1) {
                    minIndex = midIndex;
                }

                if (maxIndex == -1)
                {
                    maxIndex = midIndex;
                }

                if (minIndex != -1 && maxIndex != -1)
                {
                    return min ? Math.Min(minIndex, maxIndex) : Math.Max(minIndex, maxIndex);
                } else if (minIndex != -1)
                {
                    return minIndex;
                } else
                {
                    return maxIndex;
                }
            }
            else if (nums[midIndex] < target)
            {
                return SearchArray(nums, target, midIndex + 1, endIndex, min);
            } else
            {
                return SearchArray(nums, target, startIndex, midIndex - 1, min);
            }
        }
    }
}
