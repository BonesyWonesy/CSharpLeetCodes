using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  internal class Problem206 : LeetCodeProblem, ILeetCodeProblem<SingleListNode<int>, SingleListNode<int>>
  {
    public Problem206() : base(Difficulty.Easy) { }
    public string FormatOutput(SingleListNode<int> node) => OutputFormatters.Output(node);
    public bool IsEqual(SingleListNode<int> result, SingleListNode<int> expected) => true;

    public IEnumerable<(SingleListNode<int>, SingleListNode<int>)> GetTests() {
      SingleListNode<int> test1 = new SingleListNode<int>(1, new SingleListNode<int>(2, new SingleListNode<int>(3, new SingleListNode<int>(4, new SingleListNode<int>(5)))));
      SingleListNode<int> output1 = new SingleListNode<int>(5, new SingleListNode<int>(4, new SingleListNode<int>(3, new SingleListNode<int>(2, new SingleListNode<int>(1)))));
      yield return (test1, output1);

      SingleListNode<int> test2 = new SingleListNode<int>(1, new SingleListNode<int>(2));
      SingleListNode<int> output2 = new SingleListNode<int>(2, new SingleListNode<int>(1));
      yield return (test2, output2);

      yield return (null, null);
    }

    public SingleListNode<int> Test(SingleListNode<int> head) {
      SingleListNode<int> nodePrev = null;
      SingleListNode<int> curr = head;

      while (curr != null)
      {
        SingleListNode<int> next = curr.next;
        curr.next = nodePrev;
        nodePrev = curr;
        curr = next;
      }

      return nodePrev;
    }
  }
}
