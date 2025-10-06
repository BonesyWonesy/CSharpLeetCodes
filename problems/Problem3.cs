using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Given a string s, find the length of the longest substring without duplicate characters.
  /// 
  /// Example 1:
  /// Input: s = "abcabcbb"
  /// Output: 3
  /// Explanation: The answer is "abc", with the length of 3. Note that "bca" and "cab" are also correct answers
  /// 
  /// Example 2:
  /// Input: s = "bbbbb"
  /// Output: 1
  /// Explanation: The answer is "b", with the length of 1.
  /// 
  /// Example 3:
  /// Input: s = "pwwkew"
  /// Output: 3
  /// Explanation: The answer is "wke", with the length of 3.
  /// Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
  /// </summary>
  internal class Problem3 : LeetCodeProblem, ILeetCodeProblem<string, int>
  {
    public Problem3() : base(Difficulty.Medium) { }
    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;
    public IEnumerable<(string, int)> GetTests() {
      yield return ("abcabcbb", 3);
      yield return ("bbbbb", 1);
      yield return ("pwwkew", 3);
      yield return ("dvdf", 3);
      yield return ("au", 2);
    }

    public int Test(string s) {
      //return BruteForce(s);
      return SlidingWindow(s);
      //return SlidingWindowOptimized(s);
    }

    /// <summary>
    /// The brute force method iterates through all possible substrings moving forward through the main string.
    /// At each position we continue to check everything in front of it, keeping the longest substring.
    /// 
    /// Time Complexity: O(n^2)
    /// Space Complexity: O(k)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int BruteForce(string s) {
      int longest = 0;

      for (int i = 0; i < s.Length; ++i)
      {
        HashSet<char> existingChars = new();
        existingChars.Add(s[i]);

        for (int j = i + 1; j < s.Length; ++j)
        {
          if (existingChars.Contains(s[j]))
          {
            break;
          }

          longest = Math.Max(longest, j - i + 1);
          existingChars.Add(s[j]);
        }

      }

      return longest;
    }

    /// <summary>
    /// This approach uses a sliding window. Where the window grows and shrinks based on if characters exist within the set.
    /// If a character doesn't exist, we grow the window. If the character we're checking at the window's edge exists, then
    /// we need to move the starting point of the window forward. 
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(k)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int SlidingWindow(string s) {
      int longest = 0;
      int left = 0;
      int right = 0;
      HashSet<char> existingChars = new HashSet<char>();

      while (right < s.Length)
      {
        if (!existingChars.Contains(s[right]))
        {
          existingChars.Add(s[right]);
          longest = Math.Max(longest, right - left + 1);
          ++right;
        }
        else
        {
          existingChars.Remove(s[left]);
          ++left;
        }
      }

      return longest;
    }

    /// <summary>
    /// This is a slightly optimized version of the sliding window. We use a dictionary instead of a HashMap to store the
    /// characters we ran across and the index at which it as found. As we move through the string checking the characters
    /// when a duplicate character is encountered, move the left pointer directly to the next position after the last seen
    /// index of that character. This removes the need to delete each character individually, slightly improving performance
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(k)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int SlidingWindowOptimized(string s) {
      int longest = 0;
      int left = 0;
      Dictionary<char, int> characterIndexMap = new Dictionary<char, int>();

      for (int right = 0; right < s.Length; ++right)
      {
        if (characterIndexMap.ContainsKey(s[right]))
        {
          // Move left only forward to avoid shrinking backward
          left = Math.Max(characterIndexMap[s[right]] + 1, left);
        }

        characterIndexMap[s[right]] = right;
        longest = Math.Max(longest, right - left + 1);
      }

      return longest;
    }
  }
}
