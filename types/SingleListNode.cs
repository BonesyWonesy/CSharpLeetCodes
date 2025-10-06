namespace CSharpLeetCode.types
{
  internal class SingleListNode<T>
  {
    public T val;
    public SingleListNode<T> next;
    public SingleListNode(T v, SingleListNode<T> nextNode = null) {
      val = v;
      next = nextNode;
    }
  }
}
