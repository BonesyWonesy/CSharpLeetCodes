using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /**
   * 
   * Given a string s of '(' , ')' and lowercase English characters.
   * 
   * Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions ) so that the resulting parentheses string is valid and return any valid string.
   * 
   * Formally, a parentheses string is valid if and only if:
   * - It is the empty string, contains only lowercase characters, or
   * - It can be written as AB (A concatenated with B), where A and B are valid strings, or
   * - It can be written as (A), where A is a valid string.
   * 
   */
  internal class Problem1249 : LeetCodeProblem, ILeetCodeProblem<string, string>
  {
    public Problem1249() : base(Difficulty.Medium) { }
    public string FormatOutput(string output) => output;
    public bool IsEqual(string result, string expected) => result == expected;

    public IEnumerable<(string, string)> GetTests() {
      yield return ("lee(t(c)o)de)", "lee(t(c)o)de");
      yield return ("a)b(c)d", "ab(c)d");
      yield return ("))((", "");
    }

    public string Test(string testCase) {
      //return Approach1(testCase);
      return Approach2(testCase);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="testCase"></param>
    /// <returns></returns>
    private string Approach1(string testCase) {
      List<int> toRemove = new List<int>();
      int parenMatch = 0;

      for (int l = 0; l < testCase.Length; ++l)
      {
        if (testCase[l] == '(')
        {
          ++parenMatch;
        }
        else if (testCase[l] == ')')
        {
          if (parenMatch == 0)
          {
            toRemove.Add(l);
          }
          else { --parenMatch; }
        }
      }

      parenMatch = 0;
      for (int r = testCase.Length - 1; r >= 0; --r)
      {
        if (testCase[r] == ')')
        {
          ++parenMatch;
        }
        else if (testCase[r] == '(')
        {
          if (parenMatch == 0)
          {
            toRemove.Add(r);
          }
          else
          {
            --parenMatch;
          }
        }
      }

      toRemove.Sort();

      string result = testCase;

      for (int r = toRemove.Count - 1; r >= 0; --r)
      {
        result = result.Remove(toRemove[r], 1);
      }

      return result;
    }

    /// <summary>
    /// The idea here is that we're going to traverse through the array in 2 passes.
    /// 
    /// The first pass is going to look for all left parens and determine if there is a matching right paren.
    /// If for whatever reason, we come across a closing paren without an underlying opening paren we can mark it to remove.
    /// </summary>
    /// <param name="testCase"></param>
    /// <returns></returns>
    private string Approach2(string testCase) {

      List<int> indicesToRemove = new List<int>();

      int parenMatch = 0;

      for (int left = 0; left < testCase.Length; ++left)
      {
        if (testCase[left] == '(')
        {
          ++parenMatch;
        }
        else if (testCase[left] == ')')
        {
          if (parenMatch == 0)
          {
            indicesToRemove.Add(left);
          }
          else
          {
            --parenMatch;
          }

        }
      }

      parenMatch = 0;
      for (int right = testCase.Length - 1; right >= 0; --right)
      {
        if (testCase[right] == '(')
        {
          if (parenMatch == 0)
          {
            indicesToRemove.Add(right);
          }
          else
          {
            --parenMatch;
          }
        }
        else if (testCase[right] == ')')
        {
          ++parenMatch;
        }
      }

      string result = testCase;

      indicesToRemove.Sort();

      for (int i = indicesToRemove.Count - 1; i >= 0; --i)
      {
        result = result.Remove(indicesToRemove[i], 1);
      }

      return result;
    }
  }
}
