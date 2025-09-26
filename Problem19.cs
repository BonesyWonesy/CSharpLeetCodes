using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    internal class Problem19: LeetCodeProblem, ILeetCodeProblem<(SingleListNode, int), SingleListNode>
    {
        public Problem19() : base(Difficulty.Medium) { }

        public string FormatOutput(SingleListNode node) => OutputFormatters.Output(node);

        public IEnumerable<((SingleListNode,int), SingleListNode)> GetTests()
        {
            SingleListNode firstTest = new SingleListNode(1, new SingleListNode(2, new SingleListNode(3, new SingleListNode(4, new SingleListNode(5)))));
            yield return ((firstTest, 2), firstTest);

            SingleListNode secondTest = new SingleListNode(1);
            yield return ((secondTest, 1), null);

            SingleListNode thirdTest = new SingleListNode(1, new SingleListNode(2));
            yield return ((thirdTest, 1), thirdTest);
        }

        public SingleListNode Test((SingleListNode, int) testCase)
        {
            SingleListNode head = testCase.Item1;
            int n = testCase.Item2;

            // Contraint says size is minimum 1
            int sz = 0;
            SingleListNode prev = null;
            SingleListNode trackedNode = null;
            SingleListNode t = head;
            while (t != null)
            {
                ++sz;

                // We want to start tracking the node that is 'n' behind from where we are. So once our
                // initial size counter hits that number, we'll continuously update our tracked node.
                if(sz == n)
                {
                    trackedNode = head;
                } else if (trackedNode != null)
                {
                    prev = trackedNode;
                    trackedNode = trackedNode.next;
                }

                t = t.next;
            }

            if  (trackedNode != null)
            {
                if (trackedNode.next == null)
                {
                    if (prev == null)
                    {
                        return null;
                    }
                    prev.next = null;
                } else
                {
                    trackedNode.val = trackedNode.next.val;
                    trackedNode.next = trackedNode.next.next;
                }                    
            }

            return head;
        }
    }
}
