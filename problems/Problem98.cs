using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given the root of a binary tree, determine if it is a valid binary search tree (BST).
  /// 
  /// A valid BST is defined as follows:
  ///   The left subtree of a node contains only nodes with keys strictly less than the node's key.
  ///   The right subtree of a node contains only nodes with keys strictly greater than the node's key.
  ///   Both the left and right subtrees must also be binary search trees.
  /// 
  /// </summary>
  internal class Problem98 : LeetCodeProblem, ILeetCodeProblem<BinaryTree.TreeNode?, bool>
  {
    public Problem98() : base(Difficulty.Easy) { }
    public string FormatOutput(bool output) => output.ToString();
    public bool IsEqual(bool result, bool expected) => result == expected;

    public IEnumerable<(BinaryTree.TreeNode?, bool)> GetTests() {
      yield return (new BinaryTree([2, 1, 3]).GetRoot(), true);
      yield return (new BinaryTree([5, 1, 4, null, null, 3, 6]).GetRoot(), false);
      yield return (new BinaryTree([5, 4, 6, null, null, 3, 7]).GetRoot(), false);
      yield return (new BinaryTree([2, 1, 4, 7, 4, 8, 3, 6, 4, 7]).GetRoot(), false);
    }

    public bool TestNode(BinaryTree.TreeNode? node, long min, long max) {
      if (node == null)
      {
        return true;
      }

      return node.val > min && node.val < max && TestNode(node.left, min, node.val) && TestNode(node.right, node.val, max);
    }

    public bool Test(BinaryTree.TreeNode? root) {
      return TestNode(root, long.MinValue, long.MaxValue);
    }
  }
}
