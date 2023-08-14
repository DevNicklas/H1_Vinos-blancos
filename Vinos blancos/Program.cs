using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinos_blancos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr =
            {
                { 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019 },
                { 175134, 175388, 172818, 142709, 151437, 152620, 150979, 152210, 149450, 154398, 150160}
            };

            for(int i = 0; i < arr.GetLength(1); i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("  " + arr[0, i] + "   ");
            }
            Console.ResetColor();
            Console.WriteLine();
            for(int i = 0; i < arr.GetLength(1); i++)
            {
                Console.Write( " " + arr[1, i] + "  ");
            }
            Console.ReadKey();
        }
    }
}
