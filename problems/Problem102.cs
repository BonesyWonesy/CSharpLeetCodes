using CSharpLeetCode.types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.problems
{
    /// <summary>
    /// Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
    /// </summary>
    internal class Problem102 : LeetCodeProblem, ILeetCodeProblem<BinaryTree.TreeNode?, IList<IList<int>>>
    {
        public Problem102() : base(Difficulty.Medium) { }
        public string FormatOutput(IList<IList<int>> result) => OutputFormatters.Output(result);

        public IEnumerable<(BinaryTree.TreeNode?, IList<IList<int>>)> GetTests()
        {
            List<IList<int>> test1 = new List<IList<int>>();
            test1.Add(new List<int>([3]));
            test1.Add(new List<int>([9, 20]));
            test1.Add(new List<int>([15, 7]));

            yield return (
                new BinaryTree([3, 9, 20, null, null, 15, 7]).GetRoot(),
                test1
            );

            List<IList<int>> test2 = new List<IList<int>>();
            test2.Add(new List<int>([1]));

            yield return (
                new BinaryTree([1]).GetRoot(),
                test2
            );

            List<IList<int>> test3 = new List<IList<int>>();

            yield return (null, test3);
        }

        public void TraverseTree(BinaryTree.TreeNode? node, Dictionary<int, List<int>> depthMap, int currentDepth)
        {
            if (node == null)
            {
                return;
            }

            if (!depthMap.ContainsKey(currentDepth))
            {
                depthMap[currentDepth] = new List<int>();
            }

            depthMap[currentDepth].Add(node.val);

            TraverseTree(node.left, depthMap, currentDepth + 1);
            TraverseTree(node.right, depthMap, currentDepth + 1);
        }

        public IList<IList<int>> Test(BinaryTree.TreeNode? root)
        {
            List<IList<int>> result = new List<IList<int>>();
            return OptimizedSolution(root);
            if (root == null)
            {
                return result;
            }


            Dictionary<int, List<int>> depthMap = new();
            int depth = 0;
            depthMap[depth] = new List<int>();
            depthMap[depth].Add(root.val);

            TraverseTree(root.left, depthMap, depth + 1);
            TraverseTree(root.right, depthMap, depth + 1);

            result = depthMap
               .OrderBy(kvp => kvp.Key)   // sort dictionary by key
               .Select(kvp => (IList<int>)kvp.Value) // cast List<int> to IList<int>
               .ToList();                 // final result as List<IList<int>>

            return result;        
        }

        public IList<IList<int>> OptimizedSolution(BinaryTree.TreeNode? root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null)
            {
                return result;
            }

            Queue<BinaryTree.TreeNode> queue = new Queue<BinaryTree.TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int count = queue.Count;
                List<int> level = new List<int>();

                for (int i = 0; i < count; ++i)
                {
                    BinaryTree.TreeNode cur = queue.Dequeue();
                    level.Add(cur.val);

                    if (cur.left != null)
                    {
                        queue.Enqueue(cur.left);
                    }

                    if (cur.right != null)
                    {
                        queue.Enqueue(cur.right);
                    }
                }
                result.Add(level);
            }

            return result;
        }
    }
}
