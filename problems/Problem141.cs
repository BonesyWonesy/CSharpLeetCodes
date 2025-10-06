using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given head, the head of a linked list, determine if the linked list has a cycle in it.
  /// 
  /// There is a cycle in a linked list if there is some node in the list that can be reached
  /// again by continuously following the next pointer.Internally, pos is used to denote the
  /// index of the node that tail's next pointer is connected to. Note that pos is not passed
  /// as a parameter.
  /// 
  /// Return true if there is a cycle in the linked list.Otherwise, return false. 
  /// </summary>
  internal class Problem141 : LeetCodeProblem, ILeetCodeProblem<SingleListNode<int>, bool>
  {
    public Problem141() : base(Difficulty.Easy) { }
    public string FormatOutput(bool output) => output.ToString();
    public bool IsEqual(bool result, bool expected) => result == expected;

    public IEnumerable<(SingleListNode<int>, bool)> GetTests() {
      SingleListNode<int> test1n1 = new SingleListNode<int>(3);
      SingleListNode<int> test1n2 = new SingleListNode<int>(2);
      test1n1.next = test1n2;

      SingleListNode<int> test1n3 = new SingleListNode<int>(0, new SingleListNode<int>(-4, test1n2));
      test1n2.next = test1n3;
      yield return (test1n1, true);


      SingleListNode<int> test2n1 = new SingleListNode<int>(1);
      SingleListNode<int> test2n2 = new SingleListNode<int>(2, test2n1);
      test2n1.next = test2n2;
      yield return (test2n1, true);

      SingleListNode<int> test3n1 = new SingleListNode<int>(1);
      yield return (test3n1, false);
    }

    public bool Test(SingleListNode<int> list) {
      SingleListNode<int> root = list;

      SingleListNode<int> fast = root;
      SingleListNode<int> slow = root;

      while (fast != null)
      {
        slow = slow.next;
        fast = fast.next?.next;

        if (slow != null && fast != null && slow == fast)
        {
          return true;
        }
      }

      return false;
    }
  }
}
