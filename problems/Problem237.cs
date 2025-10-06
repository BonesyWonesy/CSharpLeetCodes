using CSharpLeetCode.types;
using System.Text;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Remove a node from a Linked List, given the node to remove.
  /// </summary>
  internal class Problem237 : LeetCodeProblem, ILeetCodeProblem<SingleListNode<int>, SingleListNode<int>>
  {
    public Problem237() : base(Difficulty.Medium) { }
    public string FormatOutput(SingleListNode<int> node) {
      StringBuilder sb = new StringBuilder();
      while (node != null)
      {
        sb.Append(node.val.ToString());
        sb.Append(",");
      }
      return sb.ToString();
    }

    public bool IsEqual(SingleListNode<int> result, SingleListNode<int> expected) => true;

    public IEnumerable<(SingleListNode<int>, SingleListNode<int>)> GetTests() {
      SingleListNode<int> list1 = new SingleListNode<int>(8);
      list1.next = new SingleListNode<int>(2);
      list1.next.next = new SingleListNode<int>(4);
      yield return (list1.next, list1.next);
    }

    /// <summary>
    /// This approach iterates over the rest of the linked list and just removes the node at the end
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public SingleListNode<int> Test(SingleListNode<int> node) {
      SingleListNode<int> prev = null;
      while (node.next != null)
      {
        node.val = node.next.val;
        prev = node;
        node = node.next;
      }

      prev.next = null;

      return node;
    }

    /// <summary>
    /// Derp, why iterate and copy into the next nodes? You really just need to effectively 
    /// copy the current next value into the current node and just remove the single next node
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public SingleListNode<int> Optimized(SingleListNode<int> node) {
      node.val = node.next.val;
      node.next = node.next.next;
      return node;
    }
  }
}
