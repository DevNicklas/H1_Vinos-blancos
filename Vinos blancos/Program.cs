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
            int[] year = { 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019 };
            int[] wineLiters = { 175134, 175388, 172818, 142709, 151437, 152620, 150979, 152210, 149450, 154398, 150160 };

            wineLiters[5] += 35432;
            Array.Sort(wineLiters, year);

            for(int i = 0; i < year.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  " + year[i] + "   ");
            }
            Console.WriteLine();
            for(int i = 0; i < wineLiters.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write( " " + wineLiters[i] + "  ");
            }

            // Draws every graph box
            for(int i = 0; i < year.Length; i++)
            {
                DrawGraphBox(2+i*9, 2, 28, 4, i);
            }
            //DrawGraphBox(2, 2, 28, 4);
            Console.ReadKey();
        }

        #region View
        private static void DrawGraphBox(int x, int y, int height, int width, int graphIndex)
        {
            // Sets the foreground and background color to its default color
            Console.ResetColor();

            // Subtracts 2 from width, which makes the width correct
            width -= 2;

            Console.SetCursorPosition(x, y);
            Console.Write('╔' + new string('═', width) + '╗');

            Console.SetCursorPosition(x, y+height-1);
            Console.Write('╚' + new string('═', width) + '╝');

            for(int i = 0; i < 2; i++)
            {
                for (int j = 0; j < height-2; j++)
                {
                    Console.SetCursorPosition(x + (width + 1) * i, y + j + 1);
                    Console.Write('║');
                }
            }

            int maxChar = 26;
            int result = maxChar/175388*175388;

            for(int i = 1; i <= 2; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                for(int j = result; j > 0; j--)
                {
                    Console.SetCursorPosition(x + 1, y + j);
                    Console.Write(new string(' ', 2));
                }
            }
        }

        #endregion

    }
}
