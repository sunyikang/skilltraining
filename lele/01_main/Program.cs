using System;
using System.IO;

namespace lele
{
    class Program
    {
        private static void PrintApplePen()
        {
            Console.WriteLine("I have an apple!");
            Console.WriteLine("I have a pineapple!");
            Console.WriteLine("Peng!  Pen Pineapple Apple Pen!!");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // comment1
            /* comment2 */
            for (int i = 0; i < 3; i++)
            {
                PrintApplePen();
            }
        }
    }

    class Banana
    {
        int size = 10;
    }
}
