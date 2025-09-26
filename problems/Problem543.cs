using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{


    /*
     * 543. Diameter of Binary Tree
     * 
     * Given the root of a binary tree, return the length of the diameter of the tree.
     * The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.
     * The length of a path between two nodes is represented by the number of edges between them.
    */
    internal class Problem543 : LeetCodeProblem, ILeetCodeProblem<Problem543.TreeNode, int>
    {
        internal class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public Problem543() : base(Difficulty.Easy) { }

        public string FormatOutput(int result) => result.ToString();

        public IEnumerable<(TreeNode, int)> GetTests()
        {
            return new (TreeNode, int)[]
            {
                (new TreeNode(1,
                    new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                    new TreeNode(3)
                ), 3),
                (new TreeNode(1, new TreeNode(2)), 1),
                (new TreeNode(1,
                    new TreeNode(2,
                        new TreeNode(4,
                            new TreeNode(5,
                                new TreeNode(6)
                            )
                        ),
                        new TreeNode(9,
                            new TreeNode(8,
                                new TreeNode(7)
                            )
                        )
                    ),
                    new TreeNode(3)
                ), 6)
            };
        }

        public int Test(TreeNode testCase)
        {
            // We should be able to traverse the tree on the left from the root, and see how deep it goes,
            // Then do the same on the right, and add the two depths together to get the diameter.
            // However, this only works if the longest path goes through the root.

            /*
                1
               / \ 
              2   3
             / \
            4   5
             
            longestPath(1): Max(1, 0) + 1 => 2, d = 1+ 0 + 2 => 3
               longestPath(2): Max(0, 0) + 1 => 1, d = 0 + 0 + 2 => 2
                    longestPath(4): Max(-1, -1) + 1 => 0, d = 0
                        longestPath(null) -> -1
                        longestPath(null) -> -1
                    longestPath(5): Max(-1, -1) + 1 => 0, d = 0
                        longestPath(null) -> -1
                        longestPath(null) -> -1
                longestPath(3): Max(-1, -1) + 1 => 0, d = 0
                    longestPath(null) -> -1
                    longestPath(null) -> -1              
              1
             /
            2

            longestPath(1): Max(0, -1) + 1 => 1, d = -1 + 0 + 2 => 1
              longestPath(2): Max(-1, -1) + 1 => 0, d = 0
                longestPath(null) -> -1
                longestPath(null) -> -1
              longestPath(null) -> -1
            

                1
               / \
              2   3
             / \
            4   9
           /    /
          5    8   
         /    /  
        6    7 
            
longestPath(1):: Max(3, 0) + 1 => 4. d = 6
  longestPath(2): Max(2, 2) + 1 => 3, d = 6
    longestPath(4): Max(1, -1) + 1 => 2, d = 2
      longestPath(5): Max(0, -1) + 1 => 1, d = 1
        longestPath(6) -> 0, d = 0
          longestPath(null) -> -1
          longestPath(null) -> -1
        longestPath(null) -> -1
      longestPath(null) -> -1
    longestPath(9): Max(1, -1) + 1 => 2
      longestPath(8): Max(0, -1) + 1 => 1
        longestPath(7) -> 0, d = 0
          longestPath(null) -> -1
          longestPath(null) -> -1
      longestPath(null) -> -1
  longestPath(3) -> = 0
    longestPath(null) -> -1
    longestPath(null) -> -1
             */


            int diameter = 0;

            // This function is to find the longest path from the current node to a leaf node.
            int longestPath(TreeNode? node)
            {
                if (node == null)
                {
                    return -1;
                }

                int leftPath = longestPath(node.left);
                int rightPath = longestPath(node.right);


                diameter = Math.Max(diameter, leftPath + rightPath + 2);

                return Math.Max(leftPath,rightPath) + 1;
            }

            longestPath(testCase);

            return diameter;
        }
    }
}
