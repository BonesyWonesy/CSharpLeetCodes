using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{
  /// <summary>
  /// https://leetcode.com/problems/strobogrammatic-number-ii/description/
  /// 
  /// Given an integer n, return all the strobogrammatic numbers that are of length n. You may return the answer in any order.
  /// 
  /// A strobogrammatic number is a number that looks the same when rotated 180 degrees(looked at upside down).
  /// 
  /// Contraints:
  /// 1 <= n <= 14
  /// </summary>
  internal class Problem247 : LeetCodeProblem, ILeetCodeProblem<int, string[]>
  {
    public Problem247() : base(Difficulty.Easy) { }
    public string FormatOutput(string[] output) => OutputFormatters.Output(output);
    public IEnumerable<(int, string[])> GetTests() {
      yield return (2, ["11", "69", "96", "88"]);
      yield return (1, ["0", "1", "8"]);
      yield return (3, ["101", "111", "181", "609", "619", "689", "808", "818", "888", "906", "916", "986"]);
      yield return (4, ["1001", "1111", "1881", "1691", "1961", "6009", "6119", "6699", "6889", "6969", "8008", "8118", "8698", "8888", "8968", "9006", "9116", "9696", "9886", "9966"]);
      yield return (6, ["100001", "101101", "106901", "108801", "109601", "110011", "111111", "116911", "118811", "119611", "160091", "161191", "166991", "168891", "169691", "180081", "181181", "186981", "188881", "189681", "190061", "191161", "196961", "198861", "199661", "600009", "601109", "606909", "608809", "609609", "610019", "611119", "616919", "618819", "619619", "660099", "661199", "666999", "668899", "669699", "680089", "681189", "686989", "688889", "689689", "690069", "691169", "696969", "698869", "699669", "800008", "801108", "806908", "808808", "809608", "810018", "811118", "816918", "818818", "819618", "860098", "861198", "866998", "868898", "869698", "880088", "881188", "886988", "888888", "889688", "890068", "891168", "896968", "898868", "899668", "900006", "901106", "906906", "908806", "909606", "910016", "911116", "916916", "918816", "919616", "960096", "961196", "966996", "968896", "969696", "980086", "981186", "986986", "988886", "989686", "990066", "991166", "996966", "998866", "999666"]);
    }

    public bool IsEqual(string[] result, string[] expected) {
      for (int s = 0; s < result.Length; ++s)
      {
        if (!expected.Contains(result[s])) { return false; }
      }
      return true;
    }

    public string[] Test(int n) {
      return SolutionV1(n);
    }

    public string[] GetStrobogrammaticLevel(int level, bool includeZero, Dictionary<char, char> strobogrammaticMap) {
      if (level == 1)
      {
        return ["0", "1", "8"];
      }
      else if (level == 2)
      {
        return ["00", "11", "69", "88", "96"];
      }
      else
      {
        string[] subStrobos = GetStrobogrammaticLevel(level - 2, true, strobogrammaticMap);

        List<string> stroboStrings = new List<string>();
        
        for (int s = 0; s < subStrobos.Length; ++s)
        {
          foreach(var key in strobogrammaticMap.Keys)
          {
            stroboStrings.Add($"{key}{subStrobos[s]}{strobogrammaticMap[key]}");
          }
        }
        return stroboStrings.Where(item => item[0] != '0').ToArray();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    private string[] SolutionV1(int n) {
      // Our strobogrammic numbers are: 0, 1, 6, 8, 9.
      // Since we know that our first half of our number string needs to match the 2nd half strobomatically, we only need to generate n/2 results and we can build the whole list.

      // n = 1 => ["0", "1", "8"]
      // n = 2 => (00 isn't valid) ["11", "69", "88", "96"]
      // n = 3 => ["101", "111", " 181", "609", "619", "689", "808", "818", "888", "906", "916", "986"]
      // n = 4 => ["1001", "1111", "1691", "1881", "1961", "6009", "6119", "6699", "6889", "6969", "8008", "8118", "8698", "8888", "8968", "9006", "9116", "9696", "9886", "9966"]
      // 

      // You can start to find a pattern where you will take the strobogrammic numbers: 1, 6, 8, 9 and for each number you'll inject the strobogrammic characters of (n - 2) inside each strobogrammic pairing.
      Dictionary<char, char> strobogrammaticMap = new Dictionary<char, char>();
      strobogrammaticMap.Add('0', '0');
      strobogrammaticMap.Add('1', '1');
      strobogrammaticMap.Add('6', '9');
      strobogrammaticMap.Add('8', '8');
      strobogrammaticMap.Add('9', '6');

      if (n == 1)
      {
        return ["0", "1", "8"];
      }
      else if (n == 2)
      {
        return ["11", "69", "88", "96"];
      }

      return GetStrobogrammaticLevel(n, false, strobogrammaticMap);
    }
  }
}
