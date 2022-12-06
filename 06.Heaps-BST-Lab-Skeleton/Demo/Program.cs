using System;
using System.Diagnostics.CodeAnalysis;
using _02.BinarySearchTree;
using _03.MaxHeap;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>();

            tree.Insert(8);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(6);

            tree.EachInOrder(x => Console.Write(x + ", "));
            Console.WriteLine();

            var newTree = tree.Search(6);
            newTree.Insert(9);

            newTree.EachInOrder(x => Console.Write(x + ", "));
            Console.WriteLine();

            
        }
    }
}