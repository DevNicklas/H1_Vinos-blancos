using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vinos_blancos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Draws a table of the statistics of wine sales from 2009 to 2019
            DrawTable(16, 0);

            // Draws all graph boxes and graphs inside the graph boxes
            DrawAllGraphBoxes(18, 2, 28, 4);

            // Waits for a user input
            Console.ReadLine();
        }

        #region Model

        /// <summary>
        /// Has the statistics of wine sales from 2009 to 2019 stored
        /// </summary>
        /// <returns>A 2-dimensional array with statistics of wine sales from 2009 to 2019. <br />
        /// The first row contains the year, and the second row contains the amount of wine in liters</returns>
        private static int[,] GetStatistics()
        {
            // 2-dimensional array with statistics of wine sales from 2009 to 2019
            int[,] statisticsArr =
            {
                // Year
                { 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019 },
                // Wine in liters
                { 175134, 175388, 172818, 142709, 151437, 152620, 150979, 152210, 149450, 154398, 150160 }
            };

            // Additional corrections array
            int[] correctionsArr = { 0, 0, 0, 0, 0, 35432, 0, 0, 0, 0, 0 };

            // Adds the correction
            for(int i = 0; i < correctionsArr.Length; i++)
            {
                statisticsArr[1, i] += correctionsArr[i];
            }

            // Returns the 2-dimensional array with statistics of wine sales from 2009 to 2019
            return statisticsArr;
        }

        #endregion

        #region View

        /// <summary>
        /// Draws a table of the statistics of wine sales from 2009 to 2019
        /// </summary>
        /// <param name="x">start position of x</param>
        /// <param name="y">start position of y</param>
        /// <param name="statisticArr">array of statistics</param>
        private static void DrawTable(int x, int y)
        {
            // Gets the statistics of wine sales from 2009 to 2019
            int[,] statisticsArr = SortStatistics(GetStatistics());

            // Sets position of the cursor to the start position
            Console.SetCursorPosition(x, y);

            // Prints the year
            for (int i = 0; i < statisticsArr.GetLength(1); i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  " + statisticsArr[0, i] + "  ");
            }

            // Cursor position set to start x position and +1 of the start y position
            Console.SetCursorPosition(x, y+1);

            // Prints amount of wine in leters
            for (int i = 0; i < statisticsArr.GetLength(1); i++)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" " + statisticsArr[1, i] + " ");
            }
        }

        /// <summary>
        /// Draws all graph boxes within some criterias
        /// </summary>
        /// <param name="x">start position of x</param>
        /// <param name="y">start position of y</param>
        /// <param name="height">height of graph box</param>
        /// <param name="width">width of graph box</param>
        private static void DrawAllGraphBoxes(int x, int y, int height, int width)
        {
            // Sets foreground and background console colors to their defaults
            Console.ResetColor();

            // Subtracts 2 from width, which makes the width correct
            width -= 2;

            // Gets the statistics of wine sales from 2009 to 2019
            int[,] statisticsArr = SortStatistics(GetStatistics());

            for (int i = 0; i < statisticsArr.GetLength(1); i++)
            {
                // Sets position of cursor to chosen x and y pos, and writes the first horizontal line
                Console.SetCursorPosition(x + i * 8, y);
                Console.Write('╔' + new string('═', width) + '╗');

                // Sets position of cursor to chosen x pos and chosen y pos added with the height of the box
                // and writes the second horizontal line
                Console.SetCursorPosition(x + i * 8, y + height - 1);
                Console.Write('╚' + new string('═', width) + '╝');

                // Draws two vertical lines
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < height - 2; k++)
                    {
                        // Position x is calculated by adding 1 to the width, multiply that by the index of the vertical line (either 1 or 2)
                        // and adding that to the position of x
                        // Position y is calculated by adding 1 and the loop index
                        Console.SetCursorPosition(x + i * 8 + (width + 1) * j, y + k + 1);
                        Console.Write('║');
                    }
                }

                // Max amount of chars in the bar graph
                int maxChar = 26;

                // Amount of wine litres used for calculating the bar graph
                int wineLiters = statisticsArr[1, i];

                // heighest amount of wine litres used for calculating the bar graph
                int highestWineLiters = statisticsArr[1, statisticsArr.GetLength(1) - 1];

                // Amount of chars to print in the graph specific to a year
                int graphCharAmount = maxChar * wineLiters / highestWineLiters;

                // Sets background console color to dark gray
                Console.BackgroundColor = ConsoleColor.DarkGray;

                // Prints the graphc
                for (int j = 0; j < graphCharAmount; j++)
                {
                    // Sets cursor position and goes one up for each loop index
                    Console.SetCursorPosition(x + i * 8 + 1, y + 26 - j);
                    Console.Write(new string(' ', 2));
                }

                // Sets foreground and background console colors to their defaults
                Console.ResetColor();
            }
        }

        #endregion

        #region Controller

        /// <summary>
        /// Sorts the array of statistics of wine sales from 2009 to 2019
        /// </summary>
        /// <param name="statisticsArr">array of statistics</param>
        /// <returns>An sorted statistics array of wine sales from 2009 to 2019</returns>
        private static int[,] SortStatistics(int[,] statisticsArr)
        {
            // Two arrays for seperating one 2-dimensional array
            // When initialized the length of the array is set to the amount of columns of the 2-dimensional array
            int[] yearArr = new int[statisticsArr.GetLength(1)];
            int[] wineArr = new int[statisticsArr.GetLength(1)];

            // Loops a specific amount of times which is the amount of columns in the 2-dimensional array
            // Fills the two seperated arrays with the correct data
            for(int i = 0; i < statisticsArr.GetLength(1); i++)
            {
                yearArr[i] = statisticsArr[0,i];
                wineArr[i] = statisticsArr[1,i];
            }

            // Sorts the two seperated arrays from low to high, and is sorted after the array
            // which contains the amount of wine in liters
            Array.Sort(wineArr, yearArr);

            // New 2-dimensional array which is meant to merge two sorted and seperated arrays into one 2-dimensional
            int[,] sortedStatisticsArr = new int[2, statisticsArr.GetLength(1)];

            // Loops a specific amount of times which is the amount of columns in the 2-dimensional array
            // Fill the new 2-dimensional array with the correct data from the two seperated arrays
            for (int i = 0; i < statisticsArr.GetLength(1); i++)
            {
                sortedStatisticsArr[0, i] = yearArr[i];
                sortedStatisticsArr[1, i] = wineArr[i];
            }

            // Returns the sorted statistics array
            return sortedStatisticsArr;
        }

        #endregion
    }
}
