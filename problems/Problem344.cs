using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Write a function that reverses a string. The input string is given as an array of characters s.
  /// 
  /// You must do this by modifying the input array in-place with O(1) extra memory.
  /// </summary>
  internal class Problem344 : LeetCodeProblem, ILeetCodeProblem<char[], char[]>
  {
    public Problem344() : base(Difficulty.Easy) { }

    public string FormatOutput(char[] output) => OutputFormatters.Output(output);
    public bool IsEqual(char[] result, char[] expected) {
      for (int i = 0; i < result.Length; ++i)
      {
        if (!expected.Contains(result[i]))
        {
          return false;
        }
      }
      return true;
    }

    public IEnumerable<(char[], char[])> GetTests() {
      yield return (new char[] { 'h', 'e', 'l', 'l', 'o' }, new char[] { 'o', 'l', 'l', 'e', 'h' });
      yield return (new char[] { 'h', 'a', 'n', 'n', 'a', 'h' }, new char[] { 'h', 'a', 'n', 'n', 'a', 'h' });
    }

    public char[] Test(char[] s) {
      int left = 0;
      int right = s.Length - 1;
      while (left < right)
      {
        char t = s[left];
        s[left] = s[right];
        s[right] = t;
        ++left;
        --right;
      }
      return s;
    }
  }
}
