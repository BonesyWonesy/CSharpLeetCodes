using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
  /// 
  /// An input string is valid if:
  /// Open brackets must be closed by the same type of brackets.
  /// Open brackets must be closed in the correct order.
  /// Every close bracket has a corresponding open bracket of the same type.
  /// </summary>
  internal class Problem20 : LeetCodeProblem, ILeetCodeProblem<string, bool>
  {
    public Problem20() : base(Difficulty.Easy) { }
    public string FormatOutput(bool result) => result.ToString();
    public bool IsEqual(bool result, bool expected) => result == expected;
    public IEnumerable<(string, bool)> GetTests() {
      yield return ("{}", true);
      yield return ("()[]{}", true);
      yield return ("(]", false);
      yield return ("([])", true);
      yield return ("([)]", false);
      yield return ("]", false);
    }
    public bool Test(string s) {
      Stack<char> bracketStack = new();

      for (int i = 0; i < s.Length; ++i)
      {
        switch (s[i])
        {
          case '[':
          case '(':
          case '{':
            bracketStack.Push(s[i]);
            break;
          case ']':
          case '}':
          case ')':
            if (bracketStack.Count == 0)
            {
              return false;
            }
            char peek = bracketStack.Peek();
            if ((s[i] == ']' && peek != '[') ||
                 (s[i] == ')' && peek != '(') ||
                 (s[i] == '}' && peek != '{')
            )
            {
              return false;
            }
            bracketStack.Pop();
            break;
          default:
            return false;
        }
      }

      return bracketStack.Count == 0;
    }
  }
}
