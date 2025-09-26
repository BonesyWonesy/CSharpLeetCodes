using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.types
{
    internal class SingleListNode
    {
        public int val;
        public SingleListNode next;
        public SingleListNode(int v, SingleListNode nextNode = null) {
            val = v;
            next = nextNode;
        }
    }
}
