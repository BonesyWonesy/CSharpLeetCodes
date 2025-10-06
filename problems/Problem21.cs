using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// You are given the heads of two sorted linked lists list1 and list2.
  /// Merge the two lists into one sorted list.The list should be made by splicing together the nodes of the first two lists.
  /// Return the head of the merged linked list.
  /// </summary>
  internal class Problem21 : LeetCodeProblem, ILeetCodeProblem<(SingleListNode<int>, SingleListNode<int>), SingleListNode<int>>
  {
    public Problem21() : base(Difficulty.Easy) { }
    public string FormatOutput(SingleListNode<int> node) => OutputFormatters.Output(node);
    public bool IsEqual(SingleListNode<int> result, SingleListNode<int> expected) => true;

    public IEnumerable<((SingleListNode<int>, SingleListNode<int>), SingleListNode<int>)> GetTests() {
      SingleListNode<int> list1Test1 = new SingleListNode<int>(1, new SingleListNode<int>(2, new SingleListNode<int>(4)));
      SingleListNode<int> list2Test1 = new SingleListNode<int>(1, new SingleListNode<int>(3, new SingleListNode<int>(4)));
      SingleListNode<int> outputTest1 = new SingleListNode<int>(1, new SingleListNode<int>(1, new SingleListNode<int>(2, new SingleListNode<int>(3, new SingleListNode<int>(4, new SingleListNode<int>(4))))));
      yield return ((list1Test1, list2Test1), outputTest1);

      yield return ((null, null), null);

      yield return ((null, new SingleListNode<int>(0)), new SingleListNode<int>(0));

      yield return ((new SingleListNode<int>(2), new SingleListNode<int>(1)), new SingleListNode<int>(1, new SingleListNode<int>(2)));
    }

    public SingleListNode<int> OptimizedVersion(SingleListNode<int> list1, SingleListNode<int> list2) {
      SingleListNode<int> merged = new SingleListNode<int>(0);
      SingleListNode<int> curNode = merged;

      while (list1 != null && list2 != null)
      {
        if (list1.val <= list2.val)
        {
          curNode.next = list1;
          list1 = list1.next;
        }
        else
        {
          curNode.next = list2;
          list2 = list2.next;
        }
        curNode = curNode.next;
      }

      curNode.next = list1 ?? list2;
      return merged.next;
    }

    public SingleListNode<int> Test((SingleListNode<int>, SingleListNode<int>) testCase) {
      SingleListNode<int> list1 = testCase.Item1;
      SingleListNode<int> list2 = testCase.Item2;
      SingleListNode<int> merged = new SingleListNode<int>(0);
      SingleListNode<int> curr = merged;
      while (list1 != null || list2 != null)
      {
        if (list1 != null && list2 != null)
        {
          if (list1.val <= list2.val)
          {
            curr.next = list1;
            list1 = list1.next;
          }
          else
          {
            curr.next = list2;
            list2 = list2.next;
          }

          curr = curr.next;
        }
        else
        {
          curr.next = list1 ?? list2;
          break;
        }
      }

      return merged.next;
    }
  }
}
