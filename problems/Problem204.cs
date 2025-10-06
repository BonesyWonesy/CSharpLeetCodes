using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given an integer n, return the number of prime numbers that are strictly less than n.
  /// 
  /// A prime number is divisible by itself and 1 only
  /// </summary>
  internal class Problem204 : LeetCodeProblem, ILeetCodeProblem<int, int>
  {
    public Problem204() : base(Difficulty.Easy) { }
    public string FormatOutput(int result) => $"{result}";
    public bool IsEqual(int result, int expected) => result == expected;

    public IEnumerable<(int, int)> GetTests() {
      yield return (10, 4);
      yield return (0, 0);
      yield return (1, 0);
      yield return (30, 10);
      yield return (3, 1);
    }

    public int Test(int n) {

      if (n < 2)
      {
        return 0;
      }

      int result = 0;

      bool[] isPrime = new bool[n + 1];
      for (int b = 2; b < n; ++b)
      {
        isPrime[b] = true;
      }

      for (int p = 2; (p * p) <= n; p++)
      {
        if (isPrime[p])
        {
          for (int i = p * p; i <= n; i += p)
          {
            isPrime[i] = false;
          }

        }
      }

      for (int i = 0; i <= n; ++i)
      {
        if (isPrime[i])
        {
          ++result;
        }
      }

      return result;
    }
  }
}
