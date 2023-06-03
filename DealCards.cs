using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PROIECT
{
    class DealCards : DeckofCards
    {
        public Card[] Flop;
        public Card[] River;
        public Card[] Turn;
        public Card[] playerHand;
        public Card[] computerHand;
        public Card[] sortedPlayerHand;
        public Card[] sortedComputerHand;
        public Card[] bestcomputerHand;
        public Card[] bestplayerHand;

        public DealCards()
        {
            playerHand = new Card[5];
            sortedPlayerHand = new Card[5];
            computerHand = new Card[5];
            sortedComputerHand = new Card[5];
        }
        public void Deal()
        {
            setUpDeck(); 
            getHand();
            sortCards();
            displayCards();
            Console.ForegroundColor = ConsoleColor.White;
            evaluateHands();
        }
      
        public void getHand()
        {
            
            for (int i = 0; i < 2; i++)
                playerHand[i] = getDeck[i];
            for (int i = 2; i < 4; i++)
                computerHand[i - 2] = getDeck[i];
            for(int i=5;i<8;i++)
            {
                playerHand[i - 3] = getDeck[i];
                computerHand[i-3]=playerHand[i-3];
            }
            
        }
        public void sortCards()
        {
            var queryPlayer = from hand in playerHand
                              orderby hand.MyValue
                              select hand;
            var queryComputer = from hand in computerHand
                                orderby hand.MyValue
                                select hand;
            var index = 0;
            foreach (var element in queryPlayer.ToList())
            { 
                sortedPlayerHand[index] = element;
                index++;
            }
            index = 0;
            foreach (var element in queryComputer.ToList())
            {
                sortedComputerHand[index] = element;
                index++;
            }
        }
        public void displayCards()
        {
            Console.Clear();
            int x = 0;
            int y = 1;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PLAYER'S HAND");
            y++;
            for (int i = 0; i < 5; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(sortedPlayerHand[i], x, y);
                x++;
            }
            y = 13;
            x = 0;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("COMPUTER'S HAND");
            y++;
            for (int i = 5; i < 10; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(sortedComputerHand[i - 5], x, y);
                x++;
            }
        }
        public void evaluateHands()
        {
            HandEvaluator playerHandEvaluator = new HandEvaluator(sortedPlayerHand);
            HandEvaluator computerHandEvaluator = new HandEvaluator(sortedComputerHand);

            Hand playerHand = playerHandEvaluator.EvaluateHand();
            Hand computerHand = computerHandEvaluator.EvaluateHand();

            Console.WriteLine("\n\n\n\nPlayer's Hand: " + playerHand);
            Console.WriteLine("\nComputer's Hand: " + computerHand);

            if (playerHand > computerHand)
            {
                Console.WriteLine("Player WINS");

            }
            else
                if (playerHand < computerHand)
            {
                Console.WriteLine("Computer WINS!");
            }
            else
            {
                if (playerHandEvaluator.HandValue.Total > computerHandEvaluator.HandValue.Total)
                    Console.WriteLine("Player WINS! ");
                else if (playerHandEvaluator.HandValue.Total < computerHandEvaluator.HandValue.Total)
                    Console.WriteLine("Computer WINS! ");
                else if (playerHandEvaluator.HandValue.HighCard > computerHandEvaluator.HandValue.HighCard)
                    Console.WriteLine("Player WINS! ");
                else if (playerHandEvaluator.HandValue.HighCard < computerHandEvaluator.HandValue.HighCard)
                    Console.WriteLine("Computer WINS! ");
                else
                    Console.WriteLine("DRAW");
            }
        }
    }
}
