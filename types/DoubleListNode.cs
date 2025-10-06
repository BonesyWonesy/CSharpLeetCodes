namespace CSharpLeetCode.types
{
  internal class DoubleListNode<T>
  {
    public T _val;
    public DoubleListNode<T>? _next;
    public DoubleListNode<T>? _prev;

    public DoubleListNode(T value, DoubleListNode<T>? next = null, DoubleListNode<T>? prev = null) {
      _val = value;
      _next = next;
      _prev = prev;
    }
  }
}
