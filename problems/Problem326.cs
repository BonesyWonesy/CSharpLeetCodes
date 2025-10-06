using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  internal class Problem326 : LeetCodeProblem, ILeetCodeProblem<int, bool>
  {
    public Problem326() : base(Difficulty.Easy) { }
    public string FormatOutput(bool result) => result.ToString();
    public bool IsEqual(bool result, bool expected) => result == expected;
    public IEnumerable<(int, bool)> GetTests() {
      yield return (27, true);
      yield return (0, false);
      yield return (-1, false);
    }

    public bool Test(int n) {
      if (n <= 0)
      {
        return false;
      }

      if (n == 1)
      {
        return true;
      }

      if (n % 3 == 0)
      {
        return Test(n / 3);
      }
      return false;
    }
  }
}
