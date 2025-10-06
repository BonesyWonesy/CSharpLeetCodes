using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.
  /// 
  /// n == nums.length
  /// 1 <= n <= 10^4
  /// 0 <= nums[i] <= n
  /// All the numbers of nums are unique.
  /// </summary>
  internal class Problem268 : LeetCodeProblem, ILeetCodeProblem<int[], int>
  {
    public Problem268() : base(Difficulty.Easy) { }
    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;
    public IEnumerable<(int[], int)> GetTests() {
      yield return ([3, 0, 1], 2);
      yield return ([0, 1, 5, 2, 3], 4);
      yield return ([0, 1], 2);
      yield return ([9, 6, 4, 2, 3, 5, 7, 0, 1], 8);
      yield return ([1], 0);
    }

    public int Test(int[] nums) {
      int sum = 0;
      for (int i = 0; i < nums.Length; ++i)
      {
        sum += (i + 1) - nums[i];
      }

      return sum;
    }
  }
}
