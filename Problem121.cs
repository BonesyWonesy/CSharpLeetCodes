using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    internal class Problem121 : LeetCodeProblem, ILeetCodeProblem<int[], int>
    {
        public Problem121() : base(Difficulty.Medium) { }

        public string FormatOutput(int result) => result.ToString();

        public IEnumerable<(int[], int)> GetTests()
        {
            yield return (new int[] { 7, 1, 5, 3, 6, 4 }, 5);
            yield return (new int[] { 7, 6, 4, 3, 1 }, 0);
        }

        public int Test(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxDiff = 0;

            for(int p = 0; p < prices.Length - 1; ++p)
            {
                minPrice = Math.Min(minPrice, prices[p]);
                maxDiff = Math.Max(maxDiff, prices[p + 1] - minPrice);
            }

            return maxDiff;
        }
    }
}
