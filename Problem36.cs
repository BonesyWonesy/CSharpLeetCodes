using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /// <summary>
    /// Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
    /// 
    /// Each row must contain the digits 1-9 without repetition.
    /// Each column must contain the digits 1-9 without repetition.
    /// Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
    /// 
    /// Note:
    /// A Sudoku board (partially filled) could be valid but is not necessarily solvable.
    /// Only the filled cells need to be validated according to the mentioned rules.
    /// </summary>
    internal class Problem36 : LeetCodeProblem, ILeetCodeProblem<char[][], bool>
    {
        public Problem36() : base(Difficulty.Medium) {  }

        public string FormatOutput(bool output) => output.ToString();

        public IEnumerable<(char[][], bool)> GetTests()
        {
            yield return (new char[][]
            {
                new char[] { '5','3','.','.','7','.','.','.','.' },
                new char[] { '6','.','.','1','9','5','.','.','.' },
                new char[] { '.','9','8','.','.','.','.','6','.' },
                new char[] { '8','.','.','.','6','.','.','.','3' },
                new char[] { '4','.','.','8','.','3','.','.','1' },
                new char[] { '7','.','.','.','2','.','.','.','6' },
                new char[] { '.','6','.','.','.','.','2','8','.' },
                new char[] { '.','.','.','4','1','9','.','.','5' },
                new char[] { '.','.','.','.','8','.','.','7','9' }
            }, true);

            yield return (new char[][]
            {
                new char[] { '8','3','.','.','7','.','.','.','.' },
                new char[] { '6','.','.','1','9','5','.','.','.' },
                new char[] { '.','9','8','.','.','.','.','6','.' },
                new char[] { '8','.','.','.','6','.','.','.','3' },
                new char[] { '4','.','.','8','.','3','.','.','1' },
                new char[] { '7','.','.','.','2','.','.','.','6' },
                new char[] { '.','6','.','.','.','.','2','8','.' },
                new char[] { '.','.','.','4','1','9','.','.','5' },
                new char[] { '.','.','.','.','8','.','.','7','9' }
            }, false);

            yield return (new char[][]
            {
                new char[] { '7','.','.','.','4','.','.','.','.' },
                new char[] { '.','.','.','8','6','5','.','.','.' },
                new char[] { '.','1','.','2','.','.','.','.','.' },
                new char[] { '.','.','.','.','.','9','.','.','.' },
                new char[] { '.','.','.','.','5','.','5','.','.' },
                new char[] { '.','.','.','.','.','.','.','.','.' },
                new char[] { '.','.','.','.','.','.','2','.','.' },
                new char[] { '.','.','.','.','.','.','.','.','.' },
                new char[] { '.','.','.','.','.','.','.','.','.' }
            }, false);

            yield return (new char[][]
            {
                new char[] { '.','.','.','.','5','.','.','1','.' },
                new char[] { '.','4','.','3','.','.','.','.','.' },
                new char[] { '.','.','.','.','.','3','.','.','1' },
                new char[] { '8','.','.','.','.','.','.','2','.' },
                new char[] { '.','.','2','.','7','.','.','.','.' },
                new char[] { '.','1','5','.','.','.','.','.','.' },
                new char[] { '.','.','.','.','.','2','.','.','.' },
                new char[] { '.','2','.','9','.','.','.','.','.' },
                new char[] { '.','.','4','.','.','.','.','.','.' }
            }, false);

        }

        public bool Test(char[][] board)
        {
            HashSet<string> seenMap = new HashSet<string>();


            for (int row = 0; row < board[0].Length; ++row) {
                for (int col = 0; col < 9; ++col) {
                    char c = board[row][col];

                    if (c != '.')
                    {
                        if ( !seenMap.Add("char: " + c + " col: " + col) ||
                             !seenMap.Add("char: " + c + " row: " + row) ||
                             !seenMap.Add("char: " + c + " box: " + row/3 + "," + col/3))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
