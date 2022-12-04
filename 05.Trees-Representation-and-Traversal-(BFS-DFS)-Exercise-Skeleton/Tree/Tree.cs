namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            this.DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int dept)
        {
            sb.Append(' ', dept)
                .AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                this.DfsAsString(sb, child, dept + 2);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
            return BfsWithResultKeys(x => x.Children.Count > 0 && x.Parent != null).Select(tree => tree.Key);
        }

        public IEnumerable<T> GetLeafKeys()
        {
            return BfsWithResultKeys(x => x.children.Count == 0).Select(tree => tree.Key); // tuk i na gornata funkciq izpolzvam predikat za da spestq pisane na kod. Sazdadoh metoda "DfsWithResultKeys" poneje koda i za dwete funkcii e ednakav kato v metoda zalovih uslowie koeto se izvikva (Invoke) pri izpalnenieto mu. A samoto uslovie se naricha "Predicate" i go zalagam pri izvikvaneto na metoda (x => x.children.Count == 0)
        }

        private IEnumerable<Tree<T>> BfsWithResultKeys(Predicate<Tree<T>> predicate)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (predicate.Invoke(currentNode))
                {
                    result.Add(currentNode);
                }

                foreach (var child in currentNode.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public T GetDeepestKey()
        {
            return this.GetDeepestNode().Key;
        }

        private Tree<T> GetDeepestNode()
        {
            var leafs = this.BfsWithResultKeys(tree => tree.children.Count == 0);

            Tree<T> deepestNode = null;
            var maxDept = 0;

            foreach (var leaf in leafs)
            {
                var dept = this.GetDept(leaf);

                if (dept > maxDept)
                {
                    maxDept = dept;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        private int GetDept(Tree<T> leaf)
        {
            int depth = 0;
            var tree = leaf;

            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            var current = GetDeepestNode();
            var path = new Stack<T>();

            while(current != null)
            {
                path.Push(current.Key);
                current = current.Parent;
            }

            return path;
        }
    }
}
