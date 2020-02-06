using System;
using System.Text;

namespace Algo.Common
{
    public class TreeNode
    {
        public int Val { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode(int x) { Val = x; }

        public override string ToString()
        {
            // do root->left->right iteration and add the values to the StringBuilder
            StringBuilder sbTree = new StringBuilder();

            bool isLeaf = (Left == null && Right == null);

            sbTree.Append($"{ this.Val }");

            if (!isLeaf)
            {
                string leftNode = (Left != null) ? Left.ToString() : "null";
                sbTree.Append($", { leftNode  }"); 

                string rightNode = (Right != null) ? Right.ToString(): "null";
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

            TreeNode root = new TreeNode((int)binaryTreeArray[index]) { Left = leftRoot, Right = rightRoot };
            return root;
        }
    }
}
