using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Reverse bits of a given 32 bits signed integer.
  /// </summary>
  internal class Problem190 : LeetCodeProblem, ILeetCodeProblem<int, int>
  {
    public Problem190() : base(Difficulty.Easy) { }
    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;
    public IEnumerable<(int, int)> GetTests() {

      // 43261596  00000010100101000001111010011100
      // 964176192 00111001011110000010100101000000
      yield return (43261596, 964176192);

      // 2147483644  01111111111111111111111111111100
      // 1073741822  00111111111111111111111111111110

      yield return (2147483644, 1073741822);
    }

    public int Test(int n) {
      return ReverseBits(n);
    }

    public int ReverseBits(int n) {
      int reversed = 0;

      //Console.WriteLine("Reversed: " + Convert.ToString(reversed, 2));
      //Console.WriteLine("n: " + Convert.ToString(n, 2));
      //Console.WriteLine("---------------------------------------------");

      for (int b = 0; b < 32; ++b)
      {
        reversed = reversed << 1;
        reversed |= (n & 1);
        n = n >> 1;

        //Console.WriteLine("Reversed: " + Convert.ToString(reversed, 2));
        //Console.WriteLine("n: " + Convert.ToString(n, 2));
        //Console.WriteLine("---------------------------------------------");
      }

      return reversed;
    }
  }
}
