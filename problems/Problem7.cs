using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  internal class Problem7 : LeetCodeProblem, ILeetCodeProblem<int, int>
  {
    public Problem7() : base(Difficulty.Medium) { }

    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;

    public IEnumerable<(int, int)> GetTests() {
      yield return (123, 321);
      yield return (0, 0);
      yield return (10, 1);
      yield return (-123, -321);
      yield return (120, 21);
      yield return (1534236469, 0);
      yield return (-2147483648, 0);
      yield return (1463847412, 2147483641);
    }

    public int Test(int x) {
      int output = 0;

      while (x != 0)
      {
        if (output > int.MaxValue / 10 || output < int.MinValue / 10)
        {
          return 0;
        }

        output = output * 10 + x % 10;
        x /= 10;
      }

      return output;
    }
  }
}
