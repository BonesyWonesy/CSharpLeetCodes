using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    /// <summary>
    /// Given head, the head of a linked list, determine if the linked list has a cycle in it.
    /// 
    /// There is a cycle in a linked list if there is some node in the list that can be reached
    /// again by continuously following the next pointer.Internally, pos is used to denote the
    /// index of the node that tail's next pointer is connected to. Note that pos is not passed
    /// as a parameter.
    /// 
    /// Return true if there is a cycle in the linked list.Otherwise, return false. 
    /// </summary>
    internal class Problem141 :  LeetCodeProblem, ILeetCodeProblem<SingleListNode, bool>
    {
        public Problem141() : base(Difficulty.Easy) { }
        public string FormatOutput(bool output) => output.ToString();

        public IEnumerable<(SingleListNode, bool)> GetTests()
        {
            SingleListNode test1n1 = new SingleListNode(3);
            SingleListNode test1n2 = new SingleListNode(2);
            test1n1.next = test1n2;

            SingleListNode test1n3 = new SingleListNode(0, new SingleListNode(-4, test1n2));
            test1n2.next = test1n3;
            yield return (test1n1, true);


            SingleListNode test2n1 = new SingleListNode(1);
            SingleListNode test2n2 = new SingleListNode(2, test2n1);
            test2n1.next = test2n2;
            yield return (test2n1, true);

            SingleListNode test3n1 = new SingleListNode(1);
            yield return (test3n1, false);
        }

        public bool Test(SingleListNode list)
        {
            SingleListNode root = list;

            SingleListNode fast = root;
            SingleListNode slow = root;

            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next?.next;

                if (slow != null && fast != null && slow == fast)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
