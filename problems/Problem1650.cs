using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  internal class Problem1650 : LeetCodeProblem, ILeetCodeProblem<(int?[], int, int), int>
  {
    public Problem1650() : base(Difficulty.Medium) { }
    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;

    public IEnumerable<((int?[], int, int), int)> GetTests() {
      yield return ((new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 }, 5, 1), 3);
      yield return ((new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 }, 5, 4), 5);
      yield return ((new int?[] { 1, 2 }, 1, 2), 1);
    }

    public int Test((int?[], int, int) testCase) {
      BinaryTree tree = new BinaryTree(testCase.Item1);
      BinaryTree.TreeNode? root = tree.GetRoot();
      BinaryTree.TreeNode? p = tree.FindNode(testCase.Item2);
      BinaryTree.TreeNode? q = tree.FindNode(testCase.Item3);
      return LowestCommonAncestor(root, p, q)?.val ?? -1;
    }

    private BinaryTree.TreeNode? LowestCommonAncestor(BinaryTree.TreeNode? root, BinaryTree.TreeNode? p, BinaryTree.TreeNode? q) {
      HashSet<BinaryTree.TreeNode> ancestors = new HashSet<BinaryTree.TreeNode>();
      while (p != null)
      {
        ancestors.Add(p);
        p = p.parent;
      }

      while (q != null)
      {
        if (ancestors.Contains(q))
        {
          return q;
        }

        q = q.parent;
      }

      return null;
    }
  }
}















/*HashSet<BinaryTree.TreeNode> ancestors = new HashSet<BinaryTree.TreeNode>();
while (p != null)
{
    ancestors.Add(p);
    p = p.parent;
}
while (q != null)
{
    if (ancestors.Contains(q))
    {
        return q.val;
    }
    q = q.parent;
}
*/
