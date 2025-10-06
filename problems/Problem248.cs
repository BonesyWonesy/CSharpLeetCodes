using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// Strobogrammatic Number III
  /// https://leetcode.com/problems/strobogrammatic-number-iii/description/
  /// 
  /// Given two strings low and high that represent two integers low and high where low <= high, return the number of strobogrammatic numbers in the range [low, high].
  /// 
  /// A strobogrammatic number is a number that looks the same when rotated 180 degrees(looked at upside down).
  /// </summary>
  internal class Problem248 : LeetCodeProblem, ILeetCodeProblem<(string, string), int>
  {
    private List<string>[] _stroboAtLen = new List<string>[16];
    private Dictionary<char, char> _stroboMap = new Dictionary<char, char>();
    private ulong _low;
    private ulong _high;

    public Problem248() : base(Difficulty.Hard) {
      _stroboMap.Add('0', '0');
      _stroboMap.Add('1', '1');
      _stroboMap.Add('6', '9');
      _stroboMap.Add('8', '8');
      _stroboMap.Add('9', '6');

      _stroboAtLen[0] = new List<string>();
      _stroboAtLen[0].Add("");

      _stroboAtLen[1] = new List<string>() { "0", "1", "8" };
      _stroboAtLen[2] = new List<string>() { "00", "11", "69", "88", "96" };
    }
    public string FormatOutput(int result) => result.ToString();
    public bool IsEqual(int result, int expected) => result == expected;
    public IEnumerable<((string, string), int)> GetTests() {
      yield return (("50", "100"), 3);
      yield return (("0", "0"), 1);
      yield return (("0", "1680"), 21);
    }

    public int Test((string, string) testCase) {
      return SolutionV1(testCase.Item1, testCase.Item2);
    }

    private List<string> FindStrobogrammatic(int n) {
      if (_stroboAtLen[n] != null) {
        return _stroboAtLen[n];
      }

      List<string> subStrobos = FindStrobogrammatic(n - 2);
      List<string> stroboStrings = new List<string>();

      for(int s = 0; s < subStrobos.Count; ++s)
      {
        foreach(var key in _stroboMap.Keys)
        {
          stroboStrings.Add($"{key}{subStrobos[s]}{_stroboMap[key]}");
        }
      }

      // Save for later
      _stroboAtLen[n] = stroboStrings;

      return stroboStrings;
    }

    private int SolutionV1(string low, string high) {
      int result = 0;
      _low = ulong.Parse(low);
      _high = ulong.Parse(high);

      for(int startLen = low.Length; startLen <= high.Length; ++startLen)
      {
        List<string> strobos = FindStrobogrammatic(startLen);

        result += strobos.Where(item => IsValid(item) && IsInRange(item)).Count();
      }      

      return result;
    }

    private bool IsValid(string val) {
      return val.Length < 2 || val[0] != '0';
    }

    private bool IsInRange(string val) {
      ulong number = ulong.Parse(val);
      return number >= _low && number <= _high;
    }
  }
}
