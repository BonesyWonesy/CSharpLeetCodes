using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    /// <summary>
    /// Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
    /// </summary>
    internal class Problem101 : LeetCodeProblem, ILeetCodeProblem<BinaryTree.TreeNode?, bool>
    {
        public Problem101() : base(Difficulty.Easy) { }
        public string FormatOutput(bool result) => result.ToString();

        public IEnumerable<(BinaryTree.TreeNode?, bool)> GetTests()
        {
            yield return (new BinaryTree([1, 2, 2, 3, 4, 4, 3]).GetRoot(), true);
            yield return (new BinaryTree([1, 2, 2, null, 3, null, 3]).GetRoot(), false);
        }

        public bool TestSymmetry(BinaryTree.TreeNode? left, BinaryTree.TreeNode? right) {
            if (left == null && right == null)
            {
                return true;
            } else if (left == null && right != null || left != null && right == null)
            {
                return false;
            }

            if (left.val != right.val)
            {
                return false;
            }

            return TestSymmetry(left.left, right.right) && TestSymmetry(left.right, right.left);
        }

        public bool Test(BinaryTree.TreeNode? root)
        {
            return TestSymmetry(root.left, root.right);
        }
    }
}
