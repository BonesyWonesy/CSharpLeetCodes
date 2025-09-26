using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    internal interface IHeap
    {
        public void Add(int value);
        public int Peek();
        public int Pop();
        public int Size();
    }
}
