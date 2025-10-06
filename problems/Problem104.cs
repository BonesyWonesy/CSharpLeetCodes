using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
  /// </summary>
  internal class Problem104 : LeetCodeProblem, ILeetCodeProblem<BinaryTree.TreeNode?, int>
  {
    public Problem104() : base(Difficulty.Easy) { }
    public string FormatOutput(int output) => output.ToString();
    public bool IsEqual(int result, int expected) => result == expected;

    public IEnumerable<(BinaryTree.TreeNode?, int)> GetTests() {
      yield return (new BinaryTree([3, 9, 20, null, null, 15, 7]).GetRoot(), 3);
      yield return (new BinaryTree([1, null, 2]).GetRoot(), 2);
    }

    private int GetDepth(BinaryTree.TreeNode? node) {
      if (node == null)
      {
        return 0;
      }

      var depth = 1 + Math.Max(GetDepth(node.left), GetDepth(node.right));
      return depth;
    }

    public int Test(BinaryTree.TreeNode? root) {
      int depth = 0;

      int leftDepth = GetDepth(root.left);
      int rightDepth = GetDepth(root.right);

      return 1 + Math.Max(leftDepth, rightDepth);

    }
  }
}
