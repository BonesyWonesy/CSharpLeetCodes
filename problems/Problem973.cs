using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    /*
     * Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, return the k closest points to the origin (0, 0).
     * 
     * The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)2 + (y1 - y2)2).
     * 
     * You may return the answer in any order. The answer is guaranteed to be unique (except for the order that it is in).
     */
    internal class Problem973 : LeetCodeProblem, ILeetCodeProblem<(IList<IList<int>>, int), IList<IList<int>>>
    {
        public Problem973() : base(Difficulty.Medium) { }
        public string FormatOutput(IList<IList<int>> result) => "[" + string.Join(", ", result.Select(p => "[" + string.Join(",", p) + "]")) + "]";
        public IEnumerable<((IList<IList<int>>, int), IList<IList<int>>)> GetTests()
        {
            yield return ((new List<IList<int>> { new List<int> { 1, 3 }, new List<int> { -2, 2 } }, 1), new List<IList<int>> { new List<int> { -2, 2 } });
            yield return ((new List<IList<int>> { new List<int> { 3, 3 }, new List<int> { 5, -1 }, new List<int> { -2, 4 } }, 2), new List<IList<int>> { new List<int> { 3, 3 }, new List<int> { -2, 4 } });
        }
        public IList<IList<int>> Test((IList<IList<int>>, int) testCase)
        {
            IList<IList<int>> points = testCase.Item1;
            int k = testCase.Item2;
            return KClosest(points, k);
        }
        private IList<IList<int>> KClosest(IList<IList<int>> points, int k)
        {
            return points.OrderBy(p => p[0] * p[0] + p[1] * p[1]).Take(k).ToList();

            /*
            PriorityQueue<int[], int> queue = new PriorityQueue<int[], int>();

            var result = new int[k][];

            for(int p = 0; p < points.Length; ++p) {
                int dist = points[p][0] * points[p][0] + points[p][1] * points[p][1];
                queue.Enqueue(new int[2]{points[p][0], points[p][1]}, dist);
            }

            for(int i = 0; i < k; ++i) {
                result[i] = queue.Dequeue();
            }

            return result;
            */
        }
    }
}
