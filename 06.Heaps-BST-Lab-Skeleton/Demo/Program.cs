﻿using System;
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

            tree.Insert(10);
            tree.Insert(12);

            tree.EachInOrder(Console.WriteLine);
        }
    }
}