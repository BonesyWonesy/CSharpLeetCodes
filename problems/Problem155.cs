using CSharpLeetCode.types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
  /// 
  /// Implement the MinStack class:
  /// 
  /// MinStack() initializes the stack object.
  /// void push(int val) pushes the element val onto the stack.
  /// void pop() removes the element on the top of the stack.
  /// int top() gets the top element of the stack.
  /// int getMin() retrieves the minimum element in the stack.
  /// 
  /// You must implement a solution with O(1) time complexity for each function.
  /// </summary>
  internal class Problem155 : LeetCodeProblem, ILeetCodeProblem<(string, int?), int?>
  {
    private sealed class MinStack {

      int _min;

      SingleListNode<(int, int)>? _head;
      public MinStack() {
        _head = null;
        _min = int.MaxValue;
      }
      public void Push(int val) {
        _min = Math.Min(_min, val);
        _head = new SingleListNode<(int, int)>((val, _min), _head);        
      }

      public void Pop() {
        _head = _head.next;
        _min = _head == null ? int.MaxValue : _head.val.Item2;
      }
      public int Top() { return _head.val.Item1; }
      public int GetMin() { return _head.val.Item2; }
    }

    private MinStack _stack;

    public Problem155() : base(Difficulty.Medium) { }
    public string FormatOutput(int? result) => result == null ? "null" : result.ToString();

    public IEnumerable<((string, int?), int?)> GetTests() {
      yield return (("MinStack", null), null);
      yield return (("push", -2), null);
      yield return (("push", 0), null);
      yield return (("push", -3), null);
      yield return (("getMin", null), -3);
      yield return (("pop", null), null);
      yield return (("top", null), 0);
      yield return (("getMin", null), -2);


      /// Test Case 2
      yield return (("MinStack", null), null);
      yield return (("push", -10), null);
      yield return (("push", 14), null);
      yield return (("getMin", null), -10);
      yield return (("getMin", null), -10);
      yield return (("push", -20), null);
      yield return (("getMin", null), -20);
      yield return (("getMin", null), -20);
      yield return (("top", null), -20);
      yield return (("getMin", null), -20);
      yield return (("pop", null), null);
      yield return (("push", -7), null);
      yield return (("push", -7), null);
      yield return (("getMin", null), -10);
      yield return (("push", -7), null);
      yield return (("pop", null), null);
      yield return (("top", null), -7);
      yield return (("getMin", null), -10);
      yield return (("pop", null), null);
    }

    public int? Test((string, int?) testCase) {

      if ("MinStack" == testCase.Item1) {
        _stack = new MinStack();
        return null;
      }
      else if("push" == testCase.Item1) {
        _stack.Push((int)testCase.Item2);
      } else if ("pop" == testCase.Item1) {
        _stack.Pop();
        return null;
      }
      else if ("top" == testCase.Item1) {
        return _stack.Top();
      } else if ("getMin" == testCase.Item1) {
        return _stack.GetMin();
      }

      return null;
    }
  }
}
