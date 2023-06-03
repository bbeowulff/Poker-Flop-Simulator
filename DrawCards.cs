using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROIECT
{
    class DrawCards : DeckofCards
    {
        
        public static void DrawCardOutline(int xcoor, int ycoor)
        {
            Console.ForegroundColor = ConsoleColor.White;

            int x = xcoor * 12;
            int y = ycoor;

            Console.SetCursorPosition(x, y);
            Console.WriteLine("┌─────────┐\n");
            for (int i = 0; i < 8; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);
                if (i != 7)
                    Console.WriteLine("│         │");
                else
                {
                    Console.WriteLine("└─────────┘");
                }
            }
        }
       
        public static void DrawCardSuitValue(Card card, int xcoor, int ycoor)
        {
            string cardSuit =" ";
            int x = xcoor * 12;
            int y = ycoor;
            switch (card.MySuit)
            {
                case SUIT.HEARTS:
                    cardSuit = "\u2665";
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case SUIT.DIAMONDS:
                    cardSuit = "\u2666";
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case SUIT.CLUBS:
                    cardSuit = "\u2660";
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case SUIT.SPADES:
                    cardSuit = "\u2663";
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            x = x + 5;
            y = y + 4;
            Console.SetCursorPosition(x , y);
            Console.Write(cardSuit);
            x = x - 4;
            y = y - 3;
            Console.SetCursorPosition(x, y);
            if ((int)card.MyValue > 10)
            {
                if((int)card.MyValue == 11)
                {
                    Console.WriteLine("J");
                    Console.SetCursorPosition(x + 8, y + 6);
                    Console.WriteLine("J");
                }
                else
                    if ((int)card.MyValue == 12)
                {
                    Console.WriteLine("Q");
                    Console.SetCursorPosition(x + 8, y + 6);
                    Console.WriteLine("Q");
                }
                else
                    if ((int)card.MyValue == 13)
                {
                    Console.WriteLine("K");
                    Console.SetCursorPosition(x + 8, y + 6);
                    Console.WriteLine("K");
                }
                else
                    if ((int)card.MyValue == 1)
                {
                    Console.WriteLine("A");
                    Console.SetCursorPosition(x + 8, y + 6);
                    Console.WriteLine("A");
                }
               
            }
            else
                    if ((int)card.MyValue == 1)
            {
                Console.WriteLine("A");
                Console.SetCursorPosition(x + 8, y + 6);
                Console.WriteLine("A");
            }
            else

            {
                Console.Write((int)card.MyValue);
                Console.SetCursorPosition(x + 7, y + 6);
                Console.Write((int)card.MyValue);
            }
        }
    }

}
