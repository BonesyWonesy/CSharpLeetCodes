using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /**
     * Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix. If there is no clear path, return -1.
     * 
     * A clear path in a binary matrix is a path from the top-left cell (i.e., (0, 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such that:
     * All the visited cells of the path are 0.
     * All the adjacent cells of the path are 8-directionally connected (i.e., they are different and they share an edge or a corner).
     * 
     * The length of a clear path is the number of visited cells of this path.
     */
    internal class Problem1091 : LeetCodeProblem, ILeetCodeProblem<int[][], int>
    {
        public Problem1091() : base(Difficulty.Medium) { }
        public string FormatOutput(int result) => result.ToString();
        public IEnumerable<(int[][], int)> GetTests()
        {
            yield return (new int[][] {
                new int[] {0,0,0 },
                new int[] {1,1,0 },
                new int[] {1,1,0 } }, 4);
            yield return (new int[][] {
                new int[] {0,1 },
                new int[] {1,0 } }, 2);
            yield return (new int[][] {
                new int[] {1,0,0 },
                new int[] {1,1,0 },
                new int[] {1,1,0 } }, -1);
            yield return (new int[][]
            {
                new int[] {0, 0, 1, 0, 1 },
                new int[] {0, 0, 0, 1, 0 },
                new int[] {1, 0, 0, 1, 1 },
                new int[] {0, 0, 0, 1, 1 },
                new int[] {1, 0, 0, 0, 0 } }, 6);
        }

        public int Test(int[][] grid)
        {
            if (grid.Length == 0 || grid[0].Length == 0 || grid[0][0] == 1 || grid[grid.Length - 1][grid[0].Length - 1] == 1) {
                return -1;
            }

            PriorityQueue<(int row, int col, int distance), int> queue = new PriorityQueue<(int row, int col, int distance), int>();

            queue.Enqueue((0, 0, 1), 1);
            bool[,] visited = new bool[grid.Length, grid[0].Length];

            int answer = 0;
            
            while (queue.Count > 0)
            {
                int targetRow = queue.Peek().row;
                int targetCol = queue.Peek().col;
                
                int dist = queue.Peek().distance;

                if (targetRow == grid.Length - 1 && targetCol == grid[0].Length - 1)
                {
                    answer = dist;
                    break;
                }

                queue.Dequeue();

                if (visited[targetRow, targetCol]) { continue; }
                visited[targetRow, targetCol] = true;

                // Enqueue neighbors
                int right = targetCol + 1;
                int left = targetCol - 1;
                int up = targetRow - 1;
                int down = targetRow + 1;
                //down
                if (down <= grid.Length - 1 && grid[down][targetCol] == 0)
                {
                    queue.Enqueue((down, targetCol, dist + 1), dist + 1);
                }

                // up
                if (up >= 0 && grid[up][targetCol] == 0)
                {
                    queue.Enqueue((up, targetCol, dist + 1), dist + 1);
                }

                // right
                if (right <= grid[0].Length - 1 && grid[targetRow][right] == 0)
                {
                    queue.Enqueue((targetRow, right, dist + 1), dist + 1);
                }

                // left
                if (left >= 0 && grid[targetRow][left] == 0)
                {
                    queue.Enqueue((targetRow, left, dist + 1), dist + 1);
                }

                // lower-right
                if (right <= grid[0].Length -1 && down <= grid.Length - 1 && grid[down][right] == 0)
                {
                    queue.Enqueue((down, right, dist + 1), dist + 1);
                }

                // lower-left
                if (left >= 0 && down <= grid.Length - 1 && grid[down][left] == 0)
                {
                    queue.Enqueue((down, left, dist + 1), dist + 1);
                }

                // top-right
                if (up >= 0 && right <= grid[0].Length - 1 && grid[up][right] == 0)
                {
                    queue.Enqueue((up, right, dist + 1), dist + 1);
                }

                // top-left
                if (up >= 0 && left >= 0 && grid[up][left] == 0)
                {
                    queue.Enqueue((up, left, dist + 1), dist + 1);
                }

            }

            if (answer == 0)
            {
                return -1;
            }

            return answer;
        }

    }
}
