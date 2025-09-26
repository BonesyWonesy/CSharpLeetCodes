using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /**
     * Given the root node of a binary search tree and two integers low and high, return the sum of values of all nodes with a value in the inclusive range [low, high].
     * 
     */
    internal class Problem938 : LeetCodeProblem, ILeetCodeProblem<(BinaryTree, int, int), int>
    {
        public Problem938() : base(Difficulty.Easy) { }
        public string FormatOutput(int result) => result.ToString();

        public IEnumerable<((BinaryTree, int, int), int)> GetTests()
        {
            yield return ((new BinaryTree(new int?[] { 10, 5, 15, 3, 7, null, 18 }), 7, 15), 32);
            yield return ((new BinaryTree(new int?[] { 10, 5, 15, 3, 7, 13, 18, 1, null, 6 }), 6, 10), 23);
        }

        public int Test((BinaryTree, int, int) testCase)
        {
            return RangeSum(testCase.Item1.GetRoot(), testCase.Item2, testCase.Item3);
        }

        private int RangeSum(BinaryTree.TreeNode? root, int low, int high)
        {
            if( root == null )
            {
                return 0;
            }

            int sum = RangeSum(root.left, low, high) + RangeSum(root.right, low, high);

            if ( root.val >= low && root.val <= high )
            {
                sum += root.val;
            }

            return sum;
        }
    }
}
