namespace Demo
{
    using System;
    using System.Linq;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[] { "9 17", "9 4", "9 14", "4 36", "14 53", "14 26", "53 67", "53 73" };

            var treeFactory = new IntegerTreeFactory();

            var tree = treeFactory.CreateTreeFromStrings(input);

            //Console.WriteLine(tree.AsString());
            //Console.WriteLine(string.Join(", ", tree.GetLeafKeys()));
            //Console.WriteLine(string.Join(", ", tree.GetInternalKeys()));

            //Console.WriteLine(string.Join(Environment.NewLine, tree.GetPathsWithGivenSum(49).Select(x => string.Join(", ",x))));

            Console.WriteLine(string.Join(", ", tree.GetSubtreesWithGivenSum(49)));
        }
    }
}
