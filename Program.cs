using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment2
{
    /// <summary>
    /// Programming Assignment 2 solution
    /// </summary>
    class Program
    {
        /// <summary>
        /// Deals 2 cards to 3 players and displays cards for players
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            // print welcome message
            Console.WriteLine("Welcome to the card game! Let's play :)");

            // create and shuffle a deck
            Deck deck = new Deck();
            deck.Shuffle();

            // deal 2 cards each to 3 players (deal properly, dealing
            // the first card to each player before dealing the
            // second card to each player)
            Card card1Player1 = deck.TakeTopCard();
            Card card1Player2 = deck.TakeTopCard();
            Card card1Player3 = deck.TakeTopCard();
            Card card2Player1 = deck.TakeTopCard();
            Card card2Player2 = deck.TakeTopCard();
            Card card2Player3 = deck.TakeTopCard();

            // flip all the cards over
            card1Player1.FlipOver();
            card2Player1.FlipOver();
            card1Player2.FlipOver();
            card2Player2.FlipOver();
            card1Player3.FlipOver();
            card2Player3.FlipOver();

            // print the cards for player 1
            Console.WriteLine("player 1's first card: " + card1Player1.Rank + " of " + card1Player1.Suit);
            Console.WriteLine("player 1's second card: " + card2Player1.Rank + " of " + card2Player1.Suit);

            // print the cards for player 2
            Console.WriteLine("player 2's first card: " + card1Player2.Rank + " of " + card1Player2.Suit);
            Console.WriteLine("player 2's second card: " + card2Player2.Rank + " of " + card2Player2.Suit);

            // print the cards for player 3
            Console.WriteLine("player 3's first card: " + card1Player3.Rank + " of " + card1Player3.Suit);
            Console.WriteLine("player 3's second card: " + card2Player3.Rank + " of " + card2Player3.Suit);

            Console.WriteLine();
        }
    }
}
