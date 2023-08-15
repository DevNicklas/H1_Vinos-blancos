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
            // Gets the statistics of wine sales from 2009 to 2019
            int[,] statisticsArr = SortStatistics(GetStatistics());

            DrawTable(16, 0, statisticsArr);
            //wineArr[5] += 35432;

            // Draws every graph box
            for(int i = 0; i < statisticsArr.GetLength(1); i++)
            {
                // x position is: 18+i*8  -  18 is the start position, i is the index of the graph box, 8 is amount of characters from first character to last character
                // y position is: 2  -  Its the start position
                // Height of box is: 28  -  Which is the amount of characters from top to bottom
                // Width of box is: 4  -  Which is the amount of characters from left to right
                // Wine in liters is: statisticsArr[1, i]  -  The correct value of the printed graph, which is used to draw the color inside
                // Highest amount of wine in liters is: statisticsArr[1, statisticsArr.GetLength(1)-1]  -  Which is found by the last index of the wine section which is on row 1
                DrawGraphBox(18+i*8, 2, 28, 4, statisticsArr[1, i], statisticsArr[1, statisticsArr.GetLength(1)-1]);
            }
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

        private static void DrawTable(int x, int y, int[,] statisticArr)
        {
            // Sets position of the cursor to the start position
            Console.SetCursorPosition(x, y);

            // Prints the year
            for (int i = 0; i < statisticArr.GetLength(1); i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  " + statisticArr[0, i] + "  ");
            }

            // Cursor position set to start x position and +1 of the start y position
            Console.SetCursorPosition(x, y+1);

            // Prints amount of wine in leters
            for (int i = 0; i < statisticArr.GetLength(1); i++)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" " + statisticArr[1, i] + " ");
            }
        }

        private static void DrawGraphBox(int x, int y, int height, int width, int wineLiters, int highestWineLiters)
        {
            // Sets the foreground and background color to its default color
            Console.ResetColor();

            // Subtracts 2 from width, which makes the width correct
            width -= 2;

            // Sets position of cursor to chosen x and y pos, and writes the first horizontal line
            Console.SetCursorPosition(x, y);
            Console.Write('╔' + new string('═', width) + '╗');

            // Sets position of cursor to chosen x pos and chosen y pos added with the height of the box
            // and writes the second horizontal line
            Console.SetCursorPosition(x, y+height-1);
            Console.Write('╚' + new string('═', width) + '╝');

            // Draws two vertical lines
            for(int i = 0; i < 2; i++)
            {
                for (int j = 0; j < height-2; j++)
                {
                    // Position x is calculated by adding 1 to the width, multiply that by the index of the vertical line (either 1 or 2)
                    // and adding that to the position of x
                    // Position y is calculated by adding 1 and the loop index
                    Console.SetCursorPosition(x + (width + 1) * i, y + j + 1);
                    Console.Write('║');
                }
            }

            // Max amount of chars in the bar graph
            int maxChar = 26;

            // Amount of chars to print in the graph specific to a year
            int graphCharAmount = maxChar*wineLiters/highestWineLiters;

            // Sets background console color to dark gray
            Console.BackgroundColor = ConsoleColor.DarkGray;

            // Prints the graphc
            for(int j = 0; j < graphCharAmount; j++)
            {
                // Sets cursor position and goes one up for each loop index
                Console.SetCursorPosition(x + 1, y + 26 - j);
                Console.Write(new string(' ', 2));
            }

            // Sets foreground and background console colors to their defaults
            Console.ResetColor();
        }

        #endregion

        #region Controller

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
