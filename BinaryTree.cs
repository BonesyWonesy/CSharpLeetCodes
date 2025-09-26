using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    internal class BinaryTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode? parent;
            public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null, TreeNode? parent = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
                this.parent = parent;
            }
        }

        TreeNode? root;

        public BinaryTree(int?[] nums)
        {
            if (nums.Length == 0)
            {
                throw new ArgumentException("Array is empty", nameof(nums));
            }
            this.root = BuildTree(nums, 0);
        }
        
        private TreeNode? BuildTree(int?[] nums, int index)
        {
            if (index >= nums.Length || nums[index] == null)
            {
                return null;
            }

            TreeNode node = new TreeNode(nums[index].Value);
            node.left = BuildTree(nums, 2 * index + 1);
            node.right = BuildTree(nums, 2 * index + 2);

            if (node.left != null)
            {
                node.left.parent = node;
            }

            if (node.right != null)
            {
                node.right.parent = node;
                
            }

            return node;
        }

        public TreeNode? GetRoot ()=> this.root;

        public TreeNode? FindNode(int val)
        {
            return FindNodeRecursive(this.root, val);
        }

        public int?[] GetLevelOrderList()
        {
            List<int?> list = new List<int?>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                int count = queue.Count;

                for (int i = 0; i < count; ++i)
                {
                    TreeNode node = queue.Dequeue();
                    list.Add(node.val);

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    } 

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }

            return list.ToArray();
        }

        private TreeNode? FindNodeRecursive(TreeNode? node, int val)
        {
            if (node == null)
            {
                return null;
            }
            if (node.val == val)
            {
                return node;
            }
            TreeNode? leftResult = FindNodeRecursive(node.left, val);
            if (leftResult != null)
            {
                return leftResult;
            }
            return FindNodeRecursive(node.right, val);
        }
    }
}