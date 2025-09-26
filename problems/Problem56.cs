using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    /*
     * Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.
     */
    internal class Problem56 : LeetCodeProblem, ILeetCodeProblem<int[][], int[][]>
    {
        public Problem56() : base(Difficulty.Medium) { }

        public string FormatOutput(int[][] result) => "[" + string.Join(", ", result.Select(r => "[" + string.Join(", ", r) + "]")) + "]";

        public IEnumerable<(int[][], int[][])> GetTests()
        {
            yield return (new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } },
                           new int[][] { new int[] { 1, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } });
            yield return (new int[][] { new int[] { 1, 4 }, new int[] { 4, 5 } },
                           new int[][] { new int[] { 1, 5 } });
            yield return (new int[][] { new int[] { 4, 7 }, new int[] { 1, 4 } },
                           new int[][] { new int[] { 1, 7 } });
            yield return (new int[][] { new int[] { 1, 4 }, new int[] { 0, 5 } }, 
                           new int[][] { new int[] { 0, 5 } });
        }
        //  [0, [1, 2, 3, 4], 5]
        //  0, [1, [2, 3], 4, 5, 6], 7, [8, 9, 10], 11, 12, 13, 14, [15, 16, 17, 18], 19, 20
        public int[][] Test (int[][] testCase)
        {
            List<int[]> result = new List<int[]>();

            Array.Sort(testCase, (a, b) => a[0].CompareTo(b[0]));

            result.Add(testCase[0]);

            for(int i = 1; i < testCase.Length; ++i)
            {
                int[] last = result[result.Count - 1];

                if (last[1] >= testCase[i][0])
                {
                    last[1] = Math.Max(last[1], testCase[i][1]);
                } else
                {
                    result.Add(testCase[i]);
                }
            }

            return result.ToArray();
        }
    }
}
