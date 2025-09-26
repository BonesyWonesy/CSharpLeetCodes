using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpLeetCode
{
    /// <summary>
    /// Write a function that reverses a string. The input string is given as an array of characters s.
    /// 
    /// You must do this by modifying the input array in-place with O(1) extra memory.
    /// </summary>
    internal class Problem344 : LeetCodeProblem, ILeetCodeProblem<char[], char[]>
    {
        public Problem344() : base(Difficulty.Easy) { }

        public string FormatOutput(char[] output) => OutputFormatters.Output(output);

        public IEnumerable<(char[], char[])> GetTests()
        {
            yield return (new char[] { 'h', 'e', 'l', 'l', 'o' }, new char[] { 'o', 'l', 'l', 'e', 'h' });
            yield return (new char[] { 'h', 'a', 'n', 'n', 'a', 'h'}, new char[] {'h', 'a', 'n', 'n', 'a', 'h' });
        }

        public char[] Test(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                char t = s[left];
                s[left] = s[right];
                s[right] = t;
                ++left;
                --right;
            }
            return s;
        }
    }
}
