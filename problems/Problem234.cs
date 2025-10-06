using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given the head of a singly linked list, return true if it is a palindrome or false otherwise.
  /// </summary>
  internal class Problem234 : LeetCodeProblem, ILeetCodeProblem<SingleListNode<int>, bool>
  {
    public Problem234() : base(Difficulty.Easy) { }
    public string FormatOutput(bool output) => output.ToString();
    public bool IsEqual(bool result, bool expected) => result == expected;

    public IEnumerable<(SingleListNode<int>, bool)> GetTests() {
      yield return (new SingleListNode<int>(1, new SingleListNode<int>(2, new SingleListNode<int>(2, new SingleListNode<int>(1)))), true);
      yield return (new SingleListNode<int>(1, new SingleListNode<int>(2)), false);
      yield return (new SingleListNode<int>(1, new SingleListNode<int>(1, new SingleListNode<int>(3, new SingleListNode<int>(3, new SingleListNode<int>(1, new SingleListNode<int>(1)))))), true);
      yield return (new SingleListNode<int>(1, new SingleListNode<int>(0, new SingleListNode<int>(1))), true);
      yield return (new SingleListNode<int>(1, new SingleListNode<int>(1, new SingleListNode<int>(2, new SingleListNode<int>(1)))), false);
    }

    public bool Test(SingleListNode<int> node) {
      if (node == null)
      {
        return false;
      }

      if (node.next == null)
      {
        return true;
      }

      SingleListNode<int> slow = node;
      SingleListNode<int> fast = node;
      SingleListNode<int> prev = null;

      while (fast != null && fast.next != null)
      {
        fast = fast.next.next;

        // While we're traversing this list, we'll actually reverse the first half of the list
        SingleListNode<int> next = slow.next;
        slow.next = prev;
        prev = slow;
        slow = next;
      }

      if (fast != null)
      {
        slow = slow.next;
      }

      // So now we're at the middle...
      // We should be able to just start to compare the first and second halfs of the list
      while (slow != null)
      {
        if (slow.val != prev.val)
        {
          return false;
        }

        slow = slow.next;
        prev = prev.next;
      }

      return true;
    }
  }
}
