using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /*
   * A peak element is an element that is strictly greater than its neighbors.
   * 
   * Given a 0-indexed integer array nums, find a peak element, and return its index. If the array contains multiple peaks, return the index to any of the peaks.
   * 
   * You may imagine that nums[-1] = nums[n] = -∞. In other words, an element is always considered to be strictly greater than a neighbor that is outside the array.
   * 
   * You must write an algorithm that runs in O(log n) time.
  */
  internal class Problem162 : LeetCodeProblem, ILeetCodeProblem<int[], int>
  {
    public Problem162() : base(Difficulty.Medium) { }

    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;

    public IEnumerable<(int[], int)> GetTests() {
      return new (int[], int)[]
      {
                (new int[] {1,2,3,1}, 2),
                (new int[] {1,2,1,3,5,6,4}, 5),
                (new int[] {1,2}, 1)
      };
    }

    public int Test(int[] testCase) {
      for (int left = 0; left < testCase.Length; ++left)
      {
        if (left == 0)
        {
          if (testCase.Length == 1 || testCase[left] > testCase[left + 1])
          {
            return left;
          }
        }
        else
        {
          if (testCase[left - 1] < testCase[left])
          {
            if (left == testCase.Length - 1 || testCase[left] > testCase[left + 1])
            {
              return left;
            }
          }
        }
      }

      return 0;
    }
  }
}
