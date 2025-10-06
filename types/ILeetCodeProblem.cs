namespace CSharpLeetCode.types
{
  internal interface ILeetCodeProblem
  {
    IEnumerable<(object, object)> GetTests();
    object? Test(object testCase);

    string FormatOutput(object result);

    bool IsEqual(object output, object expected);
  }
  internal interface ILeetCodeProblem<Input, Output> : ILeetCodeProblem
  {
    public IEnumerable<(Input, Output)> GetTests();
    public Output Test(Input testCase);
    public string FormatOutput(Output result);
    public bool IsEqual(Output result, Output expected);
    IEnumerable<(object, object)> ILeetCodeProblem.GetTests() => GetTests().Select(t => ((object)t.Item1, (object)t.Item2));
    object? ILeetCodeProblem.Test(object testCase) => Test((Input)testCase);
    string ILeetCodeProblem.FormatOutput(object result) => FormatOutput((Output)result);
    bool ILeetCodeProblem.IsEqual(object result, object expected) => IsEqual((Output)result, (Output)expected);
  }

  enum Difficulty
  {
    Easy,
    Medium,
    Hard
  }
}
