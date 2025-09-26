using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    internal class Problem50 : LeetCodeProblem, ILeetCodeProblem<(double, int), double>
    {
        public Problem50() : base(Difficulty.Medium) { } 

        public string FormatOutput(double result) => result.ToString();

        public IEnumerable<((double, int), double)> GetTests()
        {
            yield return ((2.00000, 10), 1024.0);
            yield return ((2.10000, 3), 9.26100);
            yield return ((2.00000, -2), 0.25000);
        }

        public double Test((double, int) testCase)
        {
            //A negative exponent is equal to the reciprocal of the base raised to the corresponding positive exponent, expressed as a⁻ⁿ = 1 / aⁿ
            double baseItem = testCase.Item1;
            int exponent = testCase.Item2;

            bool useInv = exponent < 0;
            long N = Math.Abs((long)exponent);

            if (N == 0)
            {
                return 1;
            }

            double y = 1.0;

            while (N > 0)
            {
                if (N % 2 == 1)
                {
                    y *= baseItem;
                }

                baseItem *= baseItem;
                N /= 2;
            }

            return useInv ? 1.0 / y : y;
        }
    }
}
