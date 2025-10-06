using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// You are a professional robber planning to rob houses along a street. 
  /// Each house has a certain amount of money stashed, the only constraint 
  /// stopping you from robbing each of them is that adjacent houses have security 
  /// systems connected and it will automatically contact the police if two adjacent 
  /// houses were broken into on the same night.
  /// 
  /// Given an integer array nums representing the amount of money of each house,
  /// return the maximum amount of money you can rob tonight without alerting the
  /// police.
  /// </summary>
  internal class Problem198 : LeetCodeProblem, ILeetCodeProblem<int[], int>
  {
    public Problem198() : base(Difficulty.Medium) { }
    public string FormatOutput(int output) => $"{output}";
    public bool IsEqual(int result, int expected) => result == expected;

    public IEnumerable<(int[], int)> GetTests() {
      yield return (new int[] { 1, 2, 3, 1 }, 4);
      yield return (new int[] { 2, 7, 9, 3, 1 }, 12);
    }

    /// <summary>
    /// To sove this we're going to want to create the max money at each point of the values
    /// 
    /// Example: nums = [1, 2, 3, 1]
    /// - We keep track of a current maximum amount, and we want that to be the first element.
    /// - Since we handled our edge cases, we know that there are at least two elements in the
    /// - array, so our robbed $$ is the max of the first two elements
    /// - From there we iterate over our total number of houses and:
    /// -- Look at our currently tracked max robbed amount and compare it to 2 behind (since you cant rob two houses next to each other)
    /// --- The first loop, is gonna compare indices [0] & [2]
    /// --- We can overwrite the value in the nums array to track the max robbed at each index based on the previous maxes before it
    /// --- We can keep track of the maximum of the robbed cash root
    /// 
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int Test(int[] nums) {

      if (nums.Length == 0)
      {
        return 0;
      }
      else if (nums.Length == 1)
      {
        return nums[0];
      }
      else if (nums.Length == 2)
      {
        return nums[0] > nums[1] ? nums[0] : nums[1];
      }

      int currentMax = nums[0];
      int robbedCash = Math.Max(nums[0], nums[1]);

      for (int n = 2; n < nums.Length; ++n)
      {
        currentMax = Math.Max(currentMax, nums[n - 2]);
        nums[n] = nums[n] + currentMax;
        robbedCash = Math.Max(robbedCash, nums[n]);
      }

      return robbedCash;
    }
  }
}
