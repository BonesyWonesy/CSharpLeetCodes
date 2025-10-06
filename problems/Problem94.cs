using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given the root of a binary tree, return the inorder traversal of its nodes' values.
  /// </summary>
  internal class Problem94 : LeetCodeProblem, ILeetCodeProblem<BinaryTree.TreeNode?, int[]>
  {
    public Problem94() : base(Difficulty.Easy) { }
    public string FormatOutput(int[] result) => OutputFormatters.Output(result);
    public IEnumerable<(BinaryTree.TreeNode?, int[])> GetTests() {

      BinaryTree test1 = new BinaryTree([1, null, 2, 3]);
      yield return (test1.GetRoot(), [1, 3, 2]);
      BinaryTree test2 = new BinaryTree([1, 2, 3, 4, 5, null, 8, null, null, 6, 7, 9]);
      yield return (test2.GetRoot(), [4, 2, 6, 5, 7, 1, 3, 9, 8]);
    }

    public bool IsEqual(int[] result, int[] expected) {
      for(int i = 0; i < result.Length; ++i)
      {
        if (!expected.Contains(result[i]))
        {
          return false;
        }
      }
      return true;
    }

    public int[] Test(BinaryTree.TreeNode? root) {
      //return RecursiveSolution(root);
      //return IterativeSolution(root);
      return IterativeSolutionV2(root);
    }

    public void TraverseTree(BinaryTree.TreeNode? node, List<int> result) {
      if (node == null)
      {
        return;
      }

      TraverseTree(node.left, result);
      result.Add(node.val);
      TraverseTree(node.right, result);
    }

    public int[] RecursiveSolution(BinaryTree.TreeNode? root) {
      if (root == null)
      {
        return [];
      }

      List<int> result = new List<int>();

      TraverseTree(root.left, result);
      result.Add(root.val);
      TraverseTree(root.right, result);

      return result.ToArray();
    }

    /// <summary>
    /// Uses an iterative approach to keep track of which nodes were visited and checks that list to make sure we don't doubly check
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public int[] IterativeSolution(BinaryTree.TreeNode? root) {
      if (root == null)
      {
        return [];
      }

      Stack<BinaryTree.TreeNode> treeNodes = new Stack<BinaryTree.TreeNode>();
      List<BinaryTree.TreeNode> visitedNodes = new List<BinaryTree.TreeNode>();
      List<int> result = new List<int>();
      BinaryTree.TreeNode currentNode = root;
      treeNodes.Push(root);

      while (treeNodes.Count > 0)
      {
        BinaryTree.TreeNode current = treeNodes.Peek();

        if (visitedNodes.Contains(current))
        {
          treeNodes.Pop();
          continue;
        }

        if (current.left != null && !visitedNodes.Contains(current.left))
        {
          treeNodes.Push(current.left);
          continue;
        }

        result.Add(current.val);
        visitedNodes.Add(current);

        if (current.right != null && !visitedNodes.Contains(current.right))
        {
          treeNodes.Push(current.right);
          continue;
        }

        treeNodes.Pop();
      }

      return result.ToArray();
    }

    public int[] IterativeSolutionV2(BinaryTree.TreeNode root) {
      Stack<BinaryTree.TreeNode> nodeStack = new Stack<BinaryTree.TreeNode>();
      BinaryTree.TreeNode? current = root;
      List<int> result = new List<int>();

      while (current != null || nodeStack.Count > 0)
      {
        if (current != null)
        {
          nodeStack.Push(current);
          current = current.left;
        }
        else
        {
          BinaryTree.TreeNode parent = nodeStack.Pop();
          result.Add(parent.val);
          current = parent.right;
        }
      }

      return result.ToArray();
    }
  }
}
