namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            Value = value;
            Parent = null;
            _children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                _children.Add(child);
            }
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public bool IsRootDeleted { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            List<T> list = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            if (IsRootDeleted)
            {
                return list;
            }

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subtree = queue.Dequeue();

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }

                list.Add(subtree.Value);
            }

            return list;
        }

        public ICollection<T> OrderDfs()
        {
            List<T> list = new List<T>();

            if (IsRootDeleted)
            {
                return list;
            }

            Dfs(this, list);

            return list;
        }

        private void Dfs(Tree<T> tree, List<T> list)
        {
            foreach (var child in tree.Children)
            {
                Dfs(child, list);
            }

            list.Add(tree.Value);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parentTree = FindBfs(parentKey);
            IsNodeNull(parentTree);

            parentTree._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> nodeToRemove = FindBfs(nodeKey);
            IsNodeNull(nodeToRemove);

            foreach (var child in nodeToRemove._children)
            {
                child.Parent = null;
            }

            nodeToRemove._children.Clear();

            if (nodeToRemove.Parent != null)
            {
                nodeToRemove.Parent._children.Remove(nodeToRemove);
            }
            else
            {
                IsRootDeleted = true;
            }

            nodeToRemove.Value = default(T);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = FindBfs(firstKey);
            Tree<T> secondNode = FindBfs(secondKey);

            IsNodeNull(firstNode);
            IsNodeNull(secondNode);

            if (firstNode.Parent == null)
            {
                SwapRoot(secondNode);
                return;
            }

            else if (secondNode.Parent == null)
            {
                SwapRoot(firstNode);
                return;
            }

            Tree<T> firstParentNode = firstNode.Parent;
            Tree<T> secondParentNode = secondNode.Parent;

            int indexOfFirstNode = firstParentNode._children.IndexOf(firstNode);
            int indexOfSecondNode = secondParentNode._children.IndexOf(secondNode);

            firstNode.Parent = secondNode.Parent;
            secondNode.Parent = firstNode.Parent;

            firstParentNode._children[indexOfFirstNode] = secondNode;
            secondParentNode._children[indexOfSecondNode] = firstNode;
        }

        private void SwapRoot(Tree<T> secondNode)
        {
            T value = secondNode.Value;

            this.Value = value;
            this._children.Clear();

            foreach (var child in secondNode._children)
            {
                this._children.Add(child);
            }

            return;
        }

        private Tree<T> FindBfs(T parentKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subtree = queue.Dequeue();

                if (subtree.Value.Equals(parentKey))
                {
                    return subtree;
                }
                else
                {
                    foreach (var child in subtree._children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }

            return null;
        }

        private static void IsNodeNull(Tree<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
