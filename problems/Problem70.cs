using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  internal class Problem70 : LeetCodeProblem, ILeetCodeProblem<int, int>
  {
    public Problem70() : base(Difficulty.Easy) { }
    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;
    public IEnumerable<(int, int)> GetTests() {
      yield return (2, 2);
      yield return (1, 1);
      yield return (3, 3);
      yield return (4, 5);
    }
    public int Test(int n) {
      List<int> steps = new List<int>(n);
      steps.Add(1);
      steps.Add(2);

      if (n == 1 || n == 2)
      {
        return steps[n - 1];
      }

      for (int i = 3; i < n; ++i)
      {
        steps.Add(steps[i - 2] + steps[i - 3]);
      }

      return steps[n - 2] + steps[n - 3];
    }
  }
}
