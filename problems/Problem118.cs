using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given an integer numRows, return the first numRows of Pascal's triangle.
  /// In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
  /// 
  ///       1
  ///      1 1
  ///     1 2 1
  ///    1 3 3 1 
  ///   1 4 6 4 1
  /// </summary>
  internal class Problem118 : LeetCodeProblem, ILeetCodeProblem<int, IList<IList<int>>>
  {
    public Problem118() : base(Difficulty.Easy) { }
    public string FormatOutput(IList<IList<int>> result) => OutputFormatters.Output(result);
    public bool IsEqual(IList<IList<int>> result, IList<IList<int>> expected) {
      for(int x = 0; x < result.Count; ++x)
      {
        IList<int> sub = result[x];
        for(int y = 0; y < sub.Count; ++y)
        {

          IList<int> exp = expected[x];
          if (!exp.Contains(sub[y])) { return false; }

        }
      }

      return true;
    }
    public IEnumerable<(int, IList<IList<int>>)> GetTests() {
      yield return (5, [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]]);
      yield return (1, [[1]]);
    }

    public IList<IList<int>> Test(int n) {
      return Generate(n);
    }

    public IList<IList<int>> Generate(int numRows) {
      IList<IList<int>> result = new List<IList<int>>();
      int activeRow = 1;

      result.Add(new List<int>([1]));

      while (activeRow != numRows)
      {
        IList<int> prevRow = result.Last();
        List<int> nextRow = new List<int>();
        nextRow.Add(1);
        for (int i = 1; i < prevRow.Count; ++i)
        {
          nextRow.Add(prevRow[i] + prevRow[i - 1]);
        }
        nextRow.Add(1);
        result.Add(nextRow);
        ++activeRow;
      }

      return result;
    }
  }
}
