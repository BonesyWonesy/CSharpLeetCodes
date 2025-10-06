using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given an integer n, return a string array answer (1-indexed) where:
  /// 
  /// answer[i] == "FizzBuzz" if i is divisible by 3 and 5.
  /// answer[i] == "Fizz" if i is divisible by 3.
  /// answer[i] == "Buzz" if i is divisible by 5.
  /// answer[i] == i(as a string) if none of the above conditions are true.
  /// </summary>
  internal class Problem412 : LeetCodeProblem, ILeetCodeProblem<int, string[]>
  {
    public Problem412() : base(Difficulty.Easy) { }
    public string FormatOutput(string[] output) => OutputFormatters.Output(output);
    public bool IsEqual(string[] result, string[] expected) {
      for (int i = 0; i < result.Length; ++i)
      {
        if (!expected.Contains(result[i]))
        {
          return false;
        }
      }
      return true;
    }

    public IEnumerable<(int, string[])> GetTests() {
      yield return (3, ["1", "2", "Fizz"]);
      yield return (5, ["1", "2", "Fizz", "4", "Buzz"]);
      yield return (15, ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"]);
    }

    public string[] Test(int n) {
      string[] output = new string[n];
      for (int i = 1; i <= n; ++i)
      {
        bool mod3 = 0 == i % 3;
        bool mod5 = 0 == i % 5;
        if (mod3 && mod5)
        {
          output[i - 1] = "FizzBuzz";
        }
        else if (mod3)
        {
          output[i - 1] = "Fizz";
        }
        else if (mod5)
        {
          output[i - 1] = "Buzz";
        }
        else
        {
          output[i - 1] = i.ToString();
        }
      }
      return output;
    }
  }
}
