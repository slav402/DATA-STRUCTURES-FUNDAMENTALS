﻿namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var subtree = new Tree<int>(36,
                                    new Tree<int>(42),
                                    new Tree<int>(3)
                                    );
            
            var tree = new Tree<int>(34,
                                new Tree<int>(36,
                                    new Tree<int>(42),
                                    new Tree<int>(3, 
                                        new Tree<int>(5))
                                    ),
                                new Tree<int>(1),
                                new Tree<int>(103)
                                );
            
        }
    }
}
