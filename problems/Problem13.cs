using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
  /// 
  /// Symbol Value
  /// I             1
  /// V             5
  /// X             10
  /// L             50
  /// C             100
  /// D             500
  /// M             1000
  /// 
  /// For example, 2 is written as II in Roman numeral, just two ones added together.
  /// 12 is written as XII, which is simply X + II.
  /// The number 27 is written as XXVII, which is XX + V + II.
  /// 
  /// Roman numerals are usually written largest to smallest from left to right.
  /// However, the numeral for four is not IIII. Instead, the number four is written as IV.
  /// Because the one is before the five we subtract it making four. 
  /// The same principle applies to the number nine, which is written as IX.There are six 
  /// instances where subtraction is used:
  /// 
  /// I can be placed before V (5) and X(10) to make 4 and 9. 
  /// X can be placed before L(50) and C(100) to make 40 and 90. 
  /// C can be placed before D(500) and M(1000) to make 400 and 900.
  /// Given a roman numeral, convert it to an integer.
  /// </summary>
  internal class Problem13 : LeetCodeProblem, ILeetCodeProblem<string, int>
  {
    public Problem13() : base(Difficulty.Easy) { }
    public string FormatOutput(int output) => output.ToString();
    public bool IsEqual(int result, int expected) => result == expected;
    public IEnumerable<(string, int)> GetTests() {
      yield return ("III", 3);
      yield return ("LVIII", 58);
      yield return ("MCMXCIV", 1994);
    }

    public int Test(string s) {
      int total = 0;

      Dictionary<string, int> lookup = new Dictionary<string, int> {
        { "I", 1 },
        { "IV", 4 },
        { "IX", 9 },
        { "V", 5 },
        { "X", 10 },
        { "XL", 40 },
        { "XC", 90 },
        { "L", 50 },
        { "C", 100 },
        { "CD", 400 },
        { "D", 500 },
        { "CM", 900 },
        { "M", 1000 }
      };

      for (int c = 0; c < s.Length; ++c)
      {
        if (c + 1 < s.Length)
        {
          if (
            (s[c] == 'I' && (s[c + 1] == 'V' || s[c + 1] == 'X')) ||
            (s[c] == 'X' && (s[c + 1] == 'L' || s[c + 1] == 'C')) ||
            (s[c] == 'C' && (s[c + 1] == 'D' || s[c + 1] == 'M'))
          )
          {
            total += lookup[$"{s[c]}{s[c + 1]}"];
            ++c;
            continue;
          }
        }

        total += lookup[$"{s[c]}"];
      }
      return total;
    }
  }
}
