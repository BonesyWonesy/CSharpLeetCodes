using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /**
     * Given the root of a binary tree, return the vertical order traversal of its nodes' values. (i.e., from top to bottom, column by column).
     * 
     * If two nodes are in the same row and column, the order should be from left to right.
    */
    internal class Problem314 : LeetCodeProblem, ILeetCodeProblem<int?[], int[][]>
    {
        public Problem314() : base(Difficulty.Medium) { }
        public string FormatOutput(int[][] result)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            for (int i = 0; i < result.Length; ++i)
            {
                sb.Append("[");
                for (int j = 0; j < result[i].Length; ++j)
                {
                    sb.Append(result[i][j].ToString());

                    if (j != result[i].Length - 1)
                    {
                        sb.Append(", ");
                    }
                }
                sb.Append("]");

                if (i != result.Length - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append("]");

            return sb.ToString();
        }

        public IEnumerable<(int?[], int[][])> GetTests()
        {
            yield return (new int?[] { 3, 9, 20, null, null, 15, 7 }, new int[][] { new int[] { 9 }, new int[] { 3, 15 }, new int[] { 20 }, new int[] { 7 } });
            yield return (new int?[] { 3, 9, 8, 4, 0, 1, 7 }, new int[][] { new int[] { 4 }, new int[] { 9 }, new int[] { 3, 0, 1 }, new int[] { 8 }, new int[] { 7 } });
            yield return (new int?[] { 1, 2, 3, 4, 10, 9, 11, null, 5, null, null, null, null, null, null, null, null, null, 6 }, new int[][] { new int[] { 4 }, new int[] { 2, 5 }, new int[] { 1, 10, 9, 6 }, new int[] { 3 }, new int[] { 11 } });
        }

        public int[][] Test(int?[] testCase)
        {
            BinaryTree bt = new BinaryTree(testCase);

            IList<IList<int>> result = VerticalOrder(bt.GetRoot());

            int[][] output = new int[result.Count][];

            int i = 0;
            foreach (var item in result)
            {
                output[i] = item.ToArray();
                ++i;
            }

            return output;
        }

        private IList<IList<int>> VerticalOrder(BinaryTree.TreeNode root)
        {
            Queue<(BinaryTree.TreeNode, int)> queue = new Queue<(BinaryTree.TreeNode, int)> ();
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null) { 
                return result; 
            }

            Dictionary<int, List<int>> columnToListMap = new Dictionary<int, List<int>>();

            int minColumn = 0;
            int maxColumn = 0;

            columnToListMap.Add(0, new List<int>() { root.val });

            queue.Enqueue((root, 0));

            while(queue.Count > 0)
            {
                (BinaryTree.TreeNode node, int column) temp = queue.Dequeue();

                if (temp.node.left != null)
                {
                    int targetColumn = temp.column - 1;
                    minColumn = Math.Min(minColumn, targetColumn);

                    if (!columnToListMap.ContainsKey(minColumn))
                    {
                        columnToListMap.Add(minColumn, new List<int>());
                    }

                    columnToListMap[targetColumn].Add(temp.node.left.val);
                    queue.Enqueue((temp.node.left, targetColumn));
                }

                if (temp.node.right != null)
                {
                    int targetColumn = temp.column + 1;
                    maxColumn = Math.Max(maxColumn, targetColumn);

                    if (!columnToListMap.ContainsKey(maxColumn))
                    {
                        columnToListMap.Add(maxColumn, new List<int>());
                    }

                    columnToListMap[targetColumn].Add(temp.node.right.val);
                    queue.Enqueue((temp.node.right, targetColumn));
                }
            }

            for (int i = minColumn; i <= maxColumn; ++i)
            {
                result.Add(columnToListMap[i]);
            }

            return result;
        }

    }
}
