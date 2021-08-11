namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            _children = new List<Tree<T>>();

            foreach (var child in children)
            {
                child.Parent = this;

                this._children.Add(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();

            DfsGetAsString(this, sb, 0);

            return sb.ToString().TrimEnd();
        }

        private void DfsGetAsString(Tree<T> tree, StringBuilder sb, int intention)
        {
            sb.AppendLine(new string(' ', intention) + tree.Key);

            foreach (var child in tree.Children)
            {
                DfsGetAsString(child, sb, intention + 2);
            }
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            List<Tree<T>> leaves = new List<Tree<T>>();

            DfsGetLeavesNode(this, leaves);

            Tree<T> deepestNode = null;
            int level = 0;

            foreach (var leaf in leaves)
            {
                Tree<T> currentNode = leaf;
                int currentLevel = 0;

                while (currentNode != null)
                {
                    currentNode = currentNode.Parent;
                    currentLevel++;
                }

                if (currentLevel > level)
                {
                    level = currentLevel;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        public List<T> GetLeafKeys()
        {
            List<T> leaves = new List<T>();
            Func<Tree<T>, bool> predicate = n => n.Children.Count == 0;

            DfsGetKeys(this, leaves, predicate);

            return leaves;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> middle = new List<T>();
            Func<Tree<T>, bool> predicate = n => n.Children.Count != 0 && n.Parent != null;

            DfsGetKeys(this, middle, predicate);

            return middle;
        }

        public List<T> GetLongestPath()
        {
            Tree<T> deepestNode = GetDeepestLeftomostNode();

            List<T> path = new List<T>();

            DfsGetPath(deepestNode, path);

            return path;
        }

        private void DfsGetPath(Tree<T> deepestNode, List<T> path)
        {
            while (deepestNode != null)
            {
                path.Add(deepestNode.Key);

                deepestNode = deepestNode.Parent;
            }

            path.Reverse();
        }

        private void DfsGetLeavesNode(Tree<T> tree, List<Tree<T>> leaves)
        {
            if (tree.Children.Count == 0)
            {
                leaves.Add(tree);
            }

            foreach (var child in tree.Children)
            {
                DfsGetLeavesNode(child, leaves);
            }
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            List<Tree<T>> leaves = new List<Tree<T>>();
            List<List<T>> paths = new List<List<T>>();

            DfsGetLeavesNode(this, leaves);

            foreach (var leaf in leaves)
            {
                int currentSum = 0;

                Tree<T> currentLeaf = leaf;
                List<T> path = new List<T>();

                while (currentLeaf != null)
                {
                    currentSum += Convert.ToInt32(currentLeaf.Key);

                    path.Add(currentLeaf.Key);

                    currentLeaf = currentLeaf.Parent;
                }

                if (currentSum == sum)
                {
                    path.Reverse();

                    paths.Add(path);
                }
            }

            return paths;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> subtrees = new List<Tree<T>>();

            DfsSubtreesWithGivenSum(this, subtrees, sum);

            return subtrees;
        }

        private int DfsSubtreesWithGivenSum(Tree<T> tree, List<Tree<T>> subtrees, int sum)
        {
            int currentSum = Convert.ToInt32(tree.Key);

            foreach (var child in tree.Children)
            {
                currentSum += DfsSubtreesWithGivenSum(child, subtrees, sum);
            }

            if (currentSum == sum)
            {
                subtrees.Add(tree);
            }

            return currentSum;
        }

        private void DfsGetKeys(Tree<T> tree, List<T> leaves, Func<Tree<T>, bool> predicate)
        {
            if (predicate(tree))
            {
                leaves.Add(tree.Key);
            }

            foreach (var child in tree.Children)
            {
                DfsGetKeys(child, leaves, predicate);
            }
        }
    }
}
