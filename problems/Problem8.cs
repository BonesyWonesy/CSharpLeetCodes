using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpLeetCode.problems
{
    /// <summary>
    /// Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer.
    /// 
    /// The algorithm for myAtoi(string s) is as follows:
    /// Whitespace: Ignore any leading whitespace(" ").
    /// Signedness: Determine the sign by checking if the next character is '-' or '+', assuming positivity if neither present.
    /// Conversion: Read the integer by skipping leading zeros until a non-digit character is encountered or the end of the string is reached.If no digits were read, then the result is 0
    /// Rounding: If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then round the integer to remain in the range. Specifically, integers less than -231 should be rounded to -231, and integers greater than 231 - 1 should be rounded to 231 - 1
    /// Return the integer as the final result.
    /// </summary>
    internal class Problem8 : LeetCodeProblem, ILeetCodeProblem<string, int>
    {
        public Problem8() : base(Difficulty.Medium) { }

        public string FormatOutput(int result) => $"{result}";

        public IEnumerable<(string, int)> GetTests()
        {
            yield return ("42", 42);
            yield return (" -042", -42);
            yield return ("1337c0d3", 1337);
            yield return ("0-1", 0);
            yield return ("words and 987", 0);
            yield return ("-91283472332", int.MinValue);
            yield return ("-+12", 0);
            yield return ("", 0);
            yield return ("2147483648", 2147483647);
        }

        public int Test(string s) {
            s = s.TrimStart();

            if (s.Length == 0)
            {
                return 0;
            }

            int sign = s[0] == '-' ? -1 : 1;

            int value = 0;

            for(int i = 0; i < s.Length; ++i)
            {
                if (i == 0 && (s[i] == '-' || s[i] == '+')) {
                    continue;
                }

                if (char.IsDigit(s[i]))
                {
                    if ( value > int.MaxValue / 10 )
                    {
                        return sign > 0 ? int.MaxValue : int.MinValue;
                    }
                    value = value * 10;
                    int add = int.Parse($"{s[i]}");

                    if (int.MaxValue - value - add < 0) {
                        return sign > 0 ? int.MaxValue : int.MinValue;
                    }

                    value += add;
                    
                    continue;
                }
                break;
            }

            return value * sign;
        }
    }
}
