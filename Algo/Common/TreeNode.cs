using System;
using System.Text;

namespace Algo.Common
{
    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int x) { val = x; }

        public override string ToString()
        {
            // do root->left->right iteration and add the values to the StringBuilder
            StringBuilder sbTree = new StringBuilder();

            bool isLeaf = (left == null && right == null);

            sbTree.Append($"{ this.val }");

            if (!isLeaf)
            {
                string leftNode = (left != null) ? left.ToString() : "null";
                sbTree.Append($", { leftNode  }"); 

                string rightNode = (right != null) ? right.ToString(): "null";
                sbTree.Append($", { rightNode }");
            }

            return sbTree.ToString();
        }

        public static TreeNode Build(object[] binaryTreeArray)
        {
            TreeNode root = BuildFromIndex(binaryTreeArray, 0);
            return root;
        }

        private static TreeNode BuildFromIndex(object[] binaryTreeArray, int index)
        {
            if (binaryTreeArray.Length <= index || binaryTreeArray[index] == null) { return null; }

            TreeNode leftRoot = BuildFromIndex(binaryTreeArray, 2 * index + 1);
            TreeNode rightRoot = BuildFromIndex(binaryTreeArray, 2 * index + 2);

            TreeNode root = new TreeNode((int)binaryTreeArray[index]) { left = leftRoot, right = rightRoot };
            return root;
        }
    }
}
