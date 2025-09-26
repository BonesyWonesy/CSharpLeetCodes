using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    internal class Problem206 : LeetCodeProblem, ILeetCodeProblem<SingleListNode, SingleListNode>
    {
        public Problem206() : base(Difficulty.Easy) { }
        public string FormatOutput(SingleListNode node) => OutputFormatters.Output(node);

        public IEnumerable<(SingleListNode, SingleListNode)> GetTests()
        {
            SingleListNode test1 = new SingleListNode(1, new SingleListNode(2, new SingleListNode(3, new SingleListNode(4, new SingleListNode(5)))));
            SingleListNode output1 = new SingleListNode(5, new SingleListNode(4, new SingleListNode(3, new SingleListNode(2, new SingleListNode(1)))));
            yield return (test1, output1);

            SingleListNode test2 = new SingleListNode(1, new SingleListNode(2));
            SingleListNode output2 = new SingleListNode(2, new SingleListNode(1));
            yield return (test2, output2);

            yield return (null, null);
        }

        public SingleListNode Test(SingleListNode head)
        {
            SingleListNode nodePrev = null;
            SingleListNode curr = head;

            while ( curr != null ) {
                SingleListNode next = curr.next;
                curr.next = nodePrev;
                nodePrev = curr;
                curr = next;
            }

            return nodePrev;
        }
    }
}
