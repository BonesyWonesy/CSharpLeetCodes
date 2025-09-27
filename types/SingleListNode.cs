using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
