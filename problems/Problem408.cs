using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /**
   * A string can be abbreviated by replacing any number of non-adjacent, non-empty substrings with their lengths. The lengths should not have leading zeros.
   * 
   * For example, a string such as "substitution" could be abbreviated as (but not limited to):
   * "s10n" ("s ubstitutio n")
   * "sub4u4" ("sub stit u tion")
   * "12" ("substitution")
   * "su3i1u2on" ("su bst i t u ti on")
   * "substitution" (no substrings replaced)
   * 
   * The following are not valid abbreviations:
   * "s55n" ("s ubsti tutio n", the replaced substrings are adjacent)
   * "s010n" (has leading zeros)
   * "s0ubstitution" (replaces an empty substring)
   * 
   * Given a string word and an abbreviation abbr, return whether the string matches the given abbreviation.
   * 
   * A substring is a contiguous non-empty sequence of characters within a string.
  */
  internal class Problem408 : LeetCodeProblem, ILeetCodeProblem<(string, string), bool>
  {
    public Problem408() : base(Difficulty.Easy) { }
    public string FormatOutput(bool result) => result.ToString().ToLower();
    public bool IsEqual(bool result, bool expected) => result == expected;

    public IEnumerable<((string, string), bool)> GetTests() {
      yield return (("internationalization", "i12iz4n"), true);
      yield return (("apple", "a2e"), false);
      yield return (("substitution", "s010n"), false);
      yield return (("substitution", "s55n"), false);
      yield return (("substitution", "s0ubstitution"), false);
      yield return (("word", "w1r1"), true);
      yield return (("word", "1o1d"), true);
      yield return (("word", "1o2"), true);
      yield return (("word", "3d"), true);
      yield return (("word", "4"), true);
      yield return (("word", "5"), false);
      yield return (("hi", "2i"), false);
      yield return (("hi", "1"), false);
    }

    public bool Test((string, string) testCase) {
      string word = testCase.Item1;
      string abbrv = testCase.Item2;

      int abbrLen = 0;
      for (int a = 0; a < abbrv.Length; ++a)
      {
        if (word == string.Empty)
        {
          return false;
        }

        if (char.IsDigit(abbrv[a]))
        {
          if (abbrv[a] == '0' && abbrLen == 0)
          {
            return false;
          }

          abbrLen = int.Parse(abbrv[a].ToString());

          // Check the next character to see if they are also digits. If so append to the current number.
          int digitIndex = a + 1;
          while (digitIndex < abbrv.Length && char.IsDigit(abbrv[digitIndex]))
          {
            abbrLen = abbrLen * 10 + (abbrv[digitIndex] - '0');
            digitIndex += 1;
            a += 1;
          }

          // If the number is greater than the length of the remaining word, then return false, it's likely an invalid abbreviation
          if (abbrLen > word.Length)
          {
            return false;
          }
          else
          {
            word = word.Substring(abbrLen);
            abbrLen = 0;
          }
        }
        else if (word[0] == abbrv[a])
        {
          word = word.Substring(1);
        }
        else
        {
          return false;
        }
      }

      if (word != string.Empty)
      {
        return false;
      }

      return true;
    }
  }
}
