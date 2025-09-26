using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    internal class Problem227 : LeetCodeProblem, ILeetCodeProblem<string, int>
    {
        public Problem227() : base(Difficulty.Medium) { }
        public string FormatOutput(int result) => result.ToString();

        public IEnumerable<(string, int)> GetTests()
        {
            yield return ("3+2*2", 7);
            yield return (" 3/2 ", 1);
            yield return (" 3+5 / 2 ", 5);
            yield return ("14-3/2", 13);
            yield return ("0-2147483647", -2147483647);
            yield return ("1-1+1", 1);
        }

        public int Test(string s)
        {
            s = s.Trim();
            s = s.Replace(" ", "");
            s = s + '+';

            Stack<int> numbers = new Stack<int>();

            int curNumber = 0;
            char lastOp = '+';

            for(int c = 0; c < s.Length; ++c)
            {
                if (char.IsDigit(s[c]))
                {
                    curNumber = curNumber * 10 + (s[c] - '0');
                    continue;
                }

                switch(lastOp)
                {
                    case '+':
                        numbers.Push(curNumber);
                        break;
                    case '-':
                        numbers.Push(-curNumber);
                        break;
                    case '*':
                        numbers.Push(numbers.Pop() * curNumber);
                        break;
                    case '/':
                        numbers.Push(numbers.Pop() / curNumber);
                        break;
                    default:
                        return 0;
                }

                lastOp = s[c];
                curNumber = 0;
            }

            int calculate = 0;
            while (numbers.Count > 0) {
                calculate += numbers.Pop();
            }


            return calculate;
        }
    }
}
