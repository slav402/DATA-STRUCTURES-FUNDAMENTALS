using System;
using System.Linq;
using _03.MinHeap;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var priorityQueue = new OrderedBag<int>();

            priorityQueue.AddMany(cookies);

            int currentMinSwitnes = priorityQueue[0];
            int steps = 0;

            while (currentMinSwitnes < minSweetness && priorityQueue.Count > 1)
            {
                var firstCooky = priorityQueue.RemoveFirst();
                var secondCooky = priorityQueue.RemoveFirst();

                var newCooky = firstCooky + 2 * secondCooky;

                priorityQueue.Add(newCooky);
                currentMinSwitnes = priorityQueue.GetFirst();
                steps++;

            }

            return currentMinSwitnes < minSweetness ? -1 : steps;
        }
    }
}
