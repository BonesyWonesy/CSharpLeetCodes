using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpLeetCode.problems
{
    public class Input88
    {
        public int[] nums1;
        public int[] nums2;
        public int n, m;
    }

    /// <summary>
    /// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n,
    /// representing the number of elements in nums1 and nums2 respectively.
    /// 
    /// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
    /// 
    /// The final sorted array should not be returned by the function, but instead be stored inside the array nums1.
    /// To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should
    /// be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
    /// </summary>
    internal class Problem88 : LeetCodeProblem, ILeetCodeProblem<Input88, int[]>
    {
        public Problem88() : base(Difficulty.Easy) { }

        public string FormatOutput(int[] result) => "[" + string.Join(",", result) + "]";

        public IEnumerable<(Input88, int[])> GetTests()
        {
            return new (Input88, int[])[]
            {
                (new Input88 { nums1 = new int[] {1,2,3,0,0,0}, m = 3, nums2 = new int[] {2,5,6}, n = 3 }, new int[] {1,2,2,3,5,6}),
                (new Input88 { nums1 = new int[] {1}, m = 1, nums2 = new int[] {}, n = 0 }, new int[] {1}),
                (new Input88 { nums1 = new int[] {0}, m = 0, nums2 = new int[] {1}, n = 1 }, new int[] {1}),
                (new Input88 { nums1 = new int[] {4,5,6,0,0,0}, m = 3, nums2 = new int[] {1,2,3}, n = 3 }, new int[] {1,2,3,4,5,6}),
                (new Input88 { nums1 = new int[] {1,2,4,5,6,0}, m = 5, nums2 = new int[] {3}, n = 1 }, new int[] {1,2,3,4,5,6})
            };
        }

        public int[] Test(Input88 testCase) {

            // We'll be inserting from the back and working our was in decreasing order
            int insertionPos = testCase.n + testCase.m - 1;

            // i & j are going to be iteration indices between arrays nums1, and nums2.
            int i = testCase.m - 1;
            int j = testCase.n - 1;

            while (i >= 0 || j >= 0)
            {
                if (j < 0 || i >= 0 && testCase.nums1[i] > testCase.nums2[j])
                {
                    testCase.nums1[insertionPos--] = testCase.nums1[i];
                    --i;
                }
                else
                {
                    testCase.nums1[insertionPos--] = testCase.nums2[j];
                    --j;
                }
            }

            return testCase.nums1;
        }
    }
}
