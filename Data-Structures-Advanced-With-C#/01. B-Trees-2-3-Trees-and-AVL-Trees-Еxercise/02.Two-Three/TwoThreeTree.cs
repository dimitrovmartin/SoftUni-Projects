namespace _02.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T key)
        {
            if (root == null)
            {
                root = new TreeNode<T>(key);
            }
            else
            {
                root = Insert(root, key);
            }
        }

        private TreeNode<T> Insert(TreeNode<T> node, T key)
        {
            if (node.IsLeaf())
            {
                return MergeNewKey(node, new TreeNode<T>(key));
            }

            TreeNode<T> returnNode;

            if (key.CompareTo(node.LeftKey) < 0)
            {
                returnNode = Insert(node.LeftChild, key);

                if (returnNode == node.LeftChild)
                {
                    return node;
                }
                else
                {
                    return MergeNewKey(node, returnNode);
                }
            }
            else if (node.IsTwoNode() || key.CompareTo(node.RightKey) < 0)
            {
                returnNode = Insert(node.MiddleChild, key);

                if (returnNode == node.MiddleChild)
                {
                    return node;
                }
                else
                {
                    return MergeNewKey(node, returnNode);
                }
            }
            else
            {
                returnNode = Insert(node.RightChild, key);

                if (returnNode == node.RightChild)
                {
                    return node;
                }
                else
                {
                    return MergeNewKey(node, returnNode);
                }
            }
        }

        private TreeNode<T> MergeNewKey(TreeNode<T> currentNode, TreeNode<T> node)
        {
            if (currentNode.IsTwoNode())
            {
                if (currentNode.LeftKey.CompareTo(node.LeftKey) < 0)
                {
                    currentNode.RightKey = node.LeftKey;
                    currentNode.MiddleChild = node.LeftChild;
                    currentNode.RightChild = node.MiddleChild;
                }
                else
                {
                    currentNode.RightKey = currentNode.LeftKey;
                    currentNode.RightChild = currentNode.MiddleChild;
                    currentNode.LeftKey = node.LeftKey;
                    currentNode.MiddleChild = node.MiddleChild;
                }

                return currentNode;
            }
            else if (currentNode.LeftKey.CompareTo(node.LeftKey) >= 0)
            {
                TreeNode<T> newNode = new TreeNode<T>(currentNode.LeftKey)
                {
                    LeftChild = node,
                    MiddleChild = currentNode
                };

                node.LeftChild = currentNode.LeftChild;
                currentNode.LeftChild = currentNode.MiddleChild;
                currentNode.RightChild = null;
                currentNode.LeftKey = currentNode.RightKey;
                currentNode.RightKey = default;

                return newNode;
            }
            else if (currentNode.RightKey.CompareTo(node.LeftKey) >= 0)
            {
                node.MiddleChild = new TreeNode<T>(currentNode.RightKey)
                {
                    LeftChild = node.MiddleChild,
                    MiddleChild = currentNode.RightChild
                };

                node.LeftChild = currentNode;
                currentNode.RightKey = default;
                currentNode.RightChild = null;

                return node;
            }
            else
            {
                TreeNode<T> newNode = new TreeNode<T>(currentNode.RightKey)
                {
                    LeftChild = currentNode,
                    MiddleChild = node
                };

                node.LeftChild = currentNode.RightChild;
                currentNode.RightChild = null;
                currentNode.RightKey = default;

                return newNode;
            }
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
