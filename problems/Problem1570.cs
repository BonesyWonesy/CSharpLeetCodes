using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  internal class SparseVector
  {
    public List<int> zeroes;
    public Dictionary<int, int> values;
    public SparseVector(int[] nums) {
      zeroes = new List<int>();
      values = new Dictionary<int, int>();

      for (int i = 0; i < nums.Length; ++i)
      {
        if (nums[i] == 0)
        {
          zeroes.Add(i);
        }
        else
        {
          values.Add(i, nums[i]);
        }
      }

    }

    public int DotProduct(SparseVector vec) {
      int sum = 0;
      vec.values.ToList().ForEach(v =>
      {
        if (values.TryGetValue(v.Key, out int val))
        {
          sum += val * v.Value;
        }
      });
      return sum;
    }
  }
  /*
   * Given two sparse vectors, compute their dot product.
   * 
   * Implement class SparseVector:
   * 
   * SparseVector(nums) Initializes the object with the vector nums
   * dotProduct(vec) Compute the dot product between the instance of SparseVector and vec
   * 
   * A sparse vector is a vector that has mostly zero values, you should store the sparse vector efficiently and compute the dot product between two SparseVector.
   * 
   * Follow up: What if only one of the vectors is sparse? 
   */
  internal class Problem1570 : LeetCodeProblem, ILeetCodeProblem<(int[], int[]), int>
  {
    public Problem1570() : base(Difficulty.Medium) { }
    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;
    public IEnumerable<((int[], int[]), int)> GetTests() {
      return new ((int[], int[]), int)[]
      {
                ((new int[] {1,0,0,2,3}, new int[] {0,3,0,4,0}), 8),
                ((new int[] {0,1,0,0,2,0,0}, new int[] {1,0,0,0,3,0,4}), 6),
                ((new int[] {0,1,0,0,0}, new int[] {0,0,0,0,2}), 0)
      };
    }
    public int Test((int[], int[]) testCase) {
      SparseVector v1 = new SparseVector(testCase.Item1);
      SparseVector v2 = new SparseVector(testCase.Item2);
      return v1.DotProduct(v2);
    }
  }
}
