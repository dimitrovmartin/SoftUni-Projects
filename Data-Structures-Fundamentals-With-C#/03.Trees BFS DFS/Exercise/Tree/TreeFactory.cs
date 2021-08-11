namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                string[] args = line.Split();

                int parent = int.Parse(args[0]);
                int child = int.Parse(args[1]);

                this.CreateNodeByKey(parent);
                this.CreateNodeByKey(child);
                this.AddEdge(parent, child);
            }

            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!this.nodesBykeys.ContainsKey(key))
            {
                this.nodesBykeys.Add(key, new Tree<int>(key));
            }

            return this.nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            Tree<int> parentNode = nodesBykeys[parent];
            Tree<int> childNode = nodesBykeys[child];

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        private Tree<int> GetRoot()
        {
            foreach (var subtree in nodesBykeys.Values)
            {
                if (subtree.Parent == null)
                {
                    return subtree;
                }
            }

            return null;
        }
    }
}
