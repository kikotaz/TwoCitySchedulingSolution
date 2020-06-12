using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoCitySchedulingSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sample Array
            int[][] costs = new int[][] { new int[] {10,20 }, new int[] { 30, 50}, new int[] { 70, 50},
            new int[]{ 20, 100}, new int[]{ 60,40}, new int[]{ 80,40} };


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
            }

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
                minCostA += costs[b][1];
            }

            //Finding total minimum cost
            int minCost = minCostA + minCostB;

            Console.Write(minCost);

            Console.Read();
        }
    }
}
