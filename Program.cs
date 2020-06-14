using System;

/*
 * @Created by: Karim Saleh
 * @Date: 12 June 2020
 * @Details: This class is a simple program to solve the
 * Two City Scheduling problem in Leetcode.com. It can be
 * solved using either Quick Sorting, or Insertion Sorting.
 * Both algorithms are included
 */

namespace TwoCitySchedulingSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sample Array
            int[][] costs = new int[][] { new int[] {10,20 }, new int[] { 30, 50}, new int[] { 70, 50},
            new int[]{ 20, 100}, new int[]{ 60,40}, new int[]{ 80,40} };

            QuickSort(costs, 0, costs.Length -1);

            /*
             * Uncomment this block to use Insertion Sorting instead
            //Using insertion sorting to sort the costs Array
            for (int i = 1; i < costs.Length; ++i)
            {
                int[] cost = costs[i];
                int j = i - 1;

                //Sorting according to the biggest difference between cost of A and cost of B
                while (j >= 0 && costs[j][0] - costs[j][1] > cost[0] - cost[1])
                {
                    costs[j + 1] = costs[j];
                    j = --j;
                }
                costs[j + 1] = cost;
            }*/

            //Finding total minimum cost of City A flights
            int minCostA = 0;
            for (int a = 0; a < costs.Length / 2; ++a)
            {
                minCostA += costs[a][0];
            }

            //Finding total minimum cost of City B flights
            int minCostB = 0;
            for (int b = costs.Length - 1; b >= costs.Length / 2; --b)
            {
                minCostB += costs[b][1];
            }

            //Finding total minimum cost
            int minCost = minCostA + minCostB;

            Console.Write(minCost);

            Console.Read();
        }

        //This function will be called recursivley to apply Quick Sort
        static void QuickSort (int[][] costs, int left, int right)
        {
            //Run as long as the parameters are valid
            if(left < right)
            {
                int pIndex = Partition(costs, left, right);

                QuickSort(costs, left, pIndex - 1);
                QuickSort(costs, pIndex + 1, right);
            }
        }

        //Partitioning function for the Quick Sort algorithm
        static int Partition (int[][] costs, int left, int right)
        {
            //Assigning the pivot in the costs array or subarray
            int[] pivot = costs[right];

            //partioning index
            int pIndex = left;

            for(int i = pIndex; i < right; i++)
            {
                //Swap if the cost difference is less than pivot difference
                if (costs[i][0] - costs[i][1] <= pivot[0] - pivot[1])
                {
                    Swap(costs, i, pIndex);
                    pIndex++;                   
                }
            }

            //Finally swap the pIndex with the pivot
            Swap(costs, pIndex, right);

            return pIndex;
        }

        //Function to swap elements during quick sort
        static void Swap(int[][] costs, int left, int right)
        {
            int[] temp = costs[left];
            costs[left] = costs[right];
            costs[right] = temp;
        }
    }
}
