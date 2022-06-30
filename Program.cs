using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Classes;

namespace TicTacToe
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int turnCount = 0;
            int playerTurn;

            Console.Clear();

            Player playerOne = Game.createPlayer("1");
            Player playerTwo = Game.createPlayer("2");

            bool newGame = true;

            while (newGame)
            {
                List<string> cells = Game.initializGame();
                playerTurn = new Random().Next(1, 3);
                bool continueGame = true;

                while (continueGame && turnCount < 9)
                {
                    Game.drawBoard(cells, playerOne, playerTwo);
                    PlayerMove(ref playerTurn, ref turnCount, cells, ref continueGame, playerOne, playerTwo);
                }

                if (turnCount > 8)
                {
                    Console.WriteLine("\nOh no! You ran out of turns.");
                }

                Console.WriteLine("\nWould you like to play a another game? (y/n)");
                turnCount = 0;
                if (Console.ReadLine() != "y")
                {
                    newGame = false;
                }
            }

        }

        public static void PlayerMove(ref int playerTurn, ref int turnCount, List<string> cells, ref bool continueGame, Player playerOne, Player playerTwo)
        {
            Player player = null;
            if (playerTurn == 1)
            {
                player = playerOne;
                playerTurn = 2;
            }
            else
            {
                player = playerTwo;
                playerTurn = 1;
            }

            player.PlayerTurn(cells);
            continueGame = Game.CheckWin(playerOne, cells);
            turnCount++;
            if (!continueGame)
            {
                player.wins++;
                Game.drawBoard(cells, playerOne, playerTwo);
                Console.WriteLine($"{player.name} Wins!");
                turnCount = 0;
            }
        }
    }

   
}