using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// https://leetcode.com/problems/strobogrammatic-number/description/
  /// 
  /// Given a string num which represents an integer, return true if num is a strobogrammatic number.
  /// 
  /// A strobogrammatic number is a number that looks the same when rotated 180 degrees(looked at upside down).
  /// </summary>
  internal class Problem246 : LeetCodeProblem, ILeetCodeProblem<string, bool>
  {
    public Problem246() : base(Difficulty.Easy) { }
    public string FormatOutput(bool result) => result.ToString();
    public bool IsEqual(bool result, bool expected) => result == expected;
    public IEnumerable<(string, bool)> GetTests() {
      yield return ("69", true);
      yield return ("88", true);
      yield return ("962", false);
    }

    public bool Test(string num) {
      return SolutionV1(num);
    }

    /// <summary>
    /// A 180 degree rotation would just be the current string reversed, so we reverse the starting string and iterate over
    /// all the characters ensuring the expected digits are strobogrammic
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public bool SolutionV1(string num) {
      // Let's first identify the digits that are strobogrammic:
      // 1, 6, 9, 8 , 0

      // a 180 degree rotate string would just be reversed:
      // 69 -> 96
      // 123 -> 321

      // So if we reverse the string, and then compare the characters we should be able to determine true/false;
      string reversed = new string(num.ToCharArray().Reverse().ToArray());
      for (int i = 0; i < num.Length; ++i)
      {
        if ((reversed[i] == '1' && num[i] == '1') ||
            (reversed[i] == '8' && num[i] == '8') ||
            (reversed[i] == '0' && num[i] == '0') ||
            (reversed[i] == '9' && num[i] == '6') ||
            (reversed[i] == '6' && num[i] == '9')
        )
        {
          continue;
        }
        return false;
      }

      return true;
    }

    /// <summary>
    /// Takes the idea of #1 above, but instead of reversing the string, just uses a two-pointer approach and walks them towards each other
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public bool SolutionV2(string num) {

      int leftIdx = 0;
      int rightIdx = num.Length - 1;

      while (leftIdx <= rightIdx)
      {
        if ((num[leftIdx] == '1' && num[rightIdx] == '1') ||
            (num[leftIdx] == '8' && num[rightIdx] == '8') ||
            (num[leftIdx] == '0' && num[rightIdx] == '0') ||
            (num[leftIdx] == '9' && num[rightIdx] == '6') ||
            (num[leftIdx] == '6' && num[rightIdx] == '9')
        )
        {
          ++leftIdx;
          --rightIdx;
        }
        else
        {
          return false;
        }
      }

      return true;

    }
  }
}
