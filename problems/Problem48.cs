using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    /// <summary>
    /// You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
    /// You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.DO NOT allocate another 2D matrix and do the rotation.
    /// </summary>
    internal class Problem48 : LeetCodeProblem, ILeetCodeProblem<int[][], int[][]>
    {
        public Problem48() : base(Difficulty.Medium) { }
        public string FormatOutput(int[][] output) => OutputFormatters.Output(output);

        public IEnumerable<(int[][], int[][])> GetTests()
        {
            yield return (
                new int[][]
                {
                    new int[] {1,2,3 },
                    new int[] {4,5,6 },
                    new int[] {7,8,9 }
                },
                new int[][]
                {
                    // 3x3
                    // 0,0 => 0,2 | 0,1 => 1,2 | 0,2 => 2,2
                    // 1,0 => 0,1 | 1,1 => 1,1 | 1,2 => 2,1
                    // 2,0 => 0,0 | 2,1 => 1,0 | 2,2 => 2,0
                    new int[] {7, 4, 1 },
                    new int[] {8, 5, 2 },
                    new int[] {9, 6, 3 }
                }
            );

            yield return (
                new int[][]
                {
                    new int[] { 5,  1,  9, 11 },
                    new int[] { 2,  4,  8, 10 },
                    new int[] {13,  3,  6,  7 },
                    new int[] {15, 14, 12, 16 }
                },
                new int[][]
                {
                    // 4x4
                    // 0,0 => 0,3 | 0,1 => 1,3 | 0,2 => 2,3 | 0,3 => 3,3
                    // 1,0 => 0,2 | 1,1 => 1,2 | 1,2 => 2,2 | 1,3 => 3,2
                    // 2,0 => 0,1 | 2,1 => 1,1 | 2,2 => 2,1 | 2,3 => 3,1
                    // 3,0 => 0,0 | 3,1 => 1,0 | 3,2 => 2,0 | 3,3 => 3,0
                    new int[] {15, 13,  2,  5 },
                    new int[] {14,  3,  4,  1 },
                    new int[] {12,  6,  8,  9 },
                    new int[] {16,  7, 10, 11 }
                }
            );
        }

        public int[][] Test(int[][] matrix)
        {
            for( int row = 0; row < matrix.Length; ++row)
            {
                for (int col = row; col < matrix[row].Length; ++col)
                {
                    int t = matrix[row][col];
                    matrix[row][col] = matrix[col][row];
                    matrix[col][row] = t;
                }
            }

            for (int row = 0; row < matrix.Length; ++row)
            {
                int left = 0;
                int right = matrix[row].Length - 1;
                while (left < right)
                {
                    int t = matrix[row][left];
                    matrix[row][left] = matrix[row][right];
                    matrix[row][right] = t;
                    ++left;
                    --right;
                }
            }


            return matrix;
        }
    }
}
