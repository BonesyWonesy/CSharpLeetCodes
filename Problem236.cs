using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /*
     * 
     * Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
     * 
     * According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined 
     * between two nodes p and q as the lowest node in T that has both p and q as descendants 
     * (where we allow a node to be a descendant of itself).”
     * 
     */
    internal class Problem236 : LeetCodeProblem, ILeetCodeProblem<(int?[], int, int), int>
    {         public Problem236() : base(Difficulty.Medium) { }
        public string FormatOutput(int result) => result.ToString();
        public IEnumerable<((int?[], int, int), int)> GetTests()
        {
            yield return ((new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 }, 5, 1), 3);
            yield return ((new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 }, 5, 4), 5);
            yield return ((new int?[] { 1, 2 }, 1, 2), 1);
        }

        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         *         this.val = val;
         *         this.left = left;
         *         this.right = right;
         *     }
         * }
         */
        public int Test((int?[], int, int) testCase)
        {
            BinaryTree tree = new BinaryTree(testCase.Item1);
            BinaryTree.TreeNode? root = tree.GetRoot();
            BinaryTree.TreeNode? p = tree.FindNode(testCase.Item2);
            BinaryTree.TreeNode? q = tree.FindNode(testCase.Item3);

            return LowestCommonAncestor(root, p, q)?.val ?? -1;
        }

        /*
         * We use post-order traversal to traverse the tree to determine if this node has the children of p and q.
         */
        private BinaryTree.TreeNode? LowestCommonAncestor(BinaryTree.TreeNode? root, BinaryTree.TreeNode? p, BinaryTree.TreeNode? q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }
            BinaryTree.TreeNode? left = LowestCommonAncestor(root.left, p, q);
            BinaryTree.TreeNode? right = LowestCommonAncestor(root.right, p, q);
            if (left != null && right != null)
            {
                return root;
            }
            return left ?? right;
        }

    }
}
