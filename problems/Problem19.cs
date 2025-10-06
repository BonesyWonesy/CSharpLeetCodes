using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  internal class Problem19 : LeetCodeProblem, ILeetCodeProblem<(SingleListNode<int>, int), SingleListNode<int>>
  {
    public Problem19() : base(Difficulty.Medium) { }

    public string FormatOutput(SingleListNode<int> node) => OutputFormatters.Output(node);

    public bool IsEqual(SingleListNode<int> result, SingleListNode<int> expected) { return true; }

    public IEnumerable<((SingleListNode<int>, int), SingleListNode<int>)> GetTests() {
      SingleListNode<int> firstTest = new SingleListNode<int>(1, new SingleListNode<int>(2, new SingleListNode<int>(3, new SingleListNode<int>(4, new SingleListNode<int>(5)))));
      yield return ((firstTest, 2), firstTest);

      SingleListNode<int> secondTest = new SingleListNode<int>(1);
      yield return ((secondTest, 1), null);

      SingleListNode<int> thirdTest = new SingleListNode<int>(1, new SingleListNode<int>(2));
      yield return ((thirdTest, 1), thirdTest);
    }

    public SingleListNode<int> Test((SingleListNode<int>, int) testCase) {
      SingleListNode<int> head = testCase.Item1;
      int n = testCase.Item2;

      // Contraint says size is minimum 1
      int sz = 0;
      SingleListNode<int> prev = null;
      SingleListNode<int> trackedNode = null;
      SingleListNode<int> t = head;
      while (t != null)
      {
        ++sz;

        // We want to start tracking the node that is 'n' behind from where we are. So once our
        // initial size counter hits that number, we'll continuously update our tracked node.
        if (sz == n)
        {
          trackedNode = head;
        }
        else if (trackedNode != null)
        {
          prev = trackedNode;
          trackedNode = trackedNode.next;
        }

        t = t.next;
      }

      if (trackedNode != null)
      {
        if (trackedNode.next == null)
        {
          if (prev == null)
          {
            return null;
          }
          prev.next = null;
        }
        else
        {
          trackedNode.val = trackedNode.next.val;
          trackedNode.next = trackedNode.next.next;
        }
      }

      return head;
    }
  }
}
