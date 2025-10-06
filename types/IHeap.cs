namespace CSharpLeetCode.types
{
  internal interface IHeap
  {
    public void Add(int value);
    public int Peek();
    public int Pop();
    public int Size();
  }
}
