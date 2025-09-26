using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpLeetCode
{
    /// <summary>
    /// You are given the heads of two sorted linked lists list1 and list2.
    /// Merge the two lists into one sorted list.The list should be made by splicing together the nodes of the first two lists.
    /// Return the head of the merged linked list.
    /// </summary>
    internal class Problem21: LeetCodeProblem, ILeetCodeProblem<(SingleListNode, SingleListNode), SingleListNode>
    {
        public Problem21() : base(Difficulty.Easy) { }
        public string FormatOutput(SingleListNode node) => OutputFormatters.Output(node);

        public IEnumerable<((SingleListNode, SingleListNode), SingleListNode)> GetTests()
        {
            SingleListNode list1Test1 = new SingleListNode(1, new SingleListNode(2, new SingleListNode(4)));
            SingleListNode list2Test1 = new SingleListNode(1, new SingleListNode(3, new SingleListNode(4)));
            SingleListNode outputTest1 = new SingleListNode(1, new SingleListNode(1, new SingleListNode(2, new SingleListNode(3, new SingleListNode(4, new SingleListNode(4))))));
            yield return ((list1Test1, list2Test1), outputTest1);

            yield return ((null, null), null);

            yield return ((null, new SingleListNode(0)), new SingleListNode(0));

            yield return ((new SingleListNode(2), new SingleListNode(1)), new SingleListNode(1, new SingleListNode(2)));
        }

        public SingleListNode OptimizedVersion(SingleListNode list1, SingleListNode list2)
        {
            SingleListNode merged = new SingleListNode(0);
            SingleListNode curNode = merged;

            while(list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    curNode.next = list1;
                    list1 = list1.next;
                } else
                {
                    curNode.next = list2;
                    list2 = list2.next;
                }
                curNode = curNode.next;
            }

            curNode.next = list1 ?? list2;
            return merged.next;
        }

        public SingleListNode Test((SingleListNode, SingleListNode) testCase)
        {
            SingleListNode list1 = testCase.Item1;
            SingleListNode list2 = testCase.Item2;
            SingleListNode merged = new SingleListNode(0);
            SingleListNode curr = merged;
            while(list1 != null || list2 != null)
            {
                if (list1 != null && list2 != null)
                {
                    if (list1.val <= list2.val) {
                        curr.next = list1;
                        list1 = list1.next;
                    } else {
                        curr.next = list2;
                        list2 = list2.next;
                    }

                    curr = curr.next;
                } else 
                {
                    curr.next = list1 ?? list2;
                    break;
                }
            }

            return merged.next;
        }
    }
}
