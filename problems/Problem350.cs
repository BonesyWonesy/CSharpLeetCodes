using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order
  /// 
  /// Example 1:
  /// Input: nums1 = [1,2,2,1], nums2 = [2, 2]
  /// Output: [2, 2]
  /// 
  /// Example 2:
  /// Input: nums1 = [4, 9, 5], nums2 = [9, 4, 9, 8, 4]
  /// Output: [4, 9]
  /// Explanation: [9, 4] is also accepted.
  /// 
  /// Constraints:
  /// 1 <= nums1.length, nums2.length <= 1000
  /// 0 <= nums1[i], nums2[i] <= 1000
  /// 
  /// Follow up:
  /// What if the given array is already sorted? How would you optimize your algorithm?
  /// What if nums1's size is small compared to nums2's size? Which algorithm is better?
  /// What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
  /// </summary>
  internal class Problem350 : LeetCodeProblem, ILeetCodeProblem<(int[], int[]), int[]>
  {
    public Problem350() : base(Difficulty.Easy) { }

    public string FormatOutput(int[] result) => OutputFormatters.Output(result);
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

    public IEnumerable<((int[], int[]), int[])> GetTests() {
      yield return ((new int[] { 1, 2, 2, 1 }, new[] { 2, 2 }), new int[] { 2, 2 });
      yield return ((new int[] { 4, 9, 5 }, new int[] { 4, 9 }), new int[] { 4, 9 });
    }

    /// <summary>
    /// First question in an interview should be: How do I handle duplicates?
    /// Second question should be about ordering of inputs and outputs
    /// 
    /// </summary>
    /// <param name="testCase"></param>
    /// <returns></returns>
    public int[] Test((int[], int[]) testCase) {
      List<int> result = new List<int>();
      int[] nums1 = testCase.Item1;
      int[] nums2 = testCase.Item2;

      // Approach 1: HashMap

      /*int[] first = nums1.Length < nums2.Length ? nums1 : nums2;
      int[] second = nums1.Length < nums2.Length ? nums2 : nums1;

      Dictionary<int, int> frequencyCount = new Dictionary<int, int>();

      for(int i = 0; i < first.Length; ++i)
      {
          if (frequencyCount.TryGetValue(first[i], out int existVal))
          {
              frequencyCount[first[i]] += 1;
          } else
          {
              frequencyCount[first[i]] = 1;
          }
      }

      for (int j = 0; j < second.Length; ++j)
      {
          if (frequencyCount.TryGetValue(second[j], out int existVal)) {
              if (frequencyCount[second[j]] > 0)
              {
                  frequencyCount[second[j]] -= 1;
                  result.Add(second[j]);
              }
          }
      }                        
      */

      // Approach 2: If the input is sorted, or if the output needs to be sorted.
      Array.Sort(nums1);
      Array.Sort(nums2);

      // Traverse through nums1
      int i = 0;

      // Traverse through nums2
      int j = 0;

      while (i < nums1.Length && j < nums2.Length)
      {
        if (nums1[i] < nums2[j])
        {
          ++i;
        }
        else if (nums1[i] > nums2[j])
        {
          ++j;
        }
        else
        {
          result.Add(nums1[i]);
          ++i;
          ++j;
        }
      }


      return result.ToArray();
    }
  }
}
