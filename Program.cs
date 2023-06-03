using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROIECT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(60, 31);
            Console.BufferWidth = 60;
            Console.BufferHeight = 31;
            Console.Title = "Poker Game";
            DealCards dc = new DealCards();
            bool quit = false;
            while (!quit)
            {
                dc.Deal();
                Console.ForegroundColor = ConsoleColor.White;
                char selection = ' ';
                while (!selection.Equals('Y') && !selection.Equals('N'))
                {
                    Console.WriteLine("Play again? Y-N");
                    selection = Convert.ToChar(Console.ReadLine().ToUpper());

                    if (selection.Equals('Y'))
                        quit = false;
                    else
                        if (selection.Equals('N'))
                        quit = true;
                    else
                        Console.WriteLine("Invalid Selection. Try again");
                }
            }
         
            Console.ReadKey();

        }
    }
}