using System;
using System.Collections.Generic;
using System.Linq;

namespace GridGroupingConsoleApp
{
    class Program
    {
        private static int width = 7, height = 7, groupCount = 0;
        private static Dictionary<string, bool> marked = new Dictionary<string, bool>();

        static void Main(string[] args)
        {
            DisplayGridResults("Example1", PopulateGridExample1(height, width));
            groupCount = 0;

            DisplayGridResults("Example2", PopulateGridExample2(height, width));
            Console.ReadLine();
        }

        private static void DisplayGridResults(string exampleName, int[,] grid)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write("[{0}][{1}] = {2} ", y, x, grid[y, x]);
                    UpdateGroupCountAndMark(grid, y, x);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            foreach (var kvp in marked.OrderBy(k => k.Key))
                Console.Write("{0},", kvp.Key);

            Console.WriteLine();
            Console.WriteLine("Total Group Count for {0}: {1}", exampleName, groupCount);
            Console.WriteLine();
        }

        private static void UpdateGroupCountAndMark(int[,] grid, int currentY, int currentX)
        {
            var key = GetKey(currentY, currentX);
            if (!marked.ContainsKey(key) && grid[currentY, currentX] == 1)
            {
                groupCount++;
                marked.Add(key, true);
                Mark(grid, currentY, currentX);
            }
        }

        private static void Mark(int[,] grid, int currentY, int currentX)
        {
            // horizontal check
            int x = currentX + 1;

            if (x < width && grid[currentY, x] == 1)
            {
                if (!marked.ContainsKey(GetKey(currentY, x)))
                {
                    marked.Add(GetKey(currentY, x), true);
                    Mark(grid, currentY, x);
                }
            }

            // vertical check
            int y = currentY + 1;

            if (y < height && grid[y, currentX] == 1)
            {
                if (!marked.ContainsKey(GetKey(y, currentX)))
                {
                    marked.Add(GetKey(y, currentX), true);
                    Mark(grid, y, currentX);
                }
            }

            // diagonal
            if (currentX < width && currentY < height)
            {
                // digonal down/right check
                int xIndex = currentX;
                y = currentY + 1;

                ++xIndex;
                if (y < width && xIndex < width && grid[y, xIndex] == 1)
                {
                    if (!marked.ContainsKey(GetKey(y, xIndex)))
                    {
                        marked.Add(GetKey(y, xIndex), true);
                        Mark(grid, y, xIndex);
                    }
                }

                // diagonal down/left check
                xIndex = currentX;
                y = currentY + 1;

                --xIndex;
                if (y < width && xIndex >= 0 && grid[y, xIndex] == 1)
                {
                    if (!marked.ContainsKey(GetKey(y, xIndex)))
                    {
                        marked.Add(GetKey(y, xIndex), true);
                        Mark(grid, y, xIndex);
                    }
                }

                // diagonal up/right check
                xIndex = currentX;
                y = currentY - 1;

                ++xIndex;
                if (y >= 0 && xIndex < width && grid[y, xIndex] == 1)
                {
                    if (!marked.ContainsKey(GetKey(y, xIndex)))
                    {
                        marked.Add(GetKey(y, xIndex), true);
                        Mark(grid, y, xIndex);
                    }
                }

                // diagonal up/left check [Not needed as you would have parsed this square]
                //xIndex = currentX;
                //y = currentY - 1;

                //--xIndex;
                //if (y >= 0 && xIndex >= 0 && grid[y, xIndex] == 1)
                //{
                //    if (!marked.ContainsKey(GetKey(y, xIndex)))
                //    {
                //        marked.Add(GetKey(y, xIndex), true);
                //        Mark(grid, y, xIndex);
                //    }
                //}
            }
        }

        private static string GetKey(int y, int x)
        {
            return String.Format("{0}{1}", y, x);
        }

        private static int[,] PopulateGridExample1(int height, int width)
        {
            int[,] grid = new int[height, width];
            grid[0, 1] = 1;
            grid[0, 3] = 1;
            grid[0, 4] = 1;
            grid[1, 1] = 1;
            grid[1, 2] = 1;
            grid[2, 2] = 1;
            grid[3, 0] = 1;
            grid[4, 0] = 1;
            grid[4, 2] = 1;
            grid[4, 4] = 1;
            grid[4, 5] = 1;
            grid[4, 6] = 1;
            grid[5, 1] = 1;
            grid[5, 2] = 1;
            grid[6, 2] = 1;

            return grid;
        }

        private static int[,] PopulateGridExample2(int height, int width)
        {
            int[,] grid = new int[height, width];
            grid[0, 0] = 1;
            grid[0, 1] = 1;
            grid[0, 3] = 1;
            grid[0, 4] = 1;
            grid[0, 5] = 1;
            grid[1, 0] = 1;
            grid[1, 1] = 1;
            grid[2, 3] = 1;
            grid[2, 4] = 1;
            grid[3, 1] = 1;
            grid[3, 4] = 1;
            grid[3, 5] = 1;
            grid[4, 0] = 1;
            grid[4, 2] = 1;
            grid[5, 5] = 1;
            grid[6, 0] = 1;
            grid[6, 4] = 1;
            grid[6, 5] = 1;
            grid[6, 6] = 1;

            return grid;
        }
    }
}