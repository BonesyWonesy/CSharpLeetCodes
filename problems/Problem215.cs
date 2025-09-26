using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    /**
     * 
     *
     *Given an integer array nums and an integer k, return the kth largest element in the array.
     *
     *Note that it is the kth largest element in the sorted order, not the kth distinct element.
     *
     *Can you solve it without sorting?
     */
    internal class Problem215 : LeetCodeProblem, ILeetCodeProblem<(int[], int), int>
    {
        public Problem215() : base(Difficulty.Medium) { }
        public string FormatOutput(int result) => result.ToString();
        public IEnumerable<((int[], int), int)> GetTests()
        {
            yield return ((new int[] { 3, 2, 1, 5, 6, 4 }, 2), 5);
            yield return ((new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4), 4);
            yield return ((new int[] { 1 }, 1), 1);
            yield return ((new int[] { 2, 1 }, 1), 2);
            yield return ((new int[] { -1, -1 }, 2), -1);
        }

        /**
         * A heap is a very powerful data structure that allows us to efficiently find the maximum or minimum value in a dynamic dataset.
         */
        public int Test((int[], int) testCase)
        {
            int[] nums = testCase.Item1;
            IHeap heap = new MinHeap(nums.Length);

            for (int i = 0; i < nums.Length; ++i)
            {
                heap.Add(nums[i]);
                if( heap.Size() > testCase.Item2)
                {
                    heap.Pop();
                }
            }

            return heap.Peek();            
        }
    }
}
