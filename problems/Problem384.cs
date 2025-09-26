using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given an integer array nums, design an algorithm to randomly shuffle the array. 
  /// All permutations of the array should be equally likely as a result of the shuffling.
  /// 
  /// Implement the Solution class:
  /// Solution(int[] nums) Initializes the object with the integer array nums.
  /// int[] reset() Resets the array to its original configuration and returns it.
  /// int[] shuffle() Returns a random shuffling of the array.
  /// 
  /// Example 1:
  /// 
  /// Input
  /// ["Solution", "shuffle", "reset", "shuffle"]
  /// [[[1, 2, 3]], [], [], []]
  /// Output
  /// [null, [3, 1, 2], [1, 2, 3], [1, 3, 2]]
  /// 
  /// Explanation
  /// 
  /// Solution solution = new Solution([1, 2, 3]);
  /// solution.shuffle();    // Shuffle the array [1,2,3] and return its result.
  ///                        // Any permutation of [1,2,3] must be equally likely to be returned.
  ///                        // Example: return [3, 1, 2]
  /// solution.reset();      // Resets the array back to its original configuration [1,2,3]. Return [1, 2, 3]
  /// solution.shuffle();    // Returns the random shuffling of array [1,2,3]. Example: return [1, 3, 2]
  /// </summary>
  internal class Problem384 : LeetCodeProblem, ILeetCodeProblem<(string, int[]), int[]>
  {
    private int[] _nums;
    private int[] _shuffled;
    private Random _rng;

    public Problem384() : base(Difficulty.Medium) { }

    public string FormatOutput(int[] result) => OutputFormatters.Output(result);

    public IEnumerable<((string, int[]), int[])> GetTests() {
      yield return (("Solution", new int[] { 1, 2, 3 }), []);
      yield return (("shuffle", []), new int[] { 3, 1, 2 });
      yield return (("reset", []), new int[] { 1, 2, 3 });
      yield return (("shuffle", []), new int[] { 1, 3, 2 });
    }

    public int[] Test((string, int[]) testCase) {
      if (testCase.Item1 == "Solution") { 
        Solution(testCase.Item2);
      } else if (testCase.Item1 == "shuffle") {
        return shuffle();
      } else if (testCase.Item1 == "reset") {
        return reset();
      }

      return [];
    }

    public void Solution(int[] nums) {
      _nums = nums;
      _rng = new Random();
      _shuffled = new int[nums.Length];
    }


    public int[] reset() {
      return _nums;
    }

    /// <summary>
    /// A brute force way of doing this would to just be to pull a random item from the array
    /// until there are no more items left. 
    /// 
    /// There is another algorithm called the Fisher-Yates Algorithm. It essentially 
    /// looks for a random character within range [0, n]. And swaps the elements. From there
    /// at each iteration the generated random index is between [0, i+1] where i0 = _shuffled.Length
    /// So for 5 element array:
    /// - Pick random number between [0, 5], i = 4, swap(4, r)
    /// - Pick random number between [0, 4], i = 3, swap(3, r)
    /// - Pick random number between [0, 3], i = 2, swap(2, r)
    /// - Pick random number between [0, 2], i = 1, swap(1, r)
    /// We are continuously swaping the last element with something from within the array that
    /// may or may not have been swapped yet.
    /// </summary>
    /// <returns></returns>
    public int[] shuffle() {

      _nums.CopyTo(_shuffled, 0);

      for(int i = _shuffled.Length - 1; i > 0; --i)
      {
        int j = _rng.Next(0, i+1);
        int t = _shuffled[i];
        _shuffled[i] = _shuffled[j];
        _shuffled[j] = t;
      }

      return _shuffled;
    }
  }
}
