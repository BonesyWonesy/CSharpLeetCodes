using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given a positive integer n, write a function that returns the number of set bits in its binary representation (also known as the Hamming weight).
  /// </summary>
  internal class Problem191 : LeetCodeProblem, ILeetCodeProblem<int, int>
  {
    public Problem191() : base(Difficulty.Easy) { }
    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;
    public IEnumerable<(int, int)> GetTests() {
      yield return (11, 3);  // 1011
      yield return (128, 1); // 1000 0000
      yield return (2147483645, 30); // 0111 1111 1111 1111 1111 1111 1111 1101 
    }

    public int Test(int n) {

      int count = 0;
      while (n > 0)
      {
        if (1 == (n & 1)) { ++count; }
        n = n >> 1;
      }

      return count;
    }
  }
}
