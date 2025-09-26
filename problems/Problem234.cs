using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    /// <summary>
    /// Given the head of a singly linked list, return true if it is a palindrome or false otherwise.
    /// </summary>
    internal class Problem234 : LeetCodeProblem, ILeetCodeProblem<SingleListNode, bool>
    {
        public Problem234() : base(Difficulty.Easy) { }
        public string FormatOutput(bool output) => output.ToString();

        public IEnumerable<(SingleListNode, bool)> GetTests()
        {
            yield return (new SingleListNode(1, new SingleListNode(2, new SingleListNode(2, new SingleListNode(1)))), true);
            yield return (new SingleListNode(1, new SingleListNode(2)), false);
            yield return (new SingleListNode(1, new SingleListNode(1, new SingleListNode(3, new SingleListNode(3, new SingleListNode(1, new SingleListNode(1)))))), true);
            yield return (new SingleListNode(1, new SingleListNode(0, new SingleListNode(1))), true);
            yield return (new SingleListNode(1, new SingleListNode(1, new SingleListNode(2, new SingleListNode(1)))), false);
        }

        public bool Test(SingleListNode node)
        {
            if (node == null)
            {
                return false;
            }
            
            if (node.next == null)
            {
                return true;
            }

            SingleListNode slow = node;
            SingleListNode fast = node;
            SingleListNode prev = null;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;

                // While we're traversing this list, we'll actually reverse the first half of the list
                SingleListNode next = slow.next;
                slow.next = prev;
                prev = slow;
                slow = next;
            }

            if (fast != null)
            {
                slow = slow.next;
            }

            // So now we're at the middle...
            // We should be able to just start to compare the first and second halfs of the list
            while (slow != null)
            {
                if (slow.val != prev.val)
                {
                    return false;
                }

                slow = slow.next;
                prev = prev.next;
            }

            return true;
        }
    }
}
