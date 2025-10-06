using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// The Hamming distance between two integers is the number of positions at which the corresponding bits are different.
  /// 
  /// Given two integers x and y, return the Hamming distance between them.
  /// </summary>
  internal class Problem461 : LeetCodeProblem, ILeetCodeProblem<(int x, int y), int>
  {
    public Problem461() : base(Difficulty.Easy) { }
    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;
    public IEnumerable<((int, int), int)> GetTests() {
      // 0 0 0 1
      // 0 1 0 0
      // 2
      yield return ((1, 4), 2);

      // 0 0 1 1
      // 0 0 0 1
      // 1
      yield return ((3, 1), 1);
    }
    public int Test((int x, int y) test) {
      return HammingDistanceV1(test.x, test.y);
    }

    public int HammingDistanceV1(int x, int y) {
      int dist = 0;

      // Performing an XOR operation on x and y will return a value where only the differing bits are set.
      for (int v = x ^ y; v > 0; ++dist)
      {
        // So we'll keep doing a check to count the bits set to 1
        v = v & (v - 1);
      }

      return dist;
    }
  }
}
