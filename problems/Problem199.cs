using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  internal class Problem199 : LeetCodeProblem, ILeetCodeProblem<BinaryTree.TreeNode?, int[]>
  {
    public Problem199() : base(Difficulty.Medium) { }
    public string FormatOutput(int[] result) => $"[{string.Join(',', result)}]";
    public bool IsEqual(int[] result, int[] expected) {
      for (int i = 0; i < result.Length; ++i)
      {
        if (!expected.Contains(result[i]))
        {
          return false;
        }
      }
      return true;
    }

    public IEnumerable<(BinaryTree.TreeNode?, int[])> GetTests() {
      yield return (new BinaryTree(new int?[] { 1, 2, 3, null, 5, null, 4 }).GetRoot(), new int[] { 1, 3, 4 });
      yield return (new BinaryTree(new int?[] { 1, 2, 3, 5, null, null, null, 5 }).GetRoot(), new int[] { 1, 3, 4, 5 });
    }

    public int[] Test(BinaryTree.TreeNode? root) {
      Queue<(int, BinaryTree.TreeNode)> queue = new Queue<(int, BinaryTree.TreeNode)>();
      Dictionary<int, BinaryTree.TreeNode> visibleNodes = new Dictionary<int, BinaryTree.TreeNode>();

      visibleNodes.Add(0, root);

      Visit(root.right, 1, visibleNodes);
      Visit(root.left, 1, visibleNodes);

      return visibleNodes.OrderBy(v => v.Key).Select(v => v.Value.val).ToArray();
    }

    public void Visit(BinaryTree.TreeNode? node, int depth, Dictionary<int, BinaryTree.TreeNode> visibleNodes) {
      if (node == null)
      {
        return;
      }

      if (visibleNodes.ContainsKey(depth) == false)
      {
        visibleNodes.Add(depth, node);
      }

      Visit(node.right, depth + 1, visibleNodes);
      Visit(node.left, depth + 1, visibleNodes);
    }
  }
}
