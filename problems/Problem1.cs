using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
  /// 
  /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
  /// 
  /// You can return the answer in any order.
  /// </summary>
  internal class Problem1 : LeetCodeProblem, ILeetCodeProblem<(int[], int), int[]>
  {
    public Problem1() : base(Difficulty.Easy) { }
    public string FormatOutput(int[] result) => OutputFormatters.Output(result);
    public IEnumerable<((int[], int), int[])> GetTests() {
      yield return ((new int[] { 2, 7, 11, 15 }, 9), new int[] { 0, 1 });
      yield return ((new int[] { 3, 2, 4 }, 6), new int[] { 1, 2 });
      yield return ((new int[] { 3, 3 }, 6), new int[] { 0, 1 });
    }

    public bool IsEqual(int[] result, int[] expected) {
      for (int i = 0; i < result.Length; ++i)
      {
        if (!expected.Contains(result[i]))
        {
          return false;
        }
      }

      return true;
    }

    public int[] Test((int[], int) testCase) {
      int[] nums = testCase.Item1;
      int target = testCase.Item2;

      // Store number and index
      Dictionary<int, int> numMap = new Dictionary<int, int>();

      for (int i = 0; i < nums.Length; ++i)
      {
        int complement = target - nums[i];
        if (numMap.ContainsKey(complement))
        {
          return new int[] { numMap[complement], i };
        }
        numMap.Add(nums[i], i);
      }


      return new int[2];
    }
  }
}
