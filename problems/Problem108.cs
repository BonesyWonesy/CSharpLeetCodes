using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    /// <summary>
    /// Given an integer array nums where the elements are sorted in ascending order,
    /// convert it to a height-balanced binary search tree.
    /// 
    /// A height-balanced binary tree is a binary tree in which the depth of the two
    /// subtrees of every node never differs by more than one.
    /// </summary>
    internal class Problem108 : LeetCodeProblem, ILeetCodeProblem<int[], int?[]>
    {
        public Problem108() : base(Difficulty.Easy) { }

        public string FormatOutput(int?[] output) => OutputFormatters.Output(output);

        public IEnumerable<(int[], int?[])> GetTests()
        {
            yield return (new int[] { -10, -3, 0, 5, 9 }, new int?[] { 0, -3, 9, -10, null, 5 });
            yield return (new int[] { 1, 3 }, new int?[] { 3, 1 });
        }

        public BinaryTree.TreeNode? BuildSubtree(int[] input, int leftIdx, int rightIdx)
        {
            int midIdx = (rightIdx - leftIdx) / 2;

            BinaryTree.TreeNode root = new BinaryTree.TreeNode(input[midIdx]);
            root.left = BuildSubtree(input, leftIdx, midIdx - 1);
            root.right = BuildSubtree(input, midIdx + 1, rightIdx);
            return root;
        }

        public int?[] Test(int[] intput)
        {
            /*
            if (intput.Length == 0)
            {
                return null;
            }
            */


            return null;

        }

    }
}
